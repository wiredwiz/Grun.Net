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
         this.cmbRules = new System.Windows.Forms.ComboBox();
         this.lblParserRule = new System.Windows.Forms.Label();
         this.CodeEditor = new FastColoredTextBoxNS.FastColoredTextBox();
         this.tabControlParse = new System.Windows.Forms.TabControl();
         this.tabParseTree = new System.Windows.Forms.TabPage();
         this.pnlGraph = new System.Windows.Forms.Panel();
         this.tabTokens = new System.Windows.Forms.TabPage();
         this.tokenListView = new BrightIdeasSoftware.ObjectListView();
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
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tracingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.diagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.simpleLLModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).BeginInit();
         this.tabControlParse.SuspendLayout();
         this.tabParseTree.SuspendLayout();
         this.tabTokens.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).BeginInit();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 24);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.cmbRules);
         this.splitContainer1.Panel1.Controls.Add(this.lblParserRule);
         this.splitContainer1.Panel1.Controls.Add(this.CodeEditor);
         this.splitContainer1.Panel1MinSize = 325;
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tabControlParse);
         this.splitContainer1.Size = new System.Drawing.Size(969, 609);
         this.splitContainer1.SplitterDistance = 325;
         this.splitContainer1.TabIndex = 0;
         // 
         // cmbRules
         // 
         this.cmbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cmbRules.FormattingEnabled = true;
         this.cmbRules.Location = new System.Drawing.Point(110, 6);
         this.cmbRules.Name = "cmbRules";
         this.cmbRules.Size = new System.Drawing.Size(203, 28);
         this.cmbRules.TabIndex = 0;
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
         this.CodeEditor.Font = new System.Drawing.Font("Courier New", 9.75F);
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
         this.CodeEditor.Size = new System.Drawing.Size(317, 564);
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
         this.tabControlParse.Size = new System.Drawing.Size(638, 607);
         this.tabControlParse.TabIndex = 0;
         // 
         // tabParseTree
         // 
         this.tabParseTree.Controls.Add(this.pnlGraph);
         this.tabParseTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabParseTree.Location = new System.Drawing.Point(4, 29);
         this.tabParseTree.Name = "tabParseTree";
         this.tabParseTree.Padding = new System.Windows.Forms.Padding(3);
         this.tabParseTree.Size = new System.Drawing.Size(630, 574);
         this.tabParseTree.TabIndex = 0;
         this.tabParseTree.Text = "Parse Tree";
         this.tabParseTree.UseVisualStyleBackColor = true;
         // 
         // pnlGraph
         // 
         this.pnlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlGraph.Location = new System.Drawing.Point(3, 3);
         this.pnlGraph.Name = "pnlGraph";
         this.pnlGraph.Size = new System.Drawing.Size(624, 568);
         this.pnlGraph.TabIndex = 0;
         // 
         // tabTokens
         // 
         this.tabTokens.Controls.Add(this.tokenListView);
         this.tabTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabTokens.Location = new System.Drawing.Point(4, 29);
         this.tabTokens.Name = "tabTokens";
         this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
         this.tabTokens.Size = new System.Drawing.Size(630, 574);
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
         this.tokenListView.ShowItemCountOnGroups = true;
         this.tokenListView.Size = new System.Drawing.Size(624, 568);
         this.tokenListView.SortGroupItemsByPrimaryColumn = false;
         this.tokenListView.TabIndex = 0;
         this.tokenListView.UseCompatibleStateImageBehavior = false;
         this.tokenListView.View = System.Windows.Forms.View.Details;
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
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // loadGrammarToolStripMenuItem
         // 
         this.loadGrammarToolStripMenuItem.Name = "loadGrammarToolStripMenuItem";
         this.loadGrammarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
         this.loadGrammarToolStripMenuItem.Text = "&Load Grammar";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
         this.exitToolStripMenuItem.Text = "E&xit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracingToolStripMenuItem,
            this.diagnosticsToolStripMenuItem,
            this.simpleLLModeToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "&Options";
         // 
         // tracingToolStripMenuItem
         // 
         this.tracingToolStripMenuItem.CheckOnClick = true;
         this.tracingToolStripMenuItem.Name = "tracingToolStripMenuItem";
         this.tracingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.tracingToolStripMenuItem.Text = "Tracing";
         // 
         // diagnosticsToolStripMenuItem
         // 
         this.diagnosticsToolStripMenuItem.CheckOnClick = true;
         this.diagnosticsToolStripMenuItem.Name = "diagnosticsToolStripMenuItem";
         this.diagnosticsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.diagnosticsToolStripMenuItem.Text = "Diagnostics";
         // 
         // simpleLLModeToolStripMenuItem
         // 
         this.simpleLLModeToolStripMenuItem.CheckOnClick = true;
         this.simpleLLModeToolStripMenuItem.Name = "simpleLLModeToolStripMenuItem";
         this.simpleLLModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.simpleLLModeToolStripMenuItem.Text = "Simple LL Mode";
         // 
         // VisualAnalyzer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(969, 633);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "VisualAnalyzer";
         this.Text = "Analyzer";
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).EndInit();
         this.tabControlParse.ResumeLayout(false);
         this.tabParseTree.ResumeLayout(false);
         this.tabTokens.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).EndInit();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Label lblParserRule;
      private FastColoredTextBoxNS.FastColoredTextBox CodeEditor;
      private System.Windows.Forms.ComboBox cmbRules;
      private System.Windows.Forms.TabControl tabControlParse;
      private System.Windows.Forms.TabPage tabParseTree;
      private System.Windows.Forms.TabPage tabTokens;
      private BrightIdeasSoftware.ObjectListView tokenListView;
      private BrightIdeasSoftware.OLVColumn colText;
      private BrightIdeasSoftware.OLVColumn colLine;
      private BrightIdeasSoftware.OLVColumn colColumn;
      private BrightIdeasSoftware.OLVColumn colChannel;
      private BrightIdeasSoftware.OLVColumn colType;
      private BrightIdeasSoftware.OLVColumn colStart;
      private BrightIdeasSoftware.OLVColumn colStop;
      private BrightIdeasSoftware.OLVColumn colLength;
      private System.Windows.Forms.Panel pnlGraph;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadGrammarToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tracingToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem diagnosticsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem simpleLLModeToolStripMenuItem;
   }
}

