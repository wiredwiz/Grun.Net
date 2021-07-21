#region BSD 3-Clause License
// <copyright file="ErrorNodeImplExtensions.cs" company="Edgerunner.org">
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

using Antlr4.Runtime.Tree;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Common.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Extensions
{
   /// <summary>
   /// Class containing extension methods for the ErrorNodeImpl class.
   /// </summary>
   public class ErrorNodeImplExtensions
   {
      /// <summary>
      /// Determines whether this ErrorNodeImpl contains the specified source selection.
      /// </summary>
      /// <param name="node">The error node implementation.</param>
      /// <param name="selectionStart">The source selection start.</param>
      /// <param name="selectionEnd">The source selection end.</param>
      /// <returns><c>true</c> if node contains the specified source selection; otherwise, <c>false</c>.</returns>
      public static bool ContainsSourceSelection([NotNull] this ErrorNodeImpl node, Place selectionStart, Place selectionEnd)
      {
         var nodeStart = new Place(node.Symbol.Column, node.Symbol.Line - 1);
         Place nodeEnd;
         if (node.Symbol.StartIndex != -1)
         {
            var spot = node.Symbol.GetEndPlace();
            nodeEnd = new Place(spot.Position, spot.Line - 1);
         }
         else
            nodeEnd = nodeStart;

         if (nodeStart.Line > selectionStart.Line)
            return false;
         if (nodeStart.Line == selectionStart.Line && nodeStart.Position > selectionStart.Position)
            return false;
         if (nodeEnd.Line < selectionEnd.Line)
            return false;
         if (nodeEnd.Line == selectionEnd.Line && nodeEnd.Position < selectionEnd.Position)
            return false;

         return true;
      }
   }
}