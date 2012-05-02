namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	partial class sspSetupId {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sspSetupId));
			this.txtSetupId = new System.Windows.Forms.TextBox();
			this.lblSetupId = new System.Windows.Forms.Label();
			this.lblSetupIdDescription = new System.Windows.Forms.Label();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.flpControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSetupId
			// 
			this.txtSetupId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSetupId.Location = new System.Drawing.Point(3, 73);
			this.txtSetupId.Name = "txtSetupId";
			this.txtSetupId.Size = new System.Drawing.Size(343, 23);
			this.txtSetupId.TabIndex = 8;
			this.txtSetupId.TextChanged += new System.EventHandler(this.txtSetupId_TextChanged);
			// 
			// lblSetupId
			// 
			this.lblSetupId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetupId.Location = new System.Drawing.Point(3, 45);
			this.lblSetupId.Name = "lblSetupId";
			this.lblSetupId.Size = new System.Drawing.Size(111, 25);
			this.lblSetupId.TabIndex = 7;
			this.lblSetupId.Text = "Installations-ID:";
			this.lblSetupId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSetupIdDescription
			// 
			this.lblSetupIdDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSetupIdDescription.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblSetupIdDescription, true);
			this.lblSetupIdDescription.Location = new System.Drawing.Point(3, 0);
			this.lblSetupIdDescription.Name = "lblSetupIdDescription";
			this.lblSetupIdDescription.Size = new System.Drawing.Size(437, 45);
			this.lblSetupIdDescription.TabIndex = 6;
			this.lblSetupIdDescription.Text = resources.GetString("lblSetupIdDescription.Text");
			// 
			// flpControls
			// 
			this.flpControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpControls.Controls.Add(this.lblSetupIdDescription);
			this.flpControls.Controls.Add(this.lblSetupId);
			this.flpControls.Controls.Add(this.txtSetupId);
			this.flpControls.Location = new System.Drawing.Point(3, 3);
			this.flpControls.Name = "flpControls";
			this.flpControls.Size = new System.Drawing.Size(463, 101);
			this.flpControls.TabIndex = 9;
			// 
			// sspSetupId
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpControls);
			this.displayOrder = 200;
			this.MinimumSize = new System.Drawing.Size(390, 100);
			this.Name = "sspSetupId";
			this.Size = new System.Drawing.Size(470, 108);
			this.Title = "Versionsaktualisierung";
			this.flpControls.ResumeLayout(false);
			this.flpControls.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtSetupId;
		private System.Windows.Forms.Label lblSetupId;
		private System.Windows.Forms.Label lblSetupIdDescription;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
	}
}
