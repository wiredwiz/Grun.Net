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

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun
{
   /// <summary>
   /// Class that represents command line options.
   /// </summary>
   [SuppressMessage("ReSharper", "StyleCop.SA1600", Justification = "Option attributes already describe them well enough")]
   public class Options
   {
      [Value(0, MetaName = "Grammar Name", HelpText = "ANTLR grammar to load", Required = true)]
      public string GrammarName { get; set; }

      [Value(1, MetaName = "Rule Name", HelpText = "ANTLR grammar rule to use", Required = true)]
      public string RuleName { get; set; }

      [Option("tokens", Required = false, HelpText = "Display list of grammar tokens.")]
      public bool Tokens { get; set; }

      [Option("tree", Required = false, HelpText = "Display a Lisp-style parse tree.")]
      public bool Tree { get; set; }

      [Value(2, MetaName = "Input Filename", HelpText = "File name to parse", Required = false)]
      public string FileName { get; set; }

      [Option("trace", Required = false, HelpText = "Trace grammar parsing")]
      public bool Trace { get; set; }

      [Option("gui", Required = false, HelpText = "Display parse gui")]
      public bool Gui { get; set; }

      [Option("SLL", Required = false, HelpText = "Parse using SLL prediction mode")]
      public bool Sll { get; set; }

      [Option("diagnostics", Required = false, HelpText = "Parse with diagnostics")]
      public bool Diagnostics { get; set; }

      [Option("encoding", Required = false, HelpText = "Encoding type to use")]
      public string EncodingName { get; set; }

      [Option("svg", Required = false, HelpText = "Writes parse tree graph to a scalable vector graphics file with the specified name.")]
      public string SvgFileName { get; set; }
   }
}