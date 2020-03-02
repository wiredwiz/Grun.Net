namespace Org.Edgerunner.ANTLR.Tools.Testing
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
         Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation1 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.cmbRules = new System.Windows.Forms.ComboBox();
         this.lblParserRule = new System.Windows.Forms.Label();
         this.CodeEditor = new FastColoredTextBoxNS.FastColoredTextBox();
         this.tabControlParse = new System.Windows.Forms.TabControl();
         this.tabParseTree = new System.Windows.Forms.TabPage();
         this.tabTokens = new System.Windows.Forms.TabPage();
         this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
         this.tokenListView = new BrightIdeasSoftware.ObjectListView();
         this.colText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colLine = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colChannel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CodeEditor)).BeginInit();
         this.tabControlParse.SuspendLayout();
         this.tabParseTree.SuspendLayout();
         this.tabTokens.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tokenListView)).BeginInit();
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
         this.splitContainer1.Panel1.Controls.Add(this.cmbRules);
         this.splitContainer1.Panel1.Controls.Add(this.lblParserRule);
         this.splitContainer1.Panel1.Controls.Add(this.CodeEditor);
         this.splitContainer1.Panel1MinSize = 325;
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tabControlParse);
         this.splitContainer1.Size = new System.Drawing.Size(969, 633);
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
         this.CodeEditor.Location = new System.Drawing.Point(3, 40);
         this.CodeEditor.Name = "CodeEditor";
         this.CodeEditor.Paddings = new System.Windows.Forms.Padding(0);
         this.CodeEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
         this.CodeEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeEditor.ServiceColors")));
         this.CodeEditor.Size = new System.Drawing.Size(317, 588);
         this.CodeEditor.TabIndex = 0;
         this.CodeEditor.Zoom = 100;
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
         this.tabControlParse.Size = new System.Drawing.Size(638, 631);
         this.tabControlParse.TabIndex = 0;
         // 
         // tabParseTree
         // 
         this.tabParseTree.Controls.Add(this.gViewer1);
         this.tabParseTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabParseTree.Location = new System.Drawing.Point(4, 29);
         this.tabParseTree.Name = "tabParseTree";
         this.tabParseTree.Padding = new System.Windows.Forms.Padding(3);
         this.tabParseTree.Size = new System.Drawing.Size(630, 598);
         this.tabParseTree.TabIndex = 0;
         this.tabParseTree.Text = "Parse Tree";
         this.tabParseTree.UseVisualStyleBackColor = true;
         // 
         // tabTokens
         // 
         this.tabTokens.Controls.Add(this.tokenListView);
         this.tabTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabTokens.Location = new System.Drawing.Point(4, 29);
         this.tabTokens.Name = "tabTokens";
         this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
         this.tabTokens.Size = new System.Drawing.Size(630, 598);
         this.tabTokens.TabIndex = 1;
         this.tabTokens.Text = "Tokens";
         this.tabTokens.UseVisualStyleBackColor = true;
         // 
         // gViewer1
         // 
         this.gViewer1.ArrowheadLength = 10D;
         this.gViewer1.AsyncLayout = false;
         this.gViewer1.AutoScroll = true;
         this.gViewer1.BackwardEnabled = false;
         this.gViewer1.BuildHitTree = true;
         this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
         this.gViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gViewer1.EdgeInsertButtonVisible = true;
         this.gViewer1.FileName = "";
         this.gViewer1.ForwardEnabled = false;
         this.gViewer1.Graph = null;
         this.gViewer1.InsertingEdge = false;
         this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
         this.gViewer1.LayoutEditingEnabled = true;
         this.gViewer1.Location = new System.Drawing.Point(3, 3);
         this.gViewer1.LooseOffsetForRouting = 0.25D;
         this.gViewer1.MouseHitDistance = 0.05D;
         this.gViewer1.Name = "gViewer1";
         this.gViewer1.NavigationVisible = true;
         this.gViewer1.NeedToCalculateLayout = true;
         this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
         this.gViewer1.PaddingForEdgeRouting = 8D;
         this.gViewer1.PanButtonPressed = false;
         this.gViewer1.SaveAsImageEnabled = true;
         this.gViewer1.SaveAsMsaglEnabled = true;
         this.gViewer1.SaveButtonVisible = true;
         this.gViewer1.SaveGraphButtonVisible = true;
         this.gViewer1.SaveInVectorFormatEnabled = true;
         this.gViewer1.Size = new System.Drawing.Size(624, 592);
         this.gViewer1.TabIndex = 0;
         this.gViewer1.TightOffsetForRouting = 0.125D;
         this.gViewer1.ToolBarIsVisible = true;
         this.gViewer1.Transform = planeTransformation1;
         this.gViewer1.UndoRedoButtonsVisible = true;
         this.gViewer1.WindowZoomButtonPressed = false;
         this.gViewer1.ZoomF = 1D;
         this.gViewer1.ZoomWindowThreshold = 0.05D;
         // 
         // tokenListView
         // 
         this.tokenListView.AllColumns.Add(this.colText);
         this.tokenListView.AllColumns.Add(this.colLine);
         this.tokenListView.AllColumns.Add(this.colColumn);
         this.tokenListView.AllColumns.Add(this.colChannel);
         this.tokenListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colText,
            this.colLine,
            this.colColumn,
            this.colChannel});
         this.tokenListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tokenListView.Location = new System.Drawing.Point(3, 3);
         this.tokenListView.Name = "tokenListView";
         this.tokenListView.Size = new System.Drawing.Size(624, 592);
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
         this.colText.Width = 82;
         // 
         // colLine
         // 
         this.colLine.AspectName = "Line";
         this.colLine.CellPadding = null;
         this.colLine.Groupable = false;
         this.colLine.Text = "Line";
         // 
         // colColumn
         // 
         this.colColumn.AspectName = "Column";
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
         this.colChannel.Width = 100;
         // 
         // VisualAnalyzer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(969, 633);
         this.Controls.Add(this.splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Label lblParserRule;
      private FastColoredTextBoxNS.FastColoredTextBox CodeEditor;
      private System.Windows.Forms.ComboBox cmbRules;
      private System.Windows.Forms.TabControl tabControlParse;
      private System.Windows.Forms.TabPage tabParseTree;
      private System.Windows.Forms.TabPage tabTokens;
      private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
      private BrightIdeasSoftware.ObjectListView tokenListView;
      private BrightIdeasSoftware.OLVColumn colText;
      private BrightIdeasSoftware.OLVColumn colLine;
      private BrightIdeasSoftware.OLVColumn colColumn;
      private BrightIdeasSoftware.OLVColumn colChannel;
   }
}

