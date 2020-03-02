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
using System.Reflection;
using Antlr4.Runtime;
using CommandLine;
using Parser = CommandLine.Parser;

namespace Org.Edgerunner.ANTLR.Tools.Testing
{
   /// <summary>
   /// Class that represents the entry point into the program.
   /// </summary>
   internal class Program
   {
      #region Static

      private static void Main(string[] args)
      {
         Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                      {
                         if (o.Tokens)
                         {
                            var workingDirectory = Environment.CurrentDirectory;
                            var scanner = new Grammar.Scanner();
                            var loader = new Grammar.Loader();
                            var grammar = scanner.LocateGrammar(workingDirectory, o.GrammarName);
                            if (grammar == null)
                            {
                               Console.WriteLine(
                                                 $"Could not find an assembly that defines grammar \"{o.GrammarName}\" in the current working directory");
                               return;
                            }

                            string line = null;
                            string data = string.Empty;
                            Console.WriteLine("Enter text to be parsed:");
                            while ((line = Console.ReadLine()) != null)
                            {
                               data += line + Environment.NewLine;
                            }

                            var inputStream = new AntlrInputStream(data);
                            var lexer = loader.LoadLexer(grammar, inputStream);
                            var commonTokenStream = new CommonTokenStream(lexer);
                            commonTokenStream.Fill();
                            var tokens = commonTokenStream.GetTokens();
                            foreach (var token in tokens)
                               Console.WriteLine(token.ToString());
                         }
                         else if (o.Diagnostics)
                            Console.WriteLine("This option is not yet supported.");
                         else if (o.Trace)
                            Console.WriteLine("This option is not yet supported.");
                         else if (o.Gui)
                            Console.WriteLine("This option is not yet supported.");
                         else if (string.IsNullOrEmpty(o.EncodingName))
                            Console.WriteLine("This option is not yet supported.");
                         else if (string.IsNullOrEmpty(o.PostScript))
                            Console.WriteLine("This option is not yet supported.");
                         else if (string.IsNullOrEmpty(o.FileNames))
                            Console.WriteLine("This option is not yet supported.");
                      });
      }

      #endregion
   }
}