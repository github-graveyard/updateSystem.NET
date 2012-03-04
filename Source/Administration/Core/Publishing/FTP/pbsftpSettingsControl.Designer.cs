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
			this.label1 = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboProtocol = new System.Windows.Forms.ComboBox();
			this.cboConnectionType = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDirectory = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serveradresse:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Protokoll:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Verbindung:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Benutzername:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 149);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "Passwort:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(3, 187);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "Verzeichnis:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pbsftpSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtDirectory);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cboConnectionType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cboProtocol);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(this.label1);
			this.Name = "pbsftpSettingsControl";
			this.Size = new System.Drawing.Size(405, 217);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboProtocol;
		private System.Windows.Forms.ComboBox cboConnectionType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.Label label7;
	}
}
