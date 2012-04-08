namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	partial class statisticProjectsSubPage {
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
			this.lvwProjects = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.clmId = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.pnlProjectsBase = new System.Windows.Forms.Panel();
			this.bgwRefreshProjects = new System.ComponentModel.BackgroundWorker();
			this.bgwDeleteProject = new System.ComponentModel.BackgroundWorker();
			this.pnlProjectsBase.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwProjects
			// 
			this.lvwProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmId,
            this.columnHeader3});
			this.lvwProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwProjects.FullRowSelect = true;
			this.lvwProjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwProjects.Location = new System.Drawing.Point(0, 0);
			this.lvwProjects.MultiSelect = false;
			this.lvwProjects.Name = "lvwProjects";
			this.lvwProjects.Size = new System.Drawing.Size(443, 124);
			this.lvwProjects.TabIndex = 1;
			this.lvwProjects.UseCompatibleStateImageBehavior = false;
			this.lvwProjects.View = System.Windows.Forms.View.Details;
			this.lvwProjects.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwProjects_ColumnWidthChanged);
			this.lvwProjects.SelectedIndexChanged += new System.EventHandler(this.lvwProjects_SelectedIndexChanged);
			// 
			// clmName
			// 
			this.clmName.Text = "Projektname";
			this.clmName.Width = 195;
			// 
			// clmId
			// 
			this.clmId.Text = "Projekt Id";
			this.clmId.Width = 170;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Aktiv";
			this.columnHeader3.Width = 50;
			// 
			// pnlProjectsBase
			// 
			this.pnlProjectsBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlProjectsBase.Controls.Add(this.lvwProjects);
			this.pnlProjectsBase.Location = new System.Drawing.Point(5, 28);
			this.pnlProjectsBase.Name = "pnlProjectsBase";
			this.pnlProjectsBase.Size = new System.Drawing.Size(443, 124);
			this.pnlProjectsBase.TabIndex = 2;
			// 
			// bgwRefreshProjects
			// 
			this.bgwRefreshProjects.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRefreshProjects_DoWork);
			this.bgwRefreshProjects.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRefreshProjects_RunWorkerCompleted);
			// 
			// bgwDeleteProject
			// 
			this.bgwDeleteProject.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDeleteProject_DoWork);
			this.bgwDeleteProject.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDeleteProject_RunWorkerCompleted);
			// 
			// statisticProjectsSubPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlProjectsBase);
			this.Name = "statisticProjectsSubPage";
			this.Size = new System.Drawing.Size(451, 155);
			this.Controls.SetChildIndex(this.pnlProjectsBase, 0);
			this.pnlProjectsBase.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.extendedListView lvwProjects;
		private System.Windows.Forms.Panel pnlProjectsBase;
		private System.ComponentModel.BackgroundWorker bgwRefreshProjects;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmId;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.ComponentModel.BackgroundWorker bgwDeleteProject;
	}
}
