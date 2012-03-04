namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpLicense {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.rtbLicense = new System.Windows.Forms.RichTextBox();
			this.chkAccepted = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// rtbLicense
			// 
			this.rtbLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbLicense.BackColor = System.Drawing.Color.White;
			this.rtbLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbLicense.Location = new System.Drawing.Point(3, 9);
			this.rtbLicense.Name = "rtbLicense";
			this.rtbLicense.ReadOnly = true;
			this.rtbLicense.Size = new System.Drawing.Size(549, 261);
			this.rtbLicense.TabIndex = 0;
			this.rtbLicense.Text = "";
			// 
			// chkAccepted
			// 
			this.chkAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkAccepted.AutoSize = true;
			this.chkAccepted.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAccepted.Location = new System.Drawing.Point(5, 280);
			this.chkAccepted.Name = "chkAccepted";
			this.chkAccepted.Size = new System.Drawing.Size(293, 20);
			this.chkAccepted.TabIndex = 1;
			this.chkAccepted.Text = "Ich habe den Lizenzvertrag gelesen und akzeptiert";
			this.chkAccepted.UseVisualStyleBackColor = true;
			// 
			// stpLicense
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkAccepted);
			this.Controls.Add(this.rtbLicense);
			this.Name = "stpLicense";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbLicense;
		private System.Windows.Forms.CheckBox chkAccepted;
	}
}
