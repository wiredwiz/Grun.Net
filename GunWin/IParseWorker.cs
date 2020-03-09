#region BSD 3-Clause License
// <copyright file="IParseWorker.cs" company="Edgerunner.org">
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

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   /// Interface representing an instance that does the work of parsing text using an ANTLR grammar.
   /// </summary>
   public interface IParseWorker
   {
      /// <summary>
      /// Occurs when parsing is finished.
      /// </summary>
      event EventHandler<ParserResult> ParsingFinished;

      /// <summary>
      /// Queues the specified text for parsing.
      /// </summary>
      /// <param name="grammar">The grammar to parse with.</param>
      /// <param name="parserRuleName">Name of the parser rule.</param>
      /// <param name="text">The text to parse.</param>
      /// <param name="options">The parser options.</param>
      void Parse([NotNull] GrammarReference grammar, [NotNull] string parserRuleName, string text, ParseOption options);

      /// <summary>
      /// Cancels all queued work.
      /// </summary>
      /// <returns><c>true</c> if there was existing work to cancel, <c>false</c> otherwise.</returns>
      bool CancelWork();
   }
}