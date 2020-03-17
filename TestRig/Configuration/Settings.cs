#region BSD 3-Clause License
// <copyright file="Settings.cs" company="Edgerunner.org">
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
using System.IO;

using JetBrains.Annotations;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Configuration
{
   /// <summary>
   /// Class that represents various code editor settings.
   /// </summary>
   [SuppressMessage("ReSharper", "CatchAllClause", Justification = "We want to recover gracefully regardless of errors in settings.")]
   public class Settings
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
      /// Gets or sets a value indicating whether word wrap is enabled for the editor.
      /// </summary>
      /// <value><c>true</c> if word wrap enabled; otherwise, <c>false</c>.</value>
      public bool EditorWordWrap { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether automatic indent is enabled for the editor.
      /// </summary>
      /// <value><c>true</c> if automatic indent enabled; otherwise, <c>false</c>.</value>
      public bool EditorAutoIndent { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether automatic brackets is enabled for the editor.
      /// </summary>
      /// <value><c>true</c> if automatic brackets enabled; otherwise, <c>false</c>.</value>
      public bool EditorAutoBrackets { get; set; }

      /// <summary>
      /// Gets or sets the parser message font family.
      /// </summary>
      /// <value>The parser message font family.</value>
      public FontFamily ParserMessageFontFamily { get; set; }

      /// <summary>
      /// Gets or sets the size of the parser message font.
      /// </summary>
      /// <value>The size of the parser message font.</value>
      public float ParserMessageFontSize { get; set; }

      /// <summary>
      /// Loads the editor settings from the specified file.
      /// </summary>
      /// <param name="filePath">The file path.</param>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="filePath"/> is <see langword="null"/> or empty.</exception>
      /// <exception cref="T:System.Configuration.ConfigurationErrorsException">A configuration file could not be loaded.</exception>
      public void LoadFrom([NotNull] string filePath)
      {
         if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException(nameof(filePath));

         if (File.Exists(filePath))
         {
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var appSettings = config.AppSettings.Settings;
            LoadFrom(appSettings);
         }
         else
            LoadFrom(null as KeyValueConfigurationCollection);
      }

      /// <summary>
      /// Loads the editor settings from the supplied application settings.
      /// </summary>
      /// <param name="appSettings">The application settings.</param>
      public void LoadFrom(KeyValueConfigurationCollection appSettings)
      {
         LoadGraphThrottlingSettings(appSettings);
         LoadSyntaxHighlightingSettings(appSettings);
         LoadGraphingNodeColorSettings(appSettings);
         LoadEditorSettings(appSettings);
         LoadParserMessageFontSettings(appSettings);
      }

      /// <summary>
      /// Loads the editor settings with standard default values.
      /// </summary>
      public void LoadDefaults()
      {
         LoadGraphThrottlingSettings(null);
         LoadSyntaxHighlightingSettings(null);
         LoadGraphingNodeColorSettings(null);
         LoadEditorSettings(null);
         LoadParserMessageFontSettings(null);
      }

      private void LoadEditorSettings(KeyValueConfigurationCollection appSettings)
      {
         var defFontFamily = FontFamily.GenericMonospace;
         var defFontSize = 8f;
         var defAutoIndent = false;
         var defAutoBrackets = false;
         var defWordWrap = false;

         if (appSettings == null)
         {
            EditorFontFamily = FontFamily.GenericMonospace;
            EditorFontSize = defFontSize;
            return;
         }

         // Fetch EditorFontFamily setting
         var result = appSettings["EditorFontFamily"]?.Value ?? string.Empty;
         try
         {
            EditorFontFamily = !string.IsNullOrEmpty(result) ? new FontFamily(result) : defFontFamily;
         }
         catch (ArgumentException)
         {
            EditorFontFamily = defFontFamily;
         }

         // Fetch EditorFontSize setting
         result = appSettings["EditorFontSize"]?.Value ?? string.Empty;
         EditorFontSize = !float.TryParse(result, out var settingValueFloat) ? defFontSize : settingValueFloat;

         // Fetch EditorAutoIndent settings
         result = appSettings["EditorAutoIndent"]?.Value ?? string.Empty;
         EditorAutoIndent = !bool.TryParse(result, out var settingValueBoolean) ? defAutoIndent : settingValueBoolean;

         // Fetch EditorWordWrap settings
         result = appSettings["EditorWordWrap"]?.Value ?? string.Empty;
         EditorWordWrap = !bool.TryParse(result, out settingValueBoolean) ? defWordWrap : settingValueBoolean;

         // Fetch EditorAutoBrackets settings
         result = appSettings["EditorAutoBrackets"]?.Value ?? string.Empty;
         EditorAutoBrackets = !bool.TryParse(result, out settingValueBoolean) ? defAutoBrackets : settingValueBoolean;
      }

      private void LoadParserMessageFontSettings(KeyValueConfigurationCollection appSettings)
      {
         var defFontFamily = FontFamily.GenericSerif;
         var defFontSize = 8.25f;

         if (appSettings == null)
         {
            ParserMessageFontFamily = FontFamily.GenericMonospace;
            ParserMessageFontSize = defFontSize;
            return;
         }

         // Fetch EditorFontFamily setting
         var result = appSettings["ParserMessageFontFamily"]?.Value ?? string.Empty;
         try
         {
            ParserMessageFontFamily = !string.IsNullOrEmpty(result) ? new FontFamily(result) : defFontFamily;
         }
         catch (ArgumentException)
         {
            ParserMessageFontFamily = defFontFamily;
         }

         // Fetch EditorFontSize setting
         result = appSettings["ParserMessageFontSize"]?.Value ?? string.Empty;
         ParserMessageFontSize = !float.TryParse(result, out var settingValueFloat) ? defFontSize : settingValueFloat;
      }

      private void LoadGraphingNodeColorSettings(KeyValueConfigurationCollection appSettings)
      {
         var defTextColor = Color.Black;
         var defBorderColor = Color.Black;
         var defBackgroundColor = Color.LightBlue;

         if (appSettings == null)
         {
            GraphNodeTextColor = defTextColor;
            GraphNodeBorderColor = defBorderColor;
            GraphNodeBackgroundColor = defBackgroundColor;
            return;
         }

         // Fetch GraphNodeTextColor setting
         var result = appSettings["GraphNodeTextColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeTextColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTextColor;
         }
         catch (Exception)
         {
            GraphNodeTextColor = defTextColor;
         }

         // Fetch GraphNodeBorderColor setting
         result = appSettings["GraphNodeBorderColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeBorderColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defBorderColor;
         }
         catch (Exception)
         {
            GraphNodeBorderColor = defBorderColor;
         }

         // Fetch GraphNodeBackgroundColor setting
         result = appSettings["GraphNodeBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            GraphNodeBackgroundColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defBackgroundColor;
         }
         catch (Exception)
         {
            GraphNodeBackgroundColor = defBackgroundColor;
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
         var defTokenColor = Color.Green;
         var defTokenBackColor = Color.Transparent;
         var defTokenStyle = FontStyle.Italic;

         if (appSettings == null)
         {
            CommentTokenColor = defTokenColor;
            CommentTokenBackgroundColor = defTokenBackColor;
            CommentTokenFontStyle = defTokenStyle;
            return;
         }

         // Fetch CommentTokenColor setting
         var result = appSettings["CommentTokenColor"]?.Value ?? string.Empty;
         try
         {
            CommentTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenColor;
         }
         catch (Exception)
         {
            CommentTokenColor = defTokenColor;
         }

         // Fetch CommentTokenBackgroundColor setting
         result = appSettings["CommentTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            CommentTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenBackColor;
         }
         catch (Exception)
         {
            CommentTokenBackgroundColor = defTokenBackColor;
         }

         // Fetch CommentTokenFontStyle setting
         result = appSettings["CommentTokenFontStyle"]?.Value ?? string.Empty;
         CommentTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? defTokenStyle : style;
      }

      private void LoadLiteralTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         var defTokenColor = Color.Red;
         var defTokenBackColor = Color.Transparent;
         var defTokenStyle = FontStyle.Regular;

         if (appSettings == null)
         {
            LiteralTokenColor = defTokenColor;
            LiteralTokenBackgroundColor = defTokenBackColor;
            LiteralTokenFontStyle = defTokenStyle;
            return;
         }

         // Fetch LiteralTokenColor setting
         var result = appSettings["LiteralTokenColor"]?.Value ?? string.Empty;
         try
         {
            LiteralTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenColor;
         }
         catch (Exception)
         {
            LiteralTokenColor = defTokenColor;
         }

         // Fetch LiteralTokenBackgroundColor setting
         result = appSettings["LiteralTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            LiteralTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenBackColor;
         }
         catch (Exception)
         {
            LiteralTokenBackgroundColor = defTokenBackColor;
         }

         // Fetch LiteralTokenFontStyle setting
         result = appSettings["LiteralTokenFontStyle"]?.Value ?? string.Empty;
         LiteralTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? defTokenStyle : style;
      }

      private void LoadKeywordTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         var defTokenColor = Color.Blue;
         var defTokenBackColor = Color.Transparent;
         var defTokenStyle = FontStyle.Regular;

         if (appSettings == null)
         {
            KeywordTokenColor = defTokenColor;
            KeywordTokenBackgroundColor = defTokenBackColor;
            KeywordTokenFontStyle = defTokenStyle;
            return;
         }

         // Fetch KeywordTokenColor setting
         var result = appSettings["KeywordTokenColor"]?.Value ?? string.Empty;
         try
         {
            KeywordTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenColor;
         }
         catch (Exception)
         {
            KeywordTokenColor = defTokenColor;
         }

         // Fetch KeywordTokenBackgroundColor setting
         result = appSettings["KeywordTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            KeywordTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenBackColor;
         }
         catch (Exception)
         {
            KeywordTokenBackgroundColor = defTokenBackColor;
         }

         // Fetch KeywordTokenFontStyle setting
         result = appSettings["KeywordTokenFontStyle"]?.Value ?? string.Empty;
         KeywordTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? defTokenStyle : style;
      }

      private void LoadDefaultTokenHighlightSettings(KeyValueConfigurationCollection appSettings)
      {
         var defTokenColor = Color.Black;
         var defTokenBackColor = Color.Transparent;
         var defTokenStyle = FontStyle.Regular;

         if (appSettings == null)
         {
            DefaultTokenColor = defTokenColor;
            DefaultTokenBackgroundColor = defTokenBackColor;
            DefaultTokenFontStyle = defTokenStyle;
            return;
         }

         // Fetch DefaultTokenColor setting
         var result = appSettings["DefaultTokenColor"]?.Value ?? string.Empty;
         try
         {
            DefaultTokenColor = !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenColor;
         }
         catch (Exception)
         {
            DefaultTokenColor = defTokenColor;
         }

         // Fetch DefaultTokenBackgroundColor setting
         result = appSettings["DefaultTokenBackgroundColor"]?.Value ?? string.Empty;
         try
         {
            DefaultTokenBackgroundColor =
               !string.IsNullOrEmpty(result) ? ColorTranslator.FromHtml(result) : defTokenBackColor;
         }
         catch (Exception)
         {
            DefaultTokenBackgroundColor = defTokenBackColor;
         }

         // Fetch DefaultTokenFontStyle setting
         result = appSettings["DefaultTokenFontStyle"]?.Value ?? string.Empty;
         DefaultTokenFontStyle = !Enum.TryParse(result, out FontStyle style) ? defTokenStyle : style;
      }

      private void LoadGraphThrottlingSettings(KeyValueConfigurationCollection appSettings)
      {
         var defThreshold = 50;
         var defDelayPerNode = 5;
         var defMaxRenderDelay = 1000;
         var defMinRenderCountForLongDelay = 10;

         if (appSettings == null)
         {
            NodeThresholdCountForThrottling = defThreshold;
            MillisecondsToDelayPerNodeWhenThrottling = defDelayPerNode;
            MaximumRenderShortDelay = defMaxRenderDelay;
            MinimumRenderCountToTriggerLongDelay = defMinRenderCountForLongDelay;
            return;
         }

         // Fetch NodeThresholdCountForThrottling setting
         string result = appSettings["NodeThresholdCountForThrottling"]?.Value ?? string.Empty;
         NodeThresholdCountForThrottling = !int.TryParse(result, out var settingValue) ? defThreshold : settingValue;

         // Fetch MillisecondsToDelayPerNodeWhenThrottling setting
         result = appSettings["MillisecondsToDelayPerNodeWhenThrottling"]?.Value ?? string.Empty;
         MillisecondsToDelayPerNodeWhenThrottling = !int.TryParse(result, out settingValue) ? defDelayPerNode : settingValue;

         // Fetch MaximumRenderShortDelay setting
         result = appSettings["MaximumRenderShortDelay"]?.Value ?? string.Empty;
         MaximumRenderShortDelay = !int.TryParse(result, out settingValue) ? defMaxRenderDelay : settingValue;

         // Fetch MinimumRenderCountToTriggerLongDelay setting
         result = appSettings["MinimumRenderCountToTriggerLongDelay"]?.Value ?? string.Empty;
         MinimumRenderCountToTriggerLongDelay = !int.TryParse(result, out settingValue) ? defMinRenderCountForLongDelay : settingValue;
      }
   }
}