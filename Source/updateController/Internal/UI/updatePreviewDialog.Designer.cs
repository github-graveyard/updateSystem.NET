namespace updateSystemDotNet.Internal.UI
{
	sealed partial class updatePreviewDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lblStatus = new System.Windows.Forms.Label();
			this.imgApp = new System.Windows.Forms.PictureBox();
			this.pnlExtended = new System.Windows.Forms.Panel();
			this.txtDetails = new System.Windows.Forms.TextBox();
			this.lblNewestVersion = new System.Windows.Forms.Label();
			this.lblCurrentVersion = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnStartUpdate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.imgApp)).BeginInit();
			this.pnlExtended.SuspendLayout();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblStatus.Location = new System.Drawing.Point(50, 12);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(338, 32);
			this.lblStatus.TabIndex = 9;
			this.lblStatus.Text = "#updatesavailable#";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imgApp
			// 
			this.imgApp.Location = new System.Drawing.Point(12, 12);
			this.imgApp.Name = "imgApp";
			this.imgApp.Size = new System.Drawing.Size(32, 32);
			this.imgApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgApp.TabIndex = 14;
			this.imgApp.TabStop = false;
			// 
			// pnlExtended
			// 
			this.pnlExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlExtended.BackColor = System.Drawing.Color.White;
			this.pnlExtended.Controls.Add(this.txtDetails);
			this.pnlExtended.Location = new System.Drawing.Point(12, 117);
			this.pnlExtended.Name = "pnlExtended";
			this.pnlExtended.Padding = new System.Windows.Forms.Padding(1, 5, 1, 3);
			this.pnlExtended.Size = new System.Drawing.Size(374, 111);
			this.pnlExtended.TabIndex = 20;
			this.pnlExtended.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlExtended_Paint);
			// 
			// txtDetails
			// 
			this.txtDetails.BackColor = System.Drawing.Color.White;
			this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDetails.Cursor = System.Windows.Forms.Cursors.Default;
			this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDetails.Location = new System.Drawing.Point(1, 5);
			this.txtDetails.Multiline = true;
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.ReadOnly = true;
			this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDetails.Size = new System.Drawing.Size(372, 103);
			this.txtDetails.TabIndex = 99;
			// 
			// lblNewestVersion
			// 
			this.lblNewestVersion.AutoSize = true;
			this.lblNewestVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNewestVersion.Location = new System.Drawing.Point(10, 50);
			this.lblNewestVersion.Name = "lblNewestVersion";
			this.lblNewestVersion.Size = new System.Drawing.Size(131, 13);
			this.lblNewestVersion.TabIndex = 21;
			this.lblNewestVersion.Text = "Neueste Version: 1.2.3.4";
			// 
			// lblCurrentVersion
			// 
			this.lblCurrentVersion.AutoSize = true;
			this.lblCurrentVersion.Location = new System.Drawing.Point(10, 69);
			this.lblCurrentVersion.Name = "lblCurrentVersion";
			this.lblCurrentVersion.Size = new System.Drawing.Size(86, 13);
			this.lblCurrentVersion.TabIndex = 22;
			this.lblCurrentVersion.Text = "Aktuelle Version:";
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(10, 89);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(73, 13);
			this.lblSize.TabIndex = 23;
			this.lblSize.Text = "Gesamtgröße:";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnStartUpdate);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 238);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(398, 43);
			this.buttonArea1.TabIndex = 24;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(316, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(67, 22);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "#cancel#";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnStartUpdate
			// 
			this.btnStartUpdate.AutoSize = true;
			this.btnStartUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStartUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnStartUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnStartUpdate.Location = new System.Drawing.Point(194, 13);
			this.btnStartUpdate.Name = "btnStartUpdate";
			this.btnStartUpdate.Size = new System.Drawing.Size(116, 22);
			this.btnStartUpdate.TabIndex = 1;
			this.btnStartUpdate.Text = "Update durchführen";
			this.btnStartUpdate.UseVisualStyleBackColor = true;
			// 
			// updatePreviewDialog
			// 
			this.AcceptButton = this.btnStartUpdate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(398, 281);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.lblCurrentVersion);
			this.Controls.Add(this.lblNewestVersion);
			this.Controls.Add(this.pnlExtended);
			this.Controls.Add(this.imgApp);
			this.Controls.Add(this.lblStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(404, 309);
			this.Name = "updatePreviewDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "updateSystem.Net";
			((System.ComponentModel.ISupportInitialize)(this.imgApp)).EndInit();
			this.pnlExtended.ResumeLayout(false);
			this.pnlExtended.PerformLayout();
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartUpdate;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PictureBox imgApp;
        private System.Windows.Forms.Panel pnlExtended;
        private System.Windows.Forms.Label lblNewestVersion;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblSize;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
    }
}