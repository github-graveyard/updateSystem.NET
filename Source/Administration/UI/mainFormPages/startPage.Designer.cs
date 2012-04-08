namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class startPage {
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
			this.lblProjectName = new System.Windows.Forms.Label();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.txtProjectId = new System.Windows.Forms.TextBox();
			this.lblProjectId = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblProjectName
			// 
			this.lblProjectName.Location = new System.Drawing.Point(5, 39);
			this.lblProjectName.Name = "lblProjectName";
			this.lblProjectName.Size = new System.Drawing.Size(108, 23);
			this.lblProjectName.TabIndex = 1;
			this.lblProjectName.Text = "Projektname:";
			this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProjectName
			// 
			this.txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProjectName.Location = new System.Drawing.Point(119, 39);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(392, 23);
			this.txtProjectName.TabIndex = 2;
			this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
			// 
			// txtProjectId
			// 
			this.txtProjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProjectId.Location = new System.Drawing.Point(119, 68);
			this.txtProjectId.Name = "txtProjectId";
			this.txtProjectId.ReadOnly = true;
			this.txtProjectId.Size = new System.Drawing.Size(392, 23);
			this.txtProjectId.TabIndex = 4;
			// 
			// lblProjectId
			// 
			this.lblProjectId.Location = new System.Drawing.Point(5, 68);
			this.lblProjectId.Name = "lblProjectId";
			this.lblProjectId.Size = new System.Drawing.Size(108, 23);
			this.lblProjectId.TabIndex = 3;
			this.lblProjectId.Text = "Projekt-Id:";
			this.lblProjectId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// startPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtProjectId);
			this.Controls.Add(this.lblProjectId);
			this.Controls.Add(this.txtProjectName);
			this.Controls.Add(this.lblProjectName);
			this.Name = "startPage";
			this.Size = new System.Drawing.Size(514, 301);
			this.Controls.SetChildIndex(this.lblProjectName, 0);
			this.Controls.SetChildIndex(this.txtProjectName, 0);
			this.Controls.SetChildIndex(this.lblProjectId, 0);
			this.Controls.SetChildIndex(this.txtProjectId, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProjectName;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.TextBox txtProjectId;
		private System.Windows.Forms.Label lblProjectId;
	}
}
