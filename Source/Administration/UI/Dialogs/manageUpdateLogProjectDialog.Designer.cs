namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class manageUpdateLogProjectDialog {
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
			this.mainInstructionsLabel1 = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnSave = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProjectId = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.txtProjectName = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.label2 = new System.Windows.Forms.Label();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.bgwEditProject = new System.ComponentModel.BackgroundWorker();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainInstructionsLabel1
			// 
			this.mainInstructionsLabel1.AutoSize = true;
			this.mainInstructionsLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.mainInstructionsLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.mainInstructionsLabel1.Location = new System.Drawing.Point(12, 9);
			this.mainInstructionsLabel1.Name = "mainInstructionsLabel1";
			this.mainInstructionsLabel1.Size = new System.Drawing.Size(137, 21);
			this.mainInstructionsLabel1.TabIndex = 0;
			this.mainInstructionsLabel1.Text = "Projekt bearbeiten";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnSave);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 142);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(459, 50);
			this.buttonArea1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(365, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.AutoSize = true;
			this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(286, 13);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(73, 24);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Projekt-Id:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProjectId
			// 
			this.txtProjectId.cueText = null;
			this.txtProjectId.Location = new System.Drawing.Point(108, 42);
			this.txtProjectId.Name = "txtProjectId";
			this.txtProjectId.Size = new System.Drawing.Size(336, 23);
			this.txtProjectId.TabIndex = 3;
			// 
			// txtProjectName
			// 
			this.txtProjectName.cueText = null;
			this.txtProjectName.Location = new System.Drawing.Point(108, 76);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(336, 23);
			this.txtProjectName.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Anzeigename:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.Location = new System.Drawing.Point(108, 110);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(315, 19);
			this.chkIsActive.TabIndex = 6;
			this.chkIsActive.Text = "Aktiv (wenn inaktiv werden keine Statistikdaten erfasst)";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// bgwEditProject
			// 
			this.bgwEditProject.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEditProject_DoWork);
			this.bgwEditProject.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEditProject_RunWorkerCompleted);
			// 
			// manageUpdateLogProjectDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 192);
			this.Controls.Add(this.chkIsActive);
			this.Controls.Add(this.txtProjectName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtProjectId);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.mainInstructionsLabel1);
			this.Name = "manageUpdateLogProjectDialog";
			this.Text = "manageUpdateLogProjectDialog";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel mainInstructionsLabel1;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnSave;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCancel;
		private System.Windows.Forms.Label label1;
		private updateSystemDotNet.Administration.UI.Controls.textBoxEx txtProjectId;
		private updateSystemDotNet.Administration.UI.Controls.textBoxEx txtProjectName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.ComponentModel.BackgroundWorker bgwEditProject;
	}
}