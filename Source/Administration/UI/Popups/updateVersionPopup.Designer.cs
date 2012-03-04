namespace updateSystemDotNet.Administration.UI.Popups {
	partial class updateVersionPopup {
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.chkServicePack = new System.Windows.Forms.CheckBox();
			this.chkPublished = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(13, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Version:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVersion
			// 
			this.txtVersion.Location = new System.Drawing.Point(126, 10);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.Size = new System.Drawing.Size(148, 23);
			this.txtVersion.TabIndex = 1;
			this.txtVersion.TextChanged += new System.EventHandler(this.txtVersion_TextChanged);
			// 
			// chkServicePack
			// 
			this.chkServicePack.AutoSize = true;
			this.chkServicePack.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkServicePack.Location = new System.Drawing.Point(16, 67);
			this.chkServicePack.Name = "chkServicePack";
			this.chkServicePack.Size = new System.Drawing.Size(97, 20);
			this.chkServicePack.TabIndex = 72;
			this.chkServicePack.Text = "Service Pack";
			this.chkServicePack.UseVisualStyleBackColor = true;
			this.chkServicePack.CheckedChanged += new System.EventHandler(this.chkServicePack_CheckedChanged);
			// 
			// chkPublished
			// 
			this.chkPublished.AutoSize = true;
			this.chkPublished.Checked = true;
			this.chkPublished.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPublished.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkPublished.Location = new System.Drawing.Point(16, 41);
			this.chkPublished.Name = "chkPublished";
			this.chkPublished.Size = new System.Drawing.Size(104, 20);
			this.chkPublished.TabIndex = 73;
			this.chkPublished.Text = "Veröffentlicht";
			this.chkPublished.UseVisualStyleBackColor = true;
			this.chkPublished.CheckedChanged += new System.EventHandler(this.chkPublished_CheckedChanged);
			// 
			// updateVersionPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 97);
			this.Controls.Add(this.chkServicePack);
			this.Controls.Add(this.chkPublished);
			this.Controls.Add(this.txtVersion);
			this.Controls.Add(this.label1);
			this.Name = "updateVersionPopup";
			this.Text = "updateVersionPopup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.CheckBox chkServicePack;
		private System.Windows.Forms.CheckBox chkPublished;
	}
}