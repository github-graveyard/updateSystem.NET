using System;
using System.Drawing;
using updateSystemDotNet.Administration.Core.updateLog;
using System.Collections.Generic;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	internal sealed partial class statisticProjectsSubPage : statisticSubBasePage {
		private readonly List<updateLogProject> _cachedProjects;

		private ToolStripButton _tsBtnRefresh;
		private ToolStripButton _tsBtnEditProject;
		private ToolStripButton _tsBtnRemoveProject;

		public statisticProjectsSubPage() {
			InitializeComponent();
			_cachedProjects = new List<updateLogProject>();
			Id = "38020300-5caa-4c9f-ac7e-1f6b595052b4";
			pageSymbol = resourceHelper.getImage("projects.png");
			extendsToolStrip = true;
			initializeToolStripButtons();
		}

		public override void initializeData() {
			//Größe der ListViewSpalten wiederherstellen
			restoreColumnHeaderSizes(lvwProjects);
		}

		protected override void initializeToolStripButtons() {
			_tsBtnRefresh = createToolStripButton("Aktualisieren");
			_tsBtnEditProject = createToolStripButton("Bearbeiten");
			_tsBtnRemoveProject = createToolStripButton("Entfernen");

			_tsBtnEditProject.Enabled = false;
			_tsBtnRemoveProject.Enabled = false;

			_tsBtnRefresh.Click += _tsBtnRefresh_Click;
			_tsBtnEditProject.Click += _tsBtnEditProject_Click;
			_tsBtnRemoveProject.Click += _tsBtnRemoveProject_Click;
		}

		void _tsBtnRemoveProject_Click(object sender, EventArgs e) {
			if (bgwDeleteProject.IsBusy || bgwRefreshProjects.IsBusy)
				return;

			if (lvwProjects.SelectedItems.Count <= 0)
				return;

			if (((updateLogProject)lvwProjects.SelectedItems[0].Tag).projectId == Session.currentProject.projectId) {
				Session.showMessage(ParentForm,
									"Dieses ist ihr momentan geladenen Projekt und kann nur über die Einstellungen entfernt werden",
									MessageBoxIcon.Warning, MessageBoxButtons.OK);
				return;
			}

			if (Session.showMessage(ParentForm, "Sind Sie wirklich sicher, dass Sie das ausgewählte Projekt mitsammt allen Statistikdaten entfernen möchten", "Projekt löschen?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) == DialogResult.Yes) {
				pnlProjectsBase.Enabled = false;
				bgwDeleteProject.RunWorkerAsync(lvwProjects.SelectedItems[0].Tag as updateLogProject);
			}
		}

		void _tsBtnEditProject_Click(object sender, EventArgs e) {
			if (lvwProjects.SelectedItems.Count == 0)
				return;

			if (Session.showDialog<Dialogs.manageUpdateLogProjectDialog>(lvwProjects.SelectedItems[0].Tag as updateLogProject) == DialogResult.OK)
				refreshProjectList();
		}

		void _tsBtnRefresh_Click(object sender, EventArgs e) {
			refreshProjectList();
		}

		private void lvwProjects_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
			//Größe der ListView Spalten sichern
			saveColumnHeaderSizes(lvwProjects);
		}

		private void bgwRefreshProjects_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				//Webrequest absenden und das Ergebnis ins Result schreiben
				e.Result = Session.updateLogFactory.getProjects();
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		/// <summary>Lädt alle Projekte aus dem Projektcache in die ListView.</summary>
		private void loadProjects() {
			lvwProjects.Items.Clear();

			foreach(var project in _cachedProjects) {
				var lvi = new ListViewItem(project.projectName);
				lvi.SubItems.Add(project.projectId);
				lvi.SubItems.Add(project.isActive ? "Ja" : "Nein");
				lvi.Tag = project;

				if (project.projectId == Session.currentProject.projectId)
					lvi.Font = new Font(lvi.Font, FontStyle.Bold);

				lvwProjects.Items.Add(lvi);
			}

		}

		/// <summary>Aktualisiert den Projektcache aus den Serverdaten.</summary>
		private void refreshProjectList() {
			if (bgwRefreshProjects.IsBusy || bgwDeleteProject.IsBusy)
				return;

			pnlProjectsBase.Enabled = false;
			bgwRefreshProjects.RunWorkerAsync();
		}

		private void bgwRefreshProjects_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			pnlProjectsBase.Enabled = true;
			if(e.Result is List<updateLogProject>) {
				_cachedProjects.Clear();
				_cachedProjects.AddRange(e.Result as List<updateLogProject>);
				loadProjects();
			}
			else {
				showServerError(e.Result as Exception);
			}
		}
        
		private void lvwProjects_SelectedIndexChanged(object sender, EventArgs e) {
			_tsBtnEditProject.Enabled = lvwProjects.SelectedItems.Count == 1;
			_tsBtnRemoveProject.Enabled = lvwProjects.SelectedItems.Count == 1;
		}

	    private void bgwDeleteProject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				Session.updateLogFactory.deleteProject(((updateLogProject) e.Argument).projectId);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwDeleteProject_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if(e.Result==null) {
				refreshProjectList();
			}
			else {
				pnlProjectsBase.Enabled = true;
				showServerError(e.Result as Exception);
			}
		}
	}
}
