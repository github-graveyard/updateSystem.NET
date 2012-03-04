namespace updateSystemDotNet.Administration.UI {
	partial class mainForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.mnsMain = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuShowToolbar = new System.Windows.Forms.ToolStripMenuItem();
			this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuLinkStatisticServer = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUnlinkStatisticServer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuPublish = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSendFeedback = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThrowDebugException = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.imglContentNodes = new System.Windows.Forms.ImageList(this.components);
			this.pnlContentView = new System.Windows.Forms.Panel();
			this.tosMain = new System.Windows.Forms.ToolStrip();
			this.tsBtnNewProject = new System.Windows.Forms.ToolStripButton();
			this.tsBtnOpenProject = new System.Windows.Forms.ToolStripButton();
			this.tsBtnSaveProject = new System.Windows.Forms.ToolStripButton();
			this.sepPageControls = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnPublish = new System.Windows.Forms.ToolStripButton();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.tvwContentNodes = new updateSystemDotNet.Administration.UI.Controls.explorerTreeView();
			this.mnuUpgradeProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnsMain.SuspendLayout();
			this.tosMain.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnsMain
			// 
			this.mnsMain.Dock = System.Windows.Forms.DockStyle.None;
			this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.toolStripMenuItem1,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.mnsMain.Location = new System.Drawing.Point(0, 0);
			this.mnsMain.Name = "mnsMain";
			this.mnsMain.Size = new System.Drawing.Size(651, 24);
			this.mnsMain.TabIndex = 0;
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuOpen,
            this.toolStripSeparator,
            this.mnuSave,
            this.toolStripSeparator1,
            this.mnuClose});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.dateiToolStripMenuItem.Text = "&Datei";
			// 
			// mnuNewProject
			// 
			this.mnuNewProject.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewProject.Image")));
			this.mnuNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuNewProject.Name = "mnuNewProject";
			this.mnuNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mnuNewProject.Size = new System.Drawing.Size(168, 22);
			this.mnuNewProject.Text = "&Neu";
			this.mnuNewProject.Click += new System.EventHandler(this.mnuNewProject_Click);
			// 
			// mnuOpen
			// 
			this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
			this.mnuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnuOpen.Size = new System.Drawing.Size(168, 22);
			this.mnuOpen.Text = "Ö&ffnen";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(165, 6);
			// 
			// mnuSave
			// 
			this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
			this.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuSave.Name = "mnuSave";
			this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnuSave.Size = new System.Drawing.Size(168, 22);
			this.mnuSave.Text = "&Speichern";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
			// 
			// mnuClose
			// 
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.mnuClose.Size = new System.Drawing.Size(168, 22);
			this.mnuClose.Text = "&Beenden";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowToolbar});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
			this.toolStripMenuItem1.Text = "Ansicht";
			// 
			// mnuShowToolbar
			// 
			this.mnuShowToolbar.CheckOnClick = true;
			this.mnuShowToolbar.Enabled = false;
			this.mnuShowToolbar.Name = "mnuShowToolbar";
			this.mnuShowToolbar.Size = new System.Drawing.Size(165, 22);
			this.mnuShowToolbar.Text = "Toolbar anzeigen";
			this.mnuShowToolbar.Click += new System.EventHandler(this.mnuShowToolbar_Click);
			// 
			// extrasToolStripMenuItem
			// 
			this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpgradeProject,
            this.mnuSettings,
            this.toolStripSeparator2,
            this.mnuLinkStatisticServer,
            this.mnuUnlinkStatisticServer,
            this.toolStripSeparator3,
            this.mnuPublish});
			this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
			this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.extrasToolStripMenuItem.Text = "E&xtras";
			// 
			// mnuSettings
			// 
			this.mnuSettings.Name = "mnuSettings";
			this.mnuSettings.Size = new System.Drawing.Size(243, 22);
			this.mnuSettings.Text = "&Optionen";
			this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
			// 
			// mnuLinkStatisticServer
			// 
			this.mnuLinkStatisticServer.Name = "mnuLinkStatisticServer";
			this.mnuLinkStatisticServer.Size = new System.Drawing.Size(243, 22);
			this.mnuLinkStatisticServer.Text = "Mit Statistikserver verbinden...";
			this.mnuLinkStatisticServer.Click += new System.EventHandler(this.mnuStatisticServer_Click);
			// 
			// mnuUnlinkStatisticServer
			// 
			this.mnuUnlinkStatisticServer.Name = "mnuUnlinkStatisticServer";
			this.mnuUnlinkStatisticServer.Size = new System.Drawing.Size(243, 22);
			this.mnuUnlinkStatisticServer.Text = "Statistikserveraccount entfernen";
			this.mnuUnlinkStatisticServer.Visible = false;
			this.mnuUnlinkStatisticServer.Click += new System.EventHandler(this.mnuUnlinkStatisticServer_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(240, 6);
			// 
			// mnuPublish
			// 
			this.mnuPublish.Name = "mnuPublish";
			this.mnuPublish.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.mnuPublish.Size = new System.Drawing.Size(243, 22);
			this.mnuPublish.Text = "Projekt veröffentlichen";
			this.mnuPublish.Click += new System.EventHandler(this.mnuPublish_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckForUpdates,
            this.mnuSendFeedback,
            this.mnuThrowDebugException,
            this.toolStripSeparator5,
            this.mnuAbout});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.hilfeToolStripMenuItem.Text = "&Hilfe";
			// 
			// mnuCheckForUpdates
			// 
			this.mnuCheckForUpdates.Name = "mnuCheckForUpdates";
			this.mnuCheckForUpdates.Size = new System.Drawing.Size(244, 22);
			this.mnuCheckForUpdates.Text = "Nach Aktualisierungen suchen...";
			this.mnuCheckForUpdates.Click += new System.EventHandler(this.mnuCheckForUpdates_Click);
			// 
			// mnuSendFeedback
			// 
			this.mnuSendFeedback.Name = "mnuSendFeedback";
			this.mnuSendFeedback.Size = new System.Drawing.Size(244, 22);
			this.mnuSendFeedback.Text = "Feedback senden...";
			this.mnuSendFeedback.Click += new System.EventHandler(this.mnuSendFeedback_Click);
			// 
			// mnuThrowDebugException
			// 
			this.mnuThrowDebugException.Name = "mnuThrowDebugException";
			this.mnuThrowDebugException.Size = new System.Drawing.Size(244, 22);
			this.mnuThrowDebugException.Text = "Throw Exception";
			this.mnuThrowDebugException.Click += new System.EventHandler(this.mnuThrowDebugException_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(241, 6);
			// 
			// mnuAbout
			// 
			this.mnuAbout.Name = "mnuAbout";
			this.mnuAbout.Size = new System.Drawing.Size(244, 22);
			this.mnuAbout.Text = "Inf&o...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// imglContentNodes
			// 
			this.imglContentNodes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imglContentNodes.ImageSize = new System.Drawing.Size(16, 16);
			this.imglContentNodes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlContentView
			// 
			this.pnlContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlContentView.Location = new System.Drawing.Point(193, 12);
			this.pnlContentView.Name = "pnlContentView";
			this.pnlContentView.Size = new System.Drawing.Size(446, 288);
			this.pnlContentView.TabIndex = 2;
			// 
			// tosMain
			// 
			this.tosMain.Dock = System.Windows.Forms.DockStyle.None;
			this.tosMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tosMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNewProject,
            this.tsBtnOpenProject,
            this.tsBtnSaveProject,
            this.sepPageControls,
            this.toolStripSeparator6,
            this.tsBtnPublish});
			this.tosMain.Location = new System.Drawing.Point(0, 24);
			this.tosMain.Name = "tosMain";
			this.tosMain.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
			this.tosMain.Size = new System.Drawing.Size(651, 25);
			this.tosMain.Stretch = true;
			this.tosMain.TabIndex = 3;
			// 
			// tsBtnNewProject
			// 
			this.tsBtnNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnNewProject.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNewProject.Image")));
			this.tsBtnNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnNewProject.Name = "tsBtnNewProject";
			this.tsBtnNewProject.Size = new System.Drawing.Size(23, 22);
			this.tsBtnNewProject.Text = "&Neu";
			this.tsBtnNewProject.Click += new System.EventHandler(this.tsBtnNewProject_Click);
			// 
			// tsBtnOpenProject
			// 
			this.tsBtnOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenProject.Image")));
			this.tsBtnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnOpenProject.Name = "tsBtnOpenProject";
			this.tsBtnOpenProject.Size = new System.Drawing.Size(64, 22);
			this.tsBtnOpenProject.Text = "Ö&ffnen";
			this.tsBtnOpenProject.Click += new System.EventHandler(this.tsBtnOpenProject_Click);
			// 
			// tsBtnSaveProject
			// 
			this.tsBtnSaveProject.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSaveProject.Image")));
			this.tsBtnSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnSaveProject.Name = "tsBtnSaveProject";
			this.tsBtnSaveProject.Size = new System.Drawing.Size(79, 22);
			this.tsBtnSaveProject.Text = "&Speichern";
			this.tsBtnSaveProject.Click += new System.EventHandler(this.tsBtnSaveProject_Click);
			// 
			// sepPageControls
			// 
			this.sepPageControls.Name = "sepPageControls";
			this.sepPageControls.Size = new System.Drawing.Size(6, 25);
			this.sepPageControls.Visible = false;
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// tsBtnPublish
			// 
			this.tsBtnPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnPublish.Name = "tsBtnPublish";
			this.tsBtnPublish.Size = new System.Drawing.Size(92, 22);
			this.tsBtnPublish.Text = "Veröffentlichen";
			this.tsBtnPublish.Click += new System.EventHandler(this.tsBtnPublish_Click);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.pnlContentView);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tvwContentNodes);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(651, 315);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(651, 364);
			this.toolStripContainer1.TabIndex = 4;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mnsMain);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tosMain);
			// 
			// tvwContentNodes
			// 
			this.tvwContentNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.tvwContentNodes.BackColor = System.Drawing.SystemColors.Control;
			this.tvwContentNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvwContentNodes.HideSelection = false;
			this.tvwContentNodes.HotTracking = true;
			this.tvwContentNodes.ImageIndex = 0;
			this.tvwContentNodes.ImageList = this.imglContentNodes;
			this.tvwContentNodes.ItemHeight = 24;
			this.tvwContentNodes.Location = new System.Drawing.Point(3, 12);
			this.tvwContentNodes.Name = "tvwContentNodes";
			this.tvwContentNodes.SelectedImageIndex = 0;
			this.tvwContentNodes.ShowLines = false;
			this.tvwContentNodes.Size = new System.Drawing.Size(184, 288);
			this.tvwContentNodes.TabIndex = 1;
			// 
			// mnuUpgradeProject
			// 
			this.mnuUpgradeProject.Name = "mnuUpgradeProject";
			this.mnuUpgradeProject.Size = new System.Drawing.Size(243, 22);
			this.mnuUpgradeProject.Text = "Altes Projekt konvertieren";
			this.mnuUpgradeProject.Click += new System.EventHandler(this.mnuUpgradeProject_Click);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(651, 364);
			this.Controls.Add(this.toolStripContainer1);
			this.MainMenuStrip = this.mnsMain;
			this.Name = "mainForm";
			this.Text = "mainForm2";
			this.mnsMain.ResumeLayout(false);
			this.mnsMain.PerformLayout();
			this.tosMain.ResumeLayout(false);
			this.tosMain.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnsMain;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
		private System.Windows.Forms.ToolStripMenuItem mnuOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem mnuSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuClose;
		private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuSettings;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuAbout;
		private updateSystemDotNet.Administration.UI.Controls.explorerTreeView tvwContentNodes;
		private System.Windows.Forms.ImageList imglContentNodes;
		private System.Windows.Forms.Panel pnlContentView;
		private System.Windows.Forms.ToolStripMenuItem mnuSendFeedback;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuPublish;
		private System.Windows.Forms.ToolStripMenuItem mnuCheckForUpdates;
		private System.Windows.Forms.ToolStripMenuItem mnuLinkStatisticServer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuUnlinkStatisticServer;
		private System.Windows.Forms.ToolStripMenuItem mnuThrowDebugException;
		private System.Windows.Forms.ToolStrip tosMain;
		private System.Windows.Forms.ToolStripButton tsBtnNewProject;
		private System.Windows.Forms.ToolStripButton tsBtnOpenProject;
		private System.Windows.Forms.ToolStripButton tsBtnSaveProject;
		private System.Windows.Forms.ToolStripSeparator sepPageControls;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripButton tsBtnPublish;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuShowToolbar;
		private System.Windows.Forms.ToolStripMenuItem mnuUpgradeProject;
	}
}