namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class applicationSettingsDialog {
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
			this.mainInstructionsLabel1 = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnOk = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.grpLog = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.pnlLogSettings = new System.Windows.Forms.Panel();
			this.chkLogFtp = new System.Windows.Forms.CheckBox();
			this.chkLogUpdateLog = new System.Windows.Forms.CheckBox();
			this.btnOpenLogDirectory = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.chkEnableApplicationLog = new System.Windows.Forms.CheckBox();
			this.groupBoxEx2 = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
			this.cboUpdateChannel = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBoxEx3 = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.btnProxySettings = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.buttonArea1.SuspendLayout();
			this.grpLog.SuspendLayout();
			this.pnlLogSettings.SuspendLayout();
			this.groupBoxEx2.SuspendLayout();
			this.groupBoxEx3.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainInstructionsLabel1
			// 
			this.mainInstructionsLabel1.AutoSize = true;
			this.mainInstructionsLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.mainInstructionsLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.mainInstructionsLabel1.Location = new System.Drawing.Point(12, 9);
			this.mainInstructionsLabel1.Name = "mainInstructionsLabel1";
			this.mainInstructionsLabel1.Size = new System.Drawing.Size(194, 21);
			this.mainInstructionsLabel1.TabIndex = 0;
			this.mainInstructionsLabel1.Text = "Anwendungseinstellungen";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 338);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(457, 50);
			this.buttonArea1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(363, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(284, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(73, 24);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Speichern";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// grpLog
			// 
			this.grpLog.Controls.Add(this.pnlLogSettings);
			this.grpLog.Controls.Add(this.btnOpenLogDirectory);
			this.grpLog.Controls.Add(this.chkEnableApplicationLog);
			this.grpLog.Location = new System.Drawing.Point(16, 44);
			this.grpLog.Name = "grpLog";
			this.grpLog.Size = new System.Drawing.Size(426, 133);
			this.grpLog.TabIndex = 2;
			this.grpLog.TabStop = false;
			this.grpLog.Text = "Anwendungslog";
			// 
			// pnlLogSettings
			// 
			this.pnlLogSettings.Controls.Add(this.chkLogFtp);
			this.pnlLogSettings.Controls.Add(this.chkLogUpdateLog);
			this.pnlLogSettings.Enabled = false;
			this.pnlLogSettings.Location = new System.Drawing.Point(16, 49);
			this.pnlLogSettings.Name = "pnlLogSettings";
			this.pnlLogSettings.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.pnlLogSettings.Size = new System.Drawing.Size(410, 49);
			this.pnlLogSettings.TabIndex = 2;
			// 
			// chkLogFtp
			// 
			this.chkLogFtp.AutoSize = true;
			this.chkLogFtp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkLogFtp.Location = new System.Drawing.Point(9, 26);
			this.chkLogFtp.Name = "chkLogFtp";
			this.chkLogFtp.Size = new System.Drawing.Size(214, 20);
			this.chkLogFtp.TabIndex = 1;
			this.chkLogFtp.Text = "Antworten des FTP-Servers loggen";
			this.chkLogFtp.UseVisualStyleBackColor = true;
			// 
			// chkLogUpdateLog
			// 
			this.chkLogUpdateLog.AutoSize = true;
			this.chkLogUpdateLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkLogUpdateLog.Location = new System.Drawing.Point(9, 3);
			this.chkLogUpdateLog.Name = "chkLogUpdateLog";
			this.chkLogUpdateLog.Size = new System.Drawing.Size(305, 20);
			this.chkLogUpdateLog.TabIndex = 0;
			this.chkLogUpdateLog.Text = "Anfragen und Antworten des Statistikservers loggen";
			this.chkLogUpdateLog.UseVisualStyleBackColor = true;
			// 
			// btnOpenLogDirectory
			// 
			this.btnOpenLogDirectory.AutoSize = true;
			this.btnOpenLogDirectory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOpenLogDirectory.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOpenLogDirectory.Location = new System.Drawing.Point(19, 107);
			this.btnOpenLogDirectory.Name = "btnOpenLogDirectory";
			this.btnOpenLogDirectory.Size = new System.Drawing.Size(137, 24);
			this.btnOpenLogDirectory.TabIndex = 1;
			this.btnOpenLogDirectory.Text = "Logverzeichnis öffnen";
			this.btnOpenLogDirectory.UseVisualStyleBackColor = true;
			this.btnOpenLogDirectory.Click += new System.EventHandler(this.btnOpenLogDirectory_Click);
			// 
			// chkEnableApplicationLog
			// 
			this.chkEnableApplicationLog.AutoSize = true;
			this.chkEnableApplicationLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkEnableApplicationLog.Location = new System.Drawing.Point(16, 26);
			this.chkEnableApplicationLog.Name = "chkEnableApplicationLog";
			this.chkEnableApplicationLog.Size = new System.Drawing.Size(295, 20);
			this.chkEnableApplicationLog.TabIndex = 0;
			this.chkEnableApplicationLog.Text = "Anwendungsereignisse in eine Logdatei schreiben";
			this.chkEnableApplicationLog.UseVisualStyleBackColor = true;
			this.chkEnableApplicationLog.CheckedChanged += new System.EventHandler(this.chkEnableApplicationLog_CheckedChanged);
			// 
			// groupBoxEx2
			// 
			this.groupBoxEx2.Controls.Add(this.chkCheckForUpdates);
			this.groupBoxEx2.Controls.Add(this.cboUpdateChannel);
			this.groupBoxEx2.Controls.Add(this.label1);
			this.groupBoxEx2.Location = new System.Drawing.Point(16, 183);
			this.groupBoxEx2.Name = "groupBoxEx2";
			this.groupBoxEx2.Size = new System.Drawing.Size(426, 79);
			this.groupBoxEx2.TabIndex = 3;
			this.groupBoxEx2.TabStop = false;
			this.groupBoxEx2.Text = "Aktualisierungen";
			// 
			// chkCheckForUpdates
			// 
			this.chkCheckForUpdates.AutoSize = true;
			this.chkCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkCheckForUpdates.Location = new System.Drawing.Point(19, 56);
			this.chkCheckForUpdates.Name = "chkCheckForUpdates";
			this.chkCheckForUpdates.Size = new System.Drawing.Size(319, 20);
			this.chkCheckForUpdates.TabIndex = 2;
			this.chkCheckForUpdates.Text = "Während dem Start automatisch nach Updates suchen";
			this.chkCheckForUpdates.UseVisualStyleBackColor = true;
			// 
			// cboUpdateChannel
			// 
			this.cboUpdateChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUpdateChannel.FormattingEnabled = true;
			this.cboUpdateChannel.Location = new System.Drawing.Point(112, 23);
			this.cboUpdateChannel.Name = "cboUpdateChannel";
			this.cboUpdateChannel.Size = new System.Drawing.Size(199, 23);
			this.cboUpdateChannel.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Updatekanal:";
			// 
			// groupBoxEx3
			// 
			this.groupBoxEx3.Controls.Add(this.btnProxySettings);
			this.groupBoxEx3.Location = new System.Drawing.Point(16, 268);
			this.groupBoxEx3.Name = "groupBoxEx3";
			this.groupBoxEx3.Size = new System.Drawing.Size(426, 64);
			this.groupBoxEx3.TabIndex = 4;
			this.groupBoxEx3.TabStop = false;
			this.groupBoxEx3.Text = "Proxy";
			// 
			// btnProxySettings
			// 
			this.btnProxySettings.AutoSize = true;
			this.btnProxySettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnProxySettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnProxySettings.Location = new System.Drawing.Point(16, 25);
			this.btnProxySettings.Name = "btnProxySettings";
			this.btnProxySettings.Size = new System.Drawing.Size(171, 24);
			this.btnProxySettings.TabIndex = 0;
			this.btnProxySettings.Text = "Proxyeinstellungen anzeigen";
			this.btnProxySettings.UseVisualStyleBackColor = true;
			this.btnProxySettings.Click += new System.EventHandler(this.btnProxySettings_Click);
			// 
			// applicationSettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(457, 388);
			this.Controls.Add(this.groupBoxEx3);
			this.Controls.Add(this.groupBoxEx2);
			this.Controls.Add(this.grpLog);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.mainInstructionsLabel1);
			this.Name = "applicationSettingsDialog";
			this.Text = "Anwendungseinstellungen - [appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.grpLog.ResumeLayout(false);
			this.grpLog.PerformLayout();
			this.pnlLogSettings.ResumeLayout(false);
			this.pnlLogSettings.PerformLayout();
			this.groupBoxEx2.ResumeLayout(false);
			this.groupBoxEx2.PerformLayout();
			this.groupBoxEx3.ResumeLayout(false);
			this.groupBoxEx3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel mainInstructionsLabel1;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCancel;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnOk;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpLog;
		private System.Windows.Forms.CheckBox chkEnableApplicationLog;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnOpenLogDirectory;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx groupBoxEx2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkCheckForUpdates;
		private System.Windows.Forms.ComboBox cboUpdateChannel;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx groupBoxEx3;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnProxySettings;
		private System.Windows.Forms.Panel pnlLogSettings;
		private System.Windows.Forms.CheckBox chkLogFtp;
		private System.Windows.Forms.CheckBox chkLogUpdateLog;

	}
}