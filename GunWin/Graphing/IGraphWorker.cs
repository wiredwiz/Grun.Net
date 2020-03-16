#region BSD 3-Clause License
// <copyright file="IGraphWorker.cs" company="Edgerunner.org">
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

using Antlr4.Runtime.Tree;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Graphing;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Graphing
{
   /// <summary>
   /// Interface representing an instance that does the work building parse tree graphs.
   /// </summary>
   public interface IGraphWorker
   {
      /// <summary>
      /// Occurs when graphing is finished.
      /// </summary>
      event EventHandler<GraphingResult> GraphingFinished;

      /// <summary>
      /// Occurs when the throttling status has changed.
      /// </summary>
      event EventHandler ThrottleStatusChanged;

      /// <summary>
      /// Gets a value indicating whether the worker is currently throttling.
      /// </summary>
      /// <value><c>true</c> if graph throttling is currently active; otherwise, <c>false</c>.</value>
      bool CurrentlyThrottling { get; }

      /// <summary>
      /// Gets a value indicating whether a long graphing delay is active.
      /// </summary>
      /// <value><c>true</c> if long graphing delay is active; otherwise, <c>false</c>.</value>
      bool LongDelayActive { get; }

      /// <summary>
      /// Gets the current millisecond delay between graphs.
      /// </summary>
      /// <value>The current millisecond delay between graphs.</value>
      int CurrentMillisecondDelayBetweenGraphs { get; }

      /// <summary>
      /// Queues the specified parse tree for graphing.
      /// </summary>
      /// <param name="grapher">The parse tree grapher.</param>
      /// <param name="tree">The parse tree.</param>
      /// <param name="parserRules">The parser rules.</param>
      void Graph([NotNull] IParseTreeGrapher grapher, ITree tree, IList<string> parserRules);

      /// <summary>
      /// Cancels all queued work.
      /// </summary>
      /// <returns><c>true</c> if there was existing work to cancel, <c>false</c> otherwise.</returns>
      bool CancelWork();
   }
}