#region BSD 3-Clause License
// <copyright file="GrammarReferenceExtensions.cs" company="Edgerunner.org">
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
using System.Reflection;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Syntax;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Extensions
{
   public static class GrammarReferenceExtensions
   {
      /// <summary>
      /// Attempts to load a syntax highlighting guide for the grammar.
      /// </summary>
      /// <param name="grammar">The grammar to use.</param>
      /// <returns>A new <see cref="Tuple{ISyntaxHighlightingGuide, SyntaxHighlightingGuideReference}"/> or <see langword="null"/>.</returns>
      /// <exception cref="ArgumentNullException"><paramref name="grammar"/> is <see langword="null"/>.</exception>
      /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The assembly path is not a valid assembly.</exception>
      public static Tuple<SyntaxHighlightingGuideReference, ISyntaxHighlightingGuide> LoadSyntaxHighlightingGuide([NotNull] this GrammarReference grammar)
      {
         if (grammar == null)
            throw new ArgumentNullException(nameof(grammar));

         var scanner = new Scanner();
         var loader = new Loader();

         // First try loading a guide from the target assembly's directory
         var pathRoot = Path.GetDirectoryName(grammar.AssemblyPath);
         Tuple<SyntaxHighlightingGuideReference, ISyntaxHighlightingGuide> guideResult = null;
         if (Directory.Exists(pathRoot))
         {
            guideResult = SyntaxHighlighting.LoadSyntaxGuideFromPath(grammar, scanner, loader, pathRoot);
            if (guideResult != null)
               return guideResult;
         }

         // Now try loading a guide from the Grun.Net Guides folder
         pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

         // ReSharper disable once AssignNullToNotNullAttribute
         pathRoot = Path.Combine(pathRoot, "Guides");
         if (Directory.Exists(pathRoot))
            guideResult = SyntaxHighlighting.LoadSyntaxGuideFromPath(grammar, scanner, loader, pathRoot);

         return guideResult;
      }
   }
}