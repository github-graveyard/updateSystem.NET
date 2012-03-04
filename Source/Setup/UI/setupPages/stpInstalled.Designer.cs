namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpInstalled {
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
			this.chkRunWhenDone = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(470, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "Das updateSystem.NET wurde erfolgreich installiert.";
			// 
			// chkRunWhenDone
			// 
			this.chkRunWhenDone.AutoSize = true;
			this.chkRunWhenDone.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRunWhenDone.Location = new System.Drawing.Point(7, 72);
			this.chkRunWhenDone.Name = "chkRunWhenDone";
			this.chkRunWhenDone.Size = new System.Drawing.Size(350, 18);
			this.chkRunWhenDone.TabIndex = 1;
			this.chkRunWhenDone.Text = "Die updateSystem.NET Administration nach dem Setup starten";
			this.chkRunWhenDone.UseVisualStyleBackColor = true;
			// 
			// stpInstalled
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkRunWhenDone);
			this.Controls.Add(this.label1);
			this.Name = "stpInstalled";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkRunWhenDone;
	}
}
