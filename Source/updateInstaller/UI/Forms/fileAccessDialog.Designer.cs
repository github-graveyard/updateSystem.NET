namespace updateSystemDotNet.Updater.UI.Forms
{
    partial class fileAccessDialog
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
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAbort = new System.Windows.Forms.Button();
			this.btnRetry = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.imgExclamation = new System.Windows.Forms.PictureBox();
			this.pnlBottom.SuspendLayout();
			this.flpBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgExclamation)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlBottom
			// 
			this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
			this.pnlBottom.Controls.Add(this.flpBottom);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 148);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(346, 35);
			this.pnlBottom.TabIndex = 21;
			// 
			// flpBottom
			// 
			this.flpBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpBottom.BackColor = System.Drawing.Color.Transparent;
			this.flpBottom.Controls.Add(this.btnAbort);
			this.flpBottom.Controls.Add(this.btnRetry);
			this.flpBottom.Dock = System.Windows.Forms.DockStyle.Right;
			this.flpBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpBottom.Location = new System.Drawing.Point(-20, 0);
			this.flpBottom.MinimumSize = new System.Drawing.Size(0, 34);
			this.flpBottom.Name = "flpBottom";
			this.flpBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.flpBottom.Size = new System.Drawing.Size(366, 35);
			this.flpBottom.TabIndex = 11;
			// 
			// btnAbort
			// 
			this.btnAbort.AutoSize = true;
			this.btnAbort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAbort.Location = new System.Drawing.Point(247, 7);
			this.btnAbort.MinimumSize = new System.Drawing.Size(64, 21);
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.Size = new System.Drawing.Size(110, 22);
			this.btnAbort.TabIndex = 0;
			this.btnAbort.Text = "Update abbrechen";
			this.btnAbort.UseVisualStyleBackColor = true;
			// 
			// btnRetry
			// 
			this.btnRetry.AutoSize = true;
			this.btnRetry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRetry.Location = new System.Drawing.Point(160, 7);
			this.btnRetry.MinimumSize = new System.Drawing.Size(64, 21);
			this.btnRetry.Name = "btnRetry";
			this.btnRetry.Size = new System.Drawing.Size(81, 22);
			this.btnRetry.TabIndex = 0;
			this.btnRetry.Text = "Wiederholen";
			this.btnRetry.UseVisualStyleBackColor = true;
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(50, 39);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(287, 106);
			this.lblInfo.TabIndex = 23;
			this.lblInfo.Text = "Der updateInstaller kann die folgende Datei nicht überschreiben: \'{0}\'. Was möcht" +
				"en Sie machen?";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTitle.Location = new System.Drawing.Point(47, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(161, 18);
			this.lblTitle.TabIndex = 22;
			this.lblTitle.Text = "Fehler beim Dateizugriff";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imgExclamation
			// 
			this.imgExclamation.Location = new System.Drawing.Point(9, 9);
			this.imgExclamation.Name = "imgExclamation";
			this.imgExclamation.Size = new System.Drawing.Size(32, 32);
			this.imgExclamation.TabIndex = 24;
			this.imgExclamation.TabStop = false;
			// 
			// fileAccessDialog
			// 
			this.AcceptButton = this.btnRetry;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAbort;
			this.ClientSize = new System.Drawing.Size(346, 183);
			this.Controls.Add(this.imgExclamation);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.pnlBottom);
			this.Description = "";
			this.DescriptionColor = System.Drawing.Color.Black;
			this.DrawTop = false;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "fileAccessDialog";
			this.Text = "updateSystem.Net Installer";
			this.Title = "";
			this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.pnlBottom.ResumeLayout(false);
			this.flpBottom.ResumeLayout(false);
			this.flpBottom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgExclamation)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox imgExclamation;
        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnRetry;
    }
}