namespace testApplication
{
    partial class testForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnUpdateInteractive2 = new System.Windows.Forms.Button();
			this.btnUpdateInteractive = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnCheckForUpdatesSync = new System.Windows.Forms.Button();
			this.btnCancelUpdate = new System.Windows.Forms.Button();
			this.btnCheckForUpdates = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtArgs = new System.Windows.Forms.TextBox();
			this.lblLastUpdateCheck = new System.Windows.Forms.Label();
			this.grdController = new System.Windows.Forms.PropertyGrid();
			this.updateController1 = new updateSystemDotNet.updateController();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnUpdateInteractive2);
			this.groupBox1.Controls.Add(this.btnUpdateInteractive);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(249, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Built-In GUI";
			// 
			// btnUpdateInteractive2
			// 
			this.btnUpdateInteractive2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdateInteractive2.Location = new System.Drawing.Point(6, 48);
			this.btnUpdateInteractive2.Name = "btnUpdateInteractive2";
			this.btnUpdateInteractive2.Size = new System.Drawing.Size(224, 23);
			this.btnUpdateInteractive2.TabIndex = 1;
			this.btnUpdateInteractive2.Text = "updateInteractive + myDownloadForm";
			this.btnUpdateInteractive2.UseVisualStyleBackColor = true;
			this.btnUpdateInteractive2.Click += new System.EventHandler(this.btnUpdateInteractive2_Click);
			// 
			// btnUpdateInteractive
			// 
			this.btnUpdateInteractive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdateInteractive.Location = new System.Drawing.Point(6, 19);
			this.btnUpdateInteractive.Name = "btnUpdateInteractive";
			this.btnUpdateInteractive.Size = new System.Drawing.Size(224, 23);
			this.btnUpdateInteractive.TabIndex = 0;
			this.btnUpdateInteractive.Text = "updateInteractive";
			this.btnUpdateInteractive.UseVisualStyleBackColor = true;
			this.btnUpdateInteractive.Click += new System.EventHandler(this.btnUpdateInteractive_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnCheckForUpdatesSync);
			this.groupBox2.Controls.Add(this.btnCancelUpdate);
			this.groupBox2.Controls.Add(this.btnCheckForUpdates);
			this.groupBox2.Location = new System.Drawing.Point(12, 98);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(249, 117);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Own";
			// 
			// btnCheckForUpdatesSync
			// 
			this.btnCheckForUpdatesSync.Location = new System.Drawing.Point(7, 78);
			this.btnCheckForUpdatesSync.Name = "btnCheckForUpdatesSync";
			this.btnCheckForUpdatesSync.Size = new System.Drawing.Size(223, 23);
			this.btnCheckForUpdatesSync.TabIndex = 3;
			this.btnCheckForUpdatesSync.Text = "Check for Updates";
			this.btnCheckForUpdatesSync.UseVisualStyleBackColor = true;
			this.btnCheckForUpdatesSync.Click += new System.EventHandler(this.btnCheckForUpdatesSync_Click);
			// 
			// btnCancelUpdate
			// 
			this.btnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancelUpdate.Location = new System.Drawing.Point(6, 48);
			this.btnCancelUpdate.Name = "btnCancelUpdate";
			this.btnCancelUpdate.Size = new System.Drawing.Size(224, 23);
			this.btnCancelUpdate.TabIndex = 2;
			this.btnCancelUpdate.Text = "cancelUpdate";
			this.btnCancelUpdate.UseVisualStyleBackColor = true;
			this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
			// 
			// btnCheckForUpdates
			// 
			this.btnCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCheckForUpdates.Location = new System.Drawing.Point(6, 19);
			this.btnCheckForUpdates.Name = "btnCheckForUpdates";
			this.btnCheckForUpdates.Size = new System.Drawing.Size(224, 23);
			this.btnCheckForUpdates.TabIndex = 2;
			this.btnCheckForUpdates.Text = "checkForUpdates (async)";
			this.btnCheckForUpdates.UseVisualStyleBackColor = true;
			this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(15, 320);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(534, 10);
			this.progressBar1.TabIndex = 3;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtArgs);
			this.groupBox3.Location = new System.Drawing.Point(12, 221);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(249, 93);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Arguments";
			// 
			// txtArgs
			// 
			this.txtArgs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtArgs.Location = new System.Drawing.Point(3, 18);
			this.txtArgs.Multiline = true;
			this.txtArgs.Name = "txtArgs";
			this.txtArgs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtArgs.Size = new System.Drawing.Size(243, 72);
			this.txtArgs.TabIndex = 0;
			// 
			// lblLastUpdateCheck
			// 
			this.lblLastUpdateCheck.AutoSize = true;
			this.lblLastUpdateCheck.Location = new System.Drawing.Point(12, 336);
			this.lblLastUpdateCheck.Name = "lblLastUpdateCheck";
			this.lblLastUpdateCheck.Size = new System.Drawing.Size(108, 13);
			this.lblLastUpdateCheck.TabIndex = 5;
			this.lblLastUpdateCheck.Text = "#lastUpdateCheck#";
			// 
			// grdController
			// 
			this.grdController.Location = new System.Drawing.Point(267, 12);
			this.grdController.Name = "grdController";
			this.grdController.SelectedObject = this.updateController1;
			this.grdController.Size = new System.Drawing.Size(285, 299);
			this.grdController.TabIndex = 2;
			// 
			// updateController1
			// 
			this.updateController1.applicationLocation = "";
			this.updateController1.autoCloseHostApplication = true;
			this.updateController1.autoCopyCommandlineArguments = true;
			this.updateController1.projectId = "45a4e0c6-7730-4fa9-9bcf-890f8ed9f449";
			this.updateController1.proxyPassword = null;
			this.updateController1.proxyUrl = null;
			this.updateController1.proxyUsername = null;
			this.updateController1.releaseFilter.checkForAlpha = true;
			this.updateController1.releaseFilter.checkForBeta = true;
			this.updateController1.releaseFilter.checkForFinal = true;
			this.updateController1.releaseInfo.Type = updateSystemDotNet.releaseTypes.Alpha;
			this.updateController1.releaseInfo.Version = "0.0.0.1";
			this.updateController1.requestElevation = true;
			this.updateController1.restartApplication = true;
			this.updateController1.updateLocation = "https://updates.updatesystem.net/test/debug/";
			// 
			// testForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 357);
			this.Controls.Add(this.lblLastUpdateCheck);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grdController);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "testForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "updateController - Tester";
			this.Load += new System.EventHandler(this.testForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private updateSystemDotNet.updateController updateController1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateInteractive2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.Button btnUpdateInteractive;
        private System.Windows.Forms.PropertyGrid grdController;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Label lblLastUpdateCheck;
		private System.Windows.Forms.Button btnCheckForUpdatesSync;
    }
}

