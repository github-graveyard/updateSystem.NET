namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	partial class sspImproveApp {
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
			this.lblImproveApp = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblImproveApp
			// 
			this.lblImproveApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblImproveApp.Location = new System.Drawing.Point(0, 0);
			this.lblImproveApp.Name = "lblImproveApp";
			this.lblImproveApp.Size = new System.Drawing.Size(390, 47);
			this.lblImproveApp.TabIndex = 0;
			this.lblImproveApp.Text = "Ihnen fehlt eine Einstellung oder Funktion? Dann nutzen Sie unser Feedbackformula" +
    "r (s. Links) um uns diese Mitzuteilen. Vielen Dank!";
			this.lblImproveApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sspImproveApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblImproveApp);
			this.displayOrder = 9999;
			this.Name = "sspImproveApp";
			this.Size = new System.Drawing.Size(390, 49);
			this.Title = "Feedback";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblImproveApp;
	}
}
