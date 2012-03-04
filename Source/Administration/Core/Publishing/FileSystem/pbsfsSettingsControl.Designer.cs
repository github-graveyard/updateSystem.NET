namespace updateSystemDotNet.Administration.Core.Publishing.FileSystem {
	partial class pbsfsSettingsControl {
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
			this.lblPublishTarget = new System.Windows.Forms.Label();
			this.btnBrowseDirectory = new System.Windows.Forms.Button();
			this.txtPublishDirectory = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblPublishTarget
			// 
			this.lblPublishTarget.AutoSize = true;
			this.lblPublishTarget.Location = new System.Drawing.Point(0, 3);
			this.lblPublishTarget.Name = "lblPublishTarget";
			this.lblPublishTarget.Size = new System.Drawing.Size(121, 15);
			this.lblPublishTarget.TabIndex = 0;
			this.lblPublishTarget.Text = "Veröffentlichungsziel:";
			// 
			// btnBrowseDirectory
			// 
			this.btnBrowseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseDirectory.AutoSize = true;
			this.btnBrowseDirectory.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseDirectory.Location = new System.Drawing.Point(305, 24);
			this.btnBrowseDirectory.Name = "btnBrowseDirectory";
			this.btnBrowseDirectory.Size = new System.Drawing.Size(100, 25);
			this.btnBrowseDirectory.TabIndex = 1;
			this.btnBrowseDirectory.Text = "Durchsuchen...";
			this.btnBrowseDirectory.UseVisualStyleBackColor = true;
			this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
			// 
			// txtPublishDirectory
			// 
			this.txtPublishDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPublishDirectory.Location = new System.Drawing.Point(0, 26);
			this.txtPublishDirectory.Name = "txtPublishDirectory";
			this.txtPublishDirectory.Size = new System.Drawing.Size(300, 23);
			this.txtPublishDirectory.TabIndex = 2;
			// 
			// pbsfsSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtPublishDirectory);
			this.Controls.Add(this.btnBrowseDirectory);
			this.Controls.Add(this.lblPublishTarget);
			this.Name = "pbsfsSettingsControl";
			this.Size = new System.Drawing.Size(405, 58);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPublishTarget;
		private System.Windows.Forms.Button btnBrowseDirectory;
		private System.Windows.Forms.TextBox txtPublishDirectory;
	}
}
