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
         this.CmbRules = new System.Windows.Forms.ComboBox();
         this.lblParserRule = new System.Windows.Forms.Label();
         this.CodeEditor = new FastColoredTextBoxNS.FastColoredTextBox();
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadGrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.HeuristicHighlightingtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.TracingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.DiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SimpleLLModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.ParseMessageListView = new BrightIdeasSoftware.ObjectListView();
         this.colLineNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colPosition = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
         this.StripLabelGrammar = new System.Windows.Forms.ToolStripStatusLabel();
         this.stripLabelGrammarName = new System.Windows.Forms.ToolStripStatusLabel();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).BeginInit();
         this.tabControlParse.SuspendLayout();
         this.tabParseTree.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
         this.splitContainer3.Panel1.SuspendLayout();
         this.splitContainer3.Panel2.SuspendLayout();
         this.splitContainer3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.GraphZoomTrackBar)).BeginInit();
         this.tabTokens.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).BeginInit();
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
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.CmbRules);
         this.splitContainer1.Panel1.Controls.Add(this.lblParserRule);
         this.splitContainer1.Panel1.Controls.Add(this.CodeEditor);
         this.splitContainer1.Panel1MinSize = 325;
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tabControlParse);
         this.splitContainer1.Size = new System.Drawing.Size(969, 443);
         this.splitContainer1.SplitterDistance = 325;
         this.splitContainer1.TabIndex = 0;
         // 
         // CmbRules
         // 
         this.CmbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CmbRules.FormattingEnabled = true;
         this.CmbRules.Location = new System.Drawing.Point(110, 6);
         this.CmbRules.Name = "CmbRules";
         this.CmbRules.Size = new System.Drawing.Size(203, 28);
         this.CmbRules.TabIndex = 0;
         this.CmbRules.SelectedIndexChanged += new System.EventHandler(this.ParserRulesCombo_SelectedIndexChanged);
         // 
         // lblParserRule
         // 
         this.lblParserRule.AutoSize = true;
         this.lblParserRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblParserRule.Location = new System.Drawing.Point(12, 9);
         this.lblParserRule.Name = "lblParserRule";
         this.lblParserRule.Size = new System.Drawing.Size(92, 20);
         this.lblParserRule.TabIndex = 0;
         this.lblParserRule.Text = "Parser Rule";
         // 
         // CodeEditor
         // 
         this.CodeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.CodeEditor.AutoCompleteBrackets = true;
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
         this.CodeEditor.AutoScrollMinSize = new System.Drawing.Size(27, 14);
         this.CodeEditor.BackBrush = null;
         this.CodeEditor.CharHeight = 14;
         this.CodeEditor.CharWidth = 8;
         this.CodeEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
         this.CodeEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
         this.CodeEditor.IsReplaceMode = false;
         this.CodeEditor.LeftBracket = '(';
         this.CodeEditor.LeftBracket2 = '[';
         this.CodeEditor.Location = new System.Drawing.Point(3, 40);
         this.CodeEditor.Name = "CodeEditor";
         this.CodeEditor.Paddings = new System.Windows.Forms.Padding(0);
         this.CodeEditor.RightBracket = ')';
         this.CodeEditor.RightBracket2 = ']';
         this.CodeEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
         this.CodeEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeEditor.ServiceColors")));
         this.CodeEditor.Size = new System.Drawing.Size(317, 398);
         this.CodeEditor.TabIndex = 0;
         this.CodeEditor.Zoom = 100;
         this.CodeEditor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeEditor_TextChanged);
         // 
         // tabControlParse
         // 
         this.tabControlParse.Controls.Add(this.tabParseTree);
         this.tabControlParse.Controls.Add(this.tabTokens);
         this.tabControlParse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlParse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabControlParse.Location = new System.Drawing.Point(0, 0);
         this.tabControlParse.Name = "tabControlParse";
         this.tabControlParse.SelectedIndex = 0;
         this.tabControlParse.Size = new System.Drawing.Size(638, 441);
         this.tabControlParse.TabIndex = 0;
         // 
         // tabParseTree
         // 
         this.tabParseTree.Controls.Add(this.splitContainer3);
         this.tabParseTree.Controls.Add(this.GraphZoomTrackBar);
         this.tabParseTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabParseTree.Location = new System.Drawing.Point(4, 29);
         this.tabParseTree.Name = "tabParseTree";
         this.tabParseTree.Padding = new System.Windows.Forms.Padding(3);
         this.tabParseTree.Size = new System.Drawing.Size(630, 408);
         this.tabParseTree.TabIndex = 0;
         this.tabParseTree.Text = "Parse Tree";
         this.tabParseTree.UseVisualStyleBackColor = true;
         // 
         // splitContainer3
         // 
         this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer3.Location = new System.Drawing.Point(3, 3);
         this.splitContainer3.Name = "splitContainer3";
         // 
         // splitContainer3.Panel1
         // 
         this.splitContainer3.Panel1.Controls.Add(this.ParseTreeView);
         // 
         // splitContainer3.Panel2
         // 
         this.splitContainer3.Panel2.Controls.Add(this.PnlGraph);
         this.splitContainer3.Size = new System.Drawing.Size(624, 357);
         this.splitContainer3.SplitterDistance = 140;
         this.splitContainer3.TabIndex = 1;
         // 
         // ParseTreeView
         // 
         this.ParseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ParseTreeView.Location = new System.Drawing.Point(0, 0);
         this.ParseTreeView.Name = "ParseTreeView";
         this.ParseTreeView.Size = new System.Drawing.Size(140, 357);
         this.ParseTreeView.TabIndex = 0;
         this.ParseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ParseTreeView_AfterSelect);
         // 
         // PnlGraph
         // 
         this.PnlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PnlGraph.Location = new System.Drawing.Point(0, 0);
         this.PnlGraph.Name = "PnlGraph";
         this.PnlGraph.Size = new System.Drawing.Size(480, 357);
         this.PnlGraph.TabIndex = 0;
         // 
         // GraphZoomTrackBar
         // 
         this.GraphZoomTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.GraphZoomTrackBar.Location = new System.Drawing.Point(3, 360);
         this.GraphZoomTrackBar.Maximum = 200;
         this.GraphZoomTrackBar.Name = "GraphZoomTrackBar";
         this.GraphZoomTrackBar.Size = new System.Drawing.Size(624, 45);
         this.GraphZoomTrackBar.TabIndex = 2;
         this.GraphZoomTrackBar.ValueChanged += new System.EventHandler(this.GraphZoomTrackBar_ValueChanged);
         // 
         // tabTokens
         // 
         this.tabTokens.Controls.Add(this.tokenListView);
         this.tabTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabTokens.Location = new System.Drawing.Point(4, 29);
         this.tabTokens.Name = "tabTokens";
         this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
         this.tabTokens.Size = new System.Drawing.Size(630, 408);
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
         this.tokenListView.Location = new System.Drawing.Point(3, 3);
         this.tokenListView.MultiSelect = false;
         this.tokenListView.Name = "tokenListView";
         this.tokenListView.ShowGroups = false;
         this.tokenListView.ShowItemCountOnGroups = true;
         this.tokenListView.Size = new System.Drawing.Size(624, 402);
         this.tokenListView.TabIndex = 0;
         this.tokenListView.UseCompatibleStateImageBehavior = false;
         this.tokenListView.View = System.Windows.Forms.View.Details;
         this.tokenListView.VirtualMode = true;
         this.tokenListView.Click += new System.EventHandler(this.TokenListView_Click);
         // 
         // colText
         // 
         this.colText.AspectName = "Text";
         this.colText.CellPadding = null;
         this.colText.Groupable = false;
         this.colText.Text = "Text";
         this.colText.Width = 102;
         // 
         // colType
         // 
         this.colType.AspectName = "Type";
         this.colType.CellPadding = null;
         this.colType.Text = "Type";
         this.colType.Width = 119;
         // 
         // colLine
         // 
         this.colLine.AspectName = "LineNumber";
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
         this.colChannel.AspectName = "ChannelId";
         this.colChannel.CellPadding = null;
         this.colChannel.Text = "Channel";
         this.colChannel.Width = 76;
         // 
         // colStart
         // 
         this.colStart.AspectName = "StartPosition";
         this.colStart.CellPadding = null;
         this.colStart.Text = "Start";
         // 
         // colStop
         // 
         this.colStop.AspectName = "StopPosition";
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
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(969, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGrammarToolStripMenuItem,
            this.loadSourceToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // loadGrammarToolStripMenuItem
         // 
         this.loadGrammarToolStripMenuItem.Name = "loadGrammarToolStripMenuItem";
         this.loadGrammarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.loadGrammarToolStripMenuItem.Text = "&Load Grammar";
         this.loadGrammarToolStripMenuItem.Click += new System.EventHandler(this.LoadGrammarToolStripMenuItem_Click);
         // 
         // loadSourceToolStripMenuItem
         // 
         this.loadSourceToolStripMenuItem.Name = "loadSourceToolStripMenuItem";
         this.loadSourceToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.loadSourceToolStripMenuItem.Text = "Load Source &File";
         this.loadSourceToolStripMenuItem.Click += new System.EventHandler(this.LoadSourceToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.exitToolStripMenuItem.Text = "E&xit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HeuristicHighlightingtToolStripMenuItem,
            this.toolStripSeparator2,
            this.TracingToolStripMenuItem,
            this.DiagnosticsToolStripMenuItem,
            this.SimpleLLModeToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "&Options";
         // 
         // HeuristicHighlightingtToolStripMenuItem
         // 
         this.HeuristicHighlightingtToolStripMenuItem.Checked = true;
         this.HeuristicHighlightingtToolStripMenuItem.CheckOnClick = true;
         this.HeuristicHighlightingtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.HeuristicHighlightingtToolStripMenuItem.Name = "HeuristicHighlightingtToolStripMenuItem";
         this.HeuristicHighlightingtToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this.HeuristicHighlightingtToolStripMenuItem.Text = "Heuristic Syntax Highlighting";
         this.HeuristicHighlightingtToolStripMenuItem.Click += new System.EventHandler(this.HeuristicHighlightingtToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
         // 
         // TracingToolStripMenuItem
         // 
         this.TracingToolStripMenuItem.CheckOnClick = true;
         this.TracingToolStripMenuItem.Name = "TracingToolStripMenuItem";
         this.TracingToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this.TracingToolStripMenuItem.Text = "Tracing";
         this.TracingToolStripMenuItem.Click += new System.EventHandler(this.TracingToolStripMenuItem_Click);
         // 
         // DiagnosticsToolStripMenuItem
         // 
         this.DiagnosticsToolStripMenuItem.CheckOnClick = true;
         this.DiagnosticsToolStripMenuItem.Name = "DiagnosticsToolStripMenuItem";
         this.DiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this.DiagnosticsToolStripMenuItem.Text = "Diagnostics";
         this.DiagnosticsToolStripMenuItem.Click += new System.EventHandler(this.DiagnosticsToolStripMenuItem_Click);
         // 
         // SimpleLLModeToolStripMenuItem
         // 
         this.SimpleLLModeToolStripMenuItem.CheckOnClick = true;
         this.SimpleLLModeToolStripMenuItem.Name = "SimpleLLModeToolStripMenuItem";
         this.SimpleLLModeToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this.SimpleLLModeToolStripMenuItem.Text = "Simple LL Mode";
         this.SimpleLLModeToolStripMenuItem.Click += new System.EventHandler(this.SimpleLLModeToolStripMenuItem_Click);
         // 
         // openFileDialog
         // 
         this.openFileDialog.ReadOnlyChecked = true;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 24);
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
         this.splitContainer2.Size = new System.Drawing.Size(969, 587);
         this.splitContainer2.SplitterDistance = 443;
         this.splitContainer2.TabIndex = 2;
         // 
         // ParseMessageListView
         // 
         this.ParseMessageListView.AllColumns.Add(this.colLineNumber);
         this.ParseMessageListView.AllColumns.Add(this.colPosition);
         this.ParseMessageListView.AllColumns.Add(this.colMessage);
         this.ParseMessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLineNumber,
            this.colPosition,
            this.colMessage});
         this.ParseMessageListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ParseMessageListView.FullRowSelect = true;
         this.ParseMessageListView.HideSelection = false;
         this.ParseMessageListView.Location = new System.Drawing.Point(0, 0);
         this.ParseMessageListView.Name = "ParseMessageListView";
         this.ParseMessageListView.ShowGroups = false;
         this.ParseMessageListView.Size = new System.Drawing.Size(969, 140);
         this.ParseMessageListView.TabIndex = 0;
         this.ParseMessageListView.UseCompatibleStateImageBehavior = false;
         this.ParseMessageListView.View = System.Windows.Forms.View.Details;
         this.ParseMessageListView.Click += new System.EventHandler(this.ParseMessageListView_Click);
         // 
         // colLineNumber
         // 
         this.colLineNumber.AspectName = "LineNumber";
         this.colLineNumber.CellPadding = null;
         this.colLineNumber.Text = "Line";
         // 
         // colPosition
         // 
         this.colPosition.AspectName = "Column";
         this.colPosition.CellPadding = null;
         this.colPosition.Text = "Position";
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
         this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripLabelGrammar,
            this.stripLabelGrammarName});
         this.StatusStrip1.Location = new System.Drawing.Point(0, 611);
         this.StatusStrip1.Name = "StatusStrip1";
         this.StatusStrip1.Size = new System.Drawing.Size(969, 22);
         this.StatusStrip1.TabIndex = 3;
         this.StatusStrip1.Text = "statusStrip1";
         // 
         // StripLabelGrammar
         // 
         this.StripLabelGrammar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StripLabelGrammar.Name = "StripLabelGrammar";
         this.StripLabelGrammar.Size = new System.Drawing.Size(70, 17);
         this.StripLabelGrammar.Text = "Grammar:";
         // 
         // stripLabelGrammarName
         // 
         this.stripLabelGrammarName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.stripLabelGrammarName.Name = "stripLabelGrammarName";
         this.stripLabelGrammarName.Size = new System.Drawing.Size(0, 17);
         // 
         // VisualAnalyzer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(969, 633);
         this.Controls.Add(this.splitContainer2);
         this.Controls.Add(this.menuStrip1);
         this.Controls.Add(this.StatusStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "VisualAnalyzer";
         this.Text = "GrunWin Visual Analyzer";
         this.Load += new System.EventHandler(this.VisualAnalyzer_Load);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).EndInit();
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
      private System.Windows.Forms.ToolStripMenuItem HeuristicHighlightingtToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
   }
}

