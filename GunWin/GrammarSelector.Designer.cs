namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   partial class GrammarSelector
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
         this.GrammarListView = new BrightIdeasSoftware.ObjectListView();
         this.colGrammarName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.colAssemblyFilePath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.GrammarListView)).BeginInit();
         this.SuspendLayout();
         // 
         // GrammarListView
         // 
         this.GrammarListView.AllColumns.Add(this.colGrammarName);
         this.GrammarListView.AllColumns.Add(this.colAssemblyFilePath);
         this.GrammarListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGrammarName,
            this.colAssemblyFilePath});
         this.GrammarListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.GrammarListView.FullRowSelect = true;
         this.GrammarListView.Location = new System.Drawing.Point(12, 12);
         this.GrammarListView.Name = "GrammarListView";
         this.GrammarListView.ShowGroups = false;
         this.GrammarListView.Size = new System.Drawing.Size(390, 201);
         this.GrammarListView.TabIndex = 0;
         this.GrammarListView.UseCompatibleStateImageBehavior = false;
         this.GrammarListView.View = System.Windows.Forms.View.Details;
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
         this.colAssemblyFilePath.Width = 289;
         // 
         // btnCancel
         // 
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
         this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnOk.Location = new System.Drawing.Point(226, 231);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
         // 
         // GrammarSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(414, 266);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.GrammarListView);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "GrammarSelector";
         this.Text = "Select A Grammar";
         ((System.ComponentModel.ISupportInitialize)(this.GrammarListView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private BrightIdeasSoftware.ObjectListView GrammarListView;
      private BrightIdeasSoftware.OLVColumn colGrammarName;
      private BrightIdeasSoftware.OLVColumn colAssemblyFilePath;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOk;
   }
}