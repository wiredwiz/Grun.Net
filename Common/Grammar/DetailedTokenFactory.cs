#region BSD 3-Clause License
// <copyright file="DetailedTokenFactory.cs" company="Edgerunner.org">
// Copyright 2022 Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2022, Thaddeus Ryker
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

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

// ReSharper disable TooManyArguments
namespace Org.Edgerunner.ANTLR4.Tools.Common.Grammar
{
   /// <summary>
   /// Class responsible for creating a <see cref="DetailedToken"/>.
   /// Implements the <see cref="Antlr4.Runtime.ITokenFactory" />
   /// </summary>
   /// <seealso cref="Antlr4.Runtime.ITokenFactory" />
   public class DetailedTokenFactory : ITokenFactory
   {
      /// <summary>
      /// The default static instance factory.
      /// </summary>
      public static readonly ITokenFactory Instance = new DetailedTokenFactory();

      IToken ITokenFactory.Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
      {
         return Create(source, type, text, channel, start, stop, line, charPositionInLine);
      }

      IToken ITokenFactory.Create(int type, string text)
      {
         return Create(type, text);
      }

      /// <summary>
      /// Creates the specified type.
      /// </summary>
      /// <param name="type">The type.</param>
      /// <param name="text">The text.</param>
      /// <returns>A new DetailedToken.</returns>
      public virtual DetailedToken Create(int type, string text) => new DetailedToken(type, text);

      /// <summary>
      /// Creates the specified source.
      /// </summary>
      /// <param name="source">The source of the token.</param>
      /// <param name="type">The token type.</param>
      /// <param name="text">The token text.</param>
      /// <param name="channel">The token channel.</param>
      /// <param name="start">The token start.</param>
      /// <param name="stop">The token stop.</param>
      /// <param name="line">The token line.</param>
      /// <param name="charPositionInLine">The character position in line.</param>
      /// <returns>A new DetailedToken instance.</returns>
      public DetailedToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
      {
         DetailedToken token =
            new DetailedToken(source, type, channel, start, stop) { Line = line, Column = charPositionInLine };
         if (text != null)
            token.Text = text;
         else if (source.Item2 != null)
            token.Text = source.Item2.GetText(Interval.Of(start, stop));
         if (source.Item1 is IRecognizer recognizer)
            token.TypeName = token.Type > -1 ? recognizer.Vocabulary.GetDisplayName(token.Type) : string.Empty;
         return token;
      }
   }
}