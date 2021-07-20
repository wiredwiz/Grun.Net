﻿#region BSD 3-Clause License

// <copyright file="VisualAnalyzer.cs" company="Edgerunner.org">
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using BrightIdeasSoftware;

using FastColoredTextBoxNS;

using JetBrains.Annotations;

using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.Layered;

using Org.Edgerunner.ANTLR4.Tools.Common.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Common.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Common.Syntax;
using Org.Edgerunner.ANTLR4.Tools.Graphing;
using Org.Edgerunner.ANTLR4.Tools.Graphing.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Exceptions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Extensions;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar.Errors;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Dialogs;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Editor.SyntaxHighlighting;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Graphing;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Properties;
using Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Tracing;
using Org.Edgerunner.ANTLR4.Tools.Testing.Monitors;

using Settings = Org.Edgerunner.ANTLR4.Tools.Testing.Configuration.Settings;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   ///    Class that represents an ANTLR grammar test Analyzer.
   ///    Implements the <see cref="System.Windows.Forms.Form" />
   /// </summary>
   /// <seealso cref="System.Windows.Forms.Form" />
   public partial class VisualAnalyzer : Form
   {
      private readonly EditorSyntaxHighlighter _Highlighter = new EditorSyntaxHighlighter();

      private ISyntaxHighlightingGuide _SyntaxGuide;

      private GrammarReference _Grammar;

      private IParseTreeGrapher _Grapher;

      private IGraphWorker _GraphWorker;

      private List<ParseMessage> _ParseErrors;

      private IStyleRegistry _Registry;

      private Settings _Settings;

      private IList<SyntaxToken> _Tokens;

      private GViewer _Viewer;

      private GrammarMonitor _GrammarMonitor;

      private EditorGuideMonitor _GuideMonitor;

      private string _CurrentSourceFile;

      private double _TrackbarZoomIncrement = 0.3;

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="VisualAnalyzer" /> class.
      /// </summary>
      public VisualAnalyzer()
      {
         InitializeComponent();

         LoadApplicationSettings();
      }

      #endregion

      /// <summary>
      ///    Gets or sets a value indicating whether to parse with diagnostics enabled.
      /// </summary>
      /// <value><c>true</c> if diagnostic parsing is enabled; otherwise, <c>false</c>.</value>
      /// <remarks>If SLL is also enabled, SLL will supersede diagnostic mode.</remarks>
      public bool ParseWithDiagnostics
      {
         get => DiagnosticsToolStripMenuItem.Checked;
         set
         {
            DiagnosticsToolStripMenuItem.Checked = value;
            ParseSource();
            ColorizeTokens(null);
         }
      }

      /// <summary>
      ///    Gets or sets a value indicating whether to parse with Simple LL mode.
      /// </summary>
      /// <value><c>true</c> if SLL parsing mode is enabled; otherwise, <c>false</c>.</value>
      /// <remarks>If Diagnostics are also enabled, SLL will supersede diagnostic mode.</remarks>
      public bool ParseWithSllMode
      {
         get => SimpleLLModeToolStripMenuItem.Checked;
         set
         {
            SimpleLLModeToolStripMenuItem.Checked = value;
            ParseSource();
            ColorizeTokens(null);
         }
      }

      /// <summary>
      ///    Gets or sets a value indicating whether to parse with tracing enabled.
      /// </summary>
      /// <value><c>true</c> if tracing is enabled; otherwise, <c>false</c>.</value>
      public bool ParseWithTracing
      {
         get => TracingToolStripMenuItem.Checked;
         set
         {
            TracingToolStripMenuItem.Checked = value;
            ParseSource();
            ColorizeTokens(null);
         }
      }

      /// <summary>
      ///    Gets or sets a value indicating whether to use heuristic syntax highlighting.
      /// </summary>
      /// <value><c>true</c> if heuristic syntax highlighting is enabled; otherwise, <c>false</c>.</value>
      public bool UseHeuristicSyntaxHighlighting
      {
         get => HeuristicHighlightingToolStripMenuItem.Checked;
         set
         {
            HeuristicHighlightingToolStripMenuItem.Checked = value;
            ParseSource();
            ColorizeTokens(null);
         }
      }

      /// <summary>
      ///    Parses the source code.
      /// </summary>
      public void ParseSource()
      {
         if (_Grammar == null)
            return;

         var tokensOnly = _Grammar.Parser == null || string.IsNullOrEmpty(CmbRules.SelectedItem?.ToString());

         var errorListener = new TestingErrorListener();
         var analyzer = new Analyzer();
         var options = ParseOption.Tree;
         GuiTraceListener parseTreeListener = null;
         try
         {
            if (!tokensOnly)
            {
               if (ParseWithDiagnostics) options |= ParseOption.Diagnostics;
               if (ParseWithSllMode) options |= ParseOption.Sll;
               var parser = analyzer.BuildParserWithOptions(_Grammar, CodeEditor.Text, options);
               if (ParseWithTracing)
               {
                  parseTreeListener = new GuiTraceListener(parser);
                  parser.AddParseListener(parseTreeListener);
               }

               parser.RemoveErrorListeners();
               parser.AddErrorListener(errorListener);
               analyzer.ExecuteParsing(parser, CmbRules.SelectedItem.ToString());
            }
            else
               analyzer.Tokenize(_Grammar, CodeEditor.Text);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.SourceParseErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }

         try
         {
            _GraphWorker?.Graph(_Grapher, analyzer.ParserContext, _Grammar.ParserRules);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.GraphQueueErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }

         _Tokens = analyzer.SyntaxTokens;
         _ParseErrors = errorListener.Errors;
         PopulateTokens(analyzer.SyntaxTokens);
         PopulateParserMessages(_ParseErrors);
         PopulateTraceEvents(parseTreeListener);
      }

      /// <summary>
      ///    Sets the default parser rule.
      /// </summary>
      /// <param name="rule">The parser rule.</param>
      /// <exception cref="T:System.ArgumentException">Invalid parser rule.</exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="rule" /> is <see langword="null" /></exception>
      public void SetDefaultParserRule(string rule)
      {
         if (string.IsNullOrEmpty(rule)) throw new ArgumentNullException(nameof(rule));

         if (_Grammar == null)
            throw new InvalidOperationException(Resources.CannotLoadDefaultRuleForNonexistentGrammarMessage);

         if (!_Grammar.ParserRules.Contains(rule))
            throw new GrammarException(string.Format(Resources.InvalidParserRule, rule));

         CmbRules.SelectedIndex = CmbRules.FindStringExact(rule);
      }

      /// <summary>
      ///    Sets the grammar to parse.
      /// </summary>
      /// <param name="grammar">The grammar.</param>
      public void SetGrammar([NotNull] GrammarReference grammar)
      {
         var oldGrammar = _Grammar;
         _Grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));

         LoadParserRules();

         // If our grammar is only being reloaded, no reason to load a new monitor and guide
         if (oldGrammar != null)
            if (oldGrammar.GrammarName == grammar.GrammarName &&
                oldGrammar.AssemblyPath == grammar.AssemblyPath)
               return;

         stripLabelGrammarName.Text = grammar.GrammarName;
         _GrammarMonitor = new GrammarMonitor(grammar, SynchronizationContext.Current);
         _GrammarMonitor.GrammarChanged += GrammarAssemblyChanged;

         // Now try to load an IEditorGuide instance for the specified Grammar
         var guideResult = grammar.LoadSyntaxHighlightingGuide();
         if (guideResult != null)
         {
            _SyntaxGuide = guideResult.Item2;
            _Registry = new StyleRegistry(guideResult.Item2);
            _GuideMonitor = new EditorGuideMonitor(guideResult.Item1, SynchronizationContext.Current);
            _GuideMonitor.GuideChanged += GuideAssemblyChanged;
         }
         else
         {
            _SyntaxGuide = null;
            _GuideMonitor = null;
            _Registry = new StyleRegistry(new HeuristicSyntaxHighlightingGuide(_Settings));
         }
      }

      private void GuideAssemblyChanged(object sender, SyntaxHighlightingGuideReference e)
      {
         var loader = new Loader();
         var guide = loader.LoadSyntaxGuide(e);
         if (guide != null)
         {
            _SyntaxGuide = guide;
            _Registry = new StyleRegistry(_SyntaxGuide);
            ColorizeTokens(null);
         }
      }

      private void GrammarAssemblyChanged(object sender, GrammarReference e)
      {
         var grammar = FetchGrammarInternal(e.AssemblyPath, e.GrammarName);
         SetGrammar(grammar);
         ParseSource();
         ColorizeTokens(null);
      }

      /// <summary>
      ///    Sets the source code to be analyzed.
      /// </summary>
      /// <param name="code">The code.</param>
      public void SetSourceCode(string code)
      {
         CodeEditor.Text = code;
         _CurrentSourceFile = null;
      }

      private void GraphingFinished(object sender, GraphingResult e)
      {
         BuildParseTreeTreeViewGuide(e.ParseTree);
         RenderParseTreeGraph(e.Graph);
         if (e.Graph != null)
            stripLabelNodeCount.Text = e.Graph.Nodes.Count().ToString();

         if (sender is IGraphWorker worker)
         {
            StripLabelThrottling.Text = worker.CurrentlyThrottling ? Resources.Yes : Resources.No;
            StripLabelDelay.Text = worker.CurrentMillisecondDelayBetweenGraphs + Resources.MillisecondsAbbreviation;
         }
         else
         {
            StripLabelThrottling.Text = Resources.No;
            StripLabelDelay.Text = Resources.ZeroMilliseconds;
         }
      }

      private void Viewer_Click(object sender, EventArgs e)
      {
         if (_Viewer.SelectedObject is Node node)
         {
            CodeEditor.SelectSource(node.UserData as ITree ?? throw new InvalidOperationException());
            CodeEditor.Focus();
         }
      }

      private void Viewer_MouseWheel(object sender, MouseEventArgs e)
      {
         var factor = Math.Max(
            Math.Min((int)Math.Round((_Viewer.ZoomF - 1.0) / _TrackbarZoomIncrement), GraphZoomTrackBar.Maximum),
            GraphZoomTrackBar.Minimum);
         GraphZoomTrackBar.Value = factor;
         Debug.WriteLine($"Scroll zoom factor {factor}");
      }

      private void AddTreeBranchesAndLeaves(TreeNode treeNode, ITree tree)
      {
         for (var i = 0; i < tree.ChildCount; i++)
         {
            var child = tree.GetChild(i);
            var newNode =
               new TreeNode(Trees.GetNodeText(child, _Grammar.ParserRules))
               {
                  Tag = child,
                  Name = child.GetHashCode().ToString()
               };
            treeNode.Nodes.Add(newNode);
            AddTreeBranchesAndLeaves(newNode, child);
         }
      }

      private void BuildParseTreeTreeViewGuide(ITree tree)
      {
         ParseTreeView.SuspendLayout();
         ParseTreeView.Nodes.Clear();

         if (tree == null)
         {
            ParseTreeView.ResumeLayout();
            return;
         }

         var treeNode =
            new TreeNode(Trees.GetNodeText(tree, _Grammar.ParserRules)) { Tag = tree, Name = tree.GetHashCode().ToString() };
         ParseTreeView.Nodes.Add(treeNode);
         AddTreeBranchesAndLeaves(treeNode, tree);

         ParseTreeView.ResumeLayout();
      }

      private void SetNewWorkingDirectoryUsingFile(string fileName)
      {
         if (!string.IsNullOrEmpty(fileName))
         {
            var directory = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(directory))
               Environment.CurrentDirectory = directory;
         }
      }

      // ReSharper disable once TooManyDeclarations
      // ReSharper disable once ExcessiveIndentation
      private void CodeEditor_DragDrop(object sender, DragEventArgs e)
      {
         try
         {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
               CodeEditor.SelectAll();
               CodeEditor.Text = e.Data.GetData(DataFormats.Text).ToString();
            }
            else if (e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
               CodeEditor.SelectAll();
               CodeEditor.Text = e.Data.GetData(DataFormats.UnicodeText).ToString();
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
               if (e.Data.GetData(DataFormats.FileDrop) is string[] files)
               {
                  SetNewWorkingDirectoryUsingFile(files[0]);
                  var assemblyFiles = (from file in files where file.EndsWith(".dll") select file).ToList();
                  var otherFiles = (from file in files where !file.EndsWith(".dll") select file).ToList();
                  if (assemblyFiles.Count > 1 || (assemblyFiles.Count + otherFiles.Count > 2))
                  {
                     MessageBox.Show(Resources.DragDropLoadErrorMessage);
                     return;
                  }

                  if (assemblyFiles.Count != 0)
                  {
                     var grammar = FetchGrammarInternal(assemblyFiles[0]);
                     if (grammar != null)
                        SetGrammar(grammar);
                  }

                  if (otherFiles.Count != 0)
                     LoadSourceFileInternal(otherFiles[0]);
               }
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.SourceLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void CodeEditor_DragEnter(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.UnicodeText) || e.Data.GetDataPresent(DataFormats.Text)
                                                            || e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
         else
            e.Effect = DragDropEffects.None;
      }

      private List<IToken> GetErrorTokens()
      {
         var result = new List<IToken>();

         if (_ParseErrors == null)
            return result;

         foreach (var error in _ParseErrors)
            if (error.Token != null)
               result.Add(error.Token);

         return result;
      }

      private void ColorizeTokens(Range range)
      {
         if (_Registry == null)
            return;

         if (CodeEditor.Handle == IntPtr.Zero)
            return;

         var tokensToColor = range == null ? _Tokens : FindTokensInRange(_Tokens, range);
         _Highlighter.ColorizeTokens(CodeEditor, _Registry, tokensToColor, GetErrorTokens());
      }

      private void ConfigureGraphWorker()
      {
         _GraphWorker = new GraphWorker(SynchronizationContext.Current, _Settings);
         _GraphWorker.GraphingFinished += GraphingFinished;
         _GraphWorker.ThrottleStatusChanged += ThrottleStatusChanged;
         _Grapher = new ParseTreeGrapher
         {
            BackgroundColor = _Settings.GraphNodeBackgroundColor.GetMsAglColor(),
            BorderColor = _Settings.GraphNodeBorderColor.GetMsAglColor(),
            TextColor = _Settings.GraphNodeTextColor.GetMsAglColor()
         };
      }

      private void ThrottleStatusChanged(object sender, EventArgs e)
      {
         if (sender is IGraphWorker worker)
         {
            if (worker.LongDelayActive && StripLabelDelay.Text != Resources.Long)
               StripLabelDelay.Text = Resources.Long;
         }
      }

      private void DiagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ParseSource();
         ColorizeTokens(null);
      }

      private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private IList<SyntaxToken> FindTokensInRange(IList<SyntaxToken> tokens, Range range)
      {
         var results = new List<SyntaxToken>();
         var startLine = range.FromLine;
         var stopLine = range.ToLine + 2;

         foreach (var token in tokens)
         {
            if (token.LineNumber < startLine || token.LineNumber > stopLine)
               continue;

            results.Add(token);
         }

         return results;
      }

      private void GraphZoomTrackBar_ValueChanged(object sender, EventArgs e)
      {
         if (_Viewer != null)
            _Viewer.ZoomF = (GraphZoomTrackBar.Value * _TrackbarZoomIncrement) + 1.0;
      }

      private void HeuristicHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (HeuristicHighlightingToolStripMenuItem.Checked)
         {
            ColorizeTokens(null);
         }
         else
            CodeEditor.ClearStyle(StyleIndex.All);
      }

      private void InitializeGraphCanvas()
      {
         SuspendLayout();
         _Viewer = new GViewer();
         PnlGraph.Controls.Add(_Viewer);
         _Viewer.Dock = DockStyle.Fill;
         ResumeLayout();
         _Viewer.LayoutAlgorithmSettingsButtonVisible = false;
         _Viewer.Click += Viewer_Click;
         _Viewer.MouseWheel += Viewer_MouseWheel;
         var viewerContextMenu = new ContextMenu();
         var menuItem = viewerContextMenu.MenuItems.Add("Graph from here");
         menuItem.Click += Menu_GraphFromHere_Click;
         _Viewer.ContextMenu = viewerContextMenu;
      }

      private void LoadApplicationSettings()
      {
         _Settings = new Settings();
         var pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         if (pathRoot != null)
         {
            var configFile = Path.Combine(pathRoot, Resources.AppconfigFile);
            if (File.Exists(configFile))
            {
               _Settings.LoadFrom(configFile);
               return;
            }
         }

         _Settings.LoadDefaults();
      }

      private GrammarReference FetchGrammarInternal(string fileToSearch, string grammarName = "")
      {
         var scanner = new Scanner();
         IEnumerable<GrammarReference> grammars;
         try
         {
            grammars = scanner.LocateAllGrammarsInFile(fileToSearch);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.GrammarLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
            return null;
         }

         var selectableGrammars = grammars as GrammarReference[] ?? grammars.ToArray();
         if (!string.IsNullOrEmpty(grammarName))
            selectableGrammars = (from grammar in selectableGrammars where grammar.GrammarName == grammarName select grammar).ToArray();
         var grammarCount = selectableGrammars.Length;
         GrammarReference foundGrammar;

         switch (grammarCount)
         {
            case 0:
               MessageBox.Show(string.Format(Resources.NoGrammarsFoundInAssembly, Path.GetFileName(fileToSearch)));
               return null;
            case 1:
               foundGrammar = selectableGrammars.First();
               break;
            default:
               {
                  var selector = new GrammarSelector { GrammarsToSelectFrom = selectableGrammars };
                  if (selector.ShowDialog(this) == DialogResult.Cancel)
                     return null;

                  foundGrammar = selector.SelectedGrammar;
                  break;
               }
         }

         return foundGrammar;
      }

      private void LoadGrammarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = Resources.AssemblyFileFilter;
            openFileDialog.DefaultExt = "dll";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
               return;

            var fileToSearch = openFileDialog.FileName;
            if (!string.IsNullOrEmpty(fileToSearch))
            {
               SetNewWorkingDirectoryUsingFile(fileToSearch);
               var grammar = FetchGrammarInternal(fileToSearch);
               if (grammar != null)
                  SetGrammar(grammar);
            }
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.GrammarLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void LoadParserRules()
      {
         var rules = _Grammar == null ? new List<string>() : _Grammar.ParserRules;
         var currentRule = CmbRules.SelectedItem as string;
         CmbRules.DataSource = rules.OrderBy(x => x).Distinct().ToList();
         if (!string.IsNullOrEmpty(currentRule))
         {
            var index = CmbRules.FindStringExact(currentRule);
            if (index != -1)
               CmbRules.SelectedIndex = index;
         }
         CmbRules.Refresh();
      }

      private void LoadSourceFileInternal(string fileToLoad)
      {
         try
         {
            using (var reader = new StreamReader(fileToLoad))
            {
               SetSourceCode(reader.ReadToEnd());
            }

            _CurrentSourceFile = fileToLoad;
         }
         catch (ArgumentException)
         {
         }
         catch (FileNotFoundException)
         {
            MessageBox.Show(string.Format(Resources.FileNotFoundMessage, fileToLoad));
         }
         catch (DirectoryNotFoundException)
         {
            MessageBox.Show(Resources.FileLoadFailedMessage);
         }
         catch (IOException)
         {
            MessageBox.Show(Resources.FileLoadFailedMessage);
         }
      }

      public void LoadSourceFile(string fileToLoad, Encoding encoding)
      {
         using (var reader = new StreamReader(fileToLoad, encoding))
         {
            SetSourceCode(reader.ReadToEnd());
         }

         _CurrentSourceFile = fileToLoad;
      }

      public void LoadSourceFile(string fileToLoad)
      {
         LoadSourceFile(fileToLoad, Encoding.Default);
      }
      
      private void LoadSourceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = Resources.AllFilesFilter;

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
               return;

            var fileToLoad = openFileDialog.FileName;
            SetNewWorkingDirectoryUsingFile(fileToLoad);
            LoadSourceFileInternal(fileToLoad);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.SourceLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void Menu_GraphFromHere_Click(object sender, EventArgs e)
      {
         if (_Viewer.SelectedObject is Node node)
         {
            var treeNodes = ParseTreeView.Nodes.Find(node.UserData?.GetHashCode().ToString(), true);
            if (treeNodes.Length != 0)
            {
               var workingNode = treeNodes.First();
               ParseTreeView.SelectedNode = workingNode;
               RenderParseTreeGraph(workingNode.Tag as ITree, 0);
               ParseTreeView.Focus();
            }
         }
      }

      private void ParseMessageListView_Click(object sender, EventArgs e)
      {
         OLVListItem selected;
         if ((selected = ParseMessageListView.SelectedItem) != null)
            if (selected.RowObject != null)
            {
               var message = (ParseMessage)selected.RowObject;
               CodeEditor.SelectSource(message.Token);
               CodeEditor.Focus();
            }
      }

      private void ParserRulesCombo_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (CmbRules.Items.Count > 0)
         {
            ParseSource();
            ColorizeTokens(null);
         }
      }

      private void ParseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
      {
         // Now we graph and display just the selected branch
         if (e.Node.Tag is ITree selected)
         {
            RenderParseTreeGraph(selected);
            CodeEditor.SelectSource(selected);
         }
      }

      private void ParseTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         if (sender is TreeView viewer)
         {
            if (viewer.SelectedNode == e.Node)
               // Now we graph and display just the selected branch
               if (e.Node.Tag is ITree selected)
               {
                  RenderParseTreeGraph(selected);
                  CodeEditor.SelectSource(selected);
               }
         }
      }

      private void PopulateParserMessages(List<ParseMessage> listenerErrors)
      {
         ParseMessageListView.SetObjects(listenerErrors);
      }

      private void PopulateTokens(IList<SyntaxToken> tokens)
      {
         tokenListView.SetObjects(tokens);
      }

      private void PopulateTraceEvents(GuiTraceListener parseTreeListener)
      {
         if (parseTreeListener == null)
            TraceListView.SetObjects(null);
         else
            TraceListView.SetObjects(parseTreeListener.Events);
      }

      private void RenderParseTreeGraph(ITree tree, int? zoomFactor = null)
      {
         if (_Viewer == null)
            return;

         if (_Grammar == null)
            return;

         if (tree == null)
            return;

         if (_Grapher == null)
            return;

         try
         {
            var graph = _Grapher.CreateGraph(tree, _Grammar.ParserRules);
            graph.LayoutAlgorithmSettings = new SugiyamaLayoutSettings();
            _Viewer.SuspendLayout();
            _Viewer.Graph = graph;
            if (zoomFactor.HasValue)
               GraphZoomTrackBar.Value = zoomFactor.Value;
            _Viewer.ZoomF = (GraphZoomTrackBar.Value * _TrackbarZoomIncrement) + 1.0;
            _Viewer.ResumeLayout();
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.GraphRenderErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void RenderParseTreeGraph(Graph graph, int? zoomFactor = null)
      {
         if (_Viewer == null)
            return;

         _Viewer.SuspendLayout();
         _Viewer.Graph = graph;
         if (zoomFactor.HasValue)
            GraphZoomTrackBar.Value = zoomFactor.Value;
         _Viewer.ZoomF = (GraphZoomTrackBar.Value * _TrackbarZoomIncrement) + 1.0;
         _Viewer.ResumeLayout();
      }

      private void SelectParserRuleToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var graph = _Viewer?.Graph;
         if (graph != null)
         {
            OLVListItem selected;
            if ((selected = TraceListView.SelectedItem) != null)
               if (selected.RowObject != null)
               {
                  var traceEvent = (TraceEvent)selected.RowObject;
                  CodeEditor.SelectSource(traceEvent.ParserRuleContext);
               }
         }
      }

      private void SelectTokenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OLVListItem selected;
         if ((selected = TraceListView.SelectedItem) != null)
            if (selected.RowObject != null)
            {
               var traceEvent = (TraceEvent)selected.RowObject;
               CodeEditor.SelectSource(traceEvent.Token);
               var model =
                  (from token in _Tokens where token.ActualParserToken == traceEvent.Token select token).First();
               tokenListView.SelectObject(model);
            }
      }

      private void SimpleLLModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ParseSource();
         ColorizeTokens(null);
      }

      private void TokenListView_Click(object sender, EventArgs e)
      {
         OLVListItem selected;
         if ((selected = tokenListView.SelectedItem) != null)
            if (selected.RowObject != null)
            {
               var tokenView = (SyntaxToken)selected.RowObject;
               CodeEditor.SelectSource(tokenView.ActualParserToken);
            }
      }

      private void TraceListView_BeforeSorting(object sender, BeforeSortingEventArgs e)
      {
         e.Canceled = true;
      }

      private void TracingToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ParseSource();
      }

      private void VisualAnalyzer_Load(object sender, EventArgs e)
      {
         InitializeGraphCanvas();
         ConfigureGraphWorker();
         ConfigureParserMessageWindow();

         ConfigureEditorSettings();
         ParseMessageListView.Font = new Font(_Settings.ParserMessageFontFamily, _Settings.ParserMessageFontSize);

         // Handle initial parse and coloring on load
         ParseSource();
         ColorizeTokens(null);
      }

      private void ConfigureEditorSettings()
      {
         CodeEditor.Font = new Font(_Settings.EditorFontFamily, _Settings.EditorFontSize);
         CodeEditor.ForeColor = _Settings.EditorTextColor;
         CodeEditor.CaretColor = _Settings.EditorCaretColor;
         CodeEditor.BackColor = _Settings.EditorBackgroundColor;
         CodeEditor.CurrentLineColor = _Settings.EditorCurrentLineColor;
         CodeEditor.AutoIndent = _Settings.EditorAutoIndent;
         CodeEditor.WordWrapIndent = _Settings.EditorWordWrapIndent;
         CodeEditor.WordWrap = _Settings.EditorWordWrap;
         CodeEditor.AutoCompleteBrackets = _Settings.EditorAutoBrackets;
         CodeEditor.TabLength = _Settings.EditorTabLength;
         CodeEditor.LineNumberColor = _Settings.EditorLineNumberColor;
      }

      private void ConfigureParserMessageWindow()
      {
         var font = new Font(_Settings.EditorFontFamily, _Settings.EditorFontSize);
         ParseMessageListView.Font = font;
      }

      private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var aboutBox = new AboutBox();

         aboutBox.ShowDialog(this);
      }

      private void CodeEditor_SelectionChanged(object sender, EventArgs e)
      {
         StripLabelLine.Text = (CodeEditor.Selection.Start.iLine + 1).ToString();
         StripLabelColumn.Text = (CodeEditor.Selection.Start.iChar + 1).ToString();
      }

      private void CodeEditor_TextChangedDelayed(object sender, TextChangedEventArgs e)
      {
         if (string.IsNullOrEmpty(CodeEditor.Text))
            CodeEditor.ClearStyle(StyleIndex.All);
         else
         {
            ParseSource();
            ColorizeTokens(null);
         }
      }

      private void SelectTokenFromSource(Common.Grammar.Place sourcePlace)
      {
         foreach (var token in _Tokens)
           if (token.LineNumber == sourcePlace.Line)
           {
             if (sourcePlace.IsWithinTokenBounds(token))
             {
               // We have found the related source token, now we select it in the list and source.
               tokenListView.SelectedObject = token;
               var selectedPos = tokenListView.SelectedItem.Position;
               int offset = (tokenListView.RowHeightEffective + 2) * tokenListView.RowsPerPage / 2;
               tokenListView.LowLevelScroll(0, selectedPos.Y - offset);
               CodeEditor.SelectSource(token.ActualParserToken);
               tabControlParse.SelectTab(1);
               CodeEditor.Select();
             }
           }
      }

      private void SelectParserRuleFromSource(Common.Grammar.Place sourcePlace)
      {
         // TODO: Add code to do the selection
      }

      private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CodeEditor.ShowGoToDialog();
      }

      private void FindToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CodeEditor.ShowFindDialog();
      }

      private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CodeEditor.ShowReplaceDialog();
      }

      private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (string.IsNullOrEmpty(_CurrentSourceFile))
            {
               saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
               saveFileDialog.Filter = Resources.AllFilesFilter;

               if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                  return;
            }

            var fileToWrite = _CurrentSourceFile ?? saveFileDialog.FileName;
            File.WriteAllText(fileToWrite, CodeEditor.Text);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.SourceLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void SaveFileAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = Resources.AllFilesFilter;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
               return;

            var fileToWrite = saveFileDialog.FileName;
            File.WriteAllText(fileToWrite, CodeEditor.Text);
         }
         catch (Exception ex)
         {
            var errorDisplay = new ErrorDisplay
            {
               Text = Resources.SourceLoadErrorTitle,
               ErrorMessage = ex.Message,
               ErrorStackTrace = ex.StackTrace
            };
            errorDisplay.ShowDialog();
         }
      }

      private void selectTokenToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         SelectTokenFromSource(
            new Common.Grammar.Place(
               CodeEditor.Selection.Start.iLine + 1, 
               CodeEditor.Selection.Start.iChar));
      }

      private void selectParserRuleToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         SelectParserRuleFromSource(
            new Common.Grammar.Place(
               CodeEditor.Selection.Start.iLine + 1, 
               CodeEditor.Selection.Start.iChar));
      }
   }
}