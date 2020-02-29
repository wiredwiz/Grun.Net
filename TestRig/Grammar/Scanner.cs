#region BSD 3-Clause License
// <copyright file="Scanner.cs" company="Edgerunner.org">
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
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR.Tools.Testing.Exceptions;

namespace Org.Edgerunner.ANTLR.Tools.Testing.Grammar
{
   /// <summary>
   /// Class that represents an ANTLR grammar scanner.
   /// </summary>
   public class Scanner
   {
      /// <summary>
      /// Searches for all ANTLR grammars in the specified path and returns an enumeration of those found.
      /// </summary>
      /// <param name="path">The path to search.</param>
      /// <returns>A new <see cref="IEnumerable{GrammarReference}"/>.</returns>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="path"/> is <see langword="null"/></exception>
      public IEnumerable<GrammarReference> LocateAllGrammars([NotNull] string path)
      {
         if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
         return FindGrammars(path);
      }

      /// <summary>
      /// Searches for the named ANTLR grammar in the specified path and returns a reference if found.
      /// </summary>
      /// <param name="path">The path to search.</param>
      /// <param name="name">The name of the grammar.</param>
      /// <returns>A new <see cref="GrammarReference" /> or <see langword="null" /> if not found.</returns>
      /// <exception cref="T:Org.Edgerunner.ANTLR.Tools.Testing.Exceptions.GrammarConflictException">
      /// More than one assembly defines the specified grammar.
      /// </exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="path"/> or <paramref name="name"/> is <see langword="null"/></exception>
      public GrammarReference LocateGrammar([NotNull] string path, [NotNull] string name)
      {
         if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
         if (name is null) throw new ArgumentNullException(nameof(name));

         var grammars = FindGrammars(path, name);
         switch (grammars.Count)
         {
            case 0:
               return null;
            case 1:
               return grammars.First();
            default:
               throw new GrammarConflictException(
                  $"More than one assembly in path \"{path}\" contains a definition for a grammar named \"{name}\"");
         }
      }

      private List<GrammarReference> FindGrammars([NotNull] string path, string name = null)
      {
         DirectoryInfo di = new DirectoryInfo(path);
         FileInfo[] files = di.GetFiles("*.dll");
         var results = new List<GrammarReference>();

         foreach (FileInfo file in files)
         {
            var assembly = Assembly.LoadFile(file.FullName);
            var grammars = FindGrammarsInAssembly(assembly);
            if (string.IsNullOrEmpty(name))
               foreach (var grammarName in grammars)
               {
                  results.Add(new GrammarReference(file.FullName, grammarName));
               }
            else if (grammars.Contains(name))
               results.Add(new GrammarReference(file.FullName, name));
         }

         return results;
      }

      private List<string> FindGrammarsInAssembly([NotNull] Assembly assembly)
      {
         if (assembly is null) throw new ArgumentNullException(nameof(assembly));

         var result = new List<string>();
         var types = assembly.GetTypes().Where(t => typeof(Antlr4.Runtime.Parser).IsAssignableFrom(t));

         foreach (Type type in types)
         {
            var workingName = type.Name;

            if (!workingName.EndsWith("Parser"))
               throw new GrammarException($"Found parser \"{workingName}\" with irregular name.  Expected parser name to end with \"Parser\"");

            workingName = workingName.Substring(0, workingName.Length - 6);
            result.Add(workingName);
         }

         return result;
      }
   }
}