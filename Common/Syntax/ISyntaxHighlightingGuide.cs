#region BSD 3-Clause License
// <copyright file="ISyntaxHighlightingGuide.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.ANTLR4.Tools.Common.Syntax
{
   /// <summary>
   /// Interface that represents a syntax highlighting guide
   /// </summary>
   public interface ISyntaxHighlightingGuide
   {
      /// <summary>
      /// Gets the name of the grammar.
      /// </summary>
      /// <value>The name of the grammar.</value>
      string GrammarName { get; }

      /// <summary>Gets all grammar names this syntax highlighting guide supports.</summary>
      /// <value>All grammar names.</value>
      /// <remarks>Usually used for a cluster of grammar variants that share structure.</remarks>
      IList<string> AllGrammarNames { get; }

      /// <summary>
      /// Gets the error indicator color.
      /// </summary>
      /// <returns>The <see cref="Color"/> to use.</returns>
      Color GetErrorIndicatorColor();

      /// <summary>
      /// Gets the foreground color to use for the token.
      /// </summary>
      /// <param name="token">The token.</param>
      /// <returns>The <see cref="Color"/> to use.</returns>
      Color GetTokenForegroundColor(DetailedToken token);

      /// <summary>
      /// Gets the background color to use for the token.
      /// </summary>
      /// <param name="token">The token.</param>
      /// <returns>The <see cref="Color"/> to use.</returns>
      Color GetTokenBackgroundColor(DetailedToken token);

      /// <summary>
      /// Gets the FontStyle to use for the token.
      /// </summary>
      /// <param name="token">The token.</param>
      /// <returns>The <see cref="FontStyle"/> to use.</returns>
      FontStyle GetTokenFontStyle(DetailedToken token);
   }
}