using System.Drawing;
namespace updateSystemDotNet.Internal.UI
{
   internal partial class updateDownloadDialog
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
			this.lblTop = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.prgGlobal = new System.Windows.Forms.ProgressBar();
			this.aclDownload = new updateSystemDotNet.Internal.updateUI.Controls.statusLabel();
			this.aclApply = new updateSystemDotNet.Internal.updateUI.Controls.statusLabel();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTop
			// 
			this.lblTop.AutoSize = true;
			this.lblTop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTop.Location = new System.Drawing.Point(9, 9);
			this.lblTop.Name = "lblTop";
			this.lblTop.Size = new System.Drawing.Size(230, 20);
			this.lblTop.TabIndex = 2;
			this.lblTop.Text = "Updates werden heruntergeladen";
			this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(316, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(67, 22);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "#cancel#";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(9, 44);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(380, 22);
			this.lblInfo.TabIndex = 20;
			this.lblInfo.Text = "Die Aktualisierungen für Ihre Anwendung werden heruntergeladen...";
			// 
			// prgGlobal
			// 
			this.prgGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.prgGlobal.Location = new System.Drawing.Point(13, 132);
			this.prgGlobal.Name = "prgGlobal";
			this.prgGlobal.Size = new System.Drawing.Size(370, 16);
			this.prgGlobal.TabIndex = 21;
			// 
			// aclDownload
			// 
			this.aclDownload.BackColor = System.Drawing.Color.Transparent;
			this.aclDownload.Location = new System.Drawing.Point(12, 70);
			this.aclDownload.Name = "aclDownload";
			this.aclDownload.Size = new System.Drawing.Size(371, 23);
			this.aclDownload.State = updateSystemDotNet.Internal.updateUI.Controls.statusLabelStates.Waiting;
			this.aclDownload.TabIndex = 23;
			this.aclDownload.Text = "Updates werden heruntergeladen (0% abgeschlossen)";
			// 
			// aclApply
			// 
			this.aclApply.BackColor = System.Drawing.Color.Transparent;
			this.aclApply.Location = new System.Drawing.Point(13, 99);
			this.aclApply.Name = "aclApply";
			this.aclApply.Size = new System.Drawing.Size(370, 23);
			this.aclApply.State = updateSystemDotNet.Internal.updateUI.Controls.statusLabelStates.Waiting;
			this.aclApply.TabIndex = 24;
			this.aclApply.Text = "Updates werden installiert";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 158);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(398, 43);
			this.buttonArea1.TabIndex = 25;
			// 
			// updateDownloadDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(398, 201);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.prgGlobal);
			this.Controls.Add(this.aclApply);
			this.Controls.Add(this.aclDownload);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.lblTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "updateDownloadDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "updateSystem.NET";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.ProgressBar prgGlobal;
		private updateSystemDotNet.Internal.updateUI.Controls.statusLabel aclDownload;
		private updateSystemDotNet.Internal.updateUI.Controls.statusLabel aclApply;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
    }
}