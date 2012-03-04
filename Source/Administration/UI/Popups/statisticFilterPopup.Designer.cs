namespace updateSystemDotNet.Administration.UI.Popups {
	partial class statisticFilterPopup {
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
			this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTimespan = new System.Windows.Forms.Label();
			this.cboOS = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// dtpDateTo
			// 
			this.dtpDateTo.CustomFormat = "dddd, dd.MM.yyyy";
			this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateTo.Location = new System.Drawing.Point(120, 61);
			this.dtpDateTo.Name = "dtpDateTo";
			this.dtpDateTo.Size = new System.Drawing.Size(181, 23);
			this.dtpDateTo.TabIndex = 3;
			this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bis:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpDateFrom
			// 
			this.dtpDateFrom.CustomFormat = "dddd, dd.MM.yyyy";
			this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateFrom.Location = new System.Drawing.Point(120, 32);
			this.dtpDateFrom.Name = "dtpDateFrom";
			this.dtpDateFrom.Size = new System.Drawing.Size(181, 23);
			this.dtpDateFrom.TabIndex = 1;
			this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Von:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Betriebssystem:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTimespan
			// 
			this.lblTimespan.AutoSize = true;
			this.lblTimespan.Location = new System.Drawing.Point(12, 9);
			this.lblTimespan.Name = "lblTimespan";
			this.lblTimespan.Size = new System.Drawing.Size(65, 15);
			this.lblTimespan.TabIndex = 5;
			this.lblTimespan.Text = "Zeitspanne";
			// 
			// cboOS
			// 
			this.cboOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOS.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cboOS.FormattingEnabled = true;
			this.cboOS.Location = new System.Drawing.Point(121, 95);
			this.cboOS.Name = "cboOS";
			this.cboOS.Size = new System.Drawing.Size(180, 23);
			this.cboOS.TabIndex = 6;
			this.cboOS.SelectedIndexChanged += new System.EventHandler(this.cboOS_SelectedIndexChanged);
			// 
			// statisticFilterPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(316, 132);
			this.Controls.Add(this.cboOS);
			this.Controls.Add(this.lblTimespan);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtpDateTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtpDateFrom);
			this.Controls.Add(this.label1);
			this.Name = "statisticFilterPopup";
			this.Text = "statisticFilterPopup";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtpDateFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpDateTo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblTimespan;
		private System.Windows.Forms.ComboBox cboOS;
	}
}