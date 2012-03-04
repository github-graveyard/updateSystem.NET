namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	partial class sspGeneral {
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
			this.chkNativeImage = new System.Windows.Forms.CheckBox();
			this.lnkGoToMsdn = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.chkServicePackIsDefault = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkNativeImage
			// 
			this.chkNativeImage.AutoSize = true;
			this.chkNativeImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkNativeImage.Location = new System.Drawing.Point(0, 0);
			this.chkNativeImage.Name = "chkNativeImage";
			this.chkNativeImage.Size = new System.Drawing.Size(205, 20);
			this.chkNativeImage.TabIndex = 0;
			this.chkNativeImage.Text = ".NET Assemblies vorkompillieren";
			this.chkNativeImage.UseVisualStyleBackColor = true;
			this.chkNativeImage.CheckedChanged += new System.EventHandler(this.chkNativeImage_CheckedChanged);
			// 
			// lnkGoToMsdn
			// 
			this.lnkGoToMsdn.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lnkGoToMsdn.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lnkGoToMsdn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkGoToMsdn.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lnkGoToMsdn.Location = new System.Drawing.Point(211, 0);
			this.lnkGoToMsdn.Name = "lnkGoToMsdn";
			this.lnkGoToMsdn.Size = new System.Drawing.Size(137, 20);
			this.lnkGoToMsdn.TabIndex = 1;
			this.lnkGoToMsdn.TabStop = true;
			this.lnkGoToMsdn.Text = "Mehr Informationen";
			this.lnkGoToMsdn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkGoToMsdn.Url = "http://msdn.microsoft.com/de-de/library/6t9t5wcf(v=vs.80).aspx";
			// 
			// chkServicePackIsDefault
			// 
			this.chkServicePackIsDefault.AutoSize = true;
			this.chkServicePackIsDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkServicePackIsDefault.Location = new System.Drawing.Point(0, 26);
			this.chkServicePackIsDefault.Name = "chkServicePackIsDefault";
			this.chkServicePackIsDefault.Size = new System.Drawing.Size(350, 20);
			this.chkServicePackIsDefault.TabIndex = 2;
			this.chkServicePackIsDefault.Text = "Neue Updatepakete Standardmäßig als Service Pack anlegen";
			this.chkServicePackIsDefault.UseVisualStyleBackColor = true;
			this.chkServicePackIsDefault.CheckedChanged += new System.EventHandler(this.chkServicePackIsDefault_CheckedChanged);
			// 
			// sspGeneral
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkServicePackIsDefault);
			this.Controls.Add(this.lnkGoToMsdn);
			this.Controls.Add(this.chkNativeImage);
			this.displayOrder = 100;
			this.Name = "sspGeneral";
			this.Size = new System.Drawing.Size(390, 53);
			this.Title = "Allgemeine Einstellungen";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkNativeImage;
		private updateSystemDotNet.Administration.UI.Controls.linkLabelEx lnkGoToMsdn;
		private System.Windows.Forms.CheckBox chkServicePackIsDefault;

	}
}
