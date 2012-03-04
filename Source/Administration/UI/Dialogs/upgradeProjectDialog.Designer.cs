namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class upgradeProjectDialog {
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
			this.btnClose = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnConvert = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.prgConvert = new System.Windows.Forms.ProgressBar();
			this.mainInstructionsLabel1 = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.grpProjectFile = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.txtUpdateUrl = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProjectFile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBrowseProjectFile = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.grpDestination = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.txtDestination = new System.Windows.Forms.TextBox();
			this.btnBrowseDestination = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.label3 = new System.Windows.Forms.Label();
			this.bgwConvert = new System.ComponentModel.BackgroundWorker();
			this.buttonArea1.SuspendLayout();
			this.grpProjectFile.SuspendLayout();
			this.grpDestination.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnClose);
			this.buttonArea1.Controls.Add(this.btnConvert);
			this.buttonArea1.Controls.Add(this.prgConvert);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 229);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(567, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(480, 13);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Schließen";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnConvert
			// 
			this.btnConvert.AutoSize = true;
			this.btnConvert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvert.Location = new System.Drawing.Point(347, 13);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(127, 24);
			this.btnConvert.TabIndex = 1;
			this.btnConvert.Text = "Projekt konvertieren";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// prgConvert
			// 
			this.prgConvert.Location = new System.Drawing.Point(16, 13);
			this.prgConvert.Name = "prgConvert";
			this.prgConvert.Size = new System.Drawing.Size(325, 23);
			this.prgConvert.TabIndex = 2;
			this.prgConvert.Visible = false;
			// 
			// mainInstructionsLabel1
			// 
			this.mainInstructionsLabel1.AutoSize = true;
			this.mainInstructionsLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.mainInstructionsLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.mainInstructionsLabel1.Location = new System.Drawing.Point(12, 9);
			this.mainInstructionsLabel1.Name = "mainInstructionsLabel1";
			this.mainInstructionsLabel1.Size = new System.Drawing.Size(117, 21);
			this.mainInstructionsLabel1.TabIndex = 1;
			this.mainInstructionsLabel1.Text = "Projektupgrade";
			// 
			// grpProjectFile
			// 
			this.grpProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpProjectFile.Controls.Add(this.txtUpdateUrl);
			this.grpProjectFile.Controls.Add(this.label2);
			this.grpProjectFile.Controls.Add(this.txtProjectFile);
			this.grpProjectFile.Controls.Add(this.label1);
			this.grpProjectFile.Controls.Add(this.btnBrowseProjectFile);
			this.grpProjectFile.Location = new System.Drawing.Point(16, 38);
			this.grpProjectFile.Name = "grpProjectFile";
			this.grpProjectFile.Size = new System.Drawing.Size(536, 85);
			this.grpProjectFile.TabIndex = 2;
			this.grpProjectFile.TabStop = false;
			this.grpProjectFile.Text = "Projektinformationen";
			// 
			// txtUpdateUrl
			// 
			this.txtUpdateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUpdateUrl.Location = new System.Drawing.Point(94, 52);
			this.txtUpdateUrl.Name = "txtUpdateUrl";
			this.txtUpdateUrl.Size = new System.Drawing.Size(406, 23);
			this.txtUpdateUrl.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Update Url:";
			// 
			// txtProjectFile
			// 
			this.txtProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProjectFile.Location = new System.Drawing.Point(94, 19);
			this.txtProjectFile.Name = "txtProjectFile";
			this.txtProjectFile.Size = new System.Drawing.Size(406, 23);
			this.txtProjectFile.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Projektdatei:";
			// 
			// btnBrowseProjectFile
			// 
			this.btnBrowseProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseProjectFile.AutoSize = true;
			this.btnBrowseProjectFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnBrowseProjectFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseProjectFile.Location = new System.Drawing.Point(506, 19);
			this.btnBrowseProjectFile.Name = "btnBrowseProjectFile";
			this.btnBrowseProjectFile.Size = new System.Drawing.Size(30, 22);
			this.btnBrowseProjectFile.TabIndex = 0;
			this.btnBrowseProjectFile.Text = "...";
			this.btnBrowseProjectFile.UseVisualStyleBackColor = true;
			this.btnBrowseProjectFile.Click += new System.EventHandler(this.btnBrowseProjectFile_Click);
			// 
			// grpDestination
			// 
			this.grpDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpDestination.Controls.Add(this.txtDestination);
			this.grpDestination.Controls.Add(this.btnBrowseDestination);
			this.grpDestination.Controls.Add(this.label3);
			this.grpDestination.Location = new System.Drawing.Point(16, 129);
			this.grpDestination.Name = "grpDestination";
			this.grpDestination.Size = new System.Drawing.Size(536, 76);
			this.grpDestination.TabIndex = 3;
			this.grpDestination.TabStop = false;
			this.grpDestination.Text = "Neuer Speicherort";
			// 
			// txtDestination
			// 
			this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDestination.Location = new System.Drawing.Point(18, 40);
			this.txtDestination.Name = "txtDestination";
			this.txtDestination.Size = new System.Drawing.Size(421, 23);
			this.txtDestination.TabIndex = 4;
			// 
			// btnBrowseDestination
			// 
			this.btnBrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseDestination.AutoSize = true;
			this.btnBrowseDestination.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnBrowseDestination.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseDestination.Location = new System.Drawing.Point(451, 40);
			this.btnBrowseDestination.Name = "btnBrowseDestination";
			this.btnBrowseDestination.Size = new System.Drawing.Size(85, 22);
			this.btnBrowseDestination.TabIndex = 3;
			this.btnBrowseDestination.Text = "Durchsuchen";
			this.btnBrowseDestination.UseVisualStyleBackColor = true;
			this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Neues Projektverzeichnis:";
			// 
			// bgwConvert
			// 
			this.bgwConvert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwConvert_DoWork);
			// 
			// upgradeProjectDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 279);
			this.Controls.Add(this.grpDestination);
			this.Controls.Add(this.grpProjectFile);
			this.Controls.Add(this.mainInstructionsLabel1);
			this.Controls.Add(this.buttonArea1);
			this.Name = "upgradeProjectDialog";
			this.Text = "[appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.grpProjectFile.ResumeLayout(false);
			this.grpProjectFile.PerformLayout();
			this.grpDestination.ResumeLayout(false);
			this.grpDestination.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnClose;
		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel mainInstructionsLabel1;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpProjectFile;
		private System.Windows.Forms.Label label1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnBrowseProjectFile;
		private System.Windows.Forms.TextBox txtProjectFile;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnConvert;
		private System.Windows.Forms.TextBox txtUpdateUrl;
		private System.Windows.Forms.Label label2;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpDestination;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDestination;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnBrowseDestination;
		private System.Windows.Forms.ProgressBar prgConvert;
		private System.ComponentModel.BackgroundWorker bgwConvert;
	}
}