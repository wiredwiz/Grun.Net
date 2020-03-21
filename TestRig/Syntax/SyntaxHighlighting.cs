#region BSD 3-Clause License

// <copyright file="SyntaxHighlighting.cs" company="Edgerunner.org">
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

using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Syntax
{
   public static class SyntaxHighlighting
   {
      /// <summary>
      ///    Attempts to load a the syntax highlighting guide from path for the specified grammar.
      /// </summary>
      /// <param name="grammar">The grammar to load a guide for.</param>
      /// <param name="scanner">The scanner to use.</param>
      /// <param name="loader">The loader to use.</param>
      /// <param name="searchPath">The search path.</param>
      /// <returns>A new <see cref="Tuple{ISyntaxHighlightingGuide, SyntaxHighlightingGuideReference}"/> or <see langword="null"/>.</returns>
      /// <exception cref="T:System.ArgumentNullException">
      ///    <paramref name="grammar" />
      ///    or
      ///    <paramref name="scanner" />
      ///    or
      ///    <paramref name="loader" />
      ///    or
      ///    <paramref name="searchPath" /> are <see langword="null" /> or empty.
      /// </exception>
      /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The assembly path is not a valid assembly.</exception>
      public static Tuple<SyntaxHighlightingGuideReference, ISyntaxHighlightingGuide> LoadSyntaxGuideFromPath(
         [NotNull] GrammarReference grammar,
         [NotNull] Scanner scanner,
         [NotNull] Loader loader,
         [NotNull] string searchPath)
      {
         if (grammar == null)
            throw new ArgumentNullException(nameof(grammar));

         if (scanner == null)
            throw new ArgumentNullException(nameof(scanner));

         if (loader == null)
            throw new ArgumentNullException(nameof(loader));

         if (string.IsNullOrEmpty(searchPath))
            throw new ArgumentNullException(nameof(searchPath));

         var guideReferences = scanner.LocateAllSyntaxGuides(searchPath);
         foreach (var reference in guideReferences)
         {
            var guide = loader.LoadSyntaxGuide(reference);
            if (guide != null && guide.GrammarName == grammar.GrammarName)
               return new Tuple<SyntaxHighlightingGuideReference, ISyntaxHighlightingGuide>(reference, guide);
         }

         return null;
      }
   }
}