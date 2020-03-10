#region BSD 3-Clause License
// <copyright file="GuiTraceListener.cs" company="Edgerunner.org">
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

using System.Collections.Generic;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Tracing
{
   /// <summary>
   /// Class that functions as a trace listener for use in graphical applications.
   /// Implements the <see cref="Antlr4.Runtime.Tree.IParseTreeListener" />
   /// </summary>
   /// <seealso cref="Antlr4.Runtime.Tree.IParseTreeListener" />
   public class GuiTraceListener : IParseTreeListener
   {
      private Parser _Parser;
      private List<TraceEvent> _Events;

      /// <summary>
      /// Initializes a new instance of the <see cref="GuiTraceListener"/> class.
      /// </summary>
      /// <param name="parser">The parser.</param>
      public GuiTraceListener(Parser parser)
      {
         _Parser = parser;
         _Events = new List<TraceEvent>();
      }

      /// <summary>
      /// Gets the trace events.
      /// </summary>
      /// <value>The trace events.</value>
      public IList<TraceEvent> Events => _Events;

      /// <inheritdoc/>
      public void VisitTerminal(ITerminalNode node)
      {
         ParserRuleContext ruleContext = (ParserRuleContext)node.Parent.RuleContext;
         _Events.Add(new TraceEvent(TraceEventType.Consume, node.Symbol, ruleContext, _Parser.RuleNames[ruleContext.RuleIndex]));
      }

      /// <inheritdoc/>
      public void VisitErrorNode(IErrorNode node)
      {
      }

      /// <inheritdoc/>
      public void EnterEveryRule(ParserRuleContext ctx)
      {
         _Events.Add(new TraceEvent(TraceEventType.Enter, _Parser.CurrentToken, ctx, _Parser.RuleNames[ctx.RuleIndex]));
      }

      /// <inheritdoc/>
      public void ExitEveryRule(ParserRuleContext ctx)
      {
         _Events.Add(new TraceEvent(TraceEventType.Exit, _Parser.CurrentToken, ctx, _Parser.RuleNames[ctx.RuleIndex]));
      }
   }
}