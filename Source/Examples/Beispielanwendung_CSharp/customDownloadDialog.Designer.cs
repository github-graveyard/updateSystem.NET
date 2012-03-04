namespace Beispielanwendung_CSharp {
	sealed partial class customDownloadDialog {
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
			this.prgDownload = new System.Windows.Forms.ProgressBar();
			this.btnCancelUpdate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// prgDownload
			// 
			this.prgDownload.Location = new System.Drawing.Point(13, 13);
			this.prgDownload.Name = "prgDownload";
			this.prgDownload.Size = new System.Drawing.Size(385, 15);
			this.prgDownload.TabIndex = 0;
			// 
			// btnCancelUpdate
			// 
			this.btnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancelUpdate.Location = new System.Drawing.Point(303, 34);
			this.btnCancelUpdate.Name = "btnCancelUpdate";
			this.btnCancelUpdate.Size = new System.Drawing.Size(95, 23);
			this.btnCancelUpdate.TabIndex = 1;
			this.btnCancelUpdate.Text = "Abbrechen";
			this.btnCancelUpdate.UseVisualStyleBackColor = true;
			this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
			// 
			// customDownloadDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 67);
			this.Controls.Add(this.btnCancelUpdate);
			this.Controls.Add(this.prgDownload);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "customDownloadDialog";
			this.ShowInTaskbar = false;
			this.Text = "customDownloadDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgDownload;
		private System.Windows.Forms.Button btnCancelUpdate;
	}
}