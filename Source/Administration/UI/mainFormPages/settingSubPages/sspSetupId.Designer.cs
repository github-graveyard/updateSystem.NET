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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
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
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 25);
			this.label2.TabIndex = 7;
			this.label2.Text = "Installations-ID:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label1, true);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(437, 45);
			this.label1.TabIndex = 6;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// flpControls
			// 
			this.flpControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flpControls.Controls.Add(this.label1);
			this.flpControls.Controls.Add(this.label2);
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
	}
}
