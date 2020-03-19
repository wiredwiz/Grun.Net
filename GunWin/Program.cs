#region BSD 3-Clause License

// <copyright file="Program.cs" company="Edgerunner.org">
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
using System.IO;
using System.Text;
using System.Windows.Forms;

using CommandLine;

using Org.Edgerunner.ANTLR4.Tools.Testing.Exceptions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Properties;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      /// <param name="args">The arguments.</param>
      [STAThread]
      private static void Main(string[] args)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         try
         {
            var grammarName = string.Empty;
            var grammarRule = string.Empty;
            var visualAnalyzer = new VisualAnalyzer();

            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed(o =>
                     {
                        if (!string.IsNullOrEmpty(o.GrammarName))
                           grammarName = o.GrammarName;

                        if (!string.IsNullOrEmpty(o.RuleName))
                           grammarRule = o.RuleName;

                        if (!string.IsNullOrEmpty(o.FileName))
                        {
                           var encodingToUse = !string.IsNullOrEmpty(o.EncodingName) ? Encoding.GetEncoding(o.EncodingName) : Encoding.Default;
                           using (var reader = new StreamReader(o.FileName, encodingToUse))
                              visualAnalyzer.SetSourceCode(reader.ReadToEnd());
                        }

                        if (o.Diagnostics) visualAnalyzer.ParseWithDiagnostics = true;
                        if (o.Trace) visualAnalyzer.ParseWithTracing = true;
                        if (o.Sll) visualAnalyzer.ParseWithSllMode = true;
                     });

            var workingDirectory = Environment.CurrentDirectory;
            var scanner = new Scanner();

            if (!string.IsNullOrEmpty(grammarName))
            {
               var grammar = scanner.LocateGrammar(workingDirectory, grammarName);
               if (grammar == null)
                  throw new GrammarException(
                                             $"Could not find an assembly that defines grammar \"{grammarName}\" in the current working directory");

               visualAnalyzer.SetGrammar(grammar);
            }

            if (!string.IsNullOrEmpty(grammarRule))
               visualAnalyzer.SetDefaultParserRule(grammarRule);

            Application.Run(visualAnalyzer);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
