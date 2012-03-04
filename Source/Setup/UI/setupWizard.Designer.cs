namespace updateSystemDotNet.Setup.UI {
	sealed partial class setupWizard {
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
			this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.flpButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// flpButtons
			// 
			this.flpButtons.Controls.Add(this.btnCancel);
			this.flpButtons.Controls.Add(this.btnNext);
			this.flpButtons.Controls.Add(this.btnBack);
			this.flpButtons.Controls.Add(this.lblVersion);
			this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpButtons.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.flpButtons.Location = new System.Drawing.Point(0, 333);
			this.flpButtons.Name = "flpButtons";
			this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 7, 12, 0);
			this.flpButtons.Size = new System.Drawing.Size(508, 43);
			this.flpButtons.TabIndex = 0;
			this.flpButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.flpButtons_Paint);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(416, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(77, 22);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNext
			// 
			this.btnNext.AutoSize = true;
			this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNext.Location = new System.Drawing.Point(335, 10);
			this.btnNext.MinimumSize = new System.Drawing.Size(75, 0);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 22);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "Weiter";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.AutoSize = true;
			this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBack.Location = new System.Drawing.Point(254, 10);
			this.btnBack.MinimumSize = new System.Drawing.Size(75, 0);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 22);
			this.btnBack.TabIndex = 2;
			this.btnBack.Text = "Zurück";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// lblVersion
			// 
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.Enabled = false;
			this.lblVersion.Location = new System.Drawing.Point(3, 7);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(245, 22);
			this.lblVersion.TabIndex = 3;
			this.lblVersion.Text = "label1";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTitle.Location = new System.Drawing.Point(12, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(484, 32);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "#title#";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlContent
			// 
			this.pnlContent.Location = new System.Drawing.Point(12, 59);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(484, 265);
			this.pnlContent.TabIndex = 2;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(508, 50);
			this.pnlHeader.TabIndex = 3;
			this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
			// 
			// setupWizard
			// 
			this.AcceptButton = this.btnNext;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(508, 376);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlContent);
			this.Controls.Add(this.flpButtons);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "setupWizard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "setupWizard";
			this.flpButtons.ResumeLayout(false);
			this.flpButtons.PerformLayout();
			this.pnlHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flpButtons;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlContent;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Panel pnlHeader;
	}
}