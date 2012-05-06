namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class publishUpdatesDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.prgPublish = new System.Windows.Forms.ProgressBar();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblCurrentPublishInformation = new System.Windows.Forms.Label();
			this.bgwPublish = new System.ComponentModel.BackgroundWorker();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 137);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(434, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(340, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// prgPublish
			// 
			this.prgPublish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prgPublish.Location = new System.Drawing.Point(12, 99);
			this.prgPublish.Name = "prgPublish";
			this.prgPublish.Size = new System.Drawing.Size(407, 20);
			this.prgPublish.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTitle.Location = new System.Drawing.Point(12, 12);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(168, 21);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Veröffentliche Updates";
			// 
			// lblCurrentPublishInformation
			// 
			this.lblCurrentPublishInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentPublishInformation.Location = new System.Drawing.Point(12, 49);
			this.lblCurrentPublishInformation.Name = "lblCurrentPublishInformation";
			this.lblCurrentPublishInformation.Size = new System.Drawing.Size(407, 37);
			this.lblCurrentPublishInformation.TabIndex = 3;
			this.lblCurrentPublishInformation.Text = "#currentPublishInformation#";
			// 
			// bgwPublish
			// 
			this.bgwPublish.WorkerReportsProgress = true;
			this.bgwPublish.WorkerSupportsCancellation = true;
			this.bgwPublish.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPublish_DoWork);
			// 
			// publishUpdatesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 187);
			this.Controls.Add(this.lblCurrentPublishInformation);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.prgPublish);
			this.Controls.Add(this.buttonArea1);
			this.Name = "publishUpdatesDialog";
			this.Text = "[appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCancel;
		private System.Windows.Forms.ProgressBar prgPublish;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblCurrentPublishInformation;
		private System.ComponentModel.BackgroundWorker bgwPublish;
	}
}