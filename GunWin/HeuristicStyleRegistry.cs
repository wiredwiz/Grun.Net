#region BSD 3-Clause License
// <copyright file="HeuristicStyleRegistry.cs" company="Edgerunner.org">
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

using System.Drawing;

using FastColoredTextBoxNS;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   public class HeuristicStyleRegistry : IStyleRegistry
   {
      private Style _ErrorStyle;

      private Style _LiteralStyle;

      private Style _CommentStyle;

      private Style _KeywordStyle;

      private Style _DefaultStyle;

      public HeuristicStyleRegistry()
      {
         _KeywordStyle = new TextStyle(Brushes.Blue, Brushes.Transparent, FontStyle.Regular);
         _LiteralStyle = new TextStyle(Brushes.DarkRed, Brushes.Transparent, FontStyle.Regular);
         _CommentStyle = new TextStyle(Brushes.Green, Brushes.Transparent, FontStyle.Regular);
         _DefaultStyle = new TextStyle(Brushes.Black, Brushes.Transparent, FontStyle.Regular);
      }

      public Style GetTokenStyle(TokenViewModel token)
      {
         var type = token.Type.ToUpperInvariant();

         if (IsKeyword(type))
            return _KeywordStyle;
         if (IsLiteral(type))
            return _LiteralStyle;
         if (IsComment(type))
            return _CommentStyle;

         return _DefaultStyle;
      }

      public Style GetParseErrorStyle()
      {
         return _ErrorStyle ?? (_ErrorStyle = new WavyLineStyle(240, Color.Red));
      }

      private bool IsLiteral(string type)
      {
         if (type.Contains("LITERAL"))
            return true;
         if (type.Contains("NUMBER"))
            return true;
         if (type.Contains("FLOAT"))
            return true;
         if (type.Contains("INTEGER"))
            return true;
         if (type.Contains("DOUBLE"))
            return true;
         if (type.Contains("LONG"))
            return true;
         if (type.Contains("STRING"))
            return true;
         if (type.Contains("CHARACTER"))
            return true;
         if (type.Contains("HEX"))
            return true;

         return false;
      }

      private bool IsKeyword(string type)
      {
         switch (type)
         {
            case "IF":
            case "ELSE":
            case "ELSEIF":
            case "ENDIF":
            case "END":
            case "YIELD":
            case "THEN":
            case "WHILE":
            case "ENDWHILE":
            case "WEND":
            case "FOR":
            case "ENDFOR":
            case "FOREACH":
            case "IN":
            case "IS":
            case "ISA":
            case "EXIT":
            case "RETURN":
            case "CONTINUE":
            case "BREAK":
            case "IMPORT":
            case "PASS":
            case "DEL":
            case "TRUE":
            case "FALSE":
            case "NOT":
            case "OR":
            case "AND":
            case "MOD":
            case "TRY":
            case "EXCEPT":
            case "CATCH":
            case "FINALLY":
            case "RAISE":
            case "DEF":
            case "AS":
            case "PUTS":
            case "NULL":
            case "NIL":
            case "WITH":
            case "CLASS":
            case "STRUCT":
            case "INTERFACE":
            case "ENUM":
            case "STATIC":
            case "UNION":
            case "SELECT":
            case "WHERE":
            case "LIKE":
            case "EOL":
            case "OPCODE":
            case "THIS":
            case "BASE":
            case "DO":
            case "WHEN":
            case "THROW":
            case "PUBLIC":
            case "PRIVATE":
            case "PROTECTED":
            case "DYNAMIC":
            case "CONST":
            case "FINAL":
            case "SEALED":
            case "OPEN":
               return true;

            default:
               return false;
         }
      }

      private bool IsComment(string type)
      {
         return type.Contains("COMMENT");
      }
   }
}