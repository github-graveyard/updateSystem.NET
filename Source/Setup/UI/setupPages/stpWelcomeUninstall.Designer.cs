namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpWelcomeUninstall {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkRemoveSettings = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(470, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mit diesem Assistenten können Sie das updateSystem.NET von Ihrem Computer entfern" +
				"en.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 241);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(470, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Klicken Sie auf \"Weiter\" um mit der Deinstallation zu beginnen.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// chkRemoveSettings
			// 
			this.chkRemoveSettings.AutoSize = true;
			this.chkRemoveSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRemoveSettings.Location = new System.Drawing.Point(7, 74);
			this.chkRemoveSettings.Name = "chkRemoveSettings";
			this.chkRemoveSettings.Size = new System.Drawing.Size(325, 18);
			this.chkRemoveSettings.TabIndex = 2;
			this.chkRemoveSettings.Text = "Gespeicherte FTP- und Statistikserver ebenfalls entfernen";
			this.chkRemoveSettings.UseVisualStyleBackColor = true;
			// 
			// stpWelcomeUninstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkRemoveSettings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "stpWelcomeUninstall";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkRemoveSettings;
	}
}
