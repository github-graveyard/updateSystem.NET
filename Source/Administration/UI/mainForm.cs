#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.Core.updateLog;
using updateSystemDotNet.Administration.UI.Controls;
using updateSystemDotNet.Administration.UI.mainFormPages;
using System.Reflection;
using System.IO;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.Publishing;

namespace updateSystemDotNet.Administration.UI {
	public partial class mainForm : Form {

		private readonly applicationSession _session;
		private Dictionary<Type, basePage> _contentCache;
		private readonly Color _mainFormBackColor;
		private readonly redPill _redPill;

		public mainForm(string[] arguments) {

			_mainFormBackColor = Color.White;
			_redPill = new redPill();

			_session = new applicationSession();
			_session.initializeApplication(arguments);

			InitializeComponent();
			initializeUI();

			loadContentNodes();
			updateNodes();
			addEvents();
			_session.onProjectTitleChanged(EventArgs.Empty);
		}

		/// <summary>Initialisiert alle UI Elemente.</summary>
		private void initializeUI() {
			base.Font = SystemFonts.MessageBoxFont;
			Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			MinimumSize = Size;
			ToolStripManager.Renderer = new nativeRenderer(ToolbarTheme.Toolbar);
			
			try { 
				mnuPublish.Image = resourceHelper.getImage("publish.png");

				//TODO: Unter XP fliegt hier eine OutOfMemory-Exception, dass muss noch gefixed werden.
				if(Environment.OSVersion.Version.Major >= 6)
					tsBtnPublish.Image = resourceHelper.getImage("publish.png");
			}
			catch(OutOfMemoryException memExc) {
				_session.Log.writeException(memExc);
			}

			BackColor = _mainFormBackColor;
			tvwContentNodes.BackColor = _mainFormBackColor;
			pnlContentView.BackColor = _mainFormBackColor;

			tosMain.Visible = _session.Settings.showToolBar;
			mnuShowToolbar.Checked = _session.Settings.showToolBar;
		}

		/// <summary>Aboniert alle während der Ausführung benötigten Events.</summary>
		private void addEvents() {

			//Session
			_session.contentUpdateRequired += _session_contentUpdateRequired;
			_session.projectTitleChanged += _session_projectTitleChanged;
			_session.startPublishing += _session_startPublishing;

			//Form
			Load += mainForm2_Load;
			FormClosing += mainForm2_FormClosing;
			Shown += mainForm2_Shown;
			Paint += mainForm2_Paint;
			Resize += mainForm2_Resize;

			//TreeView
			tvwContentNodes.AfterSelect += tvwContentNodes_AfterSelect;			

			//UpdateController
			_session.updateController.updateInstallerStarted += updateController_updateInstallerStarted;

		}

		#region Events

		//Session
		void _session_contentUpdateRequired(object sender, EventArgs e) {

			//Da beim neuladen die Unterseiten neu erstellt werden, selektieren wir erst ggf. das Parent bevor wir die Seiten weiter neu laden
			if(tvwContentNodes.SelectedNode.Level>0) {
				TreeNode rootParent = null;
				for (TreeNode node = tvwContentNodes.SelectedNode; node != null; node = node.Parent)
					rootParent = node;

				tvwContentNodes.SelectedNode = rootParent;
			}

			//Die aktuelle Seite dazu auffordern den Inhalt erneut einzulesen
			if(pnlContentView.Controls.Count>0)
				((basePage)pnlContentView.Controls[0]).initializeData();

			//Unterseiten neu erstellen, da durch das laden eines anderen Projektes sich diese auch verändert haben
			foreach(var content in _contentCache)
				content.Value.initializeSubPages();

			//updateLog Menueinträge je nach Account anpassen
			adjustUpdateLogMenuItems();
		}
		void _session_projectTitleChanged(object sender, EventArgs e) {
			//Fenstertitel anpassen
			Text = string.Format("{0} - updateSystem.NET Administration BETA", _session.currentProject.projectName);
		}
		void _session_startPublishing(object sender, EventArgs e) {
			
			//Überprüfen, ob das Projekt gespeichert wurde
			if(string.IsNullOrEmpty(_session.currentProjectPath)) {
				_session.showMessage(this, "Sie müssen das Projekt zuerst Speichern bevor Sie es Veröffentlichen können.",
				                     MessageBoxIcon.Warning, MessageBoxButtons.OK);
				return;
			}

			if (_session.currentProject.publishProvider.Count == 0) {
				_session.showMessage(this, "Dem Updateprojekt muss mindestens eine Veröffentlichungsschnittstelle zugeordnet sein.",
				                     "Keine Veröffentlichungsschnittstellen", MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
				return;
			}

			var availableProvider = new List<IPublishProvider>();
			foreach (var provider in _session.currentProject.publishProvider)
				if (provider.Settings.isActive)
					availableProvider.Add(provider);

			if (_session.showDialog<Dialogs.publishUpdatesDialog>(this, availableProvider) == DialogResult.OK) {

				//Projekt speichern um die geänderten Daten zu übernehmen
				_session.saveProject();

				//Daten erneut einlesen
				_session.onContentUpdateRequired(EventArgs.Empty);

				//Resultate der Veröffentlichung anzeigen
				var pResult = (publishResultList) _session.dialogResultCache[typeof (Dialogs.publishUpdatesDialog)];
				
				//Resultdialog nicht anzeigen wenn es keinen Fehler gab und der Benutzer nicht möchte,
				//dass der Dialog dann angezeigt wird.
				if (!pResult.hasErrors && _session.currentProject.hidePublishResult)
					return;

				_session.showDialog<Dialogs.publishUpdatesResultDialog>(this, pResult);

			}

		}

		//Form
		void mainForm2_Load(object sender, EventArgs e) {
			
			//Fensterposition laden
			if (_session.Settings.windowPositions.ContainsKey(Name) && _session.Settings.windowPositions[Name].X > 0 &&
				_session.Settings.windowPositions[Name].Y > 0) {
				StartPosition = FormStartPosition.Manual;
				Location = _session.Settings.windowPositions[Name];
			}
			else
				StartPosition = FormStartPosition.CenterScreen;

			//Fenstergröße laden
			if (_session.Settings.windowSizes.ContainsKey(Name))
				Size = _session.Settings.windowSizes[Name];

		}
		void mainForm2_FormClosing(object sender, FormClosingEventArgs e) {

			//Fensterposition speichern
			if (_session.Settings.windowPositions.ContainsKey(Name))
				_session.Settings.windowPositions[Name] = Location;
			else
				_session.Settings.windowPositions.Add(Name, Location);

			//Fenstergröße speichern
			if (_session.Settings.windowSizes.ContainsKey(Name))
				_session.Settings.windowSizes[Name] = Size;
			else
				_session.Settings.windowSizes.Add(Name, Size);

			_session.finalizeApplication();
		}
		void mainForm2_Shown(object sender, EventArgs e) {
			if(!_redPill.canIHazFeatures())
				if (_session.showDialog<Dialogs.eapLoginDialog>(this) != DialogResult.OK) 
					Close();
		}
		void mainForm2_Resize(object sender, EventArgs e) {
			Invalidate();
		}
		void mainForm2_Paint(object sender, PaintEventArgs e) {
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(tvwContentNodes.Location.X + tvwContentNodes.Width + 5, tvwContentNodes.Location.Y),
				new Point(tvwContentNodes.Location.X + tvwContentNodes.Width + 5,
				          tvwContentNodes.Location.Y + tvwContentNodes.Height));
		}

		//tvwContentNodes
		void tvwContentNodes_AfterSelect(object sender, TreeViewEventArgs e) {
			if (e.Node.Level == 0) //Level 0 Nodes können immer nur basePages sein.
				showNode(e.Node.Tag as Type);
			else if (e.Node.Tag != null && derivesFrom<baseSubPage>(e.Node.Tag.GetType()))
				showSubNode(e.Node.Tag as baseSubPage);
		}

		//mnsMain
		private void mnuOpen_Click(object sender, EventArgs e) {
			using(var dialog = new OpenFileDialog()) {
				dialog.Filter = "Updateprojekte|*.uaproj";
				if (dialog.ShowDialog(this) == DialogResult.OK)
					_session.openProject(dialog.FileName);
			}
		}
		private void mnuSave_Click(object sender, EventArgs e) {
			string projectPath = _session.currentProjectPath;
			if (string.IsNullOrEmpty(projectPath)) {
				projectPath = chooseProjectPath();
				if (string.IsNullOrEmpty(projectPath))
					return;
			}
			_session.saveProject(projectPath);
		}
		private void mnuClose_Click(object sender, EventArgs e) {
			Close();
		}
		private void mnuSendFeedback_Click(object sender, EventArgs e) {
			showNode(typeof(feedbackPage));
		}
		private void mnuAbout_Click(object sender, EventArgs e) {
			_session.showDialog<Dialogs.aboutDialog>(this);
		}
		private void mnuPublish_Click(object sender, EventArgs e) {
			_session.onStartPublishing(EventArgs.Empty);
		}
		private void mnuNewProject_Click(object sender, EventArgs e) {
			_session.newProject();
		}
		private void mnuStatisticServer_Click(object sender, EventArgs e) {
			if(_session.showDialog<Dialogs.authorizeUpdateLogDialog>()== DialogResult.OK) {
				_session.currentProject.updateLogUser =
					(userAccount) _session.dialogResultCache[typeof (Dialogs.authorizeUpdateLogDialog)];
				_session.onContentUpdateRequired(EventArgs.Empty);
			}
		}
		private void mnuUnlinkStatisticServer_Click(object sender, EventArgs e) {
			_session.currentProject.updateLogUser = new userAccount();
			_session.onContentUpdateRequired(EventArgs.Empty);
		}
		private void mnuSettings_Click(object sender, EventArgs e) {
			_session.showDialog<Dialogs.applicationSettingsDialog>();
		}
		private void mnuThrowDebugException_Click(object sender, EventArgs e) {
			int a = 1;
			int b = 2;

			if (a == 1)
				b = 0;
			int c = a/b;
		}
		private void mnuCheckForUpdates_Click(object sender, EventArgs e) {
			_session.updateController.updateInteractive(this);
		}
		private void mnuShowToolbar_Click(object sender, EventArgs e) {
			_session.Settings.showToolBar = mnuShowToolbar.Checked;
			tosMain.Visible = _session.Settings.showToolBar;
		}
		private void mnuUpgradeProject_Click(object sender, EventArgs e) {
			if (_session.showDialog<Dialogs.upgradeProjectDialog>(this) == DialogResult.OK) {
				if (_session.showMessage("Das Projekt wurde erfolgreich konvertiert. Möchten Sie es jetzt öffnen?", MessageBoxIcon.Information, MessageBoxButtons.YesNo) == DialogResult.Yes) {
					_session.openProject( (string)_session.dialogResultCache[typeof(Dialogs.upgradeProjectDialog)] );
				}
			}
		}

		//ToolStrip
		private void tsBtnNewProject_Click(object sender, EventArgs e) {
			mnuNewProject.PerformClick();
		}
		private void tsBtnOpenProject_Click(object sender, EventArgs e) {
			mnuOpen.PerformClick();
		}
		private void tsBtnSaveProject_Click(object sender, EventArgs e) {
			mnuSave.PerformClick();
		}
		private void tsBtnPublish_Click(object sender, EventArgs e) {
			mnuPublish.PerformClick();
		}

		//updateController
		void updateController_updateInstallerStarted(object sender, appEventArgs.updateInstallerStartedEventArgs e) {
			Close();
		}

		#endregion

		#region Content

		/// <summary>Lädt alle verfügbaren Einstellungsknoten in den Cache.</summary>
		private void loadContentNodes() {
			_contentCache = new Dictionary<Type, basePage>();
			var sortedPages = new SortedList<int, basePage>();

			foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {

				if (!derivesFrom<basePage>(type) || derivesFrom<baseSubPage>(type) || type == typeof (baseSubPage) ||
				    type == typeof (basePage))
					continue;

				var instance = (basePage) Activator.CreateInstance(type);

				instance.Session = _session;
				instance.Dock = DockStyle.Fill;
				imglContentNodes.Images.Add(instance.Id, instance.pageSymbol);
				sortedPages.Add(instance.displayOrder, instance);
			}
			foreach (var sortedPage in sortedPages)
				_contentCache.Add(sortedPage.Value.GetType(), sortedPage.Value);
		}

		/// <summary>Überprüft ob ein bestimmter Type von einem anderen Type erbt.</summary>
		private bool derivesFrom<T>(Type type) {
			for (Type baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
				if (baseType == typeof(T))
					return true;
			return false;
		}

		/// <summary>Aktualisiert die Sichtbarkeit der Knoten je nach Programmstatus.</summary>
		private void updateNodes() {
			tvwContentNodes.Nodes.Clear();
			foreach (var page in _contentCache) {
				if (page.Value.canShowPage() && !page.Value.hideFromNavigation)
					tvwContentNodes.Nodes.Add(page.Value.Node);
				page.Value.initializeSubPages();
			}
		}

		/// <summary>Zeigt einen bestimmten Knoten in der Contentarea an.</summary>
		private void showNode(Type nodeType) {
			showPageCore(_contentCache[nodeType]);
		}
		private void showSubNode(baseSubPage page) {
			showPageCore(page);
		}
		private void showPageCore(basePage page) {
			if (tvwContentNodes.SelectedNode != null && (tvwContentNodes.SelectedNode.Tag as Type) != page.GetType() &&
			    !derivesFrom<baseSubPage>(page.GetType())) {
				foreach (TreeNode node in tvwContentNodes.Nodes)
					if ((node.Tag as Type) == page.GetType()) {
						tvwContentNodes.SelectedNode = node;
						return;
					}
				tvwContentNodes.SelectedNode = null;
			}

			//ContentView leeren
			pnlContentView.Controls.Clear();

			//ToolStripButtons die von dieser Seite angeboten werden sind laden
			//Aber vorher die alten Entfernen
			int seperatorIndex = tosMain.Items.IndexOf(sepPageControls)+1;
			for (int i = tosMain.Items.Count - 1; i >=0 ; i--) {
				if (tosMain.Items[i].Tag != null)
					tosMain.Items.RemoveAt(i);
			}

			//Neue hinzufügen
			sepPageControls.Visible = page.extendsToolStrip;
			if (page.extendsToolStrip && page.toolStripButtons.Count > 0) {
				for (int i = page.toolStripButtons.Count - 1; i >= 0; i--) {
					tosMain.Items.Insert(seperatorIndex, page.toolStripButtons[i]);
				}
			}

			//Knoten initialisieren und der View hinzufügen
			page.initializeData();
			pnlContentView.Controls.Add(page);
			page.Dock = DockStyle.Fill;
		}

		#endregion

		#region Projekt speichern/laden/schließen
		
		private string chooseProjectPath() {
			if(_session.showDialog<Dialogs.saveProjectDialog>(this)== DialogResult.OK) {
				if (_session.dialogResultCache.ContainsKey(typeof(Dialogs.saveProjectDialog))) {
					string path = _session.dialogResultCache[typeof (Dialogs.saveProjectDialog)].ToString();
					
					//Projektname aktualisieren
					_session.currentProject.projectName = Path.GetFileNameWithoutExtension(path);
					
					return path;
				}
			}
			return string.Empty;
		}

		#endregion

		#region Updatelog

		private void adjustUpdateLogMenuItems() {
			mnuLinkStatisticServer.Visible = !_session.currentProject.updateLogUser.Verified;
			mnuUnlinkStatisticServer.Visible = _session.currentProject.updateLogUser.Verified;
		}

		#endregion
	}
}