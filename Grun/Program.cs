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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Antlr4.Runtime.Misc;
using Colorful;
using CommandLine;
using CommandLine.Text;

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.Layered;

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Graphing;
using Org.Edgerunner.ANTLR4.Tools.Graphing.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Configuration;
using Org.Edgerunner.ANTLR4.Tools.Testing.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grun.Properties;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grun.SyntaxHighlighting;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting;

using Console = Colorful.Console;
using Parser = CommandLine.Parser;

// ReSharper disable RedundantNameQualifier
namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun
{
   /// <summary>
   /// Class that represents the entry point into the program.
   /// </summary>
   internal class Program
   {
      private static Settings _Settings;

      private static HighlightingTokenCache _Cache = new HighlightingTokenCache();

      private static int _ScrollFadeCount = 0;

      #region Static

      [DllImport("kernel32.dll", EntryPoint = "SetConsoleMode", SetLastError = true,
          CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
      private static extern bool SetConsoleMode(int hConsoleHandle, int dwMode);

      [STAThread]
      // ReSharper disable once MethodTooLong
      private static void Main(string[] args)
      {
         try
         {
            LoadApplicationSettings();
            //if (_Settings.EnableConsoleSyntaxHighlighting)
            //{
            //   Console.BackgroundColor = _Settings.EditorBackgroundColor;
            //   Console.ForegroundColor = _Settings.EditorTextColor;
            //   Console.Clear();
            //}

            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);
            parserResult
                      .WithParsed(o =>
                         {
                            var options = Grammar.ParseOption.None;
                            var loadGui = false;
                            var showParseTree = false;
                            var writeSvg = false;
                            ISyntaxHighlightingGuide guide = null;

                            if (o.Tokens) options |= Grammar.ParseOption.Tokens;
                            if (o.Diagnostics) options |= Grammar.ParseOption.Diagnostics;
                            if (o.Trace) options |= Grammar.ParseOption.Trace;
                            if (o.Tree)
                            {
                               options |= Grammar.ParseOption.Tree;
                               showParseTree = true;
                            }

                            if (!string.IsNullOrEmpty(o.SvgFileName))
                            {
                               writeSvg = true;
                               options |= Grammar.ParseOption.Tree;
                            }

                            if (o.Sll) options |= Grammar.ParseOption.Sll;
                            if (o.Gui)
                            {
                               loadGui = true;
                               options |= Grammar.ParseOption.Tree;
                            }

                            var workingDirectory = Environment.CurrentDirectory;
                            var scanner = new Grammar.Scanner();

                            var grammar = scanner.LocateGrammar(workingDirectory, o.GrammarName);
                            if (grammar == null)
                            {
                               Console.WriteLine(Resources.GrammarNotFoundErrorMessage, o.GrammarName);
                               return;
                            }

                            //// To be used later once syntax highlighting for the console is enabled.
                            //var guideResult = grammar.LoadSyntaxHighlightingGuide();
                            //guide = guideResult != null ? guideResult.Item2 : new HeuristicSyntaxHighlightingGuide(_Settings);

                            string data;
                            var analyzer = new Analyzer();

                            if (!string.IsNullOrEmpty(o.FileName))
                            {
                               if (!File.Exists(o.FileName))
                               {
                                  Console.WriteLine(Resources.FileNotFoundErrorMessage, o.FileName);
                                  return;
                               }

                               var encodingToUse = !string.IsNullOrEmpty(o.EncodingName) ? Encoding.GetEncoding(o.EncodingName) : Encoding.Default;
                               using (var reader = new StreamReader(o.FileName, encodingToUse))
                                  data = reader.ReadToEnd();
                            }
                            else
                            {
                               var builder = new StringBuilder();
                               Console.WriteLine(Resources.ReadingFromStandardInputPromptMessage);
                               var currentLine = Console.CursorTop;
                               var keepReading = true;
                               while (keepReading)
                               {
                                  if (Console.KeyAvailable)
                                  {
                                     while (Console.KeyAvailable)
                                     {
                                        var typed = Console.ReadKey(true);

                                        if ((typed.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control
                                            && typed.Key == ConsoleKey.Z)
                                        {
                                           Console.Write("^Z");
                                           keepReading = false;
                                           break;
                                        }

                                        if (typed.Key == ConsoleKey.Enter)
                                        {
                                           if (Console.CursorTop == Console.BufferHeight - 1)
                                              _ScrollFadeCount++;
                                           Console.WriteLine();
                                           FillCurrentLineBackground();
                                           builder.Append("\r\n");
                                        }
                                        else if (typed.Key == ConsoleKey.Tab)
                                        {
                                           var spaces = new string(' ', _Settings.EditorTabLength);
                                           Console.Write(spaces);
                                           builder.Append(spaces);
                                        }
                                        else if (typed.Key == ConsoleKey.Backspace)
                                        {
                                           if (Console.CursorLeft <= 0)
                                              continue;

                                           Console.Write(typed.KeyChar);
                                           Console.Write(' ');
                                           Console.Write(typed.KeyChar);
                                           builder.Remove(builder.Length - 1, 1);
                                           _Cache.FlushTokensForLine(currentLine - (_ScrollFadeCount + 1));
                                        }
                                        else
                                        {
                                           Console.Write(typed.KeyChar);
                                           builder.Append(typed.KeyChar);
                                        }
                                     }

                                     //if (_Settings.EnableConsoleSyntaxHighlighting)
                                     //{
                                     //   analyzer.Tokenize(grammar, builder.ToString(), null);
                                     //   HighlightSyntaxInConsole(currentLine - (_ScrollFadeCount + 1), analyzer, guide);
                                     //}
                                  }
                               }

                               Console.WriteLine();
                               data = builder.ToString();
                            }

                            // If tokens are the only option we've received, we don't need to parse
                            if (options == Grammar.ParseOption.Tokens)
                            {
                               DisplayTokens(grammar, analyzer, data);
                               return;
                            }

                            // Now we attempt to parse, but still handle a lexer-only grammar.
                            if (grammar.Parser != null)
                            {
                               var grammarParser = analyzer.BuildParserWithOptions(grammar, data, options, null);
                               analyzer.ExecuteParsing(grammarParser, o.RuleName);

                               if (showParseTree)
                                  Console.WriteLine(analyzer.ParserContext.ToStringTree(grammarParser));

                               if (writeSvg)
                               {
                                  var rules = scanner.GetParserRulesForGrammarParser(grammar.Parser);
                                  var grapher = new ParseTreeGrapher()
                                  {
                                     BackgroundColor = _Settings.GraphNodeBackgroundColor.GetMsAglColor(),
                                     BorderColor = _Settings.GraphNodeBorderColor.GetMsAglColor(),
                                     TextColor = _Settings.GraphNodeTextColor.GetMsAglColor()
                                  };
                                  var graph = grapher.CreateGraph(analyzer.ParserContext, rules.ToList());
                                  graph.LayoutAlgorithmSettings = new SugiyamaLayoutSettings();
                                  GraphRenderer renderer = new GraphRenderer(graph);
                                  renderer.CalculateLayout();
                                  graph.EscapeNodesForSvg();
                                  SvgGraphWriter.Write(graph, o.SvgFileName, null, null, 4);
                               }
                            }
                            else
                            {
                               if (options.HasFlag(ParseOption.Tokens))
                                  DisplayTokens(grammar, analyzer, data);

                               if (showParseTree || writeSvg)
                                  Console.WriteLine(Resources.GrammarHasNoParserErrorMessage, grammar.GrammarName);
                               if (showParseTree)
                                  Console.WriteLine(Resources.UnableToDisplayParseTree);
                               if (writeSvg)
                                  Console.WriteLine(Resources.SvgWritingAbortedErrorMessage);
                            }

                            if (loadGui)
                               LoadGui(data, grammar, o.RuleName);
                         })
                      .WithNotParsed(errs => DisplayHelp(parserResult, errs));

#if DEBUG
            Console.WriteLine(Resources.PressAnyKeyMessage);
            Console.ReadKey();
#endif
         }
         // ReSharper disable once CatchAllClause
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
#if DEBUG
            Console.WriteLine(Resources.PressAnyKeyMessage);
            Console.ReadKey();
#endif
         }
      }

      private static void HighlightSyntaxInConsole(int lineOffset, Analyzer analyzer, ISyntaxHighlightingGuide guide)
      {
         if (analyzer == null)
            return;

         if (guide == null)
            return;

         var cursorRow = Console.CursorTop;
         var cursorColumn = Console.CursorLeft;
         foreach (var token in analyzer.SyntaxTokens)
         {
            if (!_Cache.IsKnown(token))
            {
               ColorToken(token, lineOffset, guide);
               _Cache.RegisterToken(token);
            }
         }

         Console.SetCursorPosition(cursorColumn, cursorRow);
      }

      private static void ColorToken(SyntaxToken token, int lineOffset, ISyntaxHighlightingGuide guide)
      {
         if (token.Channel != 0)
            return;

         if (token.DisplayText == "<EOF>")
            return;

         var startLine = token.Line + lineOffset;
         var endLine = token.EndingLineNumber + lineOffset;

         if (startLine < 0)
            if (endLine < 0)
               return;

         var index = 0;
         Console.ForegroundColor = guide.GetTokenForegroundColor(token);

         for (int ln = startLine; ln < endLine + 1; ln++)
         {
            for (int col = token.ColumnPosition; col < token.EndingColumnPosition + 1; col++)
            {
               Console.SetCursorPosition(col - 1, ln);
               Console.Write(token.DisplayText[index++]);
            }
         }

         Console.ForegroundColor = _Settings.EditorTextColor;
      }

      private static void FillCurrentLineBackground()
      {
         var cursorRow = Console.CursorTop;
         var cursorColumn = Console.CursorLeft;
         Console.SetCursorPosition(0, cursorRow);
         var filler = new string(' ', Console.BufferWidth);
         Console.Write(filler);
         Console.SetCursorPosition(cursorColumn, cursorRow);
      }

      private static void DisplayTokens(GrammarReference grammar, Analyzer analyzer, string data)
      {
         var tokens = analyzer.Tokenize(grammar, data, null);
         foreach (var token in tokens)
            Console.WriteLine(token.ToString());
      }

      private static void LoadGui(string data, GrammarReference grammar, string parserRule)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         var visualAnalyzer = new VisualAnalyzer();
         visualAnalyzer.SetSourceCode(data);
         visualAnalyzer.SetGrammar(grammar);
         if (grammar.Parser != null || !parserRule.Equals("tokens", StringComparison.InvariantCultureIgnoreCase))
            visualAnalyzer.SetDefaultParserRule(parserRule);
         Application.Run(visualAnalyzer);
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

      private static void LoadApplicationSettings()
      {
         _Settings = new Settings();
         var pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         if (pathRoot != null)
         {
            var configFile = Path.Combine(pathRoot, Resources.AppconfigFile);
            if (File.Exists(configFile))
            {
               _Settings.LoadFrom(configFile);
               return;
            }
         }

         _Settings.LoadDefaults();
      }

      private static int MakeTokenKey(SyntaxToken token)
      {
         return $"{token.Line}-{token.ColumnPosition}-{token.DisplayText}".GetHashCode();
      }

      #endregion
   }
}