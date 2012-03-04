namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpUpgrade {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.grpDonate = new System.Windows.Forms.GroupBox();
			this.picDonate = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpDonate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDonate)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(470, 116);
			this.label1.TabIndex = 2;
			this.label1.Text = "Das Setup hat erkannt, dass bereits eine frühere Version vom updateSystem.NET auf" +
				" Ihrem Computer installiert ist.\r\n\r\nSie können es automatisch Upgraden in dem Si" +
				"e auf \"Weiter\" klicken.";
			// 
			// grpDonate
			// 
			this.grpDonate.Controls.Add(this.picDonate);
			this.grpDonate.Controls.Add(this.label2);
			this.grpDonate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpDonate.Location = new System.Drawing.Point(0, 190);
			this.grpDonate.Name = "grpDonate";
			this.grpDonate.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.grpDonate.Size = new System.Drawing.Size(477, 75);
			this.grpDonate.TabIndex = 3;
			this.grpDonate.TabStop = false;
			this.grpDonate.Text = "Die Weiterentwicklung unterstützen";
			// 
			// picDonate
			// 
			this.picDonate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picDonate.Dock = System.Windows.Forms.DockStyle.Right;
			this.picDonate.Image = global::updateSystemDotNet.Setup.Properties.Resources.paypalDonate;
			this.picDonate.Location = new System.Drawing.Point(331, 16);
			this.picDonate.Name = "picDonate";
			this.picDonate.Size = new System.Drawing.Size(143, 56);
			this.picDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picDonate.TabIndex = 1;
			this.picDonate.TabStop = false;
			this.picDonate.Click += new System.EventHandler(this.picDonate_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(10, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(323, 56);
			this.label2.TabIndex = 0;
			this.label2.Text = "Um auch weiterhin kostenlose Updates veröffentlichen zu können, wäre es schön wen" +
				"n Sie die Entwicklung mit einer Spende unterstützen könnten.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// stpUpgrade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpDonate);
			this.Controls.Add(this.label1);
			this.Name = "stpUpgrade";
			this.grpDonate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picDonate)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpDonate;
		private System.Windows.Forms.PictureBox picDonate;
		private System.Windows.Forms.Label label2;
	}
}
