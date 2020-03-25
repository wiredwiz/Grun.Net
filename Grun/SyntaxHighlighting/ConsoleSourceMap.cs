#region BSD 3-Clause License
// <copyright file="ConsoleSourceMap.cs" company="Edgerunner.org">
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

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun.SyntaxHighlighting
{
   public class ConsoleSourceMap : IConsoleSourceMap
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ConsoleSourceMap"/> class.
      /// </summary>
      /// <param name="source">The source text to map.</param>
      /// <param name="consoleBufferWidth">Width of the console buffer.</param>
      /// <param name="consoleBufferHeight">Height of the console buffer.</param>
      /// <exception cref="ArgumentNullException"><paramref name="source"/> must not be null.</exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="consoleBufferWidth"/> and <paramref name="consoleBufferHeight"/> must be 1 or greater.</exception>
      public ConsoleSourceMap(string source, int consoleBufferWidth, int consoleBufferHeight)
      {
         if (consoleBufferWidth <= 1)
            throw new ArgumentOutOfRangeException(nameof(consoleBufferWidth));
         if (consoleBufferHeight <= 1)
            throw new ArgumentOutOfRangeException(nameof(consoleBufferHeight));
         Source = source ?? throw new ArgumentNullException(nameof(source));
         ConsoleBufferWidth = consoleBufferWidth;
         ConsoleBufferHeight = consoleBufferHeight;
         LineMap = new Dictionary<int, int>();
         CreateSourceMapData();
      }

      private void CreateSourceMapData()
      {
         var offset = 0;
         var sourceLines = Source.Split('\r', '\n');
         var start = sourceLines.Length - ConsoleBufferHeight;
         var lastLine = sourceLines.Length;
         for (int i = start; i < lastLine; i++)
         {
            var line = sourceLines[i];
            LineMap.Add(i + 1, i + offset);
            if (line.Length > ConsoleBufferWidth)
            {
               offset += line.Length / ConsoleBufferWidth;
               //offset += (int)Math.Truncate((double)(line.Length / ConsoleBufferWidth));
               if (line.Length % ConsoleBufferWidth == 0)
                  offset--;
            }
         } 
      }

      private Dictionary<int, int> LineMap { get; }

      /// <summary>
      /// Gets the source text.
      /// </summary>
      /// <value>The source text.</value>
      public string Source { get; }

      /// <summary>
      /// Gets the width of the console buffer.
      /// </summary>
      /// <value>The width of the console buffer.</value>
      public int ConsoleBufferWidth { get; }

      /// <summary>
      /// Gets the height of the console buffer.
      /// </summary>
      /// <value>The height of the console buffer.</value>
      public int ConsoleBufferHeight { get; }

      /// <inheritdoc/>
      /// <exception cref="ArgumentOutOfRangeException">
      /// line
      /// or
      /// column
      /// </exception>
      public Place TranslateSourcePositionToConsole(int line, int column)
      {
         if (line <= 1)
            throw new ArgumentOutOfRangeException(nameof(line));
         if (column <= 1)
            throw new ArgumentOutOfRangeException(nameof(column));

         if (!LineMap.TryGetValue(line, out var newLine))
            return Place.Empty;

         var newColumn = (column % ConsoleBufferWidth) - 1;

         return new Place(newLine, newColumn);
      }
   }
}