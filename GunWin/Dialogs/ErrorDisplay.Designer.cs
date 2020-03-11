namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin.Dialogs
{
   partial class ErrorDisplay
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
         this.TxtErrorMessage = new System.Windows.Forms.TextBox();
         this.TxtStackTrace = new System.Windows.Forms.TextBox();
         this.BtnErrOk = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // TxtErrorMessage
         // 
         this.TxtErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.TxtErrorMessage.BackColor = System.Drawing.SystemColors.Control;
         this.TxtErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TxtErrorMessage.Location = new System.Drawing.Point(12, 12);
         this.TxtErrorMessage.Multiline = true;
         this.TxtErrorMessage.Name = "TxtErrorMessage";
         this.TxtErrorMessage.ReadOnly = true;
         this.TxtErrorMessage.Size = new System.Drawing.Size(614, 60);
         this.TxtErrorMessage.TabIndex = 0;
         // 
         // TxtStackTrace
         // 
         this.TxtStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.TxtStackTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TxtStackTrace.Location = new System.Drawing.Point(12, 87);
         this.TxtStackTrace.Multiline = true;
         this.TxtStackTrace.Name = "TxtStackTrace";
         this.TxtStackTrace.ReadOnly = true;
         this.TxtStackTrace.Size = new System.Drawing.Size(614, 267);
         this.TxtStackTrace.TabIndex = 1;
         // 
         // BtnErrOk
         // 
         this.BtnErrOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.BtnErrOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.BtnErrOk.Location = new System.Drawing.Point(543, 370);
         this.BtnErrOk.Name = "BtnErrOk";
         this.BtnErrOk.Size = new System.Drawing.Size(83, 30);
         this.BtnErrOk.TabIndex = 2;
         this.BtnErrOk.Text = "Ok";
         this.BtnErrOk.UseVisualStyleBackColor = true;
         this.BtnErrOk.Click += new System.EventHandler(this.BtnErrOk_Click);
         // 
         // ErrorDisplay
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.BtnErrOk;
         this.ClientSize = new System.Drawing.Size(638, 412);
         this.Controls.Add(this.BtnErrOk);
         this.Controls.Add(this.TxtStackTrace);
         this.Controls.Add(this.TxtErrorMessage);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ErrorDisplay";
         this.ShowIcon = false;
         this.Text = "Exception Information";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox TxtErrorMessage;
      private System.Windows.Forms.TextBox TxtStackTrace;
      private System.Windows.Forms.Button BtnErrOk;
   }
}