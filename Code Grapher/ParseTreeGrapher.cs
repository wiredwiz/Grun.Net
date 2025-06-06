#region BSD 3-Clause License

// <copyright file="ParseTreeGrapher.cs" company="Edgerunner.org">
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

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using Microsoft.Msagl.Drawing;

namespace Org.Edgerunner.ANTLR4.Tools.Graphing
{
   /// <summary>
   ///    Class used to graph ANTLR4 parse trees.
   /// </summary>
   /// <remarks>This class uses Microsoft's Automatic Graph Layout Library to do the actual dirty work.</remarks>
   public class ParseTreeGrapher : IParseTreeGrapher
   {
      /// <inheritdoc/>
      public Color? BackgroundColor { get; set; }

      /// <inheritdoc/>
      public Color? TextColor { get; set; }

      /// <inheritdoc/>
      public Color? BorderColor { get; set; }

      public bool UseLabelNames { get; set; }

      /// <inheritdoc/>
      public Graph CreateGraph(ITree tree, IList<string> parserRules)
      {
         var graph = new Graph();
         if (tree != null)
         {
            if (tree.ChildCount == 0)
               graph.AddNode(tree.GetHashCode().ToString());
            else
               GraphEdges(graph, tree);
            FormatNodes(graph, tree, parserRules);
         }

         return graph;
      }

      private void GraphEdges(Graph graph, ITree tree)
      {
         for (var i = tree.ChildCount - 1; i > -1; i--)
         {
            var child = tree.GetChild(i);
            graph.AddEdge(tree.GetHashCode().ToString(), child.GetHashCode().ToString());

            GraphEdges(graph, child);
         }
      }

      private void FormatNodes(Graph graph, ITree tree, IList<string> parserRules)
      {
         var node = graph.FindNode(tree.GetHashCode().ToString());
         if (node != null)
         {
            node.LabelText = Trees.GetNodeText(tree, parserRules);

            var ruleFailedAndMatchedNothing = false;

            var context = tree as ParserRuleContext;

            if (UseLabelNames && context != null)
            {
               var className = context.GetType().Name;
               var labelEnd = className.LastIndexOf("Context", StringComparison.Ordinal);
               node.LabelText = labelEnd != -1 ? className.Substring(0, labelEnd) : Trees.GetNodeText(tree, parserRules);
            }
            else
               node.LabelText = Trees.GetNodeText(tree, parserRules);

            if (context != null)
               ruleFailedAndMatchedNothing =
                  // ReSharper disable once ComplexConditionExpression
                  context.exception != null &&
                  context.Stop != null
                  && context.Stop.TokenIndex < context.Start.TokenIndex;

            if (tree is IErrorNode || ruleFailedAndMatchedNothing)
               node.Label.FontColor = Color.Red;
            else
               node.Label.FontColor = TextColor ?? Color.Black;

            node.Attr.Color = BorderColor ?? Color.Black;

            if (BackgroundColor.HasValue)
               node.Attr.FillColor = BackgroundColor.Value;

            node.Attr.Color = BorderColor ?? Color.Black;

            node.UserData = tree;
         }

         for (int i = 0; i < tree.ChildCount; i++)
            FormatNodes(graph, tree.GetChild(i), parserRules);
      }
   }
}