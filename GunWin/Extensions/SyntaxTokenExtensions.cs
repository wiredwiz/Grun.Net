﻿#region BSD 3-Clause License
// <copyright file="SyntaxTokenExtensions.cs" company="Edgerunner.org">
// Copyright 2021 Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2021, Thaddeus Ryker
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

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Extensions
{
   /// <summary>
   /// Class containing extension methods for the SyntaxToken class.
   /// </summary>
   public static class SyntaxTokenExtensions
   {
      /// <summary>
      /// Determines whether this SyntaxToken contains the specified source selection.
      /// </summary>
      /// <param name="token">The syntax token.</param>
      /// <param name="selectionStart">The source selection start.</param>
      /// <param name="selectionEnd">The source selection end.</param>
      /// <returns><c>true</c> if token contains the specified source selection; otherwise, <c>false</c>.</returns>
      public static bool ContainsSourceSelection(this SyntaxToken token, Place selectionStart, Place selectionEnd)
      {
         if (token.LineNumber > selectionStart.Line)
            return false;
         if (token.EndingLineNumber < selectionEnd.Line)
            return false;
         if (token.LineNumber == selectionStart.Line && token.ColumnPosition > selectionStart.Position + 1)
            return false;
         if (token.EndingLineNumber == selectionEnd.Line && (token.EndingColumnPosition + 1) < selectionEnd.Position)
            return false;

         return true;
      }
   }
}