#region BSD 3-Clause License

// <copyright file="Scanner.cs" company="Edgerunner.org">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Antlr4.Runtime;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Testing.Exceptions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Types;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grammar
{
   /// <summary>
   ///    Class that represents an ANTLR grammar scanner.
   /// </summary>
   public class Scanner
   {
      /// <summary>
      ///    Finds the ANTLR grammar lexers in the supplied assembly.
      /// </summary>
      /// <param name="assembly">The assembly to search.</param>
      /// <returns>An instance of <see cref="IEnumerable{LexerType}" />.</returns>
      /// <exception cref="ArgumentNullException">Assembly is null</exception>
      /// <exception cref="T:System.Reflection.ReflectionTypeLoadException">
      ///    The assembly contains one or more types that cannot
      ///    be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types" /> property
      ///    of this exception contains a <see cref="T:System.Type" /> object for each type that was loaded and null for each
      ///    type that could not be loaded, while the
      ///    <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions" /> property contains an exception for
      ///    each type that could not be loaded.
      /// </exception>
      public IEnumerable<LexerType> FindGrammarLexersInAssembly([NotNull] Assembly assembly)
      {
         if (assembly is null)
            throw new ArgumentNullException(nameof(assembly));

         var result = new List<LexerType>();
         var types = assembly.GetTypes().Where(t => typeof(Lexer).IsAssignableFrom(t));

         foreach (var type in types)
            if (type.Name.EndsWith("Lexer"))
               // ReSharper disable once ExceptionNotDocumented
               result.Add(new LexerType(type));

         return result;
      }

      /// <summary>
      ///    Finds the ANTLR grammar parsers in the supplied assembly.
      /// </summary>
      /// <param name="assembly">The assembly to search.</param>
      /// <returns>An instance of <see cref="IEnumerable{ParserType}" />.</returns>
      /// <exception cref="ArgumentNullException">Assembly is null</exception>
      /// <exception cref="T:System.Reflection.ReflectionTypeLoadException">
      ///    The assembly contains one or more types that cannot
      ///    be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types" /> property
      ///    of this exception contains a <see cref="T:System.Type" /> object for each type that was loaded and null for each
      ///    type that could not be loaded, while the
      ///    <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions" /> property contains an exception for
      ///    each type that could not be loaded.
      /// </exception>
      public IEnumerable<ParserType> FindGrammarParsersInAssembly([NotNull] Assembly assembly)
      {
         if (assembly is null)
            throw new ArgumentNullException(nameof(assembly));

         var result = new List<ParserType>();
         var types = assembly.GetTypes().Where(t => typeof(Parser).IsAssignableFrom(t));

         foreach (var type in types)
            if (type.Name.EndsWith("Parser"))
               // ReSharper disable once ExceptionNotDocumented
               result.Add(new ParserType(type));

         return result;
      }

      /// <summary>
      ///    Finds all ISyntaxGuide implementations in the supplied assembly.
      /// </summary>
      /// <param name="assembly">The assembly to search.</param>
      /// <returns>An instance of <see cref="IEnumerable{Type}" />.</returns>
      /// <exception cref="ArgumentNullException">Assembly is null</exception>
      /// <exception cref="T:System.Reflection.ReflectionTypeLoadException">
      ///    The assembly contains one or more types that cannot
      ///    be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types" /> property
      ///    of this exception contains a <see cref="T:System.Type" /> object for each type that was loaded and null for each
      ///    type that could not be loaded, while the
      ///    <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions" /> property contains an exception for
      ///    each type that could not be loaded.
      /// </exception>
      public IEnumerable<Type> FindSyntaxGuidesInAssembly([NotNull] Assembly assembly)
      {
         if (assembly is null)
            throw new ArgumentNullException(nameof(assembly));

         var result = new List<Type>();
         var types = assembly.GetTypes().Where(t => typeof(ISyntaxHighlightingGuide).IsAssignableFrom(t));

         foreach (var type in types)
            // ReSharper disable once ExceptionNotDocumented
            result.Add(type);

         return result;
      }

      /// <summary>
      ///    Searches for all ANTLR grammars in the specified path and returns an enumeration of those found.
      /// </summary>
      /// <param name="path">The filePath to search.</param>
      /// <returns>A new <see cref="IEnumerable{GrammarReference}" />.</returns>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="path" /> is <see langword="null" /></exception>
      public IEnumerable<GrammarReference> LocateAllGrammars([NotNull] string path)
      {
         if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path));

         return FindGrammars(path);
      }

      /// <summary>
      ///    Searches for all ANTLR grammars in the specified file and returns an enumeration of those found.
      /// </summary>
      /// <param name="filePath">The file to search.</param>
      /// <returns>A new <see cref="IEnumerable{GrammarReference}" />.</returns>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="filePath" /> is <see langword="null" /></exception>
      public IEnumerable<GrammarReference> LocateAllGrammarsInFile([NotNull] string filePath)
      {
         if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException(nameof(filePath));

         return FindGrammarsInFile(filePath);
      }

      /// <summary>
      ///    Searches for the named ANTLR grammar in the specified filePath and returns a reference if found.
      /// </summary>
      /// <param name="path">The filePath to search.</param>
      /// <param name="name">The name of the grammar.</param>
      /// <returns>A new <see cref="GrammarReference" /> or <see langword="null" /> if not found.</returns>
      /// <exception cref="T:Org.Edgerunner.ANTLR4.Tools.Testing.Exceptions.GrammarConflictException">
      ///    More than one assembly defines the specified grammar.
      /// </exception>
      /// <exception cref="T:System.ArgumentNullException">
      ///    <paramref name="path" /> or <paramref name="name" /> is
      ///    <see langword="null" />
      /// </exception>
      public GrammarReference LocateGrammar([NotNull] string path, [NotNull] string name)
      {
         if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path));
         if (name is null)
            throw new ArgumentNullException(nameof(name));

         var grammars = FindGrammars(path, name);
         switch (grammars.Count)
         {
            case 0:
               return null;
            case 1:
               return grammars.First();
            default:
               throw new GrammarConflictException(
                                                  $"More than one assembly in filePath \"{path}\" contains a definition for a grammar named \"{name}\"");
         }
      }

      /// <summary>
      /// Gets the parser rules for the specified grammar parser.
      /// </summary>
      /// <param name="parserType">The the grammar parser type.</param>
      /// <returns>An <see cref="IEnumerable{String}"/> containing the parser rules (if any).</returns>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="parserType"/> is <see langword="null"/></exception>
      public IEnumerable<string> GetParserRulesForGrammarParser([NotNull] Type parserType)
      {
         if (parserType is null) throw new ArgumentNullException(nameof(parserType));

         var methods = parserType.GetMethods()
            .Where(m => m.GetCustomAttributes(typeof(RuleVersionAttribute), false).Length > 0);
         return from method in methods select method.Name;
      }

      private List<GrammarReference> FindGrammars([NotNull] string path, string name = null)
      {
         var di = new DirectoryInfo(path);
         var files = di.GetFiles("*.dll");
         var results = new List<GrammarReference>();

         foreach (var file in files)
         {
            var assembly = Assembly.Load(File.ReadAllBytes(file.FullName));

            // We make parsers an explicit list to avoid multiple enumerations
            var parsers = FindGrammarParsersInAssembly(assembly).ToList();
            var lexers = FindGrammarLexersInAssembly(assembly);
            IEnumerable<LexerType> matches;
            if (!string.IsNullOrEmpty(name))
               matches = from lexer in lexers
                         where lexer.GrammarName == name
                         select lexer;
            else
               matches = lexers;

            foreach (var lexer in matches)
            {
               var parser = (from candidate in parsers
                             where candidate.GrammarName == lexer.GrammarName
                             select candidate).FirstOrDefault();

               var rules = parser.ActualType == null
                              ? new List<string>()
                              : GetParserRulesForGrammarParser(parser.ActualType).ToList();
               var grammarRef = new GrammarReference(
                                                     file,
                                                     lexer.GrammarName,
                                                     lexer.ActualType,
                                                     parser.ActualType,
                                                     rules);
               results.Add(grammarRef);
            }
         }

         return results;
      }

      private List<GrammarReference> FindGrammarsInFile([NotNull] string filePath, string name = null)
      {
         var file = new FileInfo(filePath);
         var results = new List<GrammarReference>();

         var assembly = Assembly.Load(File.ReadAllBytes(file.FullName));

         // We make parsers an explicit list to avoid multiple enumerations
         var parsers = FindGrammarParsersInAssembly(assembly).ToList();
         var lexers = FindGrammarLexersInAssembly(assembly);
         IEnumerable<LexerType> matches;
         if (!string.IsNullOrEmpty(name))
            matches = from lexer in lexers
                      where lexer.GrammarName == name
                      select lexer;
         else
            matches = lexers;

         foreach (var lexer in matches)
         {
            ParserType parser;
            parser = (from candidate in parsers
                      where candidate.GrammarName == lexer.GrammarName
                      select candidate).FirstOrDefault();

            var rules = parser.ActualType == null
                              ? new List<string>()
                              : GetParserRulesForGrammarParser(parser.ActualType).ToList();
            var grammarRef = new GrammarReference(
                                                  file,
                                                  lexer.GrammarName,
                                                  lexer.ActualType,
                                                  parser.ActualType,
                                                  rules);
            results.Add(grammarRef);
         }

         return results;
      }

      /// <summary>
      /// Locates all syntax guides in the path.
      /// </summary>
      /// <param name="path">The path to search.</param>
      /// <returns>A new <see cref="List{SyntaxGuideReference}"/>.</returns>
      /// <exception cref="ArgumentNullException">path is null or empty.</exception>
      public List<SyntaxHighlightingGuideReference> LocateAllSyntaxGuides([NotNull] string path)
      {
         if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path));

         var di = new DirectoryInfo(path);
         var files = di.GetFiles("*.dll");
         var results = new List<SyntaxHighlightingGuideReference>();

         foreach (var file in files)
         {
            var assembly = Assembly.Load(File.ReadAllBytes(file.FullName));
            foreach (var guide in FindSyntaxGuidesInAssembly(assembly).ToList())
               results.Add(new SyntaxHighlightingGuideReference(guide, file.FullName));
         }

         return results;
      }
   }
}