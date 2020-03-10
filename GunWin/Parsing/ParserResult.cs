#region BSD 3-Clause License
// <copyright file="ParserResult.cs" company="Edgerunner.org">
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

using System.Collections.Generic;

using Antlr4.Runtime;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar.Errors;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Parsing
{
   /// <summary>
   /// Struct that represents a given result of parsing
   /// </summary>
   public struct ParserResult
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ParserResult"/> struct.
      /// </summary>
      /// <param name="tokens">The tokens.</param>
      /// <param name="ruleContext">The rule context.</param>
      /// <param name="ruleName">Name of the rule.</param>
      /// <param name="errors">The errors.</param>
      // ReSharper disable once TooManyDependencies
      public ParserResult(IList<TokenViewModel> tokens, ParserRuleContext ruleContext, string ruleName, List<ParseMessage> errors)
      {
         Tokens = tokens;
         RuleContext = ruleContext;
         RuleName = ruleName;
         Errors = errors;
      }

      /// <summary>
      /// Gets the parse tokens.
      /// </summary>
      /// <value>The parse tokens.</value>
      public IList<TokenViewModel> Tokens { get; }

      /// <summary>
      /// Gets the parser rule context.
      /// </summary>
      /// <value>The parser rule context.</value>
      public ParserRuleContext RuleContext { get; }

      /// <summary>
      /// Gets the name of the rule that was parsed.
      /// </summary>
      /// <value>The name of the parser rule.</value>
      public string RuleName { get; }

      /// <summary>
      /// Gets the errors that resulted from parsing.
      /// </summary>
      /// <value>The errors.</value>
      public List<ParseMessage> Errors { get; }
   }
}