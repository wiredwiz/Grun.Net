#region BSD 3-Clause License
// <copyright file="HeuristicSyntaxHighlightGuide.cs" company="Edgerunner.org">
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

using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Testing.Configuration;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting
{
   /// <summary>
   /// Class that represents a heuristic style registry.
   /// Implements the <see cref="Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting.IStyleRegistry" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting.IStyleRegistry" />
   public class HeuristicSyntaxHighlightingGuide : ISyntaxHighlightingGuide
   {
      private readonly Settings _Settings;

      private readonly Dictionary<string, Color> _ForegroundColors;

      private readonly Dictionary<string, Color> _BackgroundColors;

      private readonly Dictionary<string, FontStyle> _FontStyles;

      /// <summary>
      /// Initializes a new instance of the <see cref="HeuristicSyntaxHighlightingGuide" /> class.
      /// </summary>
      /// <param name="settings">The settings.</param>
      public HeuristicSyntaxHighlightingGuide(Settings settings)
      {
         AllGrammarNames = new List<string>();
         _Settings = settings;
         _ForegroundColors = new Dictionary<string, Color>();
         _BackgroundColors = new Dictionary<string, Color>();
         _FontStyles = new Dictionary<string, FontStyle>();
      }

      private bool IsLiteral(DetailedToken token)
      {
         if (token.TypeNameUpperCase.Contains("LITERAL"))
            return true;
         if (token.TypeNameUpperCase.EndsWith("_LIT"))
            return true;
         if (token.TypeNameUpperCase.Contains("NUMBER"))
            return true;
         if (token.TypeNameUpperCase.Contains("FLOAT"))
            return true;
         if (token.TypeNameUpperCase.Contains("INTEGER"))
            return true;
         if (token.TypeNameUpperCase.Contains("DOUBLE"))
            return true;
         if (token.TypeNameUpperCase.Contains("LONG"))
            return true;
         if (token.TypeNameUpperCase.Contains("STRING"))
            return true;
         if (token.TypeNameUpperCase.Contains("CHARACTER"))
            return true;
         if (token.TypeNameUpperCase.Contains("HEX"))
            return true;

         return false;
      }

      private bool IsKeyword(DetailedToken token)
      {
         var type = token.TypeNameUpperCase;
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
            case "BEGIN":
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
            case "WITH":

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
            case "ENDTRY":
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
                  if (type.Equals(token.DisplayText.ToUpperInvariant()))
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

      private bool IsComment(DetailedToken token)
      {
         return token.TypeNameUpperCase.Contains("COMMENT");
      }

      public string GrammarName { get; set; }
      public IList<string> AllGrammarNames { get; }

      public Color GetErrorIndicatorColor()
      {
         return Color.Red;
      }

      public Color GetTokenForegroundColor(DetailedToken token)
      {
         if (_ForegroundColors.TryGetValue(token.TypeNameUpperCase, out var style))
            return style;

         if (IsKeyword(token))
         {
            _ForegroundColors[token.TypeNameUpperCase] = _Settings.KeywordTokenColor;
            return _Settings.KeywordTokenColor;
         }

         if (IsLiteral(token))
         {
            _ForegroundColors[token.TypeNameUpperCase] = _Settings.LiteralTokenColor;
            return _Settings.LiteralTokenColor;
         }

         if (IsComment(token))
         {
            _ForegroundColors[token.TypeNameUpperCase] = _Settings.CommentTokenColor;
            return _Settings.CommentTokenColor;
         }

         _ForegroundColors[token.TypeNameUpperCase] = _Settings.DefaultTokenColor;
         return _Settings.DefaultTokenColor;
      }

      public Color GetTokenBackgroundColor(DetailedToken token)
      {
         if (_BackgroundColors.TryGetValue(token.TypeNameUpperCase, out var style))
            return style;

         if (IsKeyword(token))
         {
            _BackgroundColors[token.TypeNameUpperCase] = _Settings.KeywordTokenBackgroundColor;
            return _Settings.KeywordTokenBackgroundColor;
         }

         if (IsLiteral(token))
         {
            _BackgroundColors[token.TypeNameUpperCase] = _Settings.LiteralTokenBackgroundColor;
            return _Settings.LiteralTokenBackgroundColor;
         }

         if (IsComment(token))
         {
            _BackgroundColors[token.TypeNameUpperCase] = _Settings.CommentTokenBackgroundColor;
            return _Settings.CommentTokenBackgroundColor;
         }

         _BackgroundColors[token.TypeNameUpperCase] = _Settings.DefaultTokenBackgroundColor;
         return _Settings.DefaultTokenBackgroundColor;
      }

      public FontStyle GetTokenFontStyle(DetailedToken token)
      {
         if (_FontStyles.TryGetValue(token.TypeNameUpperCase, out var style))
            return style;

         if (IsKeyword(token))
         {
            _FontStyles[token.TypeNameUpperCase] = _Settings.KeywordTokenFontStyle;
            return _Settings.KeywordTokenFontStyle;
         }

         if (IsLiteral(token))
         {
            _FontStyles[token.TypeNameUpperCase] = _Settings.KeywordTokenFontStyle;
            return _Settings.KeywordTokenFontStyle;
         }

         if (IsComment(token))
         {
            _FontStyles[token.TypeNameUpperCase] = _Settings.CommentTokenFontStyle;
            return _Settings.CommentTokenFontStyle;
         }

         _FontStyles[token.TypeNameUpperCase] = _Settings.DefaultTokenFontStyle;
         return _Settings.DefaultTokenFontStyle;
      }
   }
}