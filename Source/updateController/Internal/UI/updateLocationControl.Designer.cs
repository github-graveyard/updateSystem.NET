namespace updateSystemDotNet.Internal.UI {
	partial class updateLocationControl {
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
			this.txtUpdateUri = new System.Windows.Forms.TextBox();
			this.btnCheckConnection = new System.Windows.Forms.Button();
			this.aclCheckConnection = new updateSystemDotNet.Internal.updateUI.Controls.statusLabel();
			this.bgwCheckConnection = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// txtUpdateUri
			// 
			this.txtUpdateUri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUpdateUri.Location = new System.Drawing.Point(4, 4);
			this.txtUpdateUri.Multiline = true;
			this.txtUpdateUri.Name = "txtUpdateUri";
			this.txtUpdateUri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtUpdateUri.Size = new System.Drawing.Size(278, 44);
			this.txtUpdateUri.TabIndex = 0;
			// 
			// btnCheckConnection
			// 
			this.btnCheckConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCheckConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCheckConnection.Location = new System.Drawing.Point(4, 55);
			this.btnCheckConnection.Name = "btnCheckConnection";
			this.btnCheckConnection.Size = new System.Drawing.Size(75, 23);
			this.btnCheckConnection.TabIndex = 1;
			this.btnCheckConnection.Text = "Überprüfen";
			this.btnCheckConnection.UseVisualStyleBackColor = true;
			this.btnCheckConnection.Click += new System.EventHandler(this.btnCheckConnection_Click);
			// 
			// aclCheckConnection
			// 
			this.aclCheckConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.aclCheckConnection.BackColor = System.Drawing.Color.Transparent;
			this.aclCheckConnection.Location = new System.Drawing.Point(85, 55);
			this.aclCheckConnection.Name = "aclCheckConnection";
			this.aclCheckConnection.Size = new System.Drawing.Size(197, 23);
			this.aclCheckConnection.State = updateSystemDotNet.Internal.updateUI.Controls.statusLabelStates.Waiting;
			this.aclCheckConnection.TabIndex = 2;
			this.aclCheckConnection.Text = "Überprüfe Erreichbarkeit";
			this.aclCheckConnection.Visible = false;
			// 
			// bgwCheckConnection
			// 
			this.bgwCheckConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckConnection_DoWork);
			// 
			// updateLocationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.aclCheckConnection);
			this.Controls.Add(this.btnCheckConnection);
			this.Controls.Add(this.txtUpdateUri);
			this.Name = "updateLocationControl";
			this.Size = new System.Drawing.Size(285, 84);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUpdateUri;
		private System.Windows.Forms.Button btnCheckConnection;
		private updateSystemDotNet.Internal.updateUI.Controls.statusLabel aclCheckConnection;
		private System.ComponentModel.BackgroundWorker bgwCheckConnection;
	}
}
