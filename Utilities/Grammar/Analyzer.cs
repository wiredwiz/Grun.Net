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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Antlr4.Runtime;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Exceptions;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grammar
{
   /// <summary>
   /// Class that represents an ANTLR grammar analyzer.
   /// </summary>
   [SuppressMessage("ReSharper", "RedundantNameQualifier", Justification = "Being explicit never hurts")]
   public class Analyzer
   {
      /// <summary>
      /// Gets the syntax tokens.
      /// </summary>
      /// <value>The syntax tokens.</value>
      public IList<DetailedToken> Tokens { get; private set; }

      /// <summary>
      /// Gets the parser context.
      /// </summary>
      /// <value>The parser context.</value>
      public ParserRuleContext ParserContext { get; private set; }

      /// <summary>
      /// Gets a value indicating whether this instance is parsed.
      /// </summary>
      /// <value><c>true</c> if this instance is parsed; otherwise, <c>false</c>.</value>
      public bool IsParsed { get; private set; }

      /// <summary>
      /// Tokenizes the grammar text and returns the tokens.
      /// </summary>
      /// <param name="grammar">The grammar.</param>
      /// <param name="inputText">The input text.</param>
      /// <param name="lexerErrorListener">The lexer error listener.</param>
      /// <returns>A new <see cref="IList{IToken}" />.</returns>
      /// <exception cref="ArgumentNullException">grammar is <see langword="null" /></exception>
      /// <exception cref="ArgumentNullException">inputText is <see langword="null" /></exception>
      /// <exception cref="ArgumentNullException"><paramref name="grammar" /> is <see langword="null" />.</exception>
      /// <exception cref="T:System.IO.FileLoadException"><paramref name="inputText" /> is <see langword="null" /> or empty.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">Grammar assembly could not be loaded.</exception>
      /// <exception cref="T:System.BadImageFormatException">The grammar assembly path is an empty string ("") or does not exist.</exception>
      public IList<DetailedToken> Tokenize([NotNull] GrammarReference grammar, [NotNull] string inputText, IAntlrErrorListener<int> lexerErrorListener)
      {
         if (grammar is null)
            throw new ArgumentNullException(nameof(grammar));
         if (inputText is null)
            throw new ArgumentNullException(nameof(inputText));

         var loader = new Grammar.Loader();
         var inputStream = new AntlrInputStream(inputText);
         var lexer = loader.LoadLexer(grammar, inputStream);
         lexer.TokenFactory = DetailedTokenFactory.Instance;
         lexer.RemoveErrorListeners();
         if (lexerErrorListener != null)
            lexer.AddErrorListener(lexerErrorListener);
         var commonTokenStream = new CommonTokenStream(lexer);
         commonTokenStream.Fill();
         Tokens = commonTokenStream.GetTokens().Cast<DetailedToken>().ToList();
         return Tokens;
      }

      /// <summary>
      /// Builds a new parser for the specified grammar and input using the supplied rules.
      /// </summary>
      /// <param name="grammar">The grammar to use.</param>
      /// <param name="inputText">The input text to use.</param>
      /// <param name="option">The parsing options to use.</param>
      /// <param name="lexerErrorListener">The lexer error listener.</param>
      /// <returns>A new <see cref="Parser" /> instance.</returns>
      /// <exception cref="ArgumentNullException">grammar is <see langword="null" /></exception>
      /// <exception cref="ArgumentNullException">inputText is <see langword="null" /></exception>
      /// <exception cref="GrammarException">No parser found for grammar \"{grammar.GrammarName}\"</exception>
      /// <exception cref="ArgumentNullException">No parser found for specified grammar.</exception>
      // ReSharper disable once FlagArgument
      public Parser BuildParserWithOptions([NotNull] GrammarReference grammar, [NotNull] string inputText, ParseOption option, IAntlrErrorListener<int> lexerErrorListener)
      {
         if (grammar is null)
            throw new ArgumentNullException(nameof(grammar));
         if (inputText is null)
            throw new ArgumentNullException(nameof(inputText));
         if (grammar.Parser == null)
            throw new GrammarException($"No parser found for grammar \"{grammar.GrammarName}\"");

         var loader = new Grammar.Loader();
         var inputStream = new AntlrInputStream(inputText);
         var lexer = loader.LoadLexer(grammar, inputStream);
         lexer.TokenFactory = DetailedTokenFactory.Instance;
         if (lexerErrorListener != null)
         {
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(lexerErrorListener);
         }

         var commonTokenStream = new CommonTokenStream(lexer);

         commonTokenStream.Fill();
         Tokens = commonTokenStream.GetTokens().Cast<DetailedToken>().ToList();

         if (option.HasFlag(ParseOption.Tokens))
            foreach (var token in Tokens)
               Console.WriteLine(token.ToString());

         var parser = loader.LoadParser(grammar, commonTokenStream);

         // Handle Tree parsing option
         parser.BuildParseTree = option.HasFlag(ParseOption.Tree);

         // Handle Diagnostics parsing option
         if (option.HasFlag(ParseOption.Diagnostics))
         {
            parser.AddErrorListener(new DiagnosticErrorListener());
            parser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.LL_EXACT_AMBIG_DETECTION;
         }

         // Handle Sll parsing option
         if (option.HasFlag(ParseOption.Sll))
            parser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.SLL;

         // Handle Trace parsing option
         parser.Trace = option.HasFlag(ParseOption.Trace);

         return parser;
      }

      /// <summary>
      /// Executes parsing with the supplied parser and parser rule.
      /// </summary>
      /// <param name="parser">The parser.</param>
      /// <param name="parserRule">The parser rule.</param>
      /// <exception cref="ArgumentNullException"><paramref name="parser"/> is <see langword="null" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="parserRule"/> is <see langword="null" /> or empty.</exception>
      /// <exception cref="GrammarException">Specified parser rule not found.</exception>
      public void ExecuteParsing([NotNull] Parser parser, [NotNull] string parserRule)
      {
         if (parser is null)
            throw new ArgumentNullException(nameof(parser));
         if (parserRule is null)
            throw new ArgumentNullException(nameof(parserRule));

         var methodInfo = parser.GetType().GetMethod(parserRule);
         if (methodInfo == null)
            throw new GrammarException($"No parser rule with name \"{parserRule}\" found.");

         ParserContext = methodInfo.Invoke(parser, null) as ParserRuleContext;
         IsParsed = true;
      }

      private IList<DetailedToken> PopulateTokenTypeNames([NotNull] Lexer lexer, [NotNull] IEnumerable<IToken> tokens)
      {
         if (lexer is null) throw new ArgumentNullException(nameof(lexer));
         if (tokens is null) throw new ArgumentNullException(nameof(tokens));

         var syntaxTokens = new List<DetailedToken>();
         foreach (var token in tokens)
         {
            var syntaxToken = (DetailedToken)token;
            syntaxToken.TypeName = syntaxToken.Type > -1 ? lexer.Vocabulary.GetDisplayName(syntaxToken.Type) : string.Empty;
            syntaxTokens.Add(syntaxToken);
         }

         return syntaxTokens;
      }
   }
}