#region BSD 3-Clause License
// <copyright file="PlaceExtensions.cs" company="Edgerunner.org">
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

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Extensions
{
   /// <summary>
   /// Class containing extension methods for the Place struct.
   /// </summary>
   public static class PlaceExtensions
   {
      /// <summary>
      /// Converts to a token <see cref="Place"/> to a <see cref="FastColoredTextBoxNS.Place"/> place.
      /// </summary>
      /// <param name="place">The place to convert.</param>
      /// <returns>A new <see cref="FastColoredTextBoxNS.Place"/>.</returns>
      /// <remarks>The Fast Colored Text Box placement begins line indexes at index 0 so we must reduce the grammar placement by 1.</remarks>
      // ReSharper disable once IdentifierTypo
      public static FastColoredTextBoxNS.Place ConvertToFctbPlace(this Place place)
      {
         return new FastColoredTextBoxNS.Place(place.Position, place.Line - 1);
      }

      /// <summary>
      /// Determines whether this place occurs within the bounds of the specified token.
      /// </summary>
      /// <param name="place">The place to evaluate.</param>
      /// <param name="token">The token.</param>
      /// <returns><c>true</c> if within the bounds; otherwise, <c>false</c>.</returns>
      public static bool IsWithinTokenBounds(this Place place, SyntaxToken token)
      {
         if (place.Line != token.LineNumber)
            return false;

         if (place.Position + 1 < token.ColumnPosition)
            return false;

         if (token.EndingLineNumber > place.Line)
            return true;

         return place.Position < token.EndingColumnPosition;
      }
   }
}