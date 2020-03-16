#region BSD 3-Clause License
// <copyright file="IEditorGuide.cs" company="Edgerunner.org">
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

using System.Drawing;

namespace Org.Edgerunner.ANTLR4.Tools.Common.Editor
{
   public interface IEditorGuide
   {
      /// <summary>
      /// Gets the name of the grammar.
      /// </summary>
      /// <value>The name of the grammar.</value>
      string GrammarName { get; }

      /// <summary>
      /// Gets a value indicating whether to enable automatic indent.
      /// </summary>
      /// <value><c>true</c> if automatic indentation enabled; otherwise, <c>false</c>.</value>
      bool EnableAutoIndent { get; }

      /// <summary>
      /// Gets a value indicating whether to enable bracket autocomplete.
      /// </summary>
      /// <value><c>true</c> if bracket autocomplete is enabled; otherwise, <c>false</c>.</value>
      bool EnableBracketAutocomplete { get; }

      /// <summary>
      /// Gets a value indicating whether to enable word wrap.
      /// </summary>
      /// <value><c>true</c> if word wrap is enabled; otherwise, <c>false</c>.</value>
      bool EnableWordWrap { get; }

      /// <summary>
      /// Gets the color of the line number.
      /// </summary>
      /// <value>The color of the line number.</value>
      Color LineNumberColor { get; }

      /// <summary>
      /// Gets the color of the foreground text.
      /// </summary>
      /// <value>The color of the foreground text.</value>
      Color ForeColor { get; }

      /// <summary>
      /// Gets the color of the background.
      /// </summary>
      /// <value>The color of the background.</value>
      Color BackColor { get; }

      /// <summary>
      /// Gets the color of the caret.
      /// </summary>
      /// <value>The color of the caret.</value>
      Color CaretColor { get; }

      /// <summary>
      /// Gets the color of the selected text blocks.
      /// </summary>
      /// <value>The color of the selected text blocks.</value>
      Color SelectionColor { get; }

      /// <summary>
      /// Gets the color to use for parsing errors.
      /// </summary>
      /// <value>The color of the error.</value>
      Color ErrorColor { get; }

      /// <summary>
      /// Gets the foreground brush to use for the token.
      /// </summary>
      /// <param name="tokenTypeName">Name of the token type.</param>
      /// <returns>The <see cref="Brush"/> to use.</returns>
      Brush GetTokenForegroundBrush(string tokenTypeName);

      /// <summary>
      /// Gets the background brush to use for the token.
      /// </summary>
      /// <param name="tokenTypeName">Name of the token type.</param>
      /// <returns>The <see cref="Brush"/> to use.</returns>
      Brush GetTokenBackgroundBrush(string tokenTypeName);

      /// <summary>
      /// Gets the FontStyle to use for the token.
      /// </summary>
      /// <param name="tokenTypeName">Name of the token type.</param>
      /// <returns>The <see cref="FontStyle"/> to use.</returns>
      FontStyle GetTokenFontStyle(string tokenTypeName);
   }
}