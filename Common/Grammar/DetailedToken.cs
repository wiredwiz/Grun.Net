#region BSD 3-Clause License
// <copyright file="DetailedToken.cs" company="Edgerunner.org">
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

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

using Org.Edgerunner.ANTLR4.Tools.Common.Extensions;

namespace Org.Edgerunner.ANTLR4.Tools.Common.Grammar
{
   /// <summary>
   /// A more detailed implementation of IToken.
   /// </summary>
   /// <seealso cref="Antlr4.Runtime.IToken"/>
   public class DetailedToken : CommonToken
   {
      private string _TypeNameUpperCase;
      private int? _EndingLineNumber;
      private int? _EndingColumnPosition;
      private Place? _EndPlace;

      private string _TypeName;

      /// <summary>
      /// Initializes a new instance of the <see cref="DetailedToken"/> class.
      /// </summary>
      /// <param name="source">The source.</param>
      /// <param name="type">The type.</param>
      /// <param name="channel">The channel.</param>
      /// <param name="start">The start.</param>
      /// <param name="stop">The stop.</param>
      // ReSharper disable once TooManyDependencies
      public DetailedToken([NotNull] Tuple<ITokenSource, ICharStream> source, int type, int channel, int start, int stop)
         : base(source, type, channel, start, stop)
      {
         ColumnPosition = start + 1;
         Length = stop - start + 1;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DetailedToken"/> class.
      /// </summary>
      /// <param name="type">The type.</param>
      /// <param name="text">The text.</param>
      public DetailedToken(int type, string text)
         : base(type, text)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DetailedToken"/> class.
      /// </summary>
      /// <param name="type">The type.</param>
      public DetailedToken(int type)
         : base(type)
      {
      }

      /// <summary>
      /// Gets the token display text.
      /// </summary>
      /// <value>The token display text.</value>
      public string DisplayText => FormatTokenText(Text);

      /// <summary>
      /// Gets or sets the token type.
      /// </summary>
      /// <value>The token type name.</value>
      public string TypeName
      {
         get => _TypeName;
         set
         {
            _TypeNameUpperCase = null;
            _TypeName = value;
         }
      }

      /// <summary>
      /// Gets the upper case type name.
      /// </summary>
      /// <value>The upper case type name.</value>
      /// <remarks>Exists solely to avoid repeated upper casing of the TypeName property.</remarks>
      public string TypeNameUpperCase => _TypeNameUpperCase ?? (_TypeNameUpperCase = TypeName.ToUpperInvariant());

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
      public int EndingLineNumber
      {
         get
         {
            if (!_EndingLineNumber.HasValue)
            {
               if (!_EndPlace.HasValue)
                  _EndPlace = this.GetEndPlace();
               _EndingLineNumber = _EndPlace.Value.Line;
            }

            return _EndingLineNumber.Value;
         }
      }

      /// <summary>
      /// Gets the column position for the end of the token.
      /// </summary>
      /// <value>The ending column position.</value>
      public int EndingColumnPosition
      {
         get
         {
            if (!_EndingColumnPosition.HasValue)
            {
               if (!_EndPlace.HasValue)
                  _EndPlace = this.GetEndPlace();
               _EndingColumnPosition = _EndPlace.Value.Position + 1;
            }

            return _EndingColumnPosition.Value;
         }
      }

      private static string FormatTokenText(string text)
      {
         switch (text)
         {
            case "\r": return "\\r";
            case "\n": return "\\n";
            case "\t": return "\\t";
         }

         return text;
      }
   }
}