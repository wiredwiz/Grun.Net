#region BSD 3-Clause License

// <copyright file="GrammarReference.cs" company="Edgerunner.org">
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

using JetBrains.Annotations;

namespace Org.Edgerunner.ANTLR4.Tools.Testing
{
   /// <summary>
   ///    Class that represents a reference to an ANTLR grammar.
   /// </summary>
   public class GrammarReference
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="GrammarReference" /> class.
      /// </summary>
      /// <param name="assemblyPath">The assembly path.</param>
      /// <param name="grammarName">Name of the grammar.</param>
      /// <param name="lexerType">Type of the lexer.</param>
      /// <param name="parserType">Type of the parser.</param>
      /// <exception cref="ArgumentNullException">
      ///    assemblyPath
      ///    or
      ///    grammarName
      ///    or
      ///    lexerType was <see langword="null" /> or empty.
      /// </exception>
      // ReSharper disable once TooManyDependencies
      public GrammarReference(
         [NotNull] string assemblyPath,
         [NotNull] string grammarName,
         [NotNull] Type lexerType,
         [CanBeNull] Type parserType)
      {
         AssemblyPath = assemblyPath ?? throw new ArgumentNullException(nameof(assemblyPath));
         GrammarName = grammarName ?? throw new ArgumentNullException(nameof(grammarName));
         Lexer = lexerType ?? throw new ArgumentNullException(nameof(lexerType));
         Parser = parserType;
      }

      #endregion

      /// <summary>
      ///    Gets the assembly path.
      /// </summary>
      /// <value>The assembly path.</value>
      [NotNull]
      public string AssemblyPath { get; }

      /// <summary>
      ///    Gets the name of the grammar.
      /// </summary>
      /// <value>The name of the grammar.</value>
      [NotNull]
      public string GrammarName { get; }

      /// <summary>
      ///    Gets the grammar's lexer type.
      /// </summary>
      /// <value>The lexer type.</value>
      /// <see cref="Antlr4.Runtime.Lexer" />
      [NotNull]
      public Type Lexer { get; }

      /// <summary>
      ///    Gets the grammar's parser type.
      /// </summary>
      /// <value>The parser type.</value>
      /// <see cref="Antlr4.Runtime.Parser" />
      [CanBeNull]
      public Type Parser { get; }
   }
}