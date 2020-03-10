#region BSD 3-Clause License

// <copyright file="ParseWorker.cs" company="Edgerunner.org">
// Copyright 2020 Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2020, Thaddeus Ryker
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

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar.Errors;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Tracing;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Parsing
{
   /// <summary>
   ///    Class that handles the work of text in the background.
   ///    Implements the <see cref="IParseWorker" />
   /// </summary>
   /// <remarks>This class is thread safe.</remarks>
   /// <seealso cref="IParseWorker" />
   public class ParseWorker : IParseWorker
   {
      private readonly object _Padlock;

      private readonly SynchronizationContext _SynchronizationContext;

      private DateTime _LastQueuedTime;

      private int _PreviousNodeQty;

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ParseWorker" /> class.
      /// </summary>
      /// <param name="synchronizationContext">The synchronization context.</param>
      public ParseWorker([NotNull] SynchronizationContext synchronizationContext)
      {
         _SynchronizationContext =
            synchronizationContext ?? throw new ArgumentNullException(nameof(synchronizationContext));
         _PreviousNodeQty = 0;
         _Padlock = new object();
         QueuedWork = new Queue<ParserWorkItem>();
         ParserTask = new Task(ParserWorkLoop);
      }

      #endregion

      /// <summary>
      ///    Gets or sets the parser task.
      /// </summary>
      /// <value>The parser task.</value>
      private Task ParserTask { get; set; }

      private Queue<ParserWorkItem> QueuedWork { get; }

      #region IParseWorker Members

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
      public void Parse(GrammarReference grammar, string parserRuleName, string text, ParseOption options)
      {
         lock (_Padlock)
         {
            var nextRun = CalculateNextRunTime(_PreviousNodeQty, 50, 5, 1000);
            var work = new ParserWorkItem(grammar, parserRuleName, text, options, nextRun);
            QueuedWork.Enqueue(work);
            _LastQueuedTime = DateTime.Now;
            if (ParserTask.IsCompleted)
               ParserTask = new Task(ParserWorkLoop);
            if (ParserTask.Status != TaskStatus.Running)
               ParserTask.Start();
         }
      }

      /// <inheritdoc />
      public event EventHandler<ParserResult> ParsingFinished;

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

      /// <summary>
      ///    Handles the actual parsing.
      /// </summary>
      /// <param name="work">The work item to parse.</param>
      /// <returns>A new <see cref="ParserResult" />.</returns>
      private ParserResult HandleParsing(ParserWorkItem work)
      {
         var errorListener = new TestingErrorListener();
         var analyzer = new Analyzer();
         var options = work.Options;
         var trace = options.HasFlag(ParseOption.Trace);
         if (trace) options ^= ParseOption.Trace;
         var parser = analyzer.BuildParserWithOptions(work.Grammar, work.Text, options);

         GuiTraceListener parseTreeListener = null;
         if (trace)
         {
            parseTreeListener = new GuiTraceListener(parser);
            parser.AddParseListener(parseTreeListener);
         }

         parser.RemoveErrorListeners();
         parser.AddErrorListener(errorListener);
         analyzer.ExecuteParsing(parser, work.ParserRuleName);

         return new ParserResult(analyzer.DisplayTokens, analyzer.ParseContext, work.ParserRuleName, errorListener.Errors, trace ? parseTreeListener.Events : new List<TraceEvent>());
      }

      private void OnParsingFinished(ParserResult result)
      {
         _SynchronizationContext.Post(PostParsingFinishedEvent, result);
      }

      private void ParserWorkLoop()
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

            if (workCount > 4 && (DateTime.Now - lastQueued) < TimeSpan.FromMilliseconds(1000))
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
               // However, we use the "ParseWhen" target date/time for the first entry for our check
               var work = QueuedWork.Dequeue();
               var parseWhen = work.ParseWhen;
               while (QueuedWork.Count != 0)
                  work = QueuedWork.Dequeue();

               // If we should delay longer, we enqueue the last item again for later evaluation
               if (DateTime.Now < parseWhen)
               {
                  QueuedWork.Enqueue(work);
                  continue;
               }

               var result = HandleParsing(work);
               _PreviousNodeQty = CalculateTotalTreeNodes(result.RuleContext);
               OnParsingFinished(result);
            }
         }
      }

      private void PostParsingFinishedEvent(object state)
      {
         ParsingFinished?.Invoke(this, (ParserResult)state);
      }
   }
}