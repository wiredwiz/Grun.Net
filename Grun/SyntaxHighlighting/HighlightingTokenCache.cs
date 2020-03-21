#region BSD 3-Clause License
// <copyright file="HighlightingTokenCache.cs" company="Edgerunner.org">
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

using System.Collections.Generic;

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun
{
   public class HighlightingTokenCache
   {
      private readonly Dictionary<int, Dictionary<int, int>> _KnownTokens;

      public HighlightingTokenCache()
      {
         _KnownTokens = new Dictionary<int, Dictionary<int, int>>();
      }

      public bool IsKnown(SyntaxToken token)
      {
         if (_KnownTokens.TryGetValue(token.LineNumber, out var lineCache))
            if (lineCache.TryGetValue(token.ColumnPosition, out var hash))
               if (hash == token.GetHashCode())
                  return true;

         return false;
      }

      public void RegisterToken(SyntaxToken token)
      {
         if (_KnownTokens.TryGetValue(token.LineNumber, out var lineCache))
            lineCache[token.ColumnPosition] = token.GetHashCode();
         else
            _KnownTokens[token.LineNumber] = new Dictionary<int, int> { { token.ColumnPosition, token.GetHashCode() } };
      }

      public void FlushTokensForLine(int lineNumber)
      {
         if (_KnownTokens.TryGetValue(lineNumber, out var lineCache))
            lineCache.Clear();
      }
   }
}