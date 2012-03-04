namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpUninstall {
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
			this.bgwUninstall = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// prgCopyFiles
			// 
			this.prgCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.prgCopyFiles.Location = new System.Drawing.Point(68, 143);
			this.prgCopyFiles.Name = "prgCopyFiles";
			this.prgCopyFiles.Size = new System.Drawing.Size(421, 20);
			this.prgCopyFiles.TabIndex = 1;
			// 
			// bgwUninstall
			// 
			this.bgwUninstall.WorkerReportsProgress = true;
			this.bgwUninstall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUninstall_DoWork);
			// 
			// stpUninstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.prgCopyFiles);
			this.Name = "stpUninstall";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgCopyFiles;
		private System.ComponentModel.BackgroundWorker bgwUninstall;
	}
}
