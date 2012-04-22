namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class chooseNewPublishProviderDialog {
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
			this.lblNewProvider = new System.Windows.Forms.Label();
			this.cboPublishProvider = new System.Windows.Forms.ComboBox();
			this.lblPublishDescription = new System.Windows.Forms.Label();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 164);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(443, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(349, 13);
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
			this.btnOk.Location = new System.Drawing.Point(268, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 25);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblNewProvider
			// 
			this.lblNewProvider.AutoSize = true;
			this.lblNewProvider.Location = new System.Drawing.Point(12, 12);
			this.lblNewProvider.Name = "lblNewProvider";
			this.lblNewProvider.Size = new System.Drawing.Size(327, 15);
			this.lblNewProvider.TabIndex = 1;
			this.lblNewProvider.Text = "Wählen Sie das Ziel für die neue Veröffentlichungsquelle aus:";
			// 
			// cboPublishProvider
			// 
			this.cboPublishProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboPublishProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPublishProvider.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cboPublishProvider.FormattingEnabled = true;
			this.cboPublishProvider.Location = new System.Drawing.Point(12, 37);
			this.cboPublishProvider.Name = "cboPublishProvider";
			this.cboPublishProvider.Size = new System.Drawing.Size(416, 23);
			this.cboPublishProvider.TabIndex = 2;
			// 
			// lblPublishDescription
			// 
			this.lblPublishDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPublishDescription.Location = new System.Drawing.Point(12, 73);
			this.lblPublishDescription.Name = "lblPublishDescription";
			this.lblPublishDescription.Size = new System.Drawing.Size(416, 77);
			this.lblPublishDescription.TabIndex = 3;
			this.lblPublishDescription.Text = "#description goes here#";
			// 
			// chooseNewPublishProviderDialog
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(443, 214);
			this.Controls.Add(this.lblPublishDescription);
			this.Controls.Add(this.cboPublishProvider);
			this.Controls.Add(this.lblNewProvider);
			this.Controls.Add(this.buttonArea1);
			this.Name = "chooseNewPublishProviderDialog";
			this.Text = "Veröffentlichungsschnittstelle auswählen";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblNewProvider;
		private System.Windows.Forms.ComboBox cboPublishProvider;
		private System.Windows.Forms.Label lblPublishDescription;
	}
}