#region BSD 3-Clause License

// <copyright file="ParserWorkItem.cs" company="Edgerunner.org">
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

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Parsing
{
   /// <summary>
   ///    Struct that represents an item of work for the parser.
   /// </summary>
   public struct ParserWorkItem
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ParserWorkItem" /> struct.
      /// </summary>
      /// <param name="grammar">The grammar to parse with.</param>
      /// <param name="parserRuleName">Name of the parser rule.</param>
      /// <param name="text">The text to parse.</param>
      /// <param name="options">The parser options.</param>
      /// <param name="parseWhen">The DateTime indicating when to parse.</param>
      /// <exception cref="ArgumentNullException"><paramref name="grammar" /> is <see langword="null" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="parserRuleName" /> is <see langword="null" /> or empty.</exception>
      public ParserWorkItem(
         [NotNull] GrammarReference grammar,
         [NotNull] string parserRuleName,
         string text,
         ParseOption options,
         DateTime parseWhen)
      {
         Grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));
         ParserRuleName = parserRuleName ?? throw new ArgumentNullException(nameof(parserRuleName));
         Text = text;
         Options = options;
         ParseWhen = parseWhen;
      }

      #endregion

      /// <summary>
      ///    Gets the grammar to parse with.
      /// </summary>
      /// <value>The grammar.</value>
      public GrammarReference Grammar { get; }

      /// <summary>
      ///    Gets the parser options.
      /// </summary>
      /// <value>The parser options.</value>
      public ParseOption Options { get; }

      /// <summary>
      ///    Gets the name of the parser rule to use.
      /// </summary>
      /// <value>The name of the parser rule.</value>
      public string ParserRuleName { get; }

      /// <summary>
      ///    Gets the text to parse.
      /// </summary>
      /// <value>The text.</value>
      public string Text { get; }

      /// <summary>
      /// Gets the date/time of when to parse.
      /// </summary>
      /// <value>The <see cref="DateTime"/>.</value>
      public DateTime ParseWhen { get; }
   }
}