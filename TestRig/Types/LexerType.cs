#region BSD 3-Clause License
// <copyright file="LexerType.cs" company="Edgerunner.org">
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
using Antlr4.Runtime;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR.Tools.Testing.Exceptions;

namespace Org.Edgerunner.ANTLR.Tools.Testing.Types
{
   public struct LexerType
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LexerType"/> struct.
      /// </summary>
      /// <param name="type">The type.</param>
      /// <exception cref="GrammarException">Type does not appear to be a valid ANTLR lexer.</exception>
      public LexerType(Type type)
      {
         // ReSharper disable once StyleCop.SA1305
         var isParser = typeof(Lexer).IsAssignableFrom(type);
         if (!isParser || !type.Name.EndsWith("Lexer"))
            throw new
               GrammarException($"Type \"{type.FullName}\" does not appear to be a valid ANTLR exer.");

         ActualType = type;
         GrammarName = ActualType.Name.Substring(0, ActualType.Name.Length - 5);
      }

      /// <summary>
      /// Gets the actual type of the ANTLR parser type.
      /// </summary>
      /// <value>The <see cref="Type"/>.</value>
      [NotNull]
      public Type ActualType { get; }

      /// <summary>
      /// Gets the name of the grammar that the lexer is for.
      /// </summary>
      /// <value>The name of the grammar.</value>
      [NotNull]
      public string GrammarName { get; }
   }
}