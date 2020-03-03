#region BSD 3-Clause License
// <copyright file="ParseOption.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.ANTLR.Tools.Testing.Grammar
{
   /// <summary>
   /// Enumeration that defines parsing options
   /// </summary>
   [Flags]
   public enum ParseOption
   {
      /// <summary>
      /// Indicates no options.
      /// </summary>
      None = 0,

      /// <summary>
      /// Indicates tracing of the parser rules should be performed while parsing.
      /// </summary>
      Trace = 1,

      /// <summary>
      /// Indicates parsing should be performed using "Simple Left-to-right, Leftmost derivation" prediction mode.
      /// </summary>
      Diagnostics = 2,

      /// <summary>
      /// Indicates parsing should preserve the list of lexer tokens.
      /// </summary>
      Tokens = 4,

      /// <summary>
      /// Indicates that parsing should display the list of tokens in the standard output.
      /// </summary>
      DisplayTokens = 8,

      /// <summary>
      /// Indicates a parser tree should be constructed during parsing.
      /// </summary>
      Tree = 16,

      /// <summary>
      /// Indicates parsing should be performed using "Left-to-right, Leftmost derivation with exact ambiguity detection" prediction mode.
      /// </summary>
      Sll = 32
   }
}