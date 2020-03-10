#region BSD 3-Clause License

// <copyright file="GraphingWorkItem.cs" company="Edgerunner.org">
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

using Org.Edgerunner.ANTLR4.Tools.Graphing;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Graphing
{
   /// <summary>
   ///    Struct that represents an item of work for the parser.
   /// </summary>
   public struct GraphingWorkItem
   {
      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="GraphingWorkItem" /> struct.
      /// </summary>
      /// <param name="tree">The parse tree to graph.</param>
      /// <param name="parserRules">The parser rules.</param>
      /// <param name="grapher">The parse tree grapher to use.</param>
      /// <param name="graphWhen">The DateTime indicating when to parse.</param>
      public GraphingWorkItem(
         ITree tree,
         IList<string> parserRules,
         IParseTreeGrapher grapher,
         DateTime graphWhen)
      {
         ParseTree = tree;
         ParserRules = parserRules;
         GraphWhen = graphWhen;
         TreeGrapher = grapher;
      }

      #endregion

      /// <summary>
      /// Gets the parse tree to graph.
      /// </summary>
      /// <value>The parse tree.</value>
      public ITree ParseTree { get; }

      /// <summary>
      ///    Gets the parse tree grapher to use.
      /// </summary>
      /// <value>The parse tree grapher.</value>
      public IParseTreeGrapher TreeGrapher { get; }

      /// <summary>
      /// Gets the parser rules.
      /// </summary>
      /// <value>The parser rules.</value>
      public IList<string> ParserRules { get; }

      /// <summary>
      /// Gets the date/time of when to parse.
      /// </summary>
      /// <value>The <see cref="DateTime"/>.</value>
      public DateTime GraphWhen { get; }
   }
}