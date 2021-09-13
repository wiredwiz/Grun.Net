#region BSD 3-Clause License
// <copyright file="Options.cs" company="Edgerunner.org">
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

using System.Diagnostics.CodeAnalysis;

using CommandLine;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   /// Class that represents command line options.
   /// </summary>
   [SuppressMessage("ReSharper", "StyleCop.SA1600", Justification = "Option attributes already describe them well enough")]
   public class Options
   {
      [Option("grammar", HelpText = "ANTLR grammar to load", Required = false)]
      public string GrammarName { get; set; }

      [Option("rule", HelpText = "ANTLR grammar rule to use", Required = false)]
      public string RuleName { get; set; }

      [Option("file", HelpText = "File name to parse", Required = false)]
      public string FileName { get; set; }

      [Option("trace", HelpText = "Trace grammar parsing", Required = false)]
      public bool Trace { get; set; }

      [Option("diagnostics", HelpText = "Parse with diagnostics", Required = false)]
      public bool Diagnostics { get; set; }

      [Option("SLL", HelpText = "Parse using SLL prediction mode", Required = false)]
      public bool Sll { get; set; }

      [Option("encoding", HelpText = "Encoding type to use", Required = false)]
      public string EncodingName { get; set; }
   }
}