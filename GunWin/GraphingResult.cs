#region BSD 3-Clause License
// <copyright file="GraphingResult.cs" company="Edgerunner.org">
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

using Antlr4.Runtime.Tree;

using Microsoft.Msagl.Drawing;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   /// Struct that represents a graphing result.
   /// </summary>
   public struct GraphingResult
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GraphingResult"/> struct.
      /// </summary>
      /// <param name="graph">The graph.</param>
      /// <param name="parseTree">The parse tree.</param>
      public GraphingResult(Graph graph, ITree parseTree)
      {
         Graph = graph;
         ParseTree = parseTree;
      }

      /// <summary>
      /// Gets the graph.
      /// </summary>
      /// <value>The graph.</value>
      public Graph Graph { get; }

      /// <summary>
      /// Gets the parse tree.
      /// </summary>
      /// <value>The parse tree.</value>
      public ITree ParseTree { get; }
   }
}