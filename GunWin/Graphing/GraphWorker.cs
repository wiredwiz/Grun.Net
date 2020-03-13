#region BSD 3-Clause License

// <copyright file="GraphWorker.cs" company="Edgerunner.org">
// Copyright 2020 
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2020, 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its
//    contributors may be used to endorse or promote products derived from
//    this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Antlr4.Runtime.Tree;

using JetBrains.Annotations;

using Microsoft.Msagl.Layout.Layered;

using Org.Edgerunner.ANTLR4.Tools.Graphing;
using Org.Edgerunner.ANTLR4.Tools.Testing.Configuration;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Graphing
{
   /// <summary>
   ///    Class that handles the work of text in the background.
   ///    Implements the <see cref="IGraphWorker" />
   /// </summary>
   /// <remarks>This class is thread safe.</remarks>
   /// <seealso cref="IGraphWorker" />
   public class GraphWorker : IGraphWorker
   {
      private readonly object _Padlock;

      private readonly Settings _Settings;

      private readonly SynchronizationContext _SynchronizationContext;

      private DateTime _LastQueuedTime;

      private int _PreviousNodeQty;

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="GraphWorker" /> class.
      /// </summary>
      /// <param name="synchronizationContext">The synchronization context.</param>
      /// <param name="settings">The settings.</param>
      /// <exception cref="ArgumentNullException">
      ///    synchronizationContext
      ///    or
      ///    settings are null
      /// </exception>
      public GraphWorker([NotNull] SynchronizationContext synchronizationContext, [NotNull] Settings settings)
      {
         _SynchronizationContext = synchronizationContext ?? throw new ArgumentNullException(nameof(synchronizationContext));
         _Settings = settings ?? throw new ArgumentNullException(nameof(settings));
         _PreviousNodeQty = 0;
         _Padlock = new object();
         QueuedWork = new Queue<GraphingWorkItem>();
         GraphingTask = new Task(GraphingWorkLoop);
      }

      #endregion

      /// <summary>
      ///    Gets or sets the graphing task.
      /// </summary>
      /// <value>The graphing task.</value>
      private Task GraphingTask { get; set; }

      private Queue<GraphingWorkItem> QueuedWork { get; }

      #region IGraphWorker Members

      /// <inheritdoc />
      public bool CancelWork()
      {
         lock (_Padlock)
         {
            var hadWork = QueuedWork.Count != 0;
            QueuedWork.Clear();
            return hadWork;
         }
      }

      /// <inheritdoc />
      public void Graph(IParseTreeGrapher grapher, ITree tree, IList<string> parserRules)
      {
         lock (_Padlock)
         {
            var nextRun = 
               CalculateNextRunTime(
                                    _PreviousNodeQty, 
                                    _Settings.NodeThresholdCountForThrottling, 
                                    _Settings.MillisecondsToDelayPerNodeWhenThrottling, 
                                    _Settings.MaximumRenderShortDelay);
            var work = new GraphingWorkItem(tree, parserRules, grapher, nextRun);
            QueuedWork.Enqueue(work);
            _LastQueuedTime = DateTime.Now;
            if (GraphingTask.IsCompleted)
               GraphingTask = new Task(GraphingWorkLoop);
            if (GraphingTask.Status != TaskStatus.Running)
               GraphingTask.Start();
         }
      }

      /// <inheritdoc />
      public event EventHandler<GraphingResult> GraphingFinished;

      #endregion

      private DateTime CalculateNextRunTime(
         int previousNodes,
         int minimumNodeThresholdToDelay,
         int millisecondsPerNodeToDelay,
         int maximumDelay)
      {
         // We use reactive throttling to avoid overwhelming the client with repeated parsing of large samples
         if (previousNodes < minimumNodeThresholdToDelay)
            return DateTime.Now;

         var delay = Math.Min(maximumDelay, previousNodes * millisecondsPerNodeToDelay);
         return DateTime.Now + TimeSpan.FromMilliseconds(delay);
      }

      private int CalculateTotalTreeNodes(ITree tree)
      {
         if (tree == null)
            return 0;

         var result = 1;
         for (var i = 0; i < tree.ChildCount; i++)
            result += CalculateTotalTreeNodes(tree.GetChild(i));

         return result;
      }

      private void GraphingWorkLoop()
      {
         while (true)
         {
            int workCount;
            DateTime lastQueued;
            lock (_Padlock)
            {
               workCount = QueuedWork.Count;
               if (workCount == 0)
                  return;

               lastQueued = _LastQueuedTime;
            }

            if (workCount > _Settings.MinimumRenderCountToTriggerLongDelay && (DateTime.Now - lastQueued) < TimeSpan.FromMilliseconds(500))
            {
               Thread.Sleep(500);
               continue;
            }

            lock (_Padlock)
            {
               // Sanity check ....just in case
               if (QueuedWork.Count == 0)
                  return;

               // We really only care about the last work item, so that's all we are keeping
               // However, we use the "GraphWhen" target date/time for the first entry for our check
               var work = QueuedWork.Dequeue();
               var graphWhen = work.GraphWhen;
               while (QueuedWork.Count != 0)
                  work = QueuedWork.Dequeue();

               // If we should delay longer, we enqueue the last item again for later evaluation
               if (DateTime.Now < graphWhen)
               {
                  QueuedWork.Enqueue(work);
                  continue;
               }

               var result = HandleGraphing(work);
               _PreviousNodeQty = CalculateTotalTreeNodes(work.ParseTree);
               OnGraphingFinished(result);
            }
         }
      }

      /// <summary>
      ///    Handles the actual graphing.
      /// </summary>
      /// <param name="work">The work item to graph.</param>
      /// <returns>A new <see cref="Graph" />.</returns>
      private GraphingResult HandleGraphing(GraphingWorkItem work)
      {
         if (work.TreeGrapher == null || work.ParseTree == null)
            return new GraphingResult();

         var graph = work.TreeGrapher.CreateGraph(work.ParseTree, work.ParserRules);
         graph.LayoutAlgorithmSettings = new SugiyamaLayoutSettings();

         return new GraphingResult(graph, work.ParseTree);
      }

      private void OnGraphingFinished(GraphingResult result)
      {
         _SynchronizationContext.Post(PostGraphingFinishedEvent, result);
      }

      private void PostGraphingFinishedEvent(object state)
      {
         GraphingFinished?.Invoke(this, (GraphingResult)state);
      }
   }
}