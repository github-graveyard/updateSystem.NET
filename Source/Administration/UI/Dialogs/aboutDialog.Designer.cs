namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class aboutDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnClose = new System.Windows.Forms.Button();
			this.imgAppLogo = new System.Windows.Forms.PictureBox();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabelEx1 = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.lnkZipCredits = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.lnkIcons = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.lblCopyright = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.imgDonate = new System.Windows.Forms.PictureBox();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.lblAppName = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			((System.ComponentModel.ISupportInitialize)(this.imgAppLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgDonate)).BeginInit();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(589, 13);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Schließen";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// imgAppLogo
			// 
			this.imgAppLogo.Location = new System.Drawing.Point(12, 12);
			this.imgAppLogo.Name = "imgAppLogo";
			this.imgAppLogo.Size = new System.Drawing.Size(256, 256);
			this.imgAppLogo.TabIndex = 2;
			this.imgAppLogo.TabStop = false;
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.Location = new System.Drawing.Point(275, 42);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(152, 13);
			this.lblVersion.TabIndex = 4;
			this.lblVersion.Text = "Version: {0} Codename \"{1}\"";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(275, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Symbole:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(275, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Kompression:";
			// 
			// linkLabelEx1
			// 
			this.linkLabelEx1.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.linkLabelEx1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.linkLabelEx1.LinkArea = new System.Windows.Forms.LinkArea(33, 14);
			this.linkLabelEx1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkLabelEx1.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.linkLabelEx1.Location = new System.Drawing.Point(278, 147);
			this.linkLabelEx1.Name = "linkLabelEx1";
			this.linkLabelEx1.Size = new System.Drawing.Size(406, 31);
			this.linkLabelEx1.TabIndex = 11;
			this.linkLabelEx1.TabStop = true;
			this.linkLabelEx1.Text = "Ein besonderer Dank geht auch an Thomas Baumann für die Bereitstellung des Statis" +
    "tikcharts sowie diversen anderen Tipps und Tricks.";
			this.linkLabelEx1.Url = "http://shotty.devs-on.net";
			this.linkLabelEx1.UseCompatibleTextRendering = true;
			// 
			// lnkZipCredits
			// 
			this.lnkZipCredits.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lnkZipCredits.AutoSize = true;
			this.lnkZipCredits.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lnkZipCredits.LinkArea = new System.Windows.Forms.LinkArea(9, 8);
			this.lnkZipCredits.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkZipCredits.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lnkZipCredits.Location = new System.Drawing.Point(358, 115);
			this.lnkZipCredits.Name = "lnkZipCredits";
			this.lnkZipCredits.Size = new System.Drawing.Size(112, 21);
			this.lnkZipCredits.TabIndex = 10;
			this.lnkZipCredits.TabStop = true;
			this.lnkZipCredits.Text = "#ziplib (Homepage)";
			this.lnkZipCredits.Url = "http://www.icsharpcode.net/opensource/sharpziplib/";
			this.lnkZipCredits.UseCompatibleTextRendering = true;
			// 
			// lnkIcons
			// 
			this.lnkIcons.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lnkIcons.AutoSize = true;
			this.lnkIcons.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lnkIcons.LinkArea = new System.Windows.Forms.LinkArea(24, 17);
			this.lnkIcons.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkIcons.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lnkIcons.Location = new System.Drawing.Point(358, 95);
			this.lnkIcons.Name = "lnkIcons";
			this.lnkIcons.Size = new System.Drawing.Size(257, 21);
			this.lnkIcons.TabIndex = 8;
			this.lnkIcons.TabStop = true;
			this.lnkIcons.Text = "Fugue Icons Package von Yusuke Kamiyamane";
			this.lnkIcons.Url = "http://p.yusukekamiyamane.com/";
			this.lnkIcons.UseCompatibleTextRendering = true;
			// 
			// lblCopyright
			// 
			this.lblCopyright.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblCopyright.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblCopyright.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lblCopyright.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lblCopyright.Location = new System.Drawing.Point(275, 63);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(224, 15);
			this.lblCopyright.TabIndex = 6;
			this.lblCopyright.Text = "Copyright (c) 2008 - {0} Maximilian Krauß";
			this.lblCopyright.Url = "http://kraussz.com";
			// 
			// imgDonate
			// 
			this.imgDonate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgDonate.Location = new System.Drawing.Point(418, 198);
			this.imgDonate.Name = "imgDonate";
			this.imgDonate.Size = new System.Drawing.Size(126, 47);
			this.imgDonate.TabIndex = 12;
			this.imgDonate.TabStop = false;
			this.imgDonate.Click += new System.EventHandler(this.imgDonate_Click);
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnClose);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 292);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(676, 50);
			this.buttonArea1.TabIndex = 13;
			// 
			// lblAppName
			// 
			this.lblAppName.AutoSize = true;
			this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblAppName.Location = new System.Drawing.Point(274, 12);
			this.lblAppName.Name = "lblAppName";
			this.lblAppName.Size = new System.Drawing.Size(172, 21);
			this.lblAppName.TabIndex = 14;
			this.lblAppName.Text = "mainInstructionsLabel1";
			// 
			// aboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(676, 342);
			this.Controls.Add(this.lblAppName);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.imgDonate);
			this.Controls.Add(this.linkLabelEx1);
			this.Controls.Add(this.lnkZipCredits);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lnkIcons);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.imgAppLogo);
			this.Name = "aboutDialog";
			this.Text = "aboutDialog";
			((System.ComponentModel.ISupportInitialize)(this.imgAppLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgDonate)).EndInit();
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.PictureBox imgAppLogo;
		private System.Windows.Forms.Label lblVersion;
		private Controls.linkLabelEx lblCopyright;
		private System.Windows.Forms.Label label1;
		private Controls.linkLabelEx lnkIcons;
		private System.Windows.Forms.Label label2;
		private Controls.linkLabelEx lnkZipCredits;
		private Controls.linkLabelEx linkLabelEx1;
		private System.Windows.Forms.PictureBox imgDonate;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel lblAppName;

	}
}