namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class statisticPage {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.uscMain = new updateSystemDotNet.Administration.UI.Controls.updateStatisticChart();
			this.flpControl = new System.Windows.Forms.FlowLayoutPanel();
			this.fbtnRefresh = new updateSystemDotNet.Administration.UI.Controls.flatButton();
			this.fBtnShowFilter = new updateSystemDotNet.Administration.UI.Controls.flatButton();
			this.bgwGetLog = new System.ComponentModel.BackgroundWorker();
			this.flpControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// uscMain
			// 
			this.uscMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.uscMain.BackColor = System.Drawing.Color.White;
			this.uscMain.Color1 = System.Drawing.Color.Red;
			this.uscMain.Color2 = System.Drawing.Color.Blue;
			this.uscMain.Error_NoData = "Keine Daten verfügbar!";
			this.uscMain.Location = new System.Drawing.Point(4, 36);
			this.uscMain.Mode = updateSystemDotNet.Administration.UI.Controls.updateStatisticChart.DrawMode.Solid;
			this.uscMain.Name = "uscMain";
			this.uscMain.Size = new System.Drawing.Size(434, 180);
			this.uscMain.TabIndex = 1;
			this.uscMain.ToolTipFormat = "Staistiken für den {0:dd/MM/yyyy}:\r\n    {1} Anfragen\r\n    {2} Downloads";
			// 
			// flpControl
			// 
			this.flpControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flpControl.AutoSize = true;
			this.flpControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpControl.Controls.Add(this.fbtnRefresh);
			this.flpControl.Controls.Add(this.fBtnShowFilter);
			this.flpControl.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpControl.Location = new System.Drawing.Point(235, 3);
			this.flpControl.Name = "flpControl";
			this.flpControl.Size = new System.Drawing.Size(203, 27);
			this.flpControl.TabIndex = 2;
			// 
			// fbtnRefresh
			// 
			this.fbtnRefresh.AutoSize = true;
			this.fbtnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.fbtnRefresh.Location = new System.Drawing.Point(113, 0);
			this.fbtnRefresh.Name = "fbtnRefresh";
			this.fbtnRefresh.Padding = new System.Windows.Forms.Padding(6);
			this.fbtnRefresh.Size = new System.Drawing.Size(87, 27);
			this.fbtnRefresh.TabIndex = 2;
			this.fbtnRefresh.Text = "Aktualisieren";
			this.fbtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.fbtnRefresh.Click += new System.EventHandler(this.fbtnRefresh_Click);
			// 
			// fBtnShowFilter
			// 
			this.fBtnShowFilter.AutoSize = true;
			this.fBtnShowFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.fBtnShowFilter.Location = new System.Drawing.Point(3, 0);
			this.fBtnShowFilter.Name = "fBtnShowFilter";
			this.fBtnShowFilter.Padding = new System.Windows.Forms.Padding(6);
			this.fBtnShowFilter.Size = new System.Drawing.Size(104, 27);
			this.fBtnShowFilter.TabIndex = 3;
			this.fBtnShowFilter.Text = "Filter bearbeiten";
			this.fBtnShowFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.fBtnShowFilter.Click += new System.EventHandler(this.fBtnShowFilter_Click);
			// 
			// bgwGetLog
			// 
			this.bgwGetLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetLog_DoWork);
			this.bgwGetLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetLog_RunWorkerCompleted);
			// 
			// statisticPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpControl);
			this.Controls.Add(this.uscMain);
			this.Name = "statisticPage";
			this.Size = new System.Drawing.Size(441, 219);
			this.Controls.SetChildIndex(this.uscMain, 0);
			this.Controls.SetChildIndex(this.flpControl, 0);
			this.flpControl.ResumeLayout(false);
			this.flpControl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.updateStatisticChart uscMain;
		private System.Windows.Forms.FlowLayoutPanel flpControl;
		private System.ComponentModel.BackgroundWorker bgwGetLog;
		private updateSystemDotNet.Administration.UI.Controls.flatButton fbtnRefresh;
		private updateSystemDotNet.Administration.UI.Controls.flatButton fBtnShowFilter;
	}
}
