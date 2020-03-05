#region BSD 3-Clause License

// <copyright file="Program.cs" company="Edgerunner.org">
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
using System.IO;
using System.Text;
using System.Windows.Forms;

using Antlr4.Runtime.Misc;

using CommandLine;
using CommandLine.Text;

using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunDotNet
{
   /// <summary>
   /// Class that represents the entry point into the program.
   /// </summary>
   internal class Program
   {
      #region Static

      [STAThread]
      // ReSharper disable once MethodTooLong
      private static void Main(string[] args)
      {
         try
         {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);
            parserResult
                      .WithParsed(o =>
                         {
                            var options = Grammar.ParseOption.None;
                            var loadGui = false;
                            var showParseTree = false;

                            if (o.Tokens) options |= Grammar.ParseOption.Tokens;
                            if (o.Diagnostics) options |= Grammar.ParseOption.Diagnostics;
                            if (o.Trace) options |= Grammar.ParseOption.Trace;
                            if (o.Tree)
                            {
                               options |= Grammar.ParseOption.Tree;
                               showParseTree = true;
                            }

                            if (o.Sll) options |= Grammar.ParseOption.Sll;
                            if (o.Gui)
                            {
                               loadGui = true;
                               options |= Grammar.ParseOption.Tree;
                            }

                            if (!string.IsNullOrEmpty(o.PostScript))
                               Console.WriteLine("Option --ps is not yet supported.");

                            var workingDirectory = Environment.CurrentDirectory;
                            var scanner = new Grammar.Scanner();

                            var grammar = scanner.LocateGrammar(workingDirectory, o.GrammarName);
                            if (grammar == null)
                            {
                               Console.WriteLine(
                                                 $"Could not find an assembly that defines grammar \"{o.GrammarName}\" in the current working directory");
                               return;
                            }

                            string line;
                            var data = string.Empty;

                            if (!string.IsNullOrEmpty(o.FileName))
                            {
                               var encodingToUse = !string.IsNullOrEmpty(o.EncodingName) ? Encoding.GetEncoding(o.EncodingName) : Encoding.Default;
                               using (var reader = new StreamReader(o.FileName, encodingToUse))
                                  data = reader.ReadToEnd();
                            }
                            else
                            {
                               Console.WriteLine("Now reading from standard input.  Use Ctrl+Z to terminate input");
                               while ((line = Console.ReadLine()) != null)
                                  data += line + Environment.NewLine;
                            }

                            // If tokens are the only option we've received, we don't need to parse
                            if (options == Grammar.ParseOption.Tokens)
                            {
                               DisplayTokens(grammar, data);
                               return;
                            }

                            var analyzer = new Grammar.Analyzer(grammar, data);
                            analyzer.Parse(o.RuleName, options);

                            if (showParseTree)
                              Console.WriteLine(analyzer.StringSourceTree);

                            if (loadGui)
                               LoadGui(data, grammar, o.RuleName);
                         })
                      .WithNotParsed(errs => DisplayHelp(parserResult, errs));
         }
         // ReSharper disable once CatchAllClause
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
         }
      }

      private static void DisplayTokens(GrammarReference grammar, string data)
      {
         var analyzer = new Grammar.Analyzer(grammar, data);
         var tokens = analyzer.Tokenize();
         foreach (var token in tokens)
            Console.WriteLine(token.ToString());
      }

      private static void LoadGui(string data, GrammarReference grammar, string parserRule)
      {
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var visualAnalyzer = new VisualAnalyzer();
            visualAnalyzer.SetSourceCode(data);
            visualAnalyzer.SetGrammar(grammar);
            visualAnalyzer.SetDefaultParserRule(parserRule);
            visualAnalyzer.ParseSource();
            Application.Run(visualAnalyzer);
         }
      }

      /// <summary>
      /// Displays the help message.
      /// </summary>
      /// <typeparam name="T">The option type</typeparam>
      /// <param name="result">The command line parser result.</param>
      /// <param name="errors">The parser errors.</param>
      // ReSharper disable once UnusedParameter.Local
      private static void DisplayHelp<T>([NotNull] ParserResult<T> result, IEnumerable<Error> errors)
      {
         if (result is null) throw new ArgumentNullException(nameof(result));

         var helpText = HelpText.AutoBuild(
            result,
            h =>
               {
                  // ReSharper disable StringLiteralTypo
                  h.AddPostOptionsLine("Use startRuleName = 'tokens' if GrammarName is a lexer grammar.");
                  h.AddPostOptionsLine("Omitting Input Filename makes Grun.Net read from stdin.");
                  // ReSharper restore StringLiteralTypo
                  return HelpText.DefaultParsingErrorsHandler(result, h);
               },
            e => e);

         Console.WriteLine(helpText);
      }

      #endregion
   }
}