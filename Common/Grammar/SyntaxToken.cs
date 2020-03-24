#region BSD 3-Clause License
// <copyright file="SyntaxToken.cs" company="Edgerunner.org">
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

using Org.Edgerunner.ANTLR4.Tools.Common.Extensions;

namespace Org.Edgerunner.ANTLR4.Tools.Common.Grammar
{
   /// <summary>
   /// Struct that represents a lightweight view model for IToken instances
   /// </summary>
   /// <seealso cref="Antlr4.Runtime.IToken"/>
   public struct SyntaxToken
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SyntaxToken"/> struct.
      /// </summary>
      /// <param name="lexer">The lexer.</param>
      /// <param name="parserToken">The token.</param>
      public SyntaxToken(Lexer lexer, IToken parserToken)
      {
         ActualParserToken = parserToken;
         Text = FormatTokenText(parserToken);
         Type = parserToken.Type > -1 ? lexer.Vocabulary.GetDisplayName(parserToken.Type) : string.Empty;
         TypeUpperCase = Type.ToUpperInvariant();
         LineNumber = parserToken.Line;
         ColumnPosition = parserToken.Column + 1;
         ChannelId = parserToken.Channel;
         Length = parserToken.StopIndex - parserToken.StartIndex + 1;
         StartPosition = parserToken.StartIndex;
         StopPosition = parserToken.StopIndex;

         var spot = parserToken.GetEndPlace();
         EndingLineNumber = spot.Line;
         EndingColumnPosition = spot.Position + 1;
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
      /// Gets the upper case type.
      /// </summary>
      /// <value>The upper case type.</value>
      /// <remarks>Exists solely to avoid repeated upper casing of the Type property.</remarks>
      public string TypeUpperCase { get; }

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
      public int Length { get; }

      /// <summary>
      /// Gets the line number for the end of token.
      /// </summary>
      /// <value>The ending line number.</value>
      public int EndingLineNumber { get; }

      /// <summary>
      /// Gets the column position for the end of the token.
      /// </summary>
      /// <value>The ending column position.</value>
      public int EndingColumnPosition { get; }

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
      /// Gets the actual parser token.
      /// </summary>
      /// <value>The actual parser token.</value>
      public IToken ActualParserToken { get; }

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