namespace updateSystemDotNet.Internal.UI
{
    partial class updateSearchDialog
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
			this.lblCurrentVersion = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.bgwSearch = new System.ComponentModel.BackgroundWorker();
			this.aclSearch = new updateSystemDotNet.Internal.updateUI.Controls.statusLabel();
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.buttonArea1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCurrentVersion
			// 
			this.lblCurrentVersion.AutoSize = true;
			this.lblCurrentVersion.Location = new System.Drawing.Point(12, 37);
			this.lblCurrentVersion.Name = "lblCurrentVersion";
			this.lblCurrentVersion.Size = new System.Drawing.Size(103, 13);
			this.lblCurrentVersion.TabIndex = 10;
			this.lblCurrentVersion.Text = "Aktuelle Version: {0}";
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(319, 13);
			this.btnCancel.MinimumSize = new System.Drawing.Size(64, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 22);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "#var#";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.lblStatus.Location = new System.Drawing.Point(12, 9);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(143, 18);
			this.lblStatus.TabIndex = 8;
			this.lblStatus.Text = "#searchforupdates#";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bgwSearch
			// 
			this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
			// 
			// aclSearch
			// 
			this.aclSearch.BackColor = System.Drawing.Color.Transparent;
			this.aclSearch.Location = new System.Drawing.Point(12, 58);
			this.aclSearch.Name = "aclSearch";
			this.aclSearch.Size = new System.Drawing.Size(374, 39);
			this.aclSearch.State = updateSystemDotNet.Internal.updateUI.Controls.statusLabelStates.Waiting;
			this.aclSearch.TabIndex = 12;
			this.aclSearch.Text = "statusLabel1";
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 114);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(398, 43);
			this.buttonArea1.TabIndex = 13;
			// 
			// updateSearchDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(398, 157);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.aclSearch);
			this.Controls.Add(this.lblCurrentVersion);
			this.Controls.Add(this.lblStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "updateSearchDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "updateSystem.NET";
			this.Load += new System.EventHandler(this.SearchDialog_Load);
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblStatus;
		private System.ComponentModel.BackgroundWorker bgwSearch;
		private updateSystemDotNet.Internal.updateUI.Controls.statusLabel aclSearch;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
    }
}