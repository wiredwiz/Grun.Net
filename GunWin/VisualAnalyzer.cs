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
using Antlr4.Runtime.Tree;

using FastColoredTextBoxNS;

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.Layered;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
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

      private GViewer _Viewer;

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

      /// <summary>
      /// Gets or sets a value indicating whether to parse with diagnostics enabled.
      /// </summary>
      /// <value><c>true</c> if diagnostic parsing is enabled; otherwise, <c>false</c>.</value>
      /// <remarks>If SLL is also enabled, SLL will supersede diagnostic mode.</remarks>
      public bool ParseWithDiagnostics
      {
         get => diagnosticsToolStripMenuItem.Checked;
         set
         {
            diagnosticsToolStripMenuItem.Checked = value;
            ParseSource();
         }
      }

      /// <summary>
      /// Gets or sets a value indicating whether to parse with Simple LL mode.
      /// </summary>
      /// <value><c>true</c> if SLL parsing mode is enabled; otherwise, <c>false</c>.</value>
      /// <remarks>If Diagnostics are also enabled, SLL will supersede diagnostic mode.</remarks>
      public bool ParseWithSllMode
      {
         get => simpleLLModeToolStripMenuItem.Checked;
         set
         {
            simpleLLModeToolStripMenuItem.Checked = value;
            ParseSource();
         }
      }

      /// <summary>
      /// Gets or sets a value indicating whether to parse with tracing enabled.
      /// </summary>
      /// <value><c>true</c> if tracing is enabled; otherwise, <c>false</c>.</value>
      public bool ParseWithTracing
      {
         get => tracingToolStripMenuItem.Checked;
         set
         {
            tracingToolStripMenuItem.Checked = value;
            ParseSource();
         }
      }

      private void LoadParserRules()
      {
         cmbRules.DataSource = _ParserRules.OrderBy(x => x).Distinct().ToList();
         cmbRules.Refresh();
      }

      private void InitializeGraphCanvas()
      {
         SuspendLayout();
         _Viewer = new GViewer();
         pnlGraph.Controls.Add(_Viewer);
         _Viewer.Dock = DockStyle.Fill;
         ResumeLayout();
         _Viewer.LayoutAlgorithmSettingsButtonVisible = false;
         _Viewer.Click += _Viewer_Click;
      }

      private void ShowSourcePosition(ParserRuleContext context)
      {
         if (context == null)
            return;

         var startingPlace = new Place(context.Start.Column, context.start.Line - 1);
         var stoppingPlace = new Place(context.Stop.Column + context.stop.Text.Length, context.stop.Line - 1);

         CodeEditor.Selection = new Range(CodeEditor, startingPlace, stoppingPlace);
         CodeEditor.DoCaretVisible();
         CodeEditor.Focus();
      }

      private void ShowSourcePosition(TerminalNodeImpl node)
      {
         if (node == null)
            return;

         var startingPlace = new Place(node.Symbol.Column, node.Symbol.Line - 1);
         var stoppingPlace = new Place(node.Symbol.Column + node.Symbol.Text.Length, node.Symbol.Line - 1);

         CodeEditor.Selection = new Range(CodeEditor, startingPlace, stoppingPlace);
         CodeEditor.DoCaretVisible();
         CodeEditor.Focus();
      }

      private void _Viewer_Click(object sender, EventArgs e)
      {
         if (_Viewer.SelectedObject is Node node)
         {
            if (node.UserData is ParserRuleContext context)
               ShowSourcePosition(context);
            else if (node.UserData is TerminalNodeImpl terminal)
               ShowSourcePosition(terminal);
         }
      }

      /// <summary>
      /// Parses the source code.
      /// </summary>
      public void ParseSource()
      {
         if (_Grammar == null)
            return;

         if (_ParserRules.Count == 0)
            return;

         if (string.IsNullOrEmpty(cmbRules.SelectedItem?.ToString()))
            return;

         var analyzer = new Grammar.Analyzer(_Grammar, CodeEditor.Text);
         var options = ParseOption.Tree;
         if (ParseWithDiagnostics) options |= ParseOption.Diagnostics;
         if (ParseWithSllMode) options |= ParseOption.Sll;
         if (ParseWithTracing) options |= ParseOption.Trace;
         analyzer.Parse(cmbRules.SelectedItem.ToString(), options);
         PopulateTokens(analyzer.DisplayTokens);
         BuildParseTreeGraph(analyzer.ParseContext);
      }

      private void PopulateTokens(IList<TokenViewModel> tokens)
      {
         tokenListView.SetObjects(tokens);
      }

      private void BuildParseTreeGraph(ITree tree)
      {
         if (_Viewer == null)
            return;

         if (tree == null)
            return;

         var grapher = new Graphing.ParseTreeGrapher(tree, _ParserRules)
                          {
                             BackgroundColor = Color.LightBlue, BorderColor = Color.Black, TextColor = Color.Black
                          };
         var graph = grapher.CreateGraph();
         graph.LayoutAlgorithmSettings = new SugiyamaLayoutSettings();
         _Viewer.Graph = graph;
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
         cmbRules.SelectedIndex = cmbRules.FindStringExact(rule);
      }

      private void CodeEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
      {
         ParseSource();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void loadGrammarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var fileToSearch = string.Empty;
         openGrammarFileDialog.InitialDirectory = Environment.CurrentDirectory;

         if (openGrammarFileDialog.ShowDialog() == DialogResult.Cancel)
            return;

         fileToSearch = openGrammarFileDialog.FileName;
         var scanner = new Grammar.Scanner();
         var grammars = scanner.LocateAllGrammarsInFile(fileToSearch);
         var grammarCount = grammars.Count();
         GrammarReference grammarToLoad = null;

         if (grammarCount == 0)
         {
            // TODO: throw error message to user about no grammars found
         }
         else if (grammarCount == 1)
         {
            grammarToLoad = grammars.First();
         }
         else
         {
            var selector = new GrammarSelector();
            selector.GrammarsToSelectFrom = grammars;
            if (selector.ShowDialog() == DialogResult.Cancel)
               return;

            grammarToLoad = selector.SelectedGrammar;
         }

         SetGrammar(grammarToLoad);
      }

      private void VisualAnalyzer_Load(object sender, EventArgs e)
      {
         InitializeGraphCanvas();
         
         if (!string.IsNullOrEmpty(CodeEditor.Text))
            ParseSource();
      }

      private void cmbRules_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cmbRules.Items.Count > 0)
            ParseSource();
      }
   }
}