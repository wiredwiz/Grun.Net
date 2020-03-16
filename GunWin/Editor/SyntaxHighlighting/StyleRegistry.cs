#region BSD 3-Clause License
// <copyright file="StyleRegistry.cs" company="Edgerunner.org">
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

using System;
using System.Collections.Generic;

using FastColoredTextBoxNS;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common;
using Org.Edgerunner.ANTLR4.Tools.Common.Editor;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting
{
   /// <summary>
   /// Class for managing the various Style configurations of different tokens and errors.
   /// </summary>
   public class StyleRegistry : IStyleRegistry
   {
      private readonly IEditorGuide _EditorGuide;

      private readonly Dictionary<string, Style> _TokenStyles;

      private readonly Dictionary<string, Style> _UniqueStyles;

      private Style _ErrorStyle;

      public StyleRegistry([NotNull] IEditorGuide editorGuide)
      {
         _EditorGuide = editorGuide ?? throw new ArgumentNullException(nameof(editorGuide));
         _TokenStyles = new Dictionary<string, Style>();
         _UniqueStyles = new Dictionary<string, Style>();
      }

      /// <summary>
      /// Gets the style for a given token.
      /// </summary>
      /// <param name="token">The token.</param>
      /// <returns>A <see cref="Style"/> instance.</returns>
      public Style GetTokenStyle(SyntaxToken token)
      {
         if (_TokenStyles.TryGetValue(token.Type, out var style))
            return style;

         var foregroundBrush = _EditorGuide.GetTokenForegroundBrush(token.Type);
         var backgroundBrush = _EditorGuide.GetTokenBackgroundBrush(token.Type);
         var fontStyle = _EditorGuide.GetTokenFontStyle(token.Type);
         var key = foregroundBrush.GetHashCode().ToString() + backgroundBrush.GetHashCode() + fontStyle;
         if (_UniqueStyles.TryGetValue(key, out style))
         {
            _TokenStyles[token.Type] = style;
            return style;
         }

         style = new TextStyle(foregroundBrush, backgroundBrush, fontStyle);
         _UniqueStyles[key] = style;
         _TokenStyles[token.Type] = style;
         return style;
      }

      /// <summary>
      /// Gets the style for a parse error .
      /// </summary>
      /// <returns>A <see cref="Style"/> instance.</returns>
      public Style GetParseErrorStyle()
      {
         return _ErrorStyle ?? (_ErrorStyle = new WavyLineStyle(240, _EditorGuide.ErrorColor));
      }
   }
}