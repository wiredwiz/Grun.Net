namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   partial class VisualAnalyzer
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualAnalyzer));
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.CodeEditor = new FastColoredTextBoxNS.FastColoredTextBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.lblParserRule = new System.Windows.Forms.Label();
         this.CmbRules = new System.Windows.Forms.ComboBox();
         this.tabControlParse = new System.Windows.Forms.TabControl();
         this.tabParseTree = new System.Windows.Forms.TabPage();
         this.splitContainer3 = new System.Windows.Forms.SplitContainer();
         this.ParseTreeView = new System.Windows.Forms.TreeView();
         this.PnlGraph = new System.Windows.Forms.Panel();
         this.GraphZoomTrackBar = new System.Windows.Forms.TrackBar();
         this.tabTokens = new System.Windows.Forms.TabPage();
         this.tokenListView = new BrightIdeasSoftware.FastObjectListView();
         this.colText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colLine = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colChannel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colStart = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colStop = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colLength = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.tabTrace = new System.Windows.Forms.TabPage();
         this.TraceListView = new BrightIdeasSoftware.FastObjectListView();
         this.colTraceType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colTraceTokenText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colTraceRule = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.TracingContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.selectTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectParserRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadGrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SaveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.GoToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.FindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.selectTokenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.selectParserRuleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.HeuristicHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ShowLexerErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.WordWrapMnuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.TracingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.DiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SimpleLLModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.ParseMessageListView = new BrightIdeasSoftware.ObjectListView();
         this.colLineNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colPosition = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colSource = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
         this.StripLabelGrammar = new System.Windows.Forms.ToolStripStatusLabel();
         this.stripLabelGrammarName = new System.Windows.Forms.ToolStripStatusLabel();
         this.stripLabelNode = new System.Windows.Forms.ToolStripStatusLabel();
         this.stripLabelNodeCount = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelLineCaption = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelLine = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelColumnCaption = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelColumn = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelThrottling = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
         this.StripLabelDelay = new System.Windows.Forms.ToolStripStatusLabel();
         this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).BeginInit();
         this.panel1.SuspendLayout();
         this.tabControlParse.SuspendLayout();
         this.tabParseTree.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
         this.splitContainer3.Panel1.SuspendLayout();
         this.splitContainer3.Panel2.SuspendLayout();
         this.splitContainer3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.GraphZoomTrackBar)).BeginInit();
         this.tabTokens.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).BeginInit();
         this.tabTrace.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.TraceListView)).BeginInit();
         this.TracingContextMenuStrip.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ParseMessageListView)).BeginInit();
         this.StatusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
         this.splitContainer1.Panel1MinSize = 325;
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tabControlParse);
         this.splitContainer1.Size = new System.Drawing.Size(1292, 542);
         this.splitContainer1.SplitterDistance = 433;
         this.splitContainer1.SplitterWidth = 5;
         this.splitContainer1.TabIndex = 0;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.CodeEditor, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 540);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // CodeEditor
         // 
         this.CodeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.CodeEditor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
         this.CodeEditor.AutoIndent = false;
         this.CodeEditor.AutoIndentChars = false;
         this.CodeEditor.AutoScrollMinSize = new System.Drawing.Size(31, 18);
         this.CodeEditor.BackBrush = null;
         this.CodeEditor.CharHeight = 18;
         this.CodeEditor.CharWidth = 10;
         this.CodeEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
         this.CodeEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
         this.CodeEditor.Font = new System.Drawing.Font("Courier New", 9.75F);
         this.CodeEditor.IsReplaceMode = false;
         this.CodeEditor.LeftBracket = '(';
         this.CodeEditor.LeftBracket2 = '[';
         this.CodeEditor.Location = new System.Drawing.Point(4, 54);
         this.CodeEditor.Margin = new System.Windows.Forms.Padding(4);
         this.CodeEditor.Name = "CodeEditor";
         this.CodeEditor.Paddings = new System.Windows.Forms.Padding(0);
         this.CodeEditor.RightBracket = ')';
         this.CodeEditor.RightBracket2 = ']';
         this.CodeEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
         this.CodeEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeEditor.ServiceColors")));
         this.CodeEditor.Size = new System.Drawing.Size(423, 484);
         this.CodeEditor.TabIndex = 0;
         this.CodeEditor.Zoom = 100;
         this.CodeEditor.SelectionChanged += new System.EventHandler(this.CodeEditor_SelectionChanged);
         this.CodeEditor.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeEditor_TextChangedDelayed);
         this.CodeEditor.DragDrop += new System.Windows.Forms.DragEventHandler(this.CodeEditor_DragDrop);
         this.CodeEditor.DragEnter += new System.Windows.Forms.DragEventHandler(this.CodeEditor_DragEnter);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.lblParserRule);
         this.panel1.Controls.Add(this.CmbRules);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(3, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(425, 44);
         this.panel1.TabIndex = 1;
         // 
         // lblParserRule
         // 
         this.lblParserRule.AutoSize = true;
         this.lblParserRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblParserRule.Location = new System.Drawing.Point(4, 9);
         this.lblParserRule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.lblParserRule.Name = "lblParserRule";
         this.lblParserRule.Size = new System.Drawing.Size(113, 25);
         this.lblParserRule.TabIndex = 0;
         this.lblParserRule.Text = "Parser Rule";
         // 
         // CmbRules
         // 
         this.CmbRules.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.CmbRules.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this.CmbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CmbRules.FormattingEnabled = true;
         this.CmbRules.Location = new System.Drawing.Point(135, 5);
         this.CmbRules.Margin = new System.Windows.Forms.Padding(4);
         this.CmbRules.Name = "CmbRules";
         this.CmbRules.Size = new System.Drawing.Size(269, 33);
         this.CmbRules.TabIndex = 0;
         this.CmbRules.SelectedIndexChanged += new System.EventHandler(this.ParserRulesCombo_SelectedIndexChanged);
         // 
         // tabControlParse
         // 
         this.tabControlParse.Controls.Add(this.tabParseTree);
         this.tabControlParse.Controls.Add(this.tabTokens);
         this.tabControlParse.Controls.Add(this.tabTrace);
         this.tabControlParse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlParse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabControlParse.Location = new System.Drawing.Point(0, 0);
         this.tabControlParse.Margin = new System.Windows.Forms.Padding(4);
         this.tabControlParse.Name = "tabControlParse";
         this.tabControlParse.SelectedIndex = 0;
         this.tabControlParse.Size = new System.Drawing.Size(852, 540);
         this.tabControlParse.TabIndex = 0;
         // 
         // tabParseTree
         // 
         this.tabParseTree.Controls.Add(this.splitContainer3);
         this.tabParseTree.Controls.Add(this.GraphZoomTrackBar);
         this.tabParseTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabParseTree.Location = new System.Drawing.Point(4, 34);
         this.tabParseTree.Margin = new System.Windows.Forms.Padding(4);
         this.tabParseTree.Name = "tabParseTree";
         this.tabParseTree.Padding = new System.Windows.Forms.Padding(4);
         this.tabParseTree.Size = new System.Drawing.Size(844, 502);
         this.tabParseTree.TabIndex = 0;
         this.tabParseTree.Text = "Parse Tree";
         this.tabParseTree.UseVisualStyleBackColor = true;
         // 
         // splitContainer3
         // 
         this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer3.Location = new System.Drawing.Point(4, 4);
         this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
         this.splitContainer3.Name = "splitContainer3";
         // 
         // splitContainer3.Panel1
         // 
         this.splitContainer3.Panel1.Controls.Add(this.ParseTreeView);
         // 
         // splitContainer3.Panel2
         // 
         this.splitContainer3.Panel2.Controls.Add(this.PnlGraph);
         this.splitContainer3.Size = new System.Drawing.Size(836, 438);
         this.splitContainer3.SplitterDistance = 187;
         this.splitContainer3.SplitterWidth = 5;
         this.splitContainer3.TabIndex = 1;
         // 
         // ParseTreeView
         // 
         this.ParseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ParseTreeView.Location = new System.Drawing.Point(0, 0);
         this.ParseTreeView.Margin = new System.Windows.Forms.Padding(4);
         this.ParseTreeView.Name = "ParseTreeView";
         this.ParseTreeView.Size = new System.Drawing.Size(187, 438);
         this.ParseTreeView.TabIndex = 0;
         this.ParseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ParseTreeView_AfterSelect);
         this.ParseTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ParseTreeView_NodeMouseClick);
         // 
         // PnlGraph
         // 
         this.PnlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PnlGraph.Location = new System.Drawing.Point(0, 0);
         this.PnlGraph.Margin = new System.Windows.Forms.Padding(4);
         this.PnlGraph.Name = "PnlGraph";
         this.PnlGraph.Size = new System.Drawing.Size(644, 438);
         this.PnlGraph.TabIndex = 0;
         // 
         // GraphZoomTrackBar
         // 
         this.GraphZoomTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.GraphZoomTrackBar.Location = new System.Drawing.Point(4, 442);
         this.GraphZoomTrackBar.Margin = new System.Windows.Forms.Padding(4);
         this.GraphZoomTrackBar.Maximum = 200;
         this.GraphZoomTrackBar.Name = "GraphZoomTrackBar";
         this.GraphZoomTrackBar.Size = new System.Drawing.Size(836, 56);
         this.GraphZoomTrackBar.TabIndex = 2;
         this.GraphZoomTrackBar.ValueChanged += new System.EventHandler(this.GraphZoomTrackBar_ValueChanged);
         // 
         // tabTokens
         // 
         this.tabTokens.Controls.Add(this.tokenListView);
         this.tabTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabTokens.Location = new System.Drawing.Point(4, 34);
         this.tabTokens.Margin = new System.Windows.Forms.Padding(4);
         this.tabTokens.Name = "tabTokens";
         this.tabTokens.Padding = new System.Windows.Forms.Padding(4);
         this.tabTokens.Size = new System.Drawing.Size(844, 504);
         this.tabTokens.TabIndex = 1;
         this.tabTokens.Text = "Tokens";
         this.tabTokens.UseVisualStyleBackColor = true;
         // 
         // tokenListView
         // 
         this.tokenListView.AllColumns.Add(this.colText);
         this.tokenListView.AllColumns.Add(this.colType);
         this.tokenListView.AllColumns.Add(this.colLine);
         this.tokenListView.AllColumns.Add(this.colColumn);
         this.tokenListView.AllColumns.Add(this.colChannel);
         this.tokenListView.AllColumns.Add(this.colStart);
         this.tokenListView.AllColumns.Add(this.colStop);
         this.tokenListView.AllColumns.Add(this.colLength);
         this.tokenListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colText,
            this.colType,
            this.colLine,
            this.colColumn,
            this.colChannel,
            this.colStart,
            this.colStop,
            this.colLength});
         this.tokenListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tokenListView.FullRowSelect = true;
         this.tokenListView.HideSelection = false;
         this.tokenListView.Location = new System.Drawing.Point(4, 4);
         this.tokenListView.Margin = new System.Windows.Forms.Padding(4);
         this.tokenListView.MultiSelect = false;
         this.tokenListView.Name = "tokenListView";
         this.tokenListView.ShowGroups = false;
         this.tokenListView.ShowItemCountOnGroups = true;
         this.tokenListView.Size = new System.Drawing.Size(836, 496);
         this.tokenListView.TabIndex = 0;
         this.tokenListView.UseCompatibleStateImageBehavior = false;
         this.tokenListView.View = System.Windows.Forms.View.Details;
         this.tokenListView.VirtualMode = true;
         this.tokenListView.Click += new System.EventHandler(this.TokenListView_Click);
         // 
         // colText
         // 
         this.colText.AspectName = "DisplayText";
         this.colText.CellPadding = null;
         this.colText.Groupable = false;
         this.colText.Text = "DisplayText";
         this.colText.Width = 102;
         // 
         // colType
         // 
         this.colType.AspectName = "TypeName";
         this.colType.CellPadding = null;
         this.colType.Text = "TypeName";
         this.colType.Width = 119;
         // 
         // colLine
         // 
         this.colLine.AspectName = "Line";
         this.colLine.CellPadding = null;
         this.colLine.Text = "Line";
         // 
         // colColumn
         // 
         this.colColumn.AspectName = "ColumnPosition";
         this.colColumn.CellPadding = null;
         this.colColumn.Groupable = false;
         this.colColumn.Text = "Column";
         this.colColumn.Width = 71;
         // 
         // colChannel
         // 
         this.colChannel.AspectName = "Channel";
         this.colChannel.CellPadding = null;
         this.colChannel.Text = "Channel";
         this.colChannel.Width = 76;
         // 
         // colStart
         // 
         this.colStart.AspectName = "StartIndex";
         this.colStart.CellPadding = null;
         this.colStart.Text = "Start";
         // 
         // colStop
         // 
         this.colStop.AspectName = "StopIndex";
         this.colStop.CellPadding = null;
         this.colStop.Text = "Stop";
         // 
         // colLength
         // 
         this.colLength.AspectName = "Length";
         this.colLength.CellPadding = null;
         this.colLength.Text = "Length";
         this.colLength.Width = 66;
         // 
         // tabTrace
         // 
         this.tabTrace.Controls.Add(this.TraceListView);
         this.tabTrace.Location = new System.Drawing.Point(4, 34);
         this.tabTrace.Margin = new System.Windows.Forms.Padding(4);
         this.tabTrace.Name = "tabTrace";
         this.tabTrace.Size = new System.Drawing.Size(844, 504);
         this.tabTrace.TabIndex = 2;
         this.tabTrace.Text = "Trace";
         this.tabTrace.UseVisualStyleBackColor = true;
         // 
         // TraceListView
         // 
         this.TraceListView.AllColumns.Add(this.colTraceType);
         this.TraceListView.AllColumns.Add(this.colTraceTokenText);
         this.TraceListView.AllColumns.Add(this.colTraceRule);
         this.TraceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTraceType,
            this.colTraceTokenText,
            this.colTraceRule});
         this.TraceListView.ContextMenuStrip = this.TracingContextMenuStrip;
         this.TraceListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.TraceListView.FullRowSelect = true;
         this.TraceListView.HeaderUsesThemes = false;
         this.TraceListView.HideSelection = false;
         this.TraceListView.Location = new System.Drawing.Point(0, 0);
         this.TraceListView.Margin = new System.Windows.Forms.Padding(4);
         this.TraceListView.MultiSelect = false;
         this.TraceListView.Name = "TraceListView";
         this.TraceListView.ShowGroups = false;
         this.TraceListView.ShowSortIndicators = false;
         this.TraceListView.Size = new System.Drawing.Size(844, 504);
         this.TraceListView.SortGroupItemsByPrimaryColumn = false;
         this.TraceListView.TabIndex = 0;
         this.TraceListView.UseCompatibleStateImageBehavior = false;
         this.TraceListView.UseFilterIndicator = true;
         this.TraceListView.UseFiltering = true;
         this.TraceListView.View = System.Windows.Forms.View.Details;
         this.TraceListView.VirtualMode = true;
         this.TraceListView.BeforeSorting += new System.EventHandler<BrightIdeasSoftware.BeforeSortingEventArgs>(this.TraceListView_BeforeSorting);
         // 
         // colTraceType
         // 
         this.colTraceType.AspectName = "TypeName";
         this.colTraceType.CellPadding = null;
         this.colTraceType.Text = "Event TypeName";
         this.colTraceType.Width = 134;
         // 
         // colTraceTokenText
         // 
         this.colTraceTokenText.AspectName = "TokenText";
         this.colTraceTokenText.CellPadding = null;
         this.colTraceTokenText.Text = "Token";
         this.colTraceTokenText.Width = 292;
         // 
         // colTraceRule
         // 
         this.colTraceRule.AspectName = "ParserRule";
         this.colTraceRule.CellPadding = null;
         this.colTraceRule.Text = "Parser Rule";
         this.colTraceRule.Width = 195;
         // 
         // TracingContextMenuStrip
         // 
         this.TracingContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.TracingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectTokenToolStripMenuItem,
            this.selectParserRuleToolStripMenuItem});
         this.TracingContextMenuStrip.Name = "TracingContextMenuStrip";
         this.TracingContextMenuStrip.Size = new System.Drawing.Size(195, 52);
         // 
         // selectTokenToolStripMenuItem
         // 
         this.selectTokenToolStripMenuItem.Name = "selectTokenToolStripMenuItem";
         this.selectTokenToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
         this.selectTokenToolStripMenuItem.Text = "Select Token";
         this.selectTokenToolStripMenuItem.Click += new System.EventHandler(this.SelectTokenToolStripMenuItem_Click);
         // 
         // selectParserRuleToolStripMenuItem
         // 
         this.selectParserRuleToolStripMenuItem.Name = "selectParserRuleToolStripMenuItem";
         this.selectParserRuleToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
         this.selectParserRuleToolStripMenuItem.Text = "Select Parser Rule";
         this.selectParserRuleToolStripMenuItem.Click += new System.EventHandler(this.SelectParserRuleToolStripMenuItem_Click);
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1292, 30);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGrammarToolStripMenuItem,
            this.loadSourceToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveFileToolStripMenuItem,
            this.SaveFileAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // loadGrammarToolStripMenuItem
         // 
         this.loadGrammarToolStripMenuItem.Name = "loadGrammarToolStripMenuItem";
         this.loadGrammarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
         this.loadGrammarToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
         this.loadGrammarToolStripMenuItem.Text = "&Load Grammar";
         this.loadGrammarToolStripMenuItem.Click += new System.EventHandler(this.LoadGrammarToolStripMenuItem_Click);
         // 
         // loadSourceToolStripMenuItem
         // 
         this.loadSourceToolStripMenuItem.Name = "loadSourceToolStripMenuItem";
         this.loadSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this.loadSourceToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
         this.loadSourceToolStripMenuItem.Text = "Load Source &File";
         this.loadSourceToolStripMenuItem.Click += new System.EventHandler(this.LoadSourceToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
         // 
         // SaveFileToolStripMenuItem
         // 
         this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
         this.SaveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
         this.SaveFileToolStripMenuItem.Text = "Save Source";
         this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
         // 
         // SaveFileAsToolStripMenuItem
         // 
         this.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem";
         this.SaveFileAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
         this.SaveFileAsToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
         this.SaveFileAsToolStripMenuItem.Text = "Save Source As";
         this.SaveFileAsToolStripMenuItem.Click += new System.EventHandler(this.SaveFileAsToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(279, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
         this.exitToolStripMenuItem.Text = "E&xit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
         // 
         // EditToolStripMenuItem
         // 
         this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoToToolStripMenuItem,
            this.FindToolStripMenuItem,
            this.ReplaceToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectTokenToolStripMenuItem1,
            this.selectParserRuleToolStripMenuItem1});
         this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
         this.EditToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
         this.EditToolStripMenuItem.Text = "&Edit";
         // 
         // GoToToolStripMenuItem
         // 
         this.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem";
         this.GoToToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
         this.GoToToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
         this.GoToToolStripMenuItem.Text = "Go To";
         this.GoToToolStripMenuItem.Click += new System.EventHandler(this.GoToToolStripMenuItem_Click);
         // 
         // FindToolStripMenuItem
         // 
         this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
         this.FindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
         this.FindToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
         this.FindToolStripMenuItem.Text = "&Find";
         this.FindToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
         // 
         // ReplaceToolStripMenuItem
         // 
         this.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem";
         this.ReplaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
         this.ReplaceToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
         this.ReplaceToolStripMenuItem.Text = "&Replace";
         this.ReplaceToolStripMenuItem.Click += new System.EventHandler(this.ReplaceToolStripMenuItem_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(256, 6);
         // 
         // selectTokenToolStripMenuItem1
         // 
         this.selectTokenToolStripMenuItem1.Name = "selectTokenToolStripMenuItem1";
         this.selectTokenToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
         this.selectTokenToolStripMenuItem1.Size = new System.Drawing.Size(259, 26);
         this.selectTokenToolStripMenuItem1.Text = "Select &Token";
         this.selectTokenToolStripMenuItem1.Click += new System.EventHandler(this.selectTokenToolStripMenuItem1_Click);
         // 
         // selectParserRuleToolStripMenuItem1
         // 
         this.selectParserRuleToolStripMenuItem1.Name = "selectParserRuleToolStripMenuItem1";
         this.selectParserRuleToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
         this.selectParserRuleToolStripMenuItem1.Size = new System.Drawing.Size(259, 26);
         this.selectParserRuleToolStripMenuItem1.Text = "Select Parser &Rule";
         this.selectParserRuleToolStripMenuItem1.Click += new System.EventHandler(this.selectParserRuleToolStripMenuItem1_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HeuristicHighlightingToolStripMenuItem,
            this.ShowLexerErrorsToolStripMenuItem,
            this.WordWrapMnuItem,
            this.toolStripSeparator2,
            this.TracingToolStripMenuItem,
            this.DiagnosticsToolStripMenuItem,
            this.SimpleLLModeToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
         this.optionsToolStripMenuItem.Text = "&Options";
         // 
         // HeuristicHighlightingToolStripMenuItem
         // 
         this.HeuristicHighlightingToolStripMenuItem.Checked = true;
         this.HeuristicHighlightingToolStripMenuItem.CheckOnClick = true;
         this.HeuristicHighlightingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.HeuristicHighlightingToolStripMenuItem.Name = "HeuristicHighlightingToolStripMenuItem";
         this.HeuristicHighlightingToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
         this.HeuristicHighlightingToolStripMenuItem.Text = "Heuristic Syntax Highlighting";
         this.HeuristicHighlightingToolStripMenuItem.Click += new System.EventHandler(this.HeuristicHighlightingToolStripMenuItem_Click);
         // 
         // ShowLexerErrorsToolStripMenuItem
         // 
         this.ShowLexerErrorsToolStripMenuItem.Checked = true;
         this.ShowLexerErrorsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.ShowLexerErrorsToolStripMenuItem.Name = "ShowLexerErrorsToolStripMenuItem";
         this.ShowLexerErrorsToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
         this.ShowLexerErrorsToolStripMenuItem.Text = "Show Lexer Errors";
         // 
         // WordWrapMnuItem
         // 
         this.WordWrapMnuItem.Checked = true;
         this.WordWrapMnuItem.CheckOnClick = true;
         this.WordWrapMnuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.WordWrapMnuItem.Name = "WordWrapMnuItem";
         this.WordWrapMnuItem.Size = new System.Drawing.Size(284, 26);
         this.WordWrapMnuItem.Text = "Word Wrap";
         this.WordWrapMnuItem.CheckStateChanged += new System.EventHandler(this.WordWrapMnuItem_CheckStateChanged);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(281, 6);
         // 
         // TracingToolStripMenuItem
         // 
         this.TracingToolStripMenuItem.CheckOnClick = true;
         this.TracingToolStripMenuItem.Name = "TracingToolStripMenuItem";
         this.TracingToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
         this.TracingToolStripMenuItem.Text = "Tracing";
         this.TracingToolStripMenuItem.Click += new System.EventHandler(this.TracingToolStripMenuItem_Click);
         // 
         // DiagnosticsToolStripMenuItem
         // 
         this.DiagnosticsToolStripMenuItem.CheckOnClick = true;
         this.DiagnosticsToolStripMenuItem.Name = "DiagnosticsToolStripMenuItem";
         this.DiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
         this.DiagnosticsToolStripMenuItem.Text = "Diagnostics";
         this.DiagnosticsToolStripMenuItem.Click += new System.EventHandler(this.DiagnosticsToolStripMenuItem_Click);
         // 
         // SimpleLLModeToolStripMenuItem
         // 
         this.SimpleLLModeToolStripMenuItem.CheckOnClick = true;
         this.SimpleLLModeToolStripMenuItem.Name = "SimpleLLModeToolStripMenuItem";
         this.SimpleLLModeToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
         this.SimpleLLModeToolStripMenuItem.Text = "Simple LL Mode";
         this.SimpleLLModeToolStripMenuItem.Click += new System.EventHandler(this.SimpleLLModeToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
         this.aboutToolStripMenuItem.Text = "&About GrunWin";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
         // 
         // openFileDialog
         // 
         this.openFileDialog.ReadOnlyChecked = true;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 30);
         this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.ParseMessageListView);
         this.splitContainer2.Size = new System.Drawing.Size(1292, 720);
         this.splitContainer2.SplitterDistance = 542;
         this.splitContainer2.SplitterWidth = 5;
         this.splitContainer2.TabIndex = 2;
         // 
         // ParseMessageListView
         // 
         this.ParseMessageListView.AllColumns.Add(this.colLineNumber);
         this.ParseMessageListView.AllColumns.Add(this.colPosition);
         this.ParseMessageListView.AllColumns.Add(this.colSource);
         this.ParseMessageListView.AllColumns.Add(this.colMessage);
         this.ParseMessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLineNumber,
            this.colPosition,
            this.colSource,
            this.colMessage});
         this.ParseMessageListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ParseMessageListView.FullRowSelect = true;
         this.ParseMessageListView.HideSelection = false;
         this.ParseMessageListView.Location = new System.Drawing.Point(0, 0);
         this.ParseMessageListView.Margin = new System.Windows.Forms.Padding(4);
         this.ParseMessageListView.Name = "ParseMessageListView";
         this.ParseMessageListView.ShowGroups = false;
         this.ParseMessageListView.Size = new System.Drawing.Size(1292, 173);
         this.ParseMessageListView.TabIndex = 0;
         this.ParseMessageListView.UseCompatibleStateImageBehavior = false;
         this.ParseMessageListView.View = System.Windows.Forms.View.Details;
         this.ParseMessageListView.Click += new System.EventHandler(this.ParseMessageListView_Click);
         // 
         // colLineNumber
         // 
         this.colLineNumber.AspectName = "Line";
         this.colLineNumber.CellPadding = null;
         this.colLineNumber.Text = "Line";
         // 
         // colPosition
         // 
         this.colPosition.AspectName = "Column";
         this.colPosition.CellPadding = null;
         this.colPosition.Text = "Position";
         // 
         // colSource
         // 
         this.colSource.AspectName = "Source";
         this.colSource.CellPadding = null;
         this.colSource.Text = "Source";
         // 
         // colMessage
         // 
         this.colMessage.AspectName = "Message";
         this.colMessage.CellPadding = null;
         this.colMessage.Text = "Message";
         this.colMessage.Width = 842;
         // 
         // StatusStrip1
         // 
         this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripLabelGrammar,
            this.stripLabelGrammarName,
            this.stripLabelNode,
            this.stripLabelNodeCount,
            this.StripLabelLineCaption,
            this.StripLabelLine,
            this.StripLabelColumnCaption,
            this.StripLabelColumn,
            this.toolStripStatusLabel1,
            this.StripLabelThrottling,
            this.toolStripStatusLabel2,
            this.StripLabelDelay});
         this.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.StatusStrip1.Location = new System.Drawing.Point(0, 750);
         this.StatusStrip1.Name = "StatusStrip1";
         this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
         this.StatusStrip1.Size = new System.Drawing.Size(1292, 29);
         this.StatusStrip1.TabIndex = 3;
         this.StatusStrip1.Text = "statusStrip1";
         // 
         // StripLabelGrammar
         // 
         this.StripLabelGrammar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StripLabelGrammar.Name = "StripLabelGrammar";
         this.StripLabelGrammar.Size = new System.Drawing.Size(92, 23);
         this.StripLabelGrammar.Text = "Grammar:";
         // 
         // stripLabelGrammarName
         // 
         this.stripLabelGrammarName.AutoSize = false;
         this.stripLabelGrammarName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.stripLabelGrammarName.Name = "stripLabelGrammarName";
         this.stripLabelGrammarName.Size = new System.Drawing.Size(100, 17);
         this.stripLabelGrammarName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // stripLabelNode
         // 
         this.stripLabelNode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.stripLabelNode.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
         this.stripLabelNode.Name = "stripLabelNode";
         this.stripLabelNode.Size = new System.Drawing.Size(145, 23);
         this.stripLabelNode.Text = "Parse Tree Nodes:";
         // 
         // stripLabelNodeCount
         // 
         this.stripLabelNodeCount.AutoSize = false;
         this.stripLabelNodeCount.Name = "stripLabelNodeCount";
         this.stripLabelNodeCount.Size = new System.Drawing.Size(40, 17);
         this.stripLabelNodeCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // StripLabelLineCaption
         // 
         this.StripLabelLineCaption.Margin = new System.Windows.Forms.Padding(80, 3, 0, 2);
         this.StripLabelLineCaption.Name = "StripLabelLineCaption";
         this.StripLabelLineCaption.Size = new System.Drawing.Size(24, 20);
         this.StripLabelLineCaption.Text = "Ln";
         // 
         // StripLabelLine
         // 
         this.StripLabelLine.AutoSize = false;
         this.StripLabelLine.Name = "StripLabelLine";
         this.StripLabelLine.Size = new System.Drawing.Size(40, 15);
         this.StripLabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // StripLabelColumnCaption
         // 
         this.StripLabelColumnCaption.Name = "StripLabelColumnCaption";
         this.StripLabelColumnCaption.Size = new System.Drawing.Size(31, 20);
         this.StripLabelColumnCaption.Text = "Col";
         // 
         // StripLabelColumn
         // 
         this.StripLabelColumn.AutoSize = false;
         this.StripLabelColumn.Name = "StripLabelColumn";
         this.StripLabelColumn.Size = new System.Drawing.Size(40, 15);
         this.StripLabelColumn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 20);
         this.toolStripStatusLabel1.Text = "Throttling?";
         // 
         // StripLabelThrottling
         // 
         this.StripLabelThrottling.AutoSize = false;
         this.StripLabelThrottling.Name = "StripLabelThrottling";
         this.StripLabelThrottling.Size = new System.Drawing.Size(40, 15);
         this.StripLabelThrottling.Text = "No";
         this.StripLabelThrottling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // toolStripStatusLabel2
         // 
         this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
         this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 20);
         this.toolStripStatusLabel2.Text = "Delay:";
         // 
         // StripLabelDelay
         // 
         this.StripLabelDelay.AutoSize = false;
         this.StripLabelDelay.Name = "StripLabelDelay";
         this.StripLabelDelay.Size = new System.Drawing.Size(80, 15);
         this.StripLabelDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // VisualAnalyzer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1292, 779);
         this.Controls.Add(this.splitContainer2);
         this.Controls.Add(this.menuStrip1);
         this.Controls.Add(this.StatusStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Margin = new System.Windows.Forms.Padding(4);
         this.Name = "VisualAnalyzer";
         this.Text = "GrunWin Visual Analyzer";
         this.Load += new System.EventHandler(this.VisualAnalyzer_Load);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.tabControlParse.ResumeLayout(false);
         this.tabParseTree.ResumeLayout(false);
         this.tabParseTree.PerformLayout();
         this.splitContainer3.Panel1.ResumeLayout(false);
         this.splitContainer3.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
         this.splitContainer3.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.GraphZoomTrackBar)).EndInit();
         this.tabTokens.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).EndInit();
         this.tabTrace.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.TraceListView)).EndInit();
         this.TracingContextMenuStrip.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
         this.splitContainer2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.ParseMessageListView)).EndInit();
         this.StatusStrip1.ResumeLayout(false);
         this.StatusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Label lblParserRule;
      private FastColoredTextBoxNS.FastColoredTextBox CodeEditor;
      private System.Windows.Forms.ComboBox CmbRules;
      private System.Windows.Forms.TabControl tabControlParse;
      private System.Windows.Forms.TabPage tabParseTree;
      private System.Windows.Forms.TabPage tabTokens;
      private BrightIdeasSoftware.FastObjectListView tokenListView;
      private BrightIdeasSoftware.OLVColumn colText;
      private BrightIdeasSoftware.OLVColumn colLine;
      private BrightIdeasSoftware.OLVColumn colColumn;
      private BrightIdeasSoftware.OLVColumn colChannel;
      private BrightIdeasSoftware.OLVColumn colType;
      private BrightIdeasSoftware.OLVColumn colStart;
      private BrightIdeasSoftware.OLVColumn colStop;
      private BrightIdeasSoftware.OLVColumn colLength;
      private System.Windows.Forms.Panel PnlGraph;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadGrammarToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem TracingToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem DiagnosticsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SimpleLLModeToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private BrightIdeasSoftware.ObjectListView ParseMessageListView;
      private BrightIdeasSoftware.OLVColumn colLineNumber;
      private BrightIdeasSoftware.OLVColumn colPosition;
      private BrightIdeasSoftware.OLVColumn colMessage;
      private System.Windows.Forms.StatusStrip StatusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelGrammar;
      private System.Windows.Forms.ToolStripStatusLabel stripLabelGrammarName;
      private System.Windows.Forms.ToolStripMenuItem loadSourceToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splitContainer3;
      private System.Windows.Forms.TreeView ParseTreeView;
      private System.Windows.Forms.TrackBar GraphZoomTrackBar;
      private System.Windows.Forms.ToolStripMenuItem HeuristicHighlightingToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.TabPage tabTrace;
      private BrightIdeasSoftware.FastObjectListView TraceListView;
      private BrightIdeasSoftware.OLVColumn colTraceType;
      private BrightIdeasSoftware.OLVColumn colTraceTokenText;
      private BrightIdeasSoftware.OLVColumn colTraceRule;
      private System.Windows.Forms.ContextMenuStrip TracingContextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem selectTokenToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectParserRuleToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel stripLabelNode;
      private System.Windows.Forms.ToolStripStatusLabel stripLabelNodeCount;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelLineCaption;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelLine;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelColumnCaption;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelColumn;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelThrottling;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
      private System.Windows.Forms.ToolStripStatusLabel StripLabelDelay;
      private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SaveFileAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem GoToToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem FindToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ShowLexerErrorsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ReplaceToolStripMenuItem;
      private System.Windows.Forms.SaveFileDialog saveFileDialog;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripMenuItem selectTokenToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem selectParserRuleToolStripMenuItem1;
      private BrightIdeasSoftware.OLVColumn colSource;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ToolStripMenuItem WordWrapMnuItem;
   }
}

