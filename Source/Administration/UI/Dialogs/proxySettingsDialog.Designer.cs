namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class proxySettingsDialog {
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
			this.lblTitle = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnSaveSettings = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.rbCustomAuth = new System.Windows.Forms.RadioButton();
			this.rbWinAuth = new System.Windows.Forms.RadioButton();
			this.rbNoAuth = new System.Windows.Forms.RadioButton();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblProxyPort = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.lblProxyServer = new System.Windows.Forms.Label();
			this.rbCustomProxy = new System.Windows.Forms.RadioButton();
			this.rbSystemProxy = new System.Windows.Forms.RadioButton();
			this.grpCustomProxy = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.pnlCredentials = new System.Windows.Forms.Panel();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.buttonArea1.SuspendLayout();
			this.grpCustomProxy.SuspendLayout();
			this.pnlCredentials.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTitle.Location = new System.Drawing.Point(12, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(142, 21);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Proxyeinstellungen";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnSaveSettings);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 307);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(463, 50);
			this.buttonArea1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(369, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.AutoSize = true;
			this.btnSaveSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSaveSettings.Location = new System.Drawing.Point(290, 13);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(73, 24);
			this.btnSaveSettings.TabIndex = 0;
			this.btnSaveSettings.Text = "Speichern";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// rbCustomAuth
			// 
			this.rbCustomAuth.AutoSize = true;
			this.rbCustomAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbCustomAuth.Location = new System.Drawing.Point(18, 99);
			this.rbCustomAuth.Name = "rbCustomAuth";
			this.rbCustomAuth.Size = new System.Drawing.Size(138, 18);
			this.rbCustomAuth.TabIndex = 10;
			this.rbCustomAuth.TabStop = true;
			this.rbCustomAuth.Text = "Eigene Anmeldedaten:";
			this.rbCustomAuth.UseVisualStyleBackColor = true;
			this.rbCustomAuth.CheckedChanged += new System.EventHandler(this.rbCustomAuth_CheckedChanged);
			// 
			// rbWinAuth
			// 
			this.rbWinAuth.AutoSize = true;
			this.rbWinAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbWinAuth.Location = new System.Drawing.Point(18, 74);
			this.rbWinAuth.Name = "rbWinAuth";
			this.rbWinAuth.Size = new System.Drawing.Size(174, 18);
			this.rbWinAuth.TabIndex = 9;
			this.rbWinAuth.TabStop = true;
			this.rbWinAuth.Text = "Windowsanmeldung benutzen";
			this.rbWinAuth.UseVisualStyleBackColor = true;
			// 
			// rbNoAuth
			// 
			this.rbNoAuth.AutoSize = true;
			this.rbNoAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbNoAuth.Location = new System.Drawing.Point(18, 49);
			this.rbNoAuth.Name = "rbNoAuth";
			this.rbNoAuth.Size = new System.Drawing.Size(208, 18);
			this.rbNoAuth.TabIndex = 8;
			this.rbNoAuth.TabStop = true;
			this.rbNoAuth.Text = "Der Server benötigt keine Anmeldung";
			this.rbNoAuth.UseVisualStyleBackColor = true;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(365, 22);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(50, 23);
			this.txtPort.TabIndex = 7;
			// 
			// lblProxyPort
			// 
			this.lblProxyPort.Location = new System.Drawing.Point(310, 22);
			this.lblProxyPort.Name = "lblProxyPort";
			this.lblProxyPort.Size = new System.Drawing.Size(49, 23);
			this.lblProxyPort.TabIndex = 6;
			this.lblProxyPort.Text = "Port:";
			this.lblProxyPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(91, 22);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(213, 23);
			this.txtServer.TabIndex = 5;
			// 
			// lblProxyServer
			// 
			this.lblProxyServer.Location = new System.Drawing.Point(15, 22);
			this.lblProxyServer.Name = "lblProxyServer";
			this.lblProxyServer.Size = new System.Drawing.Size(70, 23);
			this.lblProxyServer.TabIndex = 4;
			this.lblProxyServer.Text = "Server:";
			this.lblProxyServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rbCustomProxy
			// 
			this.rbCustomProxy.AutoSize = true;
			this.rbCustomProxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbCustomProxy.Location = new System.Drawing.Point(16, 70);
			this.rbCustomProxy.Name = "rbCustomProxy";
			this.rbCustomProxy.Size = new System.Drawing.Size(230, 20);
			this.rbCustomProxy.TabIndex = 4;
			this.rbCustomProxy.TabStop = true;
			this.rbCustomProxy.Text = "Eigene Proxyeinstellungen verwenden";
			this.rbCustomProxy.UseVisualStyleBackColor = true;
			this.rbCustomProxy.CheckedChanged += new System.EventHandler(this.rbCustomProxy_CheckedChanged);
			// 
			// rbSystemProxy
			// 
			this.rbSystemProxy.AutoSize = true;
			this.rbSystemProxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbSystemProxy.Location = new System.Drawing.Point(16, 44);
			this.rbSystemProxy.Name = "rbSystemProxy";
			this.rbSystemProxy.Size = new System.Drawing.Size(168, 20);
			this.rbSystemProxy.TabIndex = 3;
			this.rbSystemProxy.TabStop = true;
			this.rbSystemProxy.Text = "Standardproxy verwenden";
			this.rbSystemProxy.UseVisualStyleBackColor = true;
			// 
			// grpCustomProxy
			// 
			this.grpCustomProxy.Controls.Add(this.pnlCredentials);
			this.grpCustomProxy.Controls.Add(this.rbCustomAuth);
			this.grpCustomProxy.Controls.Add(this.lblProxyServer);
			this.grpCustomProxy.Controls.Add(this.rbWinAuth);
			this.grpCustomProxy.Controls.Add(this.txtServer);
			this.grpCustomProxy.Controls.Add(this.rbNoAuth);
			this.grpCustomProxy.Controls.Add(this.lblProxyPort);
			this.grpCustomProxy.Controls.Add(this.txtPort);
			this.grpCustomProxy.Enabled = false;
			this.grpCustomProxy.Location = new System.Drawing.Point(16, 96);
			this.grpCustomProxy.Name = "grpCustomProxy";
			this.grpCustomProxy.Size = new System.Drawing.Size(430, 195);
			this.grpCustomProxy.TabIndex = 6;
			this.grpCustomProxy.TabStop = false;
			this.grpCustomProxy.Text = "Eigene Proxykonfiguration";
			// 
			// pnlCredentials
			// 
			this.pnlCredentials.Controls.Add(this.txtPassword);
			this.pnlCredentials.Controls.Add(this.lblPassword);
			this.pnlCredentials.Controls.Add(this.txtUsername);
			this.pnlCredentials.Controls.Add(this.lblUsername);
			this.pnlCredentials.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCredentials.Enabled = false;
			this.pnlCredentials.Location = new System.Drawing.Point(12, 128);
			this.pnlCredentials.Name = "pnlCredentials";
			this.pnlCredentials.Size = new System.Drawing.Size(406, 61);
			this.pnlCredentials.TabIndex = 11;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(103, 33);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(300, 23);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(7, 33);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(90, 23);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Passwort:";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(103, 4);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(300, 23);
			this.txtUsername.TabIndex = 1;
			// 
			// lblUsername
			// 
			this.lblUsername.Location = new System.Drawing.Point(7, 4);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(90, 23);
			this.lblUsername.TabIndex = 0;
			this.lblUsername.Text = "Benutzername:";
			this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// proxySettingsDialog
			// 
			this.AcceptButton = this.btnSaveSettings;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(463, 357);
			this.Controls.Add(this.grpCustomProxy);
			this.Controls.Add(this.rbCustomProxy);
			this.Controls.Add(this.rbSystemProxy);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.lblTitle);
			this.Name = "proxySettingsDialog";
			this.Text = "Proxykonfiguration - [appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.grpCustomProxy.ResumeLayout(false);
			this.grpCustomProxy.PerformLayout();
			this.pnlCredentials.ResumeLayout(false);
			this.pnlCredentials.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel lblTitle;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCancel;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnSaveSettings;
		private System.Windows.Forms.RadioButton rbCustomAuth;
		private System.Windows.Forms.RadioButton rbWinAuth;
		private System.Windows.Forms.RadioButton rbNoAuth;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lblProxyPort;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblProxyServer;
		private System.Windows.Forms.RadioButton rbCustomProxy;
		private System.Windows.Forms.RadioButton rbSystemProxy;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpCustomProxy;
		private System.Windows.Forms.Panel pnlCredentials;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblUsername;
	}
}