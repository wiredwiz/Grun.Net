#region BSD 3-Clause License
// <copyright file="ITreeExtensions.cs" company="Edgerunner.org">
// Copyright 2021 Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2021, Thaddeus Ryker
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

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Extensions
{
   /// <summary>
   /// Class containing extension methods for the ITree interface.
   /// </summary>
   public static class ITreeExtensions
   {
      /// <summary>
      /// Finds the deepest tree node that contains the select source position.
      /// </summary>
      /// <param name="tree">The tree to evaluate.</param>
      /// <param name="sourcePlace">The source placement.</param>
      /// <returns>The matching <see cref="ITree"/> node or null.</returns>
      public static ITree FindTreeNodeForSourcePosition([NotNull] this ITree tree, Place sourcePlace)
      {
         return FindTreeNodeForSourceSelection(tree, sourcePlace, sourcePlace);
      }

      /// <summary>
      /// Finds the deepest tree node that contains the select source range.
      /// </summary>
      /// <param name="tree">The tree to evaluate.</param>
      /// <param name="start">The start placement of the source selection.</param>
      /// <param name="end">The end placement of the source selection.</param>
      /// <returns>The matching <see cref="ITree"/> node or null.</returns>
      public static ITree FindTreeNodeForSourceSelection([NotNull] this ITree tree, Place start, Place end)
      {
         if (start.Equals(Place.Empty) || end.Equals(Place.Empty))
            return null;

         return EvaluateNodeAndChildren(tree, start, end);
      }

      private static ITree EvaluateNodeAndChildren(ITree tree, Place start, Place end)
      {
         var passes = false;
         var matched = tree;

         if (tree is ParserRuleContext context)
            passes = context.ContainsSourceSelection(start, end);
         else if (tree is ErrorNodeImpl errorTerminal)
            errorTerminal.ContainsSourceSelection(start, end);
         else if (tree is TerminalNodeImpl terminal)
            terminal.ContainsSourceSelection(start, end);

         if (passes)
            if (tree.ChildCount != 0)
               for (int i = 0; i < tree.ChildCount; i++)
               {
                  var child = tree.GetChild(i);
                  var result = EvaluateNodeAndChildren(child, start, end);
                  if (result != null)
                  {
                     matched = result;
                     break;
                  }
               }

         return passes ? matched : null;
      }
   }
}