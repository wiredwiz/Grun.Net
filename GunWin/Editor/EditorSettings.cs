#region BSD 3-Clause License
// <copyright file="EditorSettings.cs" company="Edgerunner.org">
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
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor
{
   /// <summary>
   /// Class that represents various code editor settings.
   /// </summary>
   [SuppressMessage("ReSharper", "CatchAllClause", Justification = "We want to recover gracefully regardless of errors in settings.")]
   public class EditorSettings
   {
      /// <summary>
      /// Gets or sets the node threshold count for throttling.
      /// </summary>
      /// <value>The node threshold count for throttling.</value>
      public int NodeThresholdCountForThrottling { get; set; }

      /// <summary>
      /// Gets or sets the milliseconds to delay per node when throttling.
      /// </summary>
      /// <value>The milliseconds to delay per node when throttling.</value>
      public int MillisecondsToDelayPerNodeWhenThrottling { get; set; }

      /// <summary>
      /// Gets or sets the maximum render short delay.
      /// </summary>
      /// <value>The maximum render short delay.</value>
      public int MaximumRenderShortDelay { get; set; }

      /// <summary>
      /// Gets or sets the minimum render count to trigger a long delay.
      /// </summary>
      /// <value>The minimum render count to trigger a long delay.</value>
      public int MinimumRenderCountToTriggerLongDelay { get; set; }

      /// <summary>
      /// Gets or sets the color of the keyword token.
      /// </summary>
      /// <value>The color of the keyword token.</value>
      public Color KeywordTokenColor { get; set; }

      /// <summary>
      /// Gets or sets the background color of the keyword token.
      /// </summary>
      /// <value>The background color of the keyword token.</value>
      public Color KeywordTokenBackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the font style for a keyword token.
      /// </summary>
      /// <value>The font style for a keyword token.</value>
      public FontStyle KeywordTokenFontStyle { get; set; }

      /// <summary>
      /// Gets or sets the color of the comment token.
      /// </summary>
      /// <value>The color of the comment token.</value>
      public Color CommentTokenColor { get; set; }

      /// <summary>
      /// Gets or sets the background color of the comment token.
      /// </summary>
      /// <value>The background color of the comment token.</value>
      public Color CommentTokenBackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the font style for a comment token.
      /// </summary>
      /// <value>The font style for a comment token.</value>
      public FontStyle CommentTokenFontStyle { get; set; }

      /// <summary>
      /// Gets or sets the color of the literal token.
      /// </summary>
      /// <value>The color of the literal token.</value>
      public Color LiteralTokenColor { get; set; }

      /// <summary>
      /// Gets or sets the background color of the literal token.
      /// </summary>
      /// <value>The background color of the literal token.</value>
      public Color LiteralTokenBackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the font style for a literal token.
      /// </summary>
      /// <value>The font style for a literal token.</value>
      public FontStyle LiteralTokenFontStyle { get; set; }

      /// <summary>
      /// Gets or sets the default color of a token.
      /// </summary>
      /// <value>The default color of a token.</value>
      public Color DefaultTokenColor { get; set; }

      /// <summary>
      /// Gets or sets the default background color of a token.
      /// </summary>
      /// <value>The default background color of a token.</value>
      public Color DefaultTokenBackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the default font style for a token.
      /// </summary>
      /// <value>The default font style for a token.</value>
      public FontStyle DefaultTokenFontStyle { get; set; }

      /// <summary>
      /// Gets or sets the border color of a graph node.
      /// </summary>
      /// <value>The border color of a graph node.</value>
      public Color GraphNodeBorderColor { get; set; }

      /// <summary>
      /// Gets or sets the text color of a graph node.
      /// </summary>
      /// <value>The text color of a graph node.</value>
      public Color GraphNodeTextColor { get; set; }

      /// <summary>
      /// Gets or sets the background color of a graph node.
      /// </summary>
      /// <value>The background color of a graph node.</value>
      public Color GraphNodeBackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the editor font family.
      /// </summary>
      /// <value>The editor font family.</value>
      public FontFamily EditorFontFamily { get; set; }

      /// <summary>
      /// Gets or sets the size of the editor font.
      /// </summary>
      /// <value>The size of the editor font.</value>
      public float EditorFontSize { get; set; }

      /// <summary>
      /// Loads the editor settings from the supplied application settings.
      /// </summary>
      /// <param name="appSettings">The application settings.</param>
      public void LoadFrom(KeyValueConfigurationCollection appSettings)
      {
         LoadGraphThrottlingSettings(appSettings);
         LoadSyntaxHighlightingSettings(appSettings);
         LoadGraphingNodeColorSettings(appSettings);
         LoadEditorFontSettings(appSettings);
      }

      private void LoadEditorFontSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch EditorFontFamily setting
         var result = appSettings["EditorFontFamily"]?.Value ?? "Courier New";
         try
         {
            EditorFontFamily = new FontFamily(result);
         }
         catch (ArgumentException)
         {
            EditorFontFamily = FontFamily.GenericMonospace;
         }

         // Fetch EditorFontSize setting
         result = appSettings["EditorFontSize"]?.Value ?? string.Empty;
         EditorFontSize = !float.TryParse(result, out var settingValueFloat) ? 9.5f : settingValueFloat;
      }

      private void LoadGraphingNodeColorSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch GraphNodeTextColor setting
         var result = appSettings["GraphNodeTextColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeTextColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Black;
         }
         catch (Exception)
         {
            GraphNodeTextColor = Color.Black;
         }

         // Fetch GraphNodeBorderColor setting
         result = appSettings["GraphNodeBorderColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeBorderColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Black;
         }
         catch (Exception)
         {
            GraphNodeBorderColor = Color.Black;
         }

         // Fetch GraphNodeBackgroundColor setting
         result = appSettings["GraphNodeBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeBackgroundColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.LightBlue;
         }
         catch (Exception)
         {
            GraphNodeBackgroundColor = Color.LightBlue;
         }
      }

      private void LoadSyntaxHighlightingSettings(KeyValueConfigurationCollection appSettings)
      {
         LoadDefaultTokenHighlightSettings(appSettings);
         LoadKeywordTokenHighlightSettings(appSettings);
         LoadLiteralTokenHighlightSettings(appSettings);
         LoadCommentTokenHighlightSettings(appSettings);
      }

      private void LoadCommentTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch CommentTokenColor setting
         var result = appSettings["CommentTokenColor"]?.Value ?? string.Empty;
         try
         {
            CommentTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Green;
         }
         catch (Exception)
         {
            CommentTokenColor = Color.Green;
         }

         // Fetch CommentTokenBackgroundColor setting
         result = appSettings["CommentTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            CommentTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Transparent;
         }
         catch (Exception)
         {
            CommentTokenBackgroundColor = Color.Transparent;
         }

         // Fetch CommentTokenFontStyle setting
         result = appSettings["CommentTokenFontStyle"]?.Value ?? string.Empty;
         CommentTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? FontStyle.Regular : style;
      }

      private void LoadLiteralTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch LiteralTokenColor setting
         var result = appSettings["LiteralTokenColor"]?.Value ?? string.Empty;
         try
         {
            LiteralTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Red;
         }
         catch (Exception)
         {
            LiteralTokenColor = Color.Red;
         }

         // Fetch LiteralTokenBackgroundColor setting
         result = appSettings["LiteralTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            LiteralTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Transparent;
         }
         catch (Exception)
         {
            LiteralTokenBackgroundColor = Color.Transparent;
         }

         // Fetch LiteralTokenFontStyle setting
         result = appSettings["LiteralTokenFontStyle"]?.Value ?? string.Empty;
         LiteralTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? FontStyle.Regular : style;
      }

      private void LoadKeywordTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch KeywordTokenColor setting
         var result = appSettings["KeywordTokenColor"]?.Value ?? string.Empty;
         try
         {
            KeywordTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Blue;
         }
         catch (Exception)
         {
            KeywordTokenColor = Color.Blue;
         }

         // Fetch KeywordTokenBackgroundColor setting
         result = appSettings["KeywordTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            KeywordTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Transparent;
         }
         catch (Exception)
         {
            KeywordTokenBackgroundColor = Color.Transparent;
         }

         // Fetch KeywordTokenFontStyle setting
         result = appSettings["KeywordTokenFontStyle"]?.Value ?? string.Empty;
         KeywordTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? FontStyle.Regular : style;
      }

      private void LoadDefaultTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch DefaultTokenColor setting
         var result = appSettings["DefaultTokenColor"]?.Value ?? string.Empty;
         try
         {
            DefaultTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Black;
         }
         catch (Exception)
         {
            DefaultTokenColor = Color.Black;
         }

         // Fetch DefaultTokenBackgroundColor setting
         result = appSettings["DefaultTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            DefaultTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : Color.Transparent;
         }
         catch (Exception)
         {
            DefaultTokenBackgroundColor = Color.Transparent;
         }

         // Fetch DefaultTokenFontStyle setting
         result = appSettings["DefaultTokenFontStyle"]?.Value ?? string.Empty;
         DefaultTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? FontStyle.Regular : style;
      }

      private void LoadGraphThrottlingSettings(KeyValueConfigurationCollection appSettings)
      {
         // Fetch NodeThresholdCountForThrottling setting
         string result = appSettings["NodeThresholdCountForThrottling"]?.Value ?? string.Empty;
         NodeThresholdCountForThrottling = !int.TryParse(result, out var settingValue) ? 50 : settingValue;

         // Fetch MillisecondsToDelayPerNodeWhenThrottling setting
         result = appSettings["MillisecondsToDelayPerNodeWhenThrottling"]?.Value ?? string.Empty;
         MillisecondsToDelayPerNodeWhenThrottling = !int.TryParse(result, out settingValue) ? 5 : settingValue;

         // Fetch MaximumRenderShortDelay setting
         result = appSettings["MaximumRenderShortDelay"]?.Value ?? string.Empty;
         MaximumRenderShortDelay = !int.TryParse(result, out settingValue) ? 1000 : settingValue;

         // Fetch MinimumRenderCountToTriggerLongDelay setting
         result = appSettings["MinimumRenderCountToTriggerLongDelay"]?.Value ?? string.Empty;
         MinimumRenderCountToTriggerLongDelay = !int.TryParse(result, out settingValue) ? 10 : settingValue;
      }
   }
}