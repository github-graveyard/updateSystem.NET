namespace updateSystemDotNet.Administration.Core.Publishing.FTP {
	partial class pbsftpSettingsControl {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.lblServerAddress = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblPort = new System.Windows.Forms.Label();
			this.lblProtocol = new System.Windows.Forms.Label();
			this.cboProtocol = new System.Windows.Forms.ComboBox();
			this.cboConnectionType = new System.Windows.Forms.ComboBox();
			this.lblConnection = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtDirectory = new System.Windows.Forms.TextBox();
			this.lblDirectory = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblServerAddress
			// 
			this.lblServerAddress.Location = new System.Drawing.Point(0, 3);
			this.lblServerAddress.Name = "lblServerAddress";
			this.lblServerAddress.Size = new System.Drawing.Size(117, 23);
			this.lblServerAddress.TabIndex = 0;
			this.lblServerAddress.Text = "Serveradresse:";
			this.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtHost
			// 
			this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHost.Location = new System.Drawing.Point(123, 3);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(279, 23);
			this.txtHost.TabIndex = 1;
			// 
			// txtPort
			// 
			this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPort.Location = new System.Drawing.Point(123, 32);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(60, 23);
			this.txtPort.TabIndex = 3;
			// 
			// lblPort
			// 
			this.lblPort.Location = new System.Drawing.Point(0, 32);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(117, 23);
			this.lblPort.TabIndex = 2;
			this.lblPort.Text = "Port:";
			this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblProtocol
			// 
			this.lblProtocol.Location = new System.Drawing.Point(0, 62);
			this.lblProtocol.Name = "lblProtocol";
			this.lblProtocol.Size = new System.Drawing.Size(117, 23);
			this.lblProtocol.TabIndex = 4;
			this.lblProtocol.Text = "Protokoll:";
			this.lblProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboProtocol
			// 
			this.cboProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProtocol.FormattingEnabled = true;
			this.cboProtocol.Items.AddRange(new object[] {
            "FTP",
            "FTP/SSL (Explizit)",
            "FTP/SSL (Implizit)"});
			this.cboProtocol.Location = new System.Drawing.Point(124, 62);
			this.cboProtocol.Name = "cboProtocol";
			this.cboProtocol.Size = new System.Drawing.Size(278, 23);
			this.cboProtocol.TabIndex = 5;
			// 
			// cboConnectionType
			// 
			this.cboConnectionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboConnectionType.FormattingEnabled = true;
			this.cboConnectionType.Items.AddRange(new object[] {
            "Passiv (Empfohlen)",
            "Aktiv"});
			this.cboConnectionType.Location = new System.Drawing.Point(124, 91);
			this.cboConnectionType.Name = "cboConnectionType";
			this.cboConnectionType.Size = new System.Drawing.Size(278, 23);
			this.cboConnectionType.TabIndex = 7;
			// 
			// lblConnection
			// 
			this.lblConnection.Location = new System.Drawing.Point(0, 91);
			this.lblConnection.Name = "lblConnection";
			this.lblConnection.Size = new System.Drawing.Size(117, 23);
			this.lblConnection.TabIndex = 6;
			this.lblConnection.Text = "Verbindung:";
			this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUsername
			// 
			this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUsername.Location = new System.Drawing.Point(126, 120);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(279, 23);
			this.txtUsername.TabIndex = 9;
			// 
			// lblUsername
			// 
			this.lblUsername.Location = new System.Drawing.Point(3, 120);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(117, 23);
			this.lblUsername.TabIndex = 8;
			this.lblUsername.Text = "Benutzername:";
			this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Location = new System.Drawing.Point(126, 149);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(279, 23);
			this.txtPassword.TabIndex = 11;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(3, 149);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(117, 23);
			this.lblPassword.TabIndex = 10;
			this.lblPassword.Text = "Passwort:";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDirectory
			// 
			this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDirectory.Location = new System.Drawing.Point(126, 187);
			this.txtDirectory.Name = "txtDirectory";
			this.txtDirectory.Size = new System.Drawing.Size(279, 23);
			this.txtDirectory.TabIndex = 13;
			// 
			// lblDirectory
			// 
			this.lblDirectory.Location = new System.Drawing.Point(3, 187);
			this.lblDirectory.Name = "lblDirectory";
			this.lblDirectory.Size = new System.Drawing.Size(114, 23);
			this.lblDirectory.TabIndex = 12;
			this.lblDirectory.Text = "Verzeichnis:";
			this.lblDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pbsftpSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtDirectory);
			this.Controls.Add(this.lblDirectory);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.cboConnectionType);
			this.Controls.Add(this.lblConnection);
			this.Controls.Add(this.cboProtocol);
			this.Controls.Add(this.lblProtocol);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.lblPort);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(this.lblServerAddress);
			this.Name = "pbsftpSettingsControl";
			this.Size = new System.Drawing.Size(405, 217);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblServerAddress;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.Label lblProtocol;
		private System.Windows.Forms.ComboBox cboProtocol;
		private System.Windows.Forms.ComboBox cboConnectionType;
		private System.Windows.Forms.Label lblConnection;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.Label lblDirectory;
	}
}
