namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpInstall {
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
			this.prgCopyFiles = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.bgwCopy = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// prgCopyFiles
			// 
			this.prgCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.prgCopyFiles.Location = new System.Drawing.Point(68, 143);
			this.prgCopyFiles.Name = "prgCopyFiles";
			this.prgCopyFiles.Size = new System.Drawing.Size(421, 20);
			this.prgCopyFiles.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(293, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bitte warten Sie während die Dateien kopiert werden ...";
			// 
			// bgwCopy
			// 
			this.bgwCopy.WorkerReportsProgress = true;
			this.bgwCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCopy_DoWork);
			// 
			// stpInstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.prgCopyFiles);
			this.Name = "stpInstall";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgCopyFiles;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker bgwCopy;
	}
}
