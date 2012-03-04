namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class updateSubPage {
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
			this.lvwPublishWith = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmDummy = new System.Windows.Forms.ColumnHeader();
			this.grpPublish = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblLastPublishedDescription = new System.Windows.Forms.Label();
			this.fbtnVersionPopup = new updateSystemDotNet.Administration.UI.Controls.flatButton();
			this.flpControl = new System.Windows.Forms.FlowLayoutPanel();
			this.grpPublish.SuspendLayout();
			this.flpControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwPublishWith
			// 
			this.lvwPublishWith.CheckBoxes = true;
			this.lvwPublishWith.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDummy});
			this.lvwPublishWith.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwPublishWith.FullRowSelect = true;
			this.lvwPublishWith.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwPublishWith.Location = new System.Drawing.Point(12, 22);
			this.lvwPublishWith.Name = "lvwPublishWith";
			this.lvwPublishWith.Size = new System.Drawing.Size(408, 64);
			this.lvwPublishWith.TabIndex = 2;
			this.lvwPublishWith.UseCompatibleStateImageBehavior = false;
			this.lvwPublishWith.View = System.Windows.Forms.View.Details;
			// 
			// clmDummy
			// 
			this.clmDummy.Text = "Dummy";
			// 
			// grpPublish
			// 
			this.grpPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPublish.Controls.Add(this.lvwPublishWith);
			this.grpPublish.Location = new System.Drawing.Point(3, 138);
			this.grpPublish.Name = "grpPublish";
			this.grpPublish.Size = new System.Drawing.Size(432, 92);
			this.grpPublish.TabIndex = 5;
			this.grpPublish.TabStop = false;
			this.grpPublish.Text = "Veröffentlichen mit";
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(3, 30);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(42, 15);
			this.lblSize.TabIndex = 6;
			this.lblSize.Text = "Größe:";
			// 
			// lblLastPublishedDescription
			// 
			this.lblLastPublishedDescription.AutoSize = true;
			this.lblLastPublishedDescription.Location = new System.Drawing.Point(3, 50);
			this.lblLastPublishedDescription.Name = "lblLastPublishedDescription";
			this.lblLastPublishedDescription.Size = new System.Drawing.Size(120, 15);
			this.lblLastPublishedDescription.TabIndex = 7;
			this.lblLastPublishedDescription.Text = "Zuletzt veröffentlicht:";
			// 
			// fbtnVersionPopup
			// 
			this.fbtnVersionPopup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fbtnVersionPopup.AutoSize = true;
			this.fbtnVersionPopup.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.fbtnVersionPopup.Location = new System.Drawing.Point(66, 0);
			this.fbtnVersionPopup.Name = "fbtnVersionPopup";
			this.fbtnVersionPopup.Padding = new System.Windows.Forms.Padding(6);
			this.fbtnVersionPopup.Size = new System.Drawing.Size(130, 27);
			this.fbtnVersionPopup.TabIndex = 8;
			this.fbtnVersionPopup.Text = "Releasekonfiguration";
			this.fbtnVersionPopup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.fbtnVersionPopup.Click += new System.EventHandler(this.fbtnVersionPopup_Click);
			// 
			// flpControl
			// 
			this.flpControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flpControl.AutoSize = true;
			this.flpControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpControl.Controls.Add(this.fbtnVersionPopup);
			this.flpControl.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpControl.Location = new System.Drawing.Point(236, 3);
			this.flpControl.MinimumSize = new System.Drawing.Size(199, 0);
			this.flpControl.Name = "flpControl";
			this.flpControl.Size = new System.Drawing.Size(199, 27);
			this.flpControl.TabIndex = 9;
			// 
			// updateSubPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpControl);
			this.Controls.Add(this.lblLastPublishedDescription);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.grpPublish);
			this.Name = "updateSubPage";
			this.pageName = "#no name set#";
			this.Size = new System.Drawing.Size(439, 234);
			this.Controls.SetChildIndex(this.grpPublish, 0);
			this.Controls.SetChildIndex(this.lblSize, 0);
			this.Controls.SetChildIndex(this.lblLastPublishedDescription, 0);
			this.Controls.SetChildIndex(this.flpControl, 0);
			this.grpPublish.ResumeLayout(false);
			this.flpControl.ResumeLayout(false);
			this.flpControl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.extendedListView lvwPublishWith;
		private System.Windows.Forms.ColumnHeader clmDummy;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpPublish;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblLastPublishedDescription;
		private updateSystemDotNet.Administration.UI.Controls.flatButton fbtnVersionPopup;
		private System.Windows.Forms.FlowLayoutPanel flpControl;
	}
}
