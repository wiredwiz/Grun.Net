#region BSD 3-Clause License

// <copyright file="EditorSyntaxHighlighter.cs" company="Edgerunner.org">
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
using System.Threading;
using System.Windows.Forms;

using FastColoredTextBoxNS;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   /// Class used to handle syntax highlighting of a FastColoredTextBox editor.
   /// </summary>
   public class EditorSyntaxHighlighter
   {
      private int _TokenColoringInProgress;

      public void ColorizeTokens(FastColoredTextBox editor, IStyleRegistry registry, IList<TokenViewModel> tokens)
      {
         int coloring = Interlocked.Exchange(ref _TokenColoringInProgress, 1);
         if (coloring != 0) 
            return;

         editor.BeginInvoke(
             new MethodInvoker(() => 
                {
                   editor.BeginUpdate();

                   try
                   {
                      foreach (var token in tokens)
                      {
                         var startingPlace = new Place(token.ActualToken.Column, token.ActualToken.Line - 1);
                         var stoppingPlace = new Place(token.EndingColumnPosition - 1, token.EndingLineNumber - 1);
                         var tokenRange = editor.GetRange(startingPlace, stoppingPlace);
                         tokenRange.ClearStyle(StyleIndex.All);
                         var style = registry.GetTokenStyle(token);
                         tokenRange.SetStyle(style);
                      }
                   }
                   finally
                   {
                      editor.EndUpdate();
                   }

                   _TokenColoringInProgress = 0;
                }));
      }
   }
}