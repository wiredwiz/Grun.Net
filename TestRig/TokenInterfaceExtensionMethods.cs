#region BSD 3-Clause License
// <copyright file="TokenInterfaceExtensionMethods.cs" company="Edgerunner.org">
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

using Antlr4.Runtime;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing
{
   /// <summary>
   /// Class containing extension methods for the token interface.
   /// </summary>
   public static class TokenInterfaceExtensionMethods
   {
      /// <summary>
      /// Gets the place within the source representing the end of the token.
      /// </summary>
      /// <param name="token">The token.</param>
      /// <returns>A new <see cref="Place"/>.</returns>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="token"/> is <see langword="null"/></exception>
      public static Place GetEndPlace([NotNull] this IToken token)
      {
         if (token is null)
            throw new ArgumentNullException(nameof(token));

         var positionShift = 0;
         var lineShift = 0;
         var lineTerminationMode = false;

         foreach (char item in token.Text)
         {
            if (item == '\r' || item == '\n')
            {
               lineTerminationMode = true;
               positionShift++;
            }
            else
            {
               if (lineTerminationMode)
               {
                  lineShift++;
                  positionShift = 0;
                  lineTerminationMode = false;
               }
               else
                  positionShift++;
            }
         }

         return new Place(token.Line + lineShift, (lineShift == 0) ? token.Column + positionShift - 1 : positionShift);
      }
   }
}