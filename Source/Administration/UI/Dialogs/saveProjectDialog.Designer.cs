namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class saveProjectDialog {
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
			this.lblProjectName = new System.Windows.Forms.Label();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.txtProjectLocation = new System.Windows.Forms.TextBox();
			this.lblDestination = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblProjectName
			// 
			this.lblProjectName.Location = new System.Drawing.Point(13, 18);
			this.lblProjectName.Name = "lblProjectName";
			this.lblProjectName.Size = new System.Drawing.Size(97, 21);
			this.lblProjectName.TabIndex = 0;
			this.lblProjectName.Text = "Projektname:";
			this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(116, 18);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(294, 23);
			this.txtProjectName.TabIndex = 1;
			this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
			// 
			// txtProjectLocation
			// 
			this.txtProjectLocation.Location = new System.Drawing.Point(116, 54);
			this.txtProjectLocation.Name = "txtProjectLocation";
			this.txtProjectLocation.Size = new System.Drawing.Size(294, 23);
			this.txtProjectLocation.TabIndex = 3;
			// 
			// lblDestination
			// 
			this.lblDestination.Location = new System.Drawing.Point(13, 54);
			this.lblDestination.Name = "lblDestination";
			this.lblDestination.Size = new System.Drawing.Size(97, 21);
			this.lblDestination.TabIndex = 2;
			this.lblDestination.Text = "Speicherort:";
			this.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBrowse
			// 
			this.btnBrowse.AutoSize = true;
			this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowse.Location = new System.Drawing.Point(416, 52);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(100, 25);
			this.btnBrowse.TabIndex = 4;
			this.btnBrowse.Text = "Durchsuchen...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 128);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(531, 50);
			this.buttonArea1.TabIndex = 5;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(437, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 25);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(319, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(112, 25);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "Projekt speichern";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// saveProjectDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 178);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtProjectLocation);
			this.Controls.Add(this.lblDestination);
			this.Controls.Add(this.txtProjectName);
			this.Controls.Add(this.lblProjectName);
			this.Name = "saveProjectDialog";
			this.Text = "Projekt speichern - [appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProjectName;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.TextBox txtProjectLocation;
		private System.Windows.Forms.Label lblDestination;
		private System.Windows.Forms.Button btnBrowse;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}