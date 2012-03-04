namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpOptions {
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
			this.txtSetupDir = new System.Windows.Forms.TextBox();
			this.btnBrowseSetupDir = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.chkStartMenuSC = new System.Windows.Forms.CheckBox();
			this.chkDesktopSC = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Installationsverzeichnis:";
			// 
			// txtSetupDir
			// 
			this.txtSetupDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSetupDir.Location = new System.Drawing.Point(7, 32);
			this.txtSetupDir.Name = "txtSetupDir";
			this.txtSetupDir.Size = new System.Drawing.Size(431, 23);
			this.txtSetupDir.TabIndex = 1;
			// 
			// btnBrowseSetupDir
			// 
			this.btnBrowseSetupDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseSetupDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseSetupDir.Location = new System.Drawing.Point(446, 30);
			this.btnBrowseSetupDir.Name = "btnBrowseSetupDir";
			this.btnBrowseSetupDir.Size = new System.Drawing.Size(107, 27);
			this.btnBrowseSetupDir.TabIndex = 2;
			this.btnBrowseSetupDir.Text = "Durchsuchen...";
			this.btnBrowseSetupDir.UseVisualStyleBackColor = true;
			this.btnBrowseSetupDir.Click += new System.EventHandler(this.btnBrowseSetupDir_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Verknüpfungen";
			// 
			// chkStartMenuSC
			// 
			this.chkStartMenuSC.AutoSize = true;
			this.chkStartMenuSC.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkStartMenuSC.Location = new System.Drawing.Point(10, 144);
			this.chkStartMenuSC.Name = "chkStartMenuSC";
			this.chkStartMenuSC.Size = new System.Drawing.Size(350, 20);
			this.chkStartMenuSC.TabIndex = 4;
			this.chkStartMenuSC.Text = "Verknüpfung zum updateSystem.NET im Startmenu anlegen";
			this.chkStartMenuSC.UseVisualStyleBackColor = true;
			// 
			// chkDesktopSC
			// 
			this.chkDesktopSC.AutoSize = true;
			this.chkDesktopSC.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkDesktopSC.Location = new System.Drawing.Point(10, 172);
			this.chkDesktopSC.Name = "chkDesktopSC";
			this.chkDesktopSC.Size = new System.Drawing.Size(368, 20);
			this.chkDesktopSC.TabIndex = 5;
			this.chkDesktopSC.Text = "Verknüpfung zum updateSystem.NET auf dem Desktop anlegen";
			this.chkDesktopSC.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label3.Location = new System.Drawing.Point(0, 279);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(556, 27);
			this.label3.TabIndex = 6;
			this.label3.Text = "Klicken Sie auf \"Weiter\" um mit der Installation zu beginnen.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// stpOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkDesktopSC);
			this.Controls.Add(this.chkStartMenuSC);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBrowseSetupDir);
			this.Controls.Add(this.txtSetupDir);
			this.Controls.Add(this.label1);
			this.Name = "stpOptions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSetupDir;
		private System.Windows.Forms.Button btnBrowseSetupDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkStartMenuSC;
		private System.Windows.Forms.CheckBox chkDesktopSC;
		private System.Windows.Forms.Label label3;
	}
}
