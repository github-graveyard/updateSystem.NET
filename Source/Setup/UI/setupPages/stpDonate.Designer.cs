namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpDonate {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stpDonate));
			this.imgDonate = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgDonate)).BeginInit();
			this.SuspendLayout();
			// 
			// imgDonate
			// 
			this.imgDonate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgDonate.Image = global::updateSystemDotNet.Setup.Properties.Resources.paypalDonate;
			this.imgDonate.Location = new System.Drawing.Point(204, 173);
			this.imgDonate.Name = "imgDonate";
			this.imgDonate.Size = new System.Drawing.Size(126, 47);
			this.imgDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgDonate.TabIndex = 0;
			this.imgDonate.TabStop = false;
			this.imgDonate.Click += new System.EventHandler(this.imgDonate_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(548, 134);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// stpDonate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imgDonate);
			this.Name = "stpDonate";
			((System.ComponentModel.ISupportInitialize)(this.imgDonate)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgDonate;
		private System.Windows.Forms.Label label1;
	}
}
