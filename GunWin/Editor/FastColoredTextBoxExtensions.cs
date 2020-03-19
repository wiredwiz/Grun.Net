#region BSD 3-Clause License
// <copyright file="FastColoredTextBoxExtensions.cs" company="Edgerunner.org">
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

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using FastColoredTextBoxNS;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Testing.Extensions;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor
{
   /// <summary>
   /// Class that contains a set of extension methods for the FastColoredTextBox.
   /// </summary>
   public static class FastColoredTextBoxExtensions
   {
      /// <summary>
      /// Selects the source source text corresponding to the provided parser rule context.
      /// </summary>
      /// <param name="codeEditor">The code editor.</param>
      /// <param name="context">The parser rule context.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="codeEditor"/> is <see langword="null"/></exception>
      public static void SelectSource([NotNull] this FastColoredTextBox codeEditor, ParserRuleContext context)
      {
         if (codeEditor is null)
            throw new ArgumentNullException(nameof(codeEditor));

         if (context == null)
            return;

         var startingPlace = new Place(context.Start.Column, context.start.Line - 1);
         var stopToken = context.Stop ?? context.Start;
         var spot = stopToken.GetEndPlace();
         var stoppingPlace = new Place(spot.Position, spot.Line - 1);
         
         codeEditor.Selection = new Range(codeEditor, startingPlace, stoppingPlace);
         codeEditor.DoCaretVisible();
      }

      /// <summary>
      /// Selects the source source text corresponding to the provided terminal node.
      /// </summary>
      /// <param name="codeEditor">The code editor.</param>
      /// <param name="node">The terminal node.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="codeEditor"/> is <see langword="null"/></exception>
      public static void SelectSource([NotNull] this FastColoredTextBox codeEditor, TerminalNodeImpl node)
      {
         if (codeEditor is null)
            throw new ArgumentNullException(nameof(codeEditor));

         if (node == null)
            return;

         SelectSource(codeEditor, node.Symbol);
      }

      /// <summary>
      /// Selects the source source text corresponding to the provided error node.
      /// </summary>
      /// <param name="codeEditor">The code editor.</param>
      /// <param name="node">The error node.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="codeEditor"/> is <see langword="null"/></exception>
      public static void SelectSource([NotNull] this FastColoredTextBox codeEditor, ErrorNodeImpl node)
      {
         if (codeEditor is null)
            throw new ArgumentNullException(nameof(codeEditor));

         if (node == null)
            return;

         var startingPlace = new Place(node.Symbol.Column, node.Symbol.Line - 1);
         Place stoppingPlace;
         if (node.Symbol.StartIndex != -1)
         {
            var spot = node.Symbol.GetEndPlace();
            stoppingPlace = new Place(spot.Position, spot.Line - 1);
         }
         else
            stoppingPlace = startingPlace;

         codeEditor.Selection = new Range(codeEditor, startingPlace, stoppingPlace);
         codeEditor.DoCaretVisible();
      }

      /// <summary>
      /// Selects the source source text corresponding to the provided token.
      /// </summary>
      /// <param name="codeEditor">The code editor.</param>
      /// <param name="token">The token.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="codeEditor"/> is <see langword="null"/></exception>
      public static void SelectSource([NotNull] this FastColoredTextBox codeEditor, IToken token)
      {
         if (codeEditor is null)
            throw new ArgumentNullException(nameof(codeEditor));

         if (token == null)
            return;

         var startingPlace = new Place(token.Column, token.Line - 1);
         var spot = token.GetEndPlace();
         var stoppingPlace = new Place(spot.Position, spot.Line - 1);

         codeEditor.Selection = new Range(codeEditor, startingPlace, stoppingPlace);
         codeEditor.DoCaretVisible();
      }

      /// <summary>
      /// Selects the source source text corresponding to the provided parse tree instance.
      /// </summary>
      /// <param name="codeEditor">The code editor.</param>
      /// <param name="tree">The parse tree.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="codeEditor"/> is <see langword="null"/></exception>
      public static void SelectSource(this FastColoredTextBox codeEditor, ITree tree)
      {
         if (tree is null)
            return;

         if (tree is ParserRuleContext context)
            codeEditor.SelectSource(context);
         else if (tree is ErrorNodeImpl errorTerminal)
            codeEditor.SelectSource(errorTerminal);
         else if (tree is TerminalNodeImpl terminal)
            codeEditor.SelectSource(terminal);
      }
   }
}