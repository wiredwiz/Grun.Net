#region BSD 3-Clause License
// <copyright file="Loader.cs" company="Edgerunner.org">
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
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Antlr4.Runtime;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common;
using Org.Edgerunner.ANTLR4.Tools.Common.Editor;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grammar
{
   /// <summary>
   /// Class that represents an ANTLR grammar loader.
   /// </summary>
   public class Loader
   {
      /// <summary>
      /// Loads a Lexer instance for the referenced grammar.
      /// </summary>
      /// <param name="reference">The grammar reference.</param>
      /// <param name="stream">The character stream.</param>
      /// <returns>A new <see cref="Antlr4.Runtime.Lexer" />.</returns>
      /// <exception cref="ArgumentNullException"><paramref name="reference"/> or <paramref name="stream"/> are <see langword="null"/></exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="reference" /> is <see langword="null" /></exception>
      /// <exception cref="T:System.IO.FileLoadException">Grammar assembly could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The grammar assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The grammar assembly path is not a valid assembly.</exception>
      public Antlr4.Runtime.Lexer LoadLexer([NotNull] GrammarReference reference, [NotNull] ICharStream stream)
      {
         if (reference is null) throw new ArgumentNullException(nameof(reference));
         if (stream is null) throw new ArgumentNullException(nameof(stream));

         Assembly.Load(File.ReadAllBytes(reference.AssemblyPath));
         var lexer = Activator.CreateInstance(reference.Lexer, stream) as Lexer;
         return lexer;
      }

      /// <summary>
      /// Loads a Parser instance for the referenced grammar.
      /// </summary>
      /// <param name="reference">The grammar reference.</param>
      /// <param name="stream">The token stream.</param>
      /// <returns>A new <see cref="Antlr4.Runtime.Parser" />.</returns>
      /// <exception cref="ArgumentNullException"><paramref name="reference"/> or <paramref name="stream"/> are <see langword="null"/></exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="reference" /> is <see langword="null" /></exception>
      /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The assembly path is not a valid assembly.</exception>
      public Antlr4.Runtime.Parser LoadParser([NotNull] GrammarReference reference, [NotNull] ITokenStream stream)
      {
         if (reference is null) throw new ArgumentNullException(nameof(reference));
         if (stream is null) throw new ArgumentNullException(nameof(stream));

         Assembly.Load(File.ReadAllBytes(reference.AssemblyPath));
         var lexer = Activator.CreateInstance(reference.Parser, stream) as Parser;
         return lexer;
      }

      /// <summary>
      /// Loads an <see cref="IEditorGuide"/> instance for the referenced grammar.
      /// </summary>
      /// <param name="reference">The editor guide reference.</param>
      /// <returns>A new <see cref="IEditorGuide" />.</returns>
      /// <exception cref="ArgumentNullException"><paramref name="reference"/> is <see langword="null"/></exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="reference" /> is <see langword="null" /></exception>
      /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The assembly path is not a valid assembly.</exception>
      public IEditorGuide LoadEditorGuide([NotNull] EditorGuideReference reference)
      {
         if (reference is null) throw new ArgumentNullException(nameof(reference));

         Assembly.Load(File.ReadAllBytes(reference.AssemblyPath));
         var guide = Activator.CreateInstance(reference.GuideType) as IEditorGuide;
         return guide;
      }

      /// <summary>
      /// Loads all editor guides.
      /// </summary>
      /// <param name="references">The references to load.</param>
      /// <returns>An <see cref="IEnumerable{IEditorGuide}"/> instance.</returns>
      /// <exception cref="ArgumentNullException">references is null.</exception>
      /// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
      /// <exception cref="T:System.IO.FileNotFoundException">The assembly path is an empty string ("") or does not exist.</exception>
      /// <exception cref="T:System.BadImageFormatException">The assembly path is not a valid assembly.</exception>
      public IEnumerable<IEditorGuide> LoadAllEditorGuides([NotNull] IEnumerable<EditorGuideReference> references)
      {
         if (references == null)
            throw new ArgumentNullException(nameof(references));

         var results = new List<IEditorGuide>();

         foreach (var guideReference in references)
            results.Add(LoadEditorGuide(guideReference));

         return results;
      }
   }
}