namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class settingPage {
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
			this.flpSettings = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// flpSettings
			// 
			this.flpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flpSettings.AutoScroll = true;
			this.flpSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpSettings.Location = new System.Drawing.Point(5, 28);
			this.flpSettings.Name = "flpSettings";
			this.flpSettings.Size = new System.Drawing.Size(494, 217);
			this.flpSettings.TabIndex = 1;
			this.flpSettings.WrapContents = false;
			// 
			// settingPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpSettings);
			this.Name = "settingPage";
			this.Size = new System.Drawing.Size(502, 248);
			this.Controls.SetChildIndex(this.flpSettings, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flpSettings;
	}
}
