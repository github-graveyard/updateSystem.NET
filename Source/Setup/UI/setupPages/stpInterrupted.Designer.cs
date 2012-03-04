namespace updateSystemDotNet.Setup.UI.setupPages {
	partial class stpInterrupted {
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtException = new System.Windows.Forms.TextBox();
			this.imgError = new System.Windows.Forms.PictureBox();
			this.btnSendErrorReport = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlErrorReport = new System.Windows.Forms.Panel();
			this.bgwSendReport = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.imgError)).BeginInit();
			this.pnlErrorReport.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(50, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(424, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Auf Grund eines unerwarteten Probloems  konnte die Installation/Deinstallation de" +
				"s updateSystem.NET nicht vollständig durchgeführt werden.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Fehlerdetails:";
			// 
			// txtException
			// 
			this.txtException.Location = new System.Drawing.Point(10, 76);
			this.txtException.Multiline = true;
			this.txtException.Name = "txtException";
			this.txtException.ReadOnly = true;
			this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtException.Size = new System.Drawing.Size(464, 150);
			this.txtException.TabIndex = 2;
			// 
			// imgError
			// 
			this.imgError.Location = new System.Drawing.Point(10, 10);
			this.imgError.Name = "imgError";
			this.imgError.Size = new System.Drawing.Size(34, 35);
			this.imgError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgError.TabIndex = 3;
			this.imgError.TabStop = false;
			// 
			// btnSendErrorReport
			// 
			this.btnSendErrorReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSendErrorReport.Location = new System.Drawing.Point(3, 3);
			this.btnSendErrorReport.Name = "btnSendErrorReport";
			this.btnSendErrorReport.Size = new System.Drawing.Size(133, 23);
			this.btnSendErrorReport.TabIndex = 4;
			this.btnSendErrorReport.Text = "Problembericht senden";
			this.btnSendErrorReport.UseVisualStyleBackColor = true;
			this.btnSendErrorReport.Click += new System.EventHandler(this.btnSendErrorReport_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(142, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(319, 22);
			this.label3.TabIndex = 5;
			this.label3.Text = "Der Problembericht enthält keine persönlichen Informationen.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlErrorReport
			// 
			this.pnlErrorReport.Controls.Add(this.btnSendErrorReport);
			this.pnlErrorReport.Controls.Add(this.label3);
			this.pnlErrorReport.Location = new System.Drawing.Point(10, 232);
			this.pnlErrorReport.Name = "pnlErrorReport";
			this.pnlErrorReport.Size = new System.Drawing.Size(464, 29);
			this.pnlErrorReport.TabIndex = 6;
			this.pnlErrorReport.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlErrorReport_Paint);
			// 
			// bgwSendReport
			// 
			this.bgwSendReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendReport_DoWork);
			// 
			// stpInterrupted
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlErrorReport);
			this.Controls.Add(this.imgError);
			this.Controls.Add(this.txtException);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "stpInterrupted";
			((System.ComponentModel.ISupportInitialize)(this.imgError)).EndInit();
			this.pnlErrorReport.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtException;
		private System.Windows.Forms.PictureBox imgError;
		private System.Windows.Forms.Button btnSendErrorReport;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlErrorReport;
		private System.ComponentModel.BackgroundWorker bgwSendReport;
	}
}
