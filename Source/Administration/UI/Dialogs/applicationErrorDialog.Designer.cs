namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class applicationErrorDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(applicationErrorDialog));
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnClose = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnSendReport = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.aclSend = new updateSystemDotNet.Administration.UI.Controls.actionLabel();
			this.mainInstructionsLabel1 = new updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDetailsDescription = new System.Windows.Forms.Label();
			this.lblExceptionText = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEMail = new System.Windows.Forms.TextBox();
			this.bgwSendReport = new System.ComponentModel.BackgroundWorker();
			this.buttonArea1.SuspendLayout();
			this.flpControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnClose);
			this.buttonArea1.Controls.Add(this.btnSendReport);
			this.buttonArea1.Controls.Add(this.aclSend);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 284);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(492, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(405, 13);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Schließen";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSendReport
			// 
			this.btnSendReport.AutoSize = true;
			this.btnSendReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSendReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSendReport.Location = new System.Drawing.Point(273, 13);
			this.btnSendReport.Name = "btnSendReport";
			this.btnSendReport.Size = new System.Drawing.Size(126, 24);
			this.btnSendReport.TabIndex = 0;
			this.btnSendReport.Text = "Fehlerreport senden";
			this.btnSendReport.UseVisualStyleBackColor = true;
			this.btnSendReport.Click += new System.EventHandler(this.btnSendReport_Click);
			// 
			// aclSend
			// 
			this.aclSend.BackColor = System.Drawing.Color.Transparent;
			this.aclSend.Location = new System.Drawing.Point(16, 13);
			this.aclSend.Name = "aclSend";
			this.aclSend.Size = new System.Drawing.Size(251, 23);
			this.aclSend.State = updateSystemDotNet.Administration.UI.Controls.actionLabelStates.Waiting;
			this.aclSend.suppressTextPadding = false;
			this.aclSend.TabIndex = 2;
			this.aclSend.Text = "Der Fehlerreport wird übertragen...";
			this.aclSend.Visible = false;
			// 
			// mainInstructionsLabel1
			// 
			this.mainInstructionsLabel1.AutoSize = true;
			this.mainInstructionsLabel1.BackColor = System.Drawing.Color.Transparent;
			this.mainInstructionsLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.mainInstructionsLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.mainInstructionsLabel1.Location = new System.Drawing.Point(12, 9);
			this.mainInstructionsLabel1.Name = "mainInstructionsLabel1";
			this.mainInstructionsLabel1.Size = new System.Drawing.Size(314, 21);
			this.mainInstructionsLabel1.TabIndex = 1;
			this.mainInstructionsLabel1.Text = "Die Anwendung hat ein Problem festgestellt";
			// 
			// flpControls
			// 
			this.flpControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flpControls.BackColor = System.Drawing.Color.Transparent;
			this.flpControls.Controls.Add(this.label1);
			this.flpControls.Controls.Add(this.lblDetailsDescription);
			this.flpControls.Controls.Add(this.lblExceptionText);
			this.flpControls.Controls.Add(this.label3);
			this.flpControls.Controls.Add(this.label4);
			this.flpControls.Controls.Add(this.txtEMail);
			this.flpControls.Location = new System.Drawing.Point(16, 42);
			this.flpControls.Name = "flpControls";
			this.flpControls.Size = new System.Drawing.Size(461, 232);
			this.flpControls.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label1, true);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(454, 60);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// lblDetailsDescription
			// 
			this.lblDetailsDescription.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblDetailsDescription, true);
			this.lblDetailsDescription.Location = new System.Drawing.Point(3, 70);
			this.lblDetailsDescription.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblDetailsDescription.Name = "lblDetailsDescription";
			this.lblDetailsDescription.Size = new System.Drawing.Size(76, 15);
			this.lblDetailsDescription.TabIndex = 1;
			this.lblDetailsDescription.Text = "Fehlerdetails:";
			// 
			// lblExceptionText
			// 
			this.lblExceptionText.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblExceptionText, true);
			this.lblExceptionText.Location = new System.Drawing.Point(3, 91);
			this.lblExceptionText.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.lblExceptionText.MaximumSize = new System.Drawing.Size(0, 35);
			this.lblExceptionText.Name = "lblExceptionText";
			this.lblExceptionText.Size = new System.Drawing.Size(295, 15);
			this.lblExceptionText.TabIndex = 2;
			this.lblExceptionText.Text = "#Das System konnte die Datei \"muh.exe\" nicht finden#";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label3, true);
			this.label3.Location = new System.Drawing.Point(3, 116);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(455, 45);
			this.label3.TabIndex = 3;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 167);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.label4.MinimumSize = new System.Drawing.Size(0, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(140, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "E-Mailadresse (Optional):";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEMail
			// 
			this.txtEMail.Location = new System.Drawing.Point(149, 167);
			this.txtEMail.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.txtEMail.Name = "txtEMail";
			this.txtEMail.Size = new System.Drawing.Size(265, 23);
			this.txtEMail.TabIndex = 5;
			// 
			// bgwSendReport
			// 
			this.bgwSendReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendReport_DoWork);
			this.bgwSendReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSendReport_RunWorkerCompleted);
			// 
			// applicationErrorDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 334);
			this.Controls.Add(this.flpControls);
			this.Controls.Add(this.mainInstructionsLabel1);
			this.Controls.Add(this.buttonArea1);
			this.Name = "applicationErrorDialog";
			this.Text = "[appname] - AppCrash";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.flpControls.ResumeLayout(false);
			this.flpControls.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnClose;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnSendReport;
		private updateSystemDotNet.Administration.UI.Controls.mainInstructionsLabel mainInstructionsLabel1;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDetailsDescription;
		private System.Windows.Forms.Label lblExceptionText;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEMail;
		private updateSystemDotNet.Administration.UI.Controls.actionLabel aclSend;
		private System.ComponentModel.BackgroundWorker bgwSendReport;
	}
}