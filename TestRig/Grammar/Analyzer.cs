#region BSD 3-Clause License
// <copyright file="Analyzer.cs" company="Edgerunner.org">
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
using System.Reflection;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR.Tools.Testing.Exceptions;

namespace Org.Edgerunner.ANTLR.Tools.Testing.Grammar
{
   /// <summary>
   /// Class that represents an ANTLR grammar analyzer.
   /// </summary>
   public class Analyzer
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Analyzer"/> class.
      /// </summary>
      /// <param name="grammar">The grammar to use.</param>
      /// <param name="text">The text to analyze.</param>
      /// <exception cref="T:System.ArgumentNullException">Grammar or text is <see langword="null"/>.</exception>
      public Analyzer([NotNull] GrammarReference grammar, [NotNull] string text)
      {
         Grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));
         Text = text ?? throw new ArgumentNullException(nameof(text));
      }

      /// <summary>
      /// Gets or sets the text to analyze.
      /// </summary>
      /// <value>The text.</value>
      protected string Text { get; set; }

      /// <summary>
      /// Gets or sets the grammar to use.
      /// </summary>
      /// <value>The grammar.</value>
      /// <seealso cref="GrammarReference"/>
      protected GrammarReference Grammar { get; set; }

      /// <summary>
      /// Gets the tokens.
      /// </summary>
      /// <value>The tokens.</value>
      public IList<IToken> Tokens { get; private set; }

      /// <summary>
      /// Gets the parse context.
      /// </summary>
      /// <value>The parse context.</value>
      public ParserRuleContext ParseContext { get; private set; }

      /// <summary>
      /// Gets a Lisp-style parse tree.
      /// </summary>
      /// <value>The string source tree.</value>
      public string StringSourceTree { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is parsed.
      /// </summary>
      /// <value><c>true</c> if this instance is parsed; otherwise, <c>false</c>.</value>
      public bool IsParsed { get; private set; }

      /// <summary>
      /// Tokenizes the grammar text and returns the tokens.
      /// </summary>
      /// <returns>A new <see cref="IList{IToken}" />.</returns>
      /// <exception cref="T:System.IO.FileLoadException">Grammar assembly could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The grammar assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The grammar assembly path is not a valid assembly.</exception>
      public IList<IToken> Tokenize()
      {
         var loader = new Grammar.Loader();
         var inputStream = new AntlrInputStream(Text);
         var lexer = loader.LoadLexer(Grammar, inputStream);
         var commonTokenStream = new CommonTokenStream(lexer);
         commonTokenStream.Fill();
         Tokens = commonTokenStream.GetTokens();
         return Tokens;
      }

      /// <summary>
      /// Parses the text for the specified rule name.
      /// </summary>
      /// <param name="ruleName">Name of the rule.</param>
      /// <exception cref="GrammarException">No parser found for the specified grammar.</exception>
      /// <exception cref="GrammarException">No matching parser rule exists.</exception>
      public void Parse(string ruleName)
      {
         if (Grammar.Parser == null)
            throw new GrammarException($"No parser found for grammar \"{Grammar.GrammarName}\"");

         var loader = new Grammar.Loader();
         var inputStream = new AntlrInputStream(Text);
         var lexer = loader.LoadLexer(Grammar, inputStream);
         var commonTokenStream = new CommonTokenStream(lexer);
         var parser = loader.LoadParser(Grammar, commonTokenStream);
         parser.BuildParseTree = true;
         var methodInfo = Grammar.Parser.GetMethod(ruleName);
         if (methodInfo == null)
            throw new GrammarException($"No parser rule with name \"{ruleName}\" found.");
         ParseContext = methodInfo.Invoke(parser, null) as ParserRuleContext;
         Tokens = commonTokenStream.GetTokens();
         StringSourceTree = ParseContext.ToStringTree(parser);
         IsParsed = true;
      }
   }
}