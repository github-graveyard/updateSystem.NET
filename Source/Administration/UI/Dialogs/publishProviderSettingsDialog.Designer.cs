namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class publishProviderSettingsDialog {
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
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.txtProviderName = new System.Windows.Forms.TextBox();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.lblActive = new System.Windows.Forms.Label();
			this.pnlProviderSettings = new System.Windows.Forms.Panel();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 233);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(486, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(392, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(311, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 25);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Speichern";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(12, 12);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(119, 23);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name:";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProviderName
			// 
			this.txtProviderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProviderName.Location = new System.Drawing.Point(137, 12);
			this.txtProviderName.Name = "txtProviderName";
			this.txtProviderName.Size = new System.Drawing.Size(334, 23);
			this.txtProviderName.TabIndex = 2;
			// 
			// chkActive
			// 
			this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkActive.Location = new System.Drawing.Point(137, 41);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(334, 23);
			this.chkActive.TabIndex = 3;
			this.chkActive.UseVisualStyleBackColor = true;
			// 
			// lblActive
			// 
			this.lblActive.Location = new System.Drawing.Point(12, 41);
			this.lblActive.Name = "lblActive";
			this.lblActive.Size = new System.Drawing.Size(119, 23);
			this.lblActive.TabIndex = 4;
			this.lblActive.Text = "Aktiviert:";
			this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlProviderSettings
			// 
			this.pnlProviderSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlProviderSettings.AutoScroll = true;
			this.pnlProviderSettings.Location = new System.Drawing.Point(12, 70);
			this.pnlProviderSettings.Name = "pnlProviderSettings";
			this.pnlProviderSettings.Size = new System.Drawing.Size(459, 157);
			this.pnlProviderSettings.TabIndex = 5;
			// 
			// publishProviderSettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 283);
			this.Controls.Add(this.pnlProviderSettings);
			this.Controls.Add(this.lblActive);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.txtProviderName);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.buttonArea1);
			this.Name = "publishProviderSettingsDialog";
			this.Text = "publishProviderSettingsDialog";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtProviderName;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.Label lblActive;
		private System.Windows.Forms.Panel pnlProviderSettings;
	}
}