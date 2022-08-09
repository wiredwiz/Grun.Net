#region BSD 3-Clause License
// <copyright file="ConsoleWrapperColor.cs" company="Edgerunner.org">
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

using System.Collections.Generic;
using System.Drawing;

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;

using Console = Colorful.Console;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun.SyntaxHighlighting
{
   /// <summary>
   /// Class that represents a console wrapper class for achieving syntax highlighting.
   /// </summary>
   public static partial class SyntaxHighlightingConsole
   {
      private static HighlightingTokenCache _Cache = new HighlightingTokenCache();

      private static int _LineOffset = 0;

      private static int _ScrollFadeCount = 0;

      public static Color BackgroundColor
      {
         get => Console.BackgroundColor;
         set => Console.BackgroundColor = value;
      }

      public static Color ForegroundColor
      {
         get => Console.ForegroundColor;
         set => Console.ForegroundColor = value;
      }

      private static void SetSourceStart()
      {
         _LineOffset = Console.CursorTop - 1;
      }

      private static void HighlightTokens(IEnumerable<SyntaxToken> tokens, ISyntaxHighlightingGuide guide)
      {
         if (guide == null)
            return;

         var cursorRow = Console.CursorTop;
         var cursorColumn = Console.CursorLeft;
         foreach (var token in tokens)
            if (!_Cache.IsKnown(token))
            {
               ColorToken(token, _LineOffset - _ScrollFadeCount, guide);
               _Cache.RegisterToken(token);
            }


         Console.SetCursorPosition(cursorColumn, cursorRow);
      }

      private static void HighlightToken(SyntaxToken token, ISyntaxHighlightingGuide guide)
      {
         if (guide == null)
            return;

         var cursorRow = Console.CursorTop;
         var cursorColumn = Console.CursorLeft;
         if (!_Cache.IsKnown(token))
         {
            ColorToken(token, _LineOffset - _ScrollFadeCount, guide);
            _Cache.RegisterToken(token);
         }

         Console.SetCursorPosition(cursorColumn, cursorRow);
      }

      private static void ColorToken(SyntaxToken token, int lineOffset, ISyntaxHighlightingGuide guide)
      {
         if (token.Channel != 0)
            return;

         if (token.DisplayText == "<EOF>")
            return;

         var defaultForeGround = Console.ForegroundColor;
         var defaultBackground = Console.BackgroundColor;

         var startLine = token.Line + lineOffset;
         var endLine = token.EndingLineNumber + lineOffset;

         if (startLine < 0)
            if (endLine < 0)
               return;

         var index = 0;
         Console.ForegroundColor = guide.GetTokenForegroundColor(token);
         Console.BackgroundColor = guide.GetTokenBackgroundColor(token);

         for (int ln = startLine; ln < endLine + 1; ln++)
         {
            for (int col = token.ColumnPosition; col < token.EndingColumnPosition + 1; col++)
            {
               Console.SetCursorPosition(col - 1, ln);
               Console.Write(token.DisplayText[index++]);
            }
         }

         Console.ForegroundColor = defaultForeGround;
         Console.BackgroundColor = defaultBackground;
      }
   }
}