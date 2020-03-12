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

using System.Collections.Generic;
using System.Drawing;

using FastColoredTextBoxNS;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting
{
   /// <summary>
   /// Class that represents a heuristic style registry.
   /// Implements the <see cref="Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting.IStyleRegistry" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting.IStyleRegistry" />
   public class HeuristicStyleRegistry : IStyleRegistry
   {
      private readonly Style _LiteralStyle;

      private readonly Style _CommentStyle;

      private readonly Style _KeywordStyle;

      private readonly Style _DefaultStyle;

      private readonly Dictionary<string, Style> _InternalRegistry;

      private Style _ErrorStyle;

      /// <summary>
      /// Initializes a new instance of the <see cref="HeuristicStyleRegistry" /> class.
      /// </summary>
      /// <param name="settings">The settings.</param>
      public HeuristicStyleRegistry(EditorSettings settings)
      {
         var keywordForeBrush = new SolidBrush(settings.KeywordTokenColor);
         var keywordBackBrush = new SolidBrush(settings.KeywordTokenBackgroundColor);
         var literalForeBrush = new SolidBrush(settings.LiteralTokenColor);
         var literalBackBrush = new SolidBrush(settings.LiteralTokenBackgroundColor);
         var commentForeBrush = new SolidBrush(settings.CommentTokenColor);
         var commentBackBrush = new SolidBrush(settings.CommentTokenBackgroundColor);
         var defaultForeBrush = new SolidBrush(settings.DefaultTokenColor);
         var defaultBackBrush = new SolidBrush(settings.DefaultTokenBackgroundColor);
         _KeywordStyle = new TextStyle(keywordForeBrush, keywordBackBrush, settings.KeywordTokenFontStyle);
         _LiteralStyle = new TextStyle(literalForeBrush, literalBackBrush, settings.LiteralTokenFontStyle);
         _CommentStyle = new TextStyle(commentForeBrush, commentBackBrush, settings.CommentTokenFontStyle);
         _DefaultStyle = new TextStyle(defaultForeBrush, defaultBackBrush, settings.DefaultTokenFontStyle);
         _InternalRegistry = new Dictionary<string, Style>();
      }

      /// <inheritdoc/>
      public Style GetTokenStyle(SyntaxToken token)
      {
         if (_InternalRegistry.TryGetValue(token.TypeUpperCase, out var style))
            return style;

         if (IsKeyword(token))
         {
            _InternalRegistry[token.TypeUpperCase] = _KeywordStyle;
            return _KeywordStyle;
         }

         if (IsLiteral(token))
         {
            _InternalRegistry[token.TypeUpperCase] = _LiteralStyle;
            return _LiteralStyle;
         }

         if (IsComment(token))
         {
            _InternalRegistry[token.TypeUpperCase] = _CommentStyle;
            return _CommentStyle;
         }

         _InternalRegistry[token.TypeUpperCase] = _DefaultStyle;
         return _DefaultStyle;
      }

      /// <inheritdoc/>
      public Style GetParseErrorStyle()
      {
         return _ErrorStyle ?? (_ErrorStyle = new WavyLineStyle(240, Color.Red));
      }

      private bool IsLiteral(SyntaxToken token)
      {
         var type = token.TypeUpperCase;
         if (type.Contains("LITERAL"))
            return true;
         if (type.EndsWith("_LIT"))
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

      private bool IsKeyword(SyntaxToken token)
      {
         var type = token.TypeUpperCase;
         if (type.StartsWith("'") && type.EndsWith("'"))
            type = type.Trim('\'');

         switch (type)
         {
            // ReSharper disable StringLiteralTypo

            // First we check the most obvious type name
            case "KEYWORD":

            // Next we check common flow keywords
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
            case "CASE":
            case "SWITCH":
            case "DEFAULT":
            case "FALLTHROUGH":
            case "FORK":
            case "ENDFORK":
            case "FOREACH":
            case "RETURN":
            case "EXIT":
            case "CONTINUE":
            case "BREAK":
            case "GO":
            case "GOTO":
            case "PAUSE":
            case "STOP":
            case "DO":
            case "WHEN":

            // Common literals
            case "TRUE":
            case "FALSE":
            case "NULL":
            case "NIL":

            // Common error handling
            case "TRY":
            case "EXCEPT":
            case "CATCH":
            case "FINALLY":
            case "THROW":
            case "RAISE":

            // Common operations
            case "IN":
            case "IS":
            case "ISA":
            case "AS":
            case "NOT":
            case "OR":
            case "AND":
            case "MOD":
            case "DIV":
            case "DIVIDE":
            case "MULT":
            case "MULTIPLY":
            case "ADD":
            case "SUBTRACT":
            case "EXP":
            case "EXPONENT":

            // Common types
            case "VAR":
            case "COMPLEX64":
            case "COMPLEX128":
            case "RUNE":
            case "LONG":
            case "SHORT":
            case "DBL":
            case "DOUBLE":
            case "STRING":
            case "CHAR":
            case "CHARACTER":
            case "DECIMAL":
            case "BOOL":
            case "BOOLEAN":
            case "BINARY":
            case "HEX":
            case "BYTE":
            case "UINTPTR":
            case "INTPTR":
            case "PTR":
            case "POINTER":
            case "LIST":

            // Common access modifiers
            case "PUBLIC":
            case "PRIVATE":
            case "PROTECTED":
            case "INTERNAL":

            // Everything else
            case "IMPORT":
            case "IMPORTS":
            case "USING":
            case "PASS":
            case "DEL":
            case "DEF":
            case "PUTS":
            case "WITH":
            case "CLASS":
            case "STRUCT":
            case "INTERFACE":
            case "FUNCTION":
            case "FUNC":
            case "PROGRAM":
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
            case "DYNAMIC":
            case "CONST":
            case "FINAL":
            case "SEALED":
            case "OPEN":
            case "CLOSE":
            case "BLOCK":
            case "WRITE":
            case "READ":
            case "PRINT":
            case "ERR":
            case "FORMAT":
            case "CALL":
            case "MAP":
            case "PACKAGE":
            case "DEFER":
            case "CHAN":
               {
                  if (type.Equals(token.Text.ToUpperInvariant()))
                     return true;

                  return false;
               }

            // Special float handling
            case "FLOAT":
            case "FLOATING_POINT":
            case "FLOAT32":
            case "FLOAT64":
               {
                  var lastChar = type[type.Length - 1];
                  // ReSharper disable once ComplexConditionExpression
                  if (type.StartsWith("FLOAT") && ((lastChar > 47 && lastChar < 58) || lastChar == 't'))
                     return true;

                  return false;
               }

            // Special integer handling
            case "INT":
            case "INT8":
            case "INT16":
            case "INT32":
            case "INT64":
            case "INTEGER":
               {
                  var lastChar = type[type.Length - 1];
                  // ReSharper disable once ComplexConditionExpression
                  if (type.StartsWith("INT") && ((lastChar > 47 && lastChar < 58) || lastChar == 't' || lastChar == 'r'))
                     return true;

                  return false;
               }

            // Special unsigned integer handling
            case "UINT":
            case "UINT8":
            case "UINT16":
            case "UINT32":
            case "UINT64":
               {
                  var lastChar = type[type.Length - 1];
                  // ReSharper disable once ComplexConditionExpression
                  if (type.StartsWith("UINT") && ((lastChar > 47 && lastChar < 58) || lastChar == 't'))
                     return true;

                  return false;
               }

            // ReSharper restore StringLiteralTypo
            default:
               return false;
         }
      }

      private bool IsComment(SyntaxToken token)
      {
         var type = token.TypeUpperCase;
         return type.Contains("COMMENT");
      }
   }
}