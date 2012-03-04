namespace updateSystemDotNet.Updater.UI.Forms
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lblStatus = new System.Windows.Forms.Label();
			this.imageApplication = new System.Windows.Forms.PictureBox();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new System.Windows.Forms.Button();
			this.aclDownload = new updateSystemDotNet.Updater.UI.Components.statusLabel();
			this.aclApply = new updateSystemDotNet.Updater.UI.Components.statusLabel();
			this.prgUpdate = new updateSystemDotNet.Updater.UI.Components.Windows7ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.imageApplication)).BeginInit();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblStatus
			// 
			this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblStatus.Location = new System.Drawing.Point(50, 5);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(336, 32);
			this.lblStatus.TabIndex = 11;
			this.lblStatus.Text = "#installUpdates#";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imageApplication
			// 
			this.imageApplication.Location = new System.Drawing.Point(12, 5);
			this.imageApplication.Name = "imageApplication";
			this.imageApplication.Size = new System.Drawing.Size(32, 32);
			this.imageApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imageApplication.TabIndex = 15;
			this.imageApplication.TabStop = false;
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
			this.buttonArea1.TabIndex = 18;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(316, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(67, 22);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "#cancel#";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// aclDownload
			// 
			this.aclDownload.BackColor = System.Drawing.Color.Transparent;
			this.aclDownload.Location = new System.Drawing.Point(12, 52);
			this.aclDownload.Name = "aclDownload";
			this.aclDownload.Size = new System.Drawing.Size(374, 23);
			this.aclDownload.State = updateSystemDotNet.Updater.UI.Components.statusLabelStates.Success;
			this.aclDownload.TabIndex = 17;
			this.aclDownload.Text = "#aclDownload#";
			// 
			// aclApply
			// 
			this.aclApply.BackColor = System.Drawing.Color.Transparent;
			this.aclApply.Location = new System.Drawing.Point(12, 81);
			this.aclApply.Name = "aclApply";
			this.aclApply.Size = new System.Drawing.Size(374, 37);
			this.aclApply.State = updateSystemDotNet.Updater.UI.Components.statusLabelStates.Waiting;
			this.aclApply.TabIndex = 16;
			this.aclApply.Text = "#aclApply#";
			// 
			// prgUpdate
			// 
			this.prgUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.prgUpdate.ContainerControl = this;
			this.prgUpdate.Location = new System.Drawing.Point(13, 132);
			this.prgUpdate.Name = "prgUpdate";
			this.prgUpdate.ShowInTaskbar = true;
			this.prgUpdate.Size = new System.Drawing.Size(370, 16);
			this.prgUpdate.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(398, 201);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.aclDownload);
			this.Controls.Add(this.aclApply);
			this.Controls.Add(this.imageApplication);
			this.Controls.Add(this.prgUpdate);
			this.Controls.Add(this.lblStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "updateSystem.NET updateInstaller";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.imageApplication)).EndInit();
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private Components.Windows7ProgressBar prgUpdate;
        private System.Windows.Forms.PictureBox imageApplication;
		private updateSystemDotNet.Updater.UI.Components.statusLabel aclDownload;
		private updateSystemDotNet.Updater.UI.Components.statusLabel aclApply;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;

    }
}