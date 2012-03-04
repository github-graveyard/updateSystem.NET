using updateSystemDotNet.Administration.UI.Controls;
namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class manageUpdateLogUserDialog {
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
			this.btnCancel = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnOk = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.lblTitle = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPasswordRetype = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.label3 = new System.Windows.Forms.Label();
			this.chkIsAdmin = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nmdMaxProjects = new System.Windows.Forms.NumericUpDown();
			this.bgwServerRequest = new System.ComponentModel.BackgroundWorker();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.buttonArea1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmdMaxProjects)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 229);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(481, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(387, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(308, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(73, 24);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Speichern";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblTitle.Location = new System.Drawing.Point(12, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(210, 21);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Benutzer anlegen/bearbeiten";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Benutzername:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUsername
			// 
			this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUsername.Location = new System.Drawing.Point(144, 42);
			this.txtUsername.MaxLength = 200;
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(322, 23);
			this.txtUsername.TabIndex = 3;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.cueText = "";
			this.txtPassword.Location = new System.Drawing.Point(144, 76);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(322, 23);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Passwort:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPasswordRetype
			// 
			this.txtPasswordRetype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPasswordRetype.cueText = null;
			this.txtPasswordRetype.Location = new System.Drawing.Point(144, 105);
			this.txtPasswordRetype.Name = "txtPasswordRetype";
			this.txtPasswordRetype.Size = new System.Drawing.Size(322, 23);
			this.txtPasswordRetype.TabIndex = 7;
			this.txtPasswordRetype.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Wiederholen:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkIsAdmin
			// 
			this.chkIsAdmin.AutoSize = true;
			this.chkIsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkIsAdmin.Location = new System.Drawing.Point(144, 168);
			this.chkIsAdmin.Name = "chkIsAdmin";
			this.chkIsAdmin.Size = new System.Drawing.Size(209, 20);
			this.chkIsAdmin.TabIndex = 8;
			this.chkIsAdmin.Text = "Der Benutzer ist ein Administrator";
			this.chkIsAdmin.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Max. Updateprojekte:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nmdMaxProjects
			// 
			this.nmdMaxProjects.Location = new System.Drawing.Point(144, 139);
			this.nmdMaxProjects.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nmdMaxProjects.Name = "nmdMaxProjects";
			this.nmdMaxProjects.Size = new System.Drawing.Size(78, 23);
			this.nmdMaxProjects.TabIndex = 10;
			this.nmdMaxProjects.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// bgwServerRequest
			// 
			this.bgwServerRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwServerRequest_DoWork);
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkIsActive.Location = new System.Drawing.Point(144, 194);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(142, 20);
			this.chkIsActive.TabIndex = 11;
			this.chkIsActive.Text = "Der Benutzer ist aktiv";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// manageUpdateLogUserDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(481, 279);
			this.Controls.Add(this.chkIsActive);
			this.Controls.Add(this.nmdMaxProjects);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkIsAdmin);
			this.Controls.Add(this.txtPasswordRetype);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.buttonArea1);
			this.Name = "manageUpdateLogUserDialog";
			this.Text = "manageUpdateLogUserDialog";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmdMaxProjects)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCancel;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnOk;
		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel lblTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUsername;
		private textBoxEx txtPassword;
		private System.Windows.Forms.Label label2;
		private textBoxEx txtPasswordRetype;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkIsAdmin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nmdMaxProjects;
		private System.ComponentModel.BackgroundWorker bgwServerRequest;
		private System.Windows.Forms.CheckBox chkIsActive;
	}
}