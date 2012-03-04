namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	partial class statisticUsersSubPage {
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Administratoren", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Benutzer", System.Windows.Forms.HorizontalAlignment.Left);
			this.pnlUsrBase = new System.Windows.Forms.Panel();
			this.lvwUser = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.clmMaxProjects = new System.Windows.Forms.ColumnHeader();
			this.clmIsActive = new System.Windows.Forms.ColumnHeader();
			this.bgwRefreshUser = new System.ComponentModel.BackgroundWorker();
			this.bgwDeleteUser = new System.ComponentModel.BackgroundWorker();
			this.pnlUsrBase.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlUsrBase
			// 
			this.pnlUsrBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlUsrBase.Controls.Add(this.lvwUser);
			this.pnlUsrBase.Location = new System.Drawing.Point(5, 28);
			this.pnlUsrBase.Name = "pnlUsrBase";
			this.pnlUsrBase.Size = new System.Drawing.Size(443, 124);
			this.pnlUsrBase.TabIndex = 1;
			// 
			// lvwUser
			// 
			this.lvwUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmMaxProjects,
            this.clmIsActive});
			this.lvwUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwUser.FullRowSelect = true;
			listViewGroup1.Header = "Administratoren";
			listViewGroup1.Name = "grpAdmins";
			listViewGroup2.Header = "Benutzer";
			listViewGroup2.Name = "grpUser";
			this.lvwUser.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.lvwUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwUser.Location = new System.Drawing.Point(0, 0);
			this.lvwUser.MultiSelect = false;
			this.lvwUser.Name = "lvwUser";
			this.lvwUser.Size = new System.Drawing.Size(443, 124);
			this.lvwUser.TabIndex = 1;
			this.lvwUser.UseCompatibleStateImageBehavior = false;
			this.lvwUser.View = System.Windows.Forms.View.Details;
			this.lvwUser.SelectedIndexChanged += new System.EventHandler(this.lvwUser_SelectedIndexChanged);
			// 
			// clmName
			// 
			this.clmName.Text = "Benutzername";
			this.clmName.Width = 269;
			// 
			// clmMaxProjects
			// 
			this.clmMaxProjects.Text = "Max. Projekte";
			this.clmMaxProjects.Width = 100;
			// 
			// clmIsActive
			// 
			this.clmIsActive.Text = "Aktiv";
			this.clmIsActive.Width = 50;
			// 
			// bgwRefreshUser
			// 
			this.bgwRefreshUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRefreshUser_DoWork);
			// 
			// bgwDeleteUser
			// 
			this.bgwDeleteUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDeleteUser_DoWork);
			this.bgwDeleteUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDeleteUser_RunWorkerCompleted);
			// 
			// statisticUsersSubPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlUsrBase);
			this.Name = "statisticUsersSubPage";
			this.pageName = "Benutzer";
			this.Size = new System.Drawing.Size(451, 155);
			this.Title = "Statistikserver Benutzer";
			this.Controls.SetChildIndex(this.pnlUsrBase, 0);
			this.pnlUsrBase.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlUsrBase;
		private updateSystemDotNet.Administration.UI.Controls.extendedListView lvwUser;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmMaxProjects;
		private System.Windows.Forms.ColumnHeader clmIsActive;
		private System.ComponentModel.BackgroundWorker bgwRefreshUser;
		private System.ComponentModel.BackgroundWorker bgwDeleteUser;

	}
}
