namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Dialogs
{
   partial class LexerSelector
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
         this.LexerListView = new BrightIdeasSoftware.ObjectListView();
         this.colGrammarName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colAssemblyFilePath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.LexerListView)).BeginInit();
         this.SuspendLayout();
         // 
         // LexerListView
         // 
         this.LexerListView.AllColumns.Add(this.colGrammarName);
         this.LexerListView.AllColumns.Add(this.colAssemblyFilePath);
         this.LexerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGrammarName,
            this.colAssemblyFilePath});
         this.LexerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LexerListView.FullRowSelect = true;
         this.LexerListView.HideSelection = false;
         this.LexerListView.Location = new System.Drawing.Point(12, 12);
         this.LexerListView.Name = "LexerListView";
         this.LexerListView.ShowGroups = false;
         this.LexerListView.Size = new System.Drawing.Size(390, 201);
         this.LexerListView.TabIndex = 0;
         this.LexerListView.UseCompatibleStateImageBehavior = false;
         this.LexerListView.View = System.Windows.Forms.View.Details;
         // 
         // colGrammarName
         // 
         this.colGrammarName.AspectName = "GrammarName";
         this.colGrammarName.CellPadding = null;
         this.colGrammarName.Text = "Grammar";
         this.colGrammarName.Width = 118;
         // 
         // colAssemblyFilePath
         // 
         this.colAssemblyFilePath.AspectName = "AssemblyPath";
         this.colAssemblyFilePath.CellPadding = null;
         this.colAssemblyFilePath.Text = "File Path";
         this.colAssemblyFilePath.Width = 260;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCancel.Location = new System.Drawing.Point(327, 231);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnOk.Location = new System.Drawing.Point(226, 231);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
         // 
         // LexerSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(414, 266);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.LexerListView);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "LexerSelector";
         this.Text = "Select A Lexer";
         ((System.ComponentModel.ISupportInitialize)(this.LexerListView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private BrightIdeasSoftware.ObjectListView LexerListView;
      private BrightIdeasSoftware.OLVColumn colGrammarName;
      private BrightIdeasSoftware.OLVColumn colAssemblyFilePath;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOk;
   }
}