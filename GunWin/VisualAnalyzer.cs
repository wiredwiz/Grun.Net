#region BSD 3-Clause License

// <copyright file="Analyzer.cs" company="Edgerunner.org">
// Copyright 2020 Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2020, Thaddeus Ryker
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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Antlr4.Runtime;

using Org.Edgerunner.ANTLR.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR.Tools.Testing
{
   /// <summary>
   /// Class that represents an ANTLR grammar test Analyzer.
   /// Implements the <see cref="System.Windows.Forms.Form" />
   /// </summary>
   /// <seealso cref="System.Windows.Forms.Form" />
   public partial class VisualAnalyzer : Form
   {
      private GrammarReference _Grammar;

      private List<string> _ParserRules;

      private string _DefaultRule;

      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="VisualAnalyzer"/> class.
      /// </summary>
      public VisualAnalyzer()
      {
         InitializeComponent();
      }

      #endregion

      private void LoadParserRules()
      {
         cmbRules.DataSource = _ParserRules;
         cmbRules.Refresh();
      }

      /// <summary>
      /// Parses the source code.
      /// </summary>
      public void ParseSource()
      {
         if (_Grammar == null)
            return; 

         var analyzer = new Grammar.Analyzer(_Grammar, CodeEditor.Text);
         analyzer.Parse(cmbRules.SelectedItem.ToString());
         PopulateTokens(analyzer.DisplayTokens);
      }

      private void PopulateTokens(IList<TokenViewModel> tokens)
      {
         tokenListView.SetObjects(tokens);
      }

      /// <summary>
      /// Sets the source code to be analyzed.
      /// </summary>
      /// <param name="code">The code.</param>
      public void SetSourceCode(string code)
      {
         CodeEditor.Text = code;
      }

      /// <summary>
      /// Sets the grammar to parse.
      /// </summary>
      /// <param name="grammar">The grammar.</param>
      public void SetGrammar(GrammarReference grammar)
      {
         var scanner = new Scanner();
         _Grammar = grammar;
         _ParserRules = scanner.GetParserRulesForGrammar(grammar).ToList();
         _ParserRules.Sort();
         LoadParserRules();
      }

      /// <summary>
      /// Sets the default parser rule.
      /// </summary>
      /// <param name="rule">The parser rule.</param>
      /// <exception cref="T:System.ArgumentException">Invalid parser rule.</exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="rule"/> is <see langword="null"/></exception>
      public void SetDefaultParserRule(string rule)
      {
         if (string.IsNullOrEmpty(rule)) throw new ArgumentNullException(nameof(rule));

         if (!_ParserRules.Contains(rule))
            throw new ArgumentException($"The rule \"{rule}\" is invalid", nameof(rule));

         _DefaultRule = rule;
         cmbRules.Refresh();
         cmbRules.SelectedIndex = cmbRules.FindStringExact(rule);
      }

      private void CodeEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
      {
         ParseSource();
      }
   }
}