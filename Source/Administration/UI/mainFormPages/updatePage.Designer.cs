namespace updateSystemDotNet.Administration.UI.mainFormPages {
	sealed partial class updatePage {
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
			this.grpFilter = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.chkShowServicePacksOnly = new System.Windows.Forms.CheckBox();
			this.chkHideUnpublishedUpdates = new System.Windows.Forms.CheckBox();
			this.txtSearchTerm = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.grpFilter.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFilter
			// 
			this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpFilter.Controls.Add(this.chkShowServicePacksOnly);
			this.grpFilter.Controls.Add(this.chkHideUnpublishedUpdates);
			this.grpFilter.Controls.Add(this.txtSearchTerm);
			this.grpFilter.Location = new System.Drawing.Point(4, 29);
			this.grpFilter.Name = "grpFilter";
			this.grpFilter.Size = new System.Drawing.Size(410, 135);
			this.grpFilter.TabIndex = 2;
			this.grpFilter.TabStop = false;
			this.grpFilter.Text = "Updatepakete filtern";
			// 
			// chkShowServicePacksOnly
			// 
			this.chkShowServicePacksOnly.AutoSize = true;
			this.chkShowServicePacksOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkShowServicePacksOnly.Location = new System.Drawing.Point(15, 83);
			this.chkShowServicePacksOnly.Name = "chkShowServicePacksOnly";
			this.chkShowServicePacksOnly.Size = new System.Drawing.Size(175, 20);
			this.chkShowServicePacksOnly.TabIndex = 2;
			this.chkShowServicePacksOnly.Text = "Nur Service Packs anzeigen";
			this.chkShowServicePacksOnly.UseVisualStyleBackColor = true;
			this.chkShowServicePacksOnly.CheckedChanged += new System.EventHandler(this.chkShowServicePacksOnly_CheckedChanged);
			// 
			// chkHideUnpublishedUpdates
			// 
			this.chkHideUnpublishedUpdates.AutoSize = true;
			this.chkHideUnpublishedUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkHideUnpublishedUpdates.Location = new System.Drawing.Point(15, 57);
			this.chkHideUnpublishedUpdates.Name = "chkHideUnpublishedUpdates";
			this.chkHideUnpublishedUpdates.Size = new System.Drawing.Size(251, 20);
			this.chkHideUnpublishedUpdates.TabIndex = 1;
			this.chkHideUnpublishedUpdates.Text = "Nicht veröffentlichte Updates ausblenden";
			this.chkHideUnpublishedUpdates.UseVisualStyleBackColor = true;
			this.chkHideUnpublishedUpdates.CheckedChanged += new System.EventHandler(this.chkHideUnpublishedUpdates_CheckedChanged);
			// 
			// txtSearchTerm
			// 
			this.txtSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchTerm.cueText = "Suchbegriff ...";
			this.txtSearchTerm.Location = new System.Drawing.Point(0, 25);
			this.txtSearchTerm.Name = "txtSearchTerm";
			this.txtSearchTerm.Size = new System.Drawing.Size(410, 23);
			this.txtSearchTerm.TabIndex = 0;
			this.txtSearchTerm.TextChanged += new System.EventHandler(this.txtSearchTerm_TextChanged);
			// 
			// updatePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpFilter);
			this.Name = "updatePage";
			this.Size = new System.Drawing.Size(417, 219);
			this.Controls.SetChildIndex(this.grpFilter, 0);
			this.grpFilter.ResumeLayout(false);
			this.grpFilter.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpFilter;
		private updateSystemDotNet.Administration.UI.Controls.textBoxEx txtSearchTerm;
		private System.Windows.Forms.CheckBox chkHideUnpublishedUpdates;
		private System.Windows.Forms.CheckBox chkShowServicePacksOnly;
	}
}
