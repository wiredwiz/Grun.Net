#region BSD 3-Clause License
// <copyright file="TokenViewModel.cs" company="Edgerunner.org">
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

using Antlr4.Runtime;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grammar
{
   /// <summary>
   /// Struct that represents a lightweight view model for IToken instances
   /// </summary>
   /// <seealso cref="Antlr4.Runtime.IToken"/>
   public struct TokenViewModel
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="TokenViewModel"/> struct.
      /// </summary>
      /// <param name="lexer">The lexer.</param>
      /// <param name="token">The token.</param>
      public TokenViewModel(Lexer lexer, IToken token)
      {
         ActualToken = token;
         Text = FormatTokenText(token);
         Type = token.Type > -1 ? lexer.Vocabulary.GetDisplayName(token.Type) : string.Empty;
         LineNumber = token.Line;
         ColumnPosition = token.Column;
         ChannelId = token.Channel;
         Length = token.StopIndex - token.StartIndex + 1;
         StartPosition = token.StartIndex;
         StopPosition = token.StopIndex;
      }

      /// <summary>
      /// Gets the token text.
      /// </summary>
      /// <value>The token text.</value>
      public string Text { get; }

      /// <summary>
      /// Gets the token type.
      /// </summary>
      /// <value>The token type.</value>
      public string Type { get; }

      /// <summary>
      /// Gets the line number where the token occurs.
      /// </summary>
      /// <value>The line number.</value>
      public int LineNumber { get; }

      /// <summary>
      /// Gets the column position of the token within the source line.
      /// </summary>
      /// <value>The column position.</value>
      public int ColumnPosition { get; }

      /// <summary>
      /// Gets the token length.
      /// </summary>
      /// <value>The token length.</value>
      public int Length { get;  }

      /// <summary>
      /// Gets the start position of the token within the source.
      /// </summary>
      /// <value>The start position.</value>
      public int StartPosition { get; }

      /// <summary>
      /// Gets the stop position of the token within the source.
      /// </summary>
      /// <value>The stop position.</value>
      public int StopPosition { get; }

      /// <summary>
      /// Gets the channel id for the token.
      /// </summary>
      /// <value>The channel id.</value>
      public int ChannelId { get; }

      /// <summary>
      /// Gets the actual token.
      /// </summary>
      /// <value>The actual token.</value>
      public IToken ActualToken { get; }

      private static string FormatTokenText(IToken token)
      {
         switch (token.Text)
         {
            case "\r": return "\\r";
            case "\n": return "\\n";
            case "\t": return "\\t";
         }

         return token.Text;
      }
   }
}