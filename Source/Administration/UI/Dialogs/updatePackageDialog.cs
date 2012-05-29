/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.Updates;
using updateSystemDotNet.Administration.Properties;
using updateSystemDotNet.Administration.UI.Controls;
using updateSystemDotNet.Administration.UI.updateActionEditor;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;
using System.Diagnostics;
using updateSystemDotNet.Administration.Core.Publishing;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal sealed partial class updatePackageDialog : dialogBase {
		
		private string _changelogDe = string.Empty;
		private string _changelogEn = string.Empty;
		private bool _onEdit;
		private string _packageId = string.Empty;

		public updatePackageDialog() {
			InitializeComponent();
			tvwContent.AfterSelect += tvwContent_AfterSelect;
			tvwContent.SelectedNode = tvwContent.Nodes[0];
			Shown += updatePackageForm_Shown;

			imglMain.Images.Add("defaultActionImage", Resources.defaultUpdateAction);
			imglMain.Images.Add("general", Resources.general);
			//imglMain.Images.Add("availability", Resources.availability);
			imglMain.Images.Add("changes", Resources.changes);
			imglMain.Images.Add("actions", Resources.actions);
			imglMain.Images.Add("customFields", resourceHelper.getImage("customFields.png"));
			imglMain.Images.Add("publish", resourceHelper.getImage("publish.png"));

			tvwContent.Nodes["nodeGeneral"].ImageKey = "general";
			tvwContent.Nodes["nodeGeneral"].SelectedImageKey = "general";
			//tvwContent.Nodes["nodeAvailability"].ImageKey = "availability";
			//tvwContent.Nodes["nodeAvailability"].SelectedImageKey = "availability";
			tvwContent.Nodes["nodeChanges"].ImageKey = "changes";
			tvwContent.Nodes["nodeChanges"].SelectedImageKey = "changes";
			tvwContent.Nodes["nodeCustomFields"].ImageKey = "customFields";
			tvwContent.Nodes["nodeCustomFields"].SelectedImageKey = "customFields";
			tvwContent.Nodes["nodeActions"].ImageKey = "actions";
			tvwContent.Nodes["nodeActions"].SelectedImageKey = "actions";
			tvwContent.Nodes["nodePublish"].ImageKey = "publish";
			tvwContent.Nodes["nodePublish"].SelectedImageKey = "publish";

			lvwActions.TileSize = new Size(lvwActions.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth, 35);
			lvwActions.Columns[1].Width = lvwActions.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;

			tvwContent.DragEnter += tvwContent_DragEnter;
			tvwContent.DragDrop += tvwContent_DragDrop;
			tvwContent.KeyDown += tvwContent_KeyDown;
			lvwActions.ItemDrag += lvwActions_ItemDrag;
			lvwActions.MouseDoubleClick += lvwActions_MouseDoubleClick;

			txtChanges.TextChanged += txtChanges_TextChanged;
			cboLanguage.SelectedIndexChanged += cboLanguage_SelectedIndexChanged;

			rbCustomVersions.CheckedChanged += delegate { pnlCustomVersion.Enabled = rbCustomVersions.Checked; };

			cboLanguage.SelectedIndex = 0;
			cboReleaseState.SelectedIndex = 2;
			cboTargetArchitecture.SelectedIndex = 0;
		}

		public override void initializeData() {
			loadUpdateActions();

			//Load Publishinterfaces
			lvwPublishWith.Items.Clear();
			foreach (var pbProvider in Session.currentProject.publishProvider) {
				if (!pbProvider.Settings.isActive)
					continue;

				var item = new ListViewItem {
					Text = string.Format("{0} (via {1})", pbProvider.Settings.Name,
										 Session.publishFactory.availableProvider[
											pbProvider.GetType()].Name),
					Tag = pbProvider
				};
				lvwPublishWith.Items.Add(item);
			}
			lvwPublishWith.Columns[0].Width = (lvwPublishWith.ClientRectangle.Width -
											   (SystemInformation.VerticalScrollBarWidth + 10));

			if(Argument != null) {
				var editResult = (prepareEditPackageResult) Argument;
				loadUpdatePackage(editResult.updatePackage, editResult.changelogGerman, editResult.changelogEnglish, true);
			}

			//Version aus Assembly übernehmen, aber nur bei neuen Updatepaketen
			if (!_onEdit && Session.currentProject.linkAssemblyToVersion && File.Exists(Session.currentProject.linkedAssemblyPath)) {
				var linkedVersion = new Version(
					FileVersionInfo.GetVersionInfo(Session.currentProject.linkedAssemblyPath).ProductVersion);

				nmMajor.Value = linkedVersion.Major;
				nmMinor.Value = linkedVersion.Minor;
				nmBuild.Value = linkedVersion.Build;
				nmRevision.Value = linkedVersion.Revision;
			}

			if (Session.currentProject.setServicePackAsDefault)
				chkServicePack.Checked = true;

		}

		private void updatePackageForm_Shown(object sender, EventArgs e) {
			lvwActions.MakeCollapsable();
		}

		/// <summary>Lädt ein Projekt zum bearbeiten in den Dialog</summary>
		public void loadUpdatePackage(updatePackage package, string changesGerman, string changesEnglish, bool setEditFlag) {
			//Texte setzen
			if (setEditFlag) {
				Text = string.Format("{0} - Updatepaket bearbeiten", Strings.applicationName);
				btnOk.Text = "Updatepaket bearbeiten";
				_onEdit = true;
				_packageId = package.ID;
			}

			//Allgemeine Daten
			if (!string.IsNullOrEmpty(package.releaseInfo.Version)) {
				var packageVersion = new Version(package.releaseInfo.Version);
				nmMajor.Value = packageVersion.Major;
				nmMinor.Value = packageVersion.Minor;
				nmBuild.Value = packageVersion.Build;
				nmRevision.Value = packageVersion.Revision;
			}

			cboReleaseState.SelectedIndex = (int) package.releaseInfo.Type;
			nmPreviewState.Value = package.releaseInfo.Step;
			cboTargetArchitecture.SelectedIndex = (int) package.TargetArchitecture;
			txtDescription.Text = package.Description;
			chkPublished.Checked = package.Published;
			chkServicePack.Checked = package.isServicePack;

			//Verfügbarkeit
			if (package.UseOwnVersionList)
				rbCustomVersions.Checked = true;
			else
				rbAllVersions.Checked = true;

			foreach (VersionEx version in package.OwnVersionList) {
				lstCustomVersions.Items.Add(version.ToString());
			}

			//Changelogs
			txtChanges.Text = changesGerman;
			_changelogDe = changesGerman;
			_changelogEn = changesEnglish;
			
			//CustomFields
			foreach (var customField in package.customFields) {
				lvwCustomFields.Items.Add(
					new ListViewItem(new[] {customField.Key, customField.Value}));
			}

			//Link PublishProvider
			foreach (ListViewItem lvwItem in lvwPublishWith.Items) {
				var provider = (IPublishProvider) lvwItem.Tag;
				lvwItem.Checked = Session.updateFactory.isUpdateLinked(package, provider);
			}

			//Aktionen laden
			Session.updateFactory.availableUpdateActions();
			foreach (string id in package.actionOrder) {
				addAction(Session.updateFactory.findActionById(id, package), false);
			}
		}

		/// <summary>Überprüft ob alle durch den Benutzer gemachen Angaben valide sind, bzw. ob notwendige Eingaben fehlen.</summary>
		/// <returns>Gibt True zurück wenn die Prüfung erfolgreich war, andernfalls False.</returns>
		private bool validateUpdatePackage() {
			// 0.0.0.0 als Version ist unzulässig
			if (nmMajor.Value == 0 && nmMinor.Value == 0 &&
			    nmRevision.Value == 0 && nmBuild.Value == 0) {
				showMissingOrInvalidDataWarning("Die Eingabe von \"0.0.0.0\" als Version ist nicht zulässig.");
				return false;
			}

			//Überprüfen ob es im Updateprojekt nicht bereits ein Paket mit identisches Informationen gibt
			var rlsInfo = new releaseInfo {
			                              	Version =
			                              		string.Format("{0}.{1}.{2}.{3}",
			                              		              new[] {
			                              		                    	nmMajor.Value.ToString(CultureInfo.InvariantCulture), nmMinor.Value.ToString(CultureInfo.InvariantCulture),
			                              		                    	nmBuild.Value.ToString(CultureInfo.InvariantCulture), nmRevision.Value.ToString(CultureInfo.InvariantCulture)
			                              		                    }),
			                              	Step = (int) nmPreviewState.Value,
			                              	Type = (releaseTypes) cboReleaseState.SelectedIndex
			                              };

			foreach (updatePackage package in Session.currentProject.updatePackages) {
				if (package.releaseInfo == rlsInfo &&
				    package.TargetArchitecture == (updatePackage.SupportedArchitectures) cboTargetArchitecture.SelectedIndex &&
				    !_onEdit) {
					showMissingOrInvalidDataWarning("Es existiert bereits eine Updatepaket mit identischen Versionsinformationen.");
					return false;
				}
			}

			//Auf eine gültige Beschreibung prüfen
			if (string.IsNullOrEmpty(txtDescription.Text)) {
				showMissingOrInvalidDataWarning("Geben Sie bitte eine Beschreibung für das Updatepaket an.");
				return false;
			}

			//Überprüfe ob ein Changelogtext angegeben wurde
			if (string.IsNullOrEmpty(_changelogDe) && string.IsNullOrEmpty(_changelogEn)) {
				showMissingOrInvalidDataWarning("Geben Sie bitte einen Changelog in mindestens einer Sprache ein.");
				return false;
			}

			if (tvwContent.Nodes["nodeActions"].Nodes.Count == 0) {
				showMissingOrInvalidDataWarning("Sie müssen mindestens eine updateAction diesem Updatepaket hinzufügen.");
				return false;
			}

			//Updateaktionen validieren
			foreach (TreeNode actionNode in tvwContent.Nodes["nodeActions"].Nodes) {
				actionBase currentAction = ((KeyValuePair<actionBase, administrationEditorAttribute>) actionNode.Tag).Key;
				if (!currentAction.Validate()) {
					showMissingOrInvalidDataWarning(
						string.Format("Die hinzugefügte Updateaktion \"{0}\" meldet ein oder mehr ungültige Werte.", currentAction));
					tvwContent.SelectedNode = actionNode;
					return false;
				}
			}

			return true;
		}

		private void showMissingOrInvalidDataWarning(string warning) {
			Session.showMessage(
				this,
				warning,
				"Es gibt fehlende oder ungültige Einträge in Ihrem Updatepaket",
				MessageBoxIcon.Error,
				MessageBoxButtons.OK);

		}

		private void tvwContent_KeyDown(object sender, KeyEventArgs e) {
			if (tvwContent.SelectedNode != null && tvwContent.SelectedNode.Level > 0) {
				//Ist eine updateAction ausgewählt?

				if (e.KeyCode == Keys.Delete) {
					//Wurde [ENTF] gedrückt?
					tvwContent.Nodes.Remove(tvwContent.SelectedNode);
					return;
				}

				TreeNode actionNode = tvwContent.Nodes["nodeActions"];
				if (e.Control && e.KeyCode == Keys.Up) {
					//Ausgewählte updateAction nach oben verschieben

					if (actionNode.Nodes[0] == tvwContent.SelectedNode)
						//Die ausgewählte updateAction ist der oberste Eintrag und kann nicht nach oben verschoben werden.
						return;

					int currentIndex = actionNode.Nodes.IndexOf(tvwContent.SelectedNode);
					TreeNode node = tvwContent.SelectedNode;
					actionNode.Nodes.Remove(node);
					actionNode.Nodes.Insert(currentIndex - 1, node);
					tvwContent.SelectedNode = node;
					e.Handled = true;
				}
				else if (e.Control && e.KeyCode == Keys.Down) {
					//Ausgewählte updateAction nach unten verschieben

					if (actionNode.Nodes[actionNode.Nodes.Count - 1] == tvwContent.SelectedNode)
						//Die ausgewählte updateAction ist der unterste Eintrag und kann nicht nach unten verschoben werden.
						return;

					int currentIndex = actionNode.Nodes.IndexOf(tvwContent.SelectedNode);
					TreeNode node = tvwContent.SelectedNode;
					actionNode.Nodes.Remove(node);
					actionNode.Nodes.Insert(currentIndex + 1, node);
					tvwContent.SelectedNode = node;
					e.Handled = true;
				}
			}
		}

		private void addAction(KeyValuePair<actionBase, administrationEditorAttribute> action) {
			addAction(action, true);
		}

		private void addAction(KeyValuePair<actionBase, administrationEditorAttribute> action, bool newInstance) {
			var nodeAction = new TreeNode(action.Key.ToString()) {
			                                                     	ImageKey = action.Key.ToString(),
			                                                     	SelectedImageKey = action.Key.ToString(),
			                                                     	Tag = (newInstance
			                                                     	       	? Session.updateFactory.createNewInstance(
			                                                     	       		action.Key.GetType())
			                                                     	       	: action)
			                                                     };

			tvwContent.Nodes["nodeActions"].Nodes.Add(nodeAction);
			tvwContent.Nodes["nodeActions"].Expand();
		}

		private void lvwActions_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (lvwActions.SelectedItems.Count <= 0) return;
			addAction((KeyValuePair<actionBase, administrationEditorAttribute>) lvwActions.SelectedItems[0].Tag);
			tvwContent.SelectedNode = tvwContent.Nodes["nodeActions"].LastNode;
		}

		private void loadUpdateActions() {
			foreach (var action in Session.updateFactory.availableUpdateActions()) {
				if (!imglMain.Images.ContainsKey(action.Key.ToString())) {
					Image actionImage = Session.updateFactory.toolboxImage(action.Value.imageName) ??
					                    imglMain.Images["defaultActionImage"];
					imglMain.Images.Add(action.Key.ToString(), actionImage);
				}

				if (!lvwActions.Groups.Contains(new ListViewGroup(action.Value.Category, action.Value.Category)))
					lvwActions.Groups.Add(new ListViewGroup(action.Value.Category, action.Value.Category));

				var lviAction = new ListViewItem(action.Key.ToString());
				lviAction.SubItems.Add(string.IsNullOrEmpty(action.Value.Description) ? "n/a" : action.Value.Description);
				lviAction.ImageKey = action.Key.ToString();
				lviAction.Tag = action;
				lviAction.Group = lvwActions.Groups[action.Value.Category];

				lvwActions.Items.Add(lviAction);
			}
		}

		private updatePackage createNewUpdatePackage() {
			var package = new updatePackage {
			                                	ID = _onEdit ? _packageId : Guid.NewGuid().ToString(),
			                                	releaseInfo = new releaseInfo(
			                                		string.Format("{0}.{1}.{2}.{3}",
			                                		              new[] {
			                                		                    	nmMajor.Value.ToString(CultureInfo.InvariantCulture), nmMinor.Value.ToString(CultureInfo.InvariantCulture),
			                                		                    	nmBuild.Value.ToString(CultureInfo.InvariantCulture), nmRevision.Value.ToString(CultureInfo.InvariantCulture)
			                                		                    }),
			                                		(releaseTypes) cboReleaseState.SelectedIndex,
			                                		(int) nmPreviewState.Value),
			                                	Description = txtDescription.Text,
			                                	Published = chkPublished.Checked,
			                                	isServicePack = chkServicePack.Checked,
			                                	ReleaseDate = DateTime.Now.ToString(new CultureInfo("de-de")),
			                                	TargetArchitecture =
			                                		(updatePackage.SupportedArchitectures) cboTargetArchitecture.SelectedIndex,
			                                	useNewFileFormat = true
			                                };
			//Verfügbarkeit
			if (rbCustomVersions.Checked) {
				package.UseOwnVersionList = true;
				foreach (string item in lstCustomVersions.Items)
					package.OwnVersionList.Add(new VersionEx(item));
			}

			//CustomFields
			foreach (ListViewItem lviCF in lvwCustomFields.Items)
				package.customFields.Add(lviCF.Text, lviCF.SubItems[1].Text);

			//Link/Unlink Publishprovider
			foreach (ListViewItem lvwItem in lvwPublishWith.Items) {
				if (lvwItem.Checked)
					Session.updateFactory.linkUpdate(package, (IPublishProvider)lvwItem.Tag);
				else
					Session.updateFactory.unlinkUpdate(package, (IPublishProvider) lvwItem.Tag);
			}

			//Updateaktionen
			foreach (TreeNode node in tvwContent.Nodes["nodeActions"].Nodes) {
				var action = (KeyValuePair<actionBase, administrationEditorAttribute>) node.Tag;
				package.actionOrder.Add(action.Key.ID);
				Session.updateFactory.addActionToPackage(action.Key, package);
			}

			return package;
		}

		private void tvwContent_AfterSelect(object sender, TreeViewEventArgs e) {
			changePage();
		}

		private void changePage() {
			if (tvwContent.SelectedNode == null)
				return;

			foreach (Control c in Controls)
				if (c is Panel && c.Name.StartsWith("pnl") && c.Visible)
					c.Hide();

			if (tvwContent.SelectedNode.Level == 0) {
				string controlName = "pnl" + tvwContent.SelectedNode.Name.Replace("node", "");
				if (Controls.ContainsKey(controlName)) {
					Controls[controlName].Show();
					Controls[controlName].BringToFront();
				}
			}
			else {
				pnlContent.Controls.Clear();

				var action =
					(KeyValuePair<actionBase, administrationEditorAttribute>) tvwContent.SelectedNode.Tag;
				actionEditorBase editor = Session.updateFactory.getActionEditor(action.Value.editorTypeName);
				editor.updateAction = action.Key;
				editor.initializeActionContent();
				editor.Size = pnlContent.ClientSize;
				pnlContent.Controls.Add(editor);

				pnlContent.Show();
				pnlContent.BringToFront();
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if (validateUpdatePackage())
				beginCreateUpdate();
		}

		#region " General "

		private void cboReleaseState_SelectedIndexChanged(object sender, EventArgs e) {
			nmPreviewState.Enabled = cboReleaseState.SelectedIndex < 2;
		}

		#endregion

		#region " Changelog "

		private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e) {
			switch (cboLanguage.SelectedIndex) {
				case 0:
					txtChanges.Text = _changelogDe;
					break;
				case 1:
					txtChanges.Text = _changelogEn;
					break;
			}
		}

		private void txtChanges_TextChanged(object sender, EventArgs e) {
			switch (cboLanguage.SelectedIndex) {
				case 0:
					_changelogDe = txtChanges.Text;
					break;
				case 1:
					_changelogEn = txtChanges.Text;
					break;
			}
		}

		private void btnImportChangeFromFile_Click(object sender, EventArgs e) {
			string filename;
			using (var dialog = new OpenFileDialog()) {
				dialog.Filter = "Textdateien|*.txt|Alle Dateien|*.*";

				if (File.Exists(Session.currentProject.changelogPath))
					dialog.FileName = Session.currentProject.changelogPath;

				if (dialog.ShowDialog(ParentForm) == DialogResult.OK) {
					filename = dialog.FileName;
					Session.currentProject.changelogPath = filename;
				}
				else
					return;
			}
			txtChanges.Text = File.ReadAllText(filename, Encoding.UTF8);
		}

		#endregion

		#region " Availability "

		private void btnAddCustomVersion_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtNewCustomVersion.Text))
				return;

			lstCustomVersions.Items.Add(txtNewCustomVersion.Text);
			txtNewCustomVersion.Text = string.Empty;
		}

		private void lstCustomVersions_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveCustomVersion.Enabled = lstCustomVersions.SelectedItems.Count > 0;
		}

		private void btnRemoveCustomVersion_Click(object sender, EventArgs e) {
			if (lstCustomVersions.SelectedItems.Count > 0) {
				lstCustomVersions.Items.Remove(lstCustomVersions.SelectedItems[0]);
			}
		}

		#endregion

		#region " CustomFields "

		private void lvwCustomFields_SelectedIndexChanged(object sender, EventArgs e) {
			if (lvwCustomFields.SelectedItems.Count == 1) {
				txtCustomFieldKey.Text = lvwCustomFields.SelectedItems[0].Text;
				txtCustomFieldValue.Text = lvwCustomFields.SelectedItems[0].SubItems[1].Text;
				btnAddOrUpdateCustomField.Text = "Bearbeiten";
			}
			else {
				btnAddOrUpdateCustomField.Text = "Hinzufügen";
				txtCustomFieldKey.Text = string.Empty;
				txtCustomFieldValue.Text = string.Empty;
			}
			btnRemoveCustomField.Enabled = (lvwCustomFields.SelectedItems.Count == 1);
		}

		private void btnRemoveCustomField_Click(object sender, EventArgs e) {
			if (lvwCustomFields.SelectedItems.Count != 1) return;
			
			lvwCustomFields.Items.Remove(lvwCustomFields.SelectedItems[0]);
			txtCustomFieldKey.Text = string.Empty;
			txtCustomFieldValue.Text = string.Empty;
		}

		private void btnAddOrUpdateCustomField_Click(object sender, EventArgs e) {
			//Wenn in einem der Felder ein leerer Wert eingegeben wurde, dann abbrechen
			if (string.IsNullOrEmpty(txtCustomFieldKey.Text) ||
			    string.IsNullOrEmpty(txtCustomFieldValue.Text))
				return;

			//Überprüfen ob das Feld neu erstellt oder bearbeitet werden soll
			if (containsCustomField(txtCustomFieldKey.Text)) {
				//bearbeiten
				ListViewItem lviField = getCustomField(txtCustomFieldKey.Text);
				lviField.Text = txtCustomFieldKey.Text;
				lviField.SubItems[1].Text = txtCustomFieldValue.Text;
			}
			else {
				//Neu erstellen
				var lviField = new ListViewItem(txtCustomFieldKey.Text);
				lviField.SubItems.Add(txtCustomFieldValue.Text);
				lvwCustomFields.Items.Add(lviField);
			}

			txtCustomFieldKey.Text = string.Empty;
			txtCustomFieldValue.Text = string.Empty;
		}

		/// <summary>Überprüft ob ein Feld mit einem bestimmten Namen bereits vorhanden ist.</summary>
		/// <param name="name">Der Name des Feldes welches gesucht werden soll.</param>
		/// <returns>Gibt True zurück wenn das Feld existiert, andernfalls False.</returns>
		private bool containsCustomField(string name) {
			foreach (ListViewItem lviCF in lvwCustomFields.Items) {
				if (lviCF.Text.ToLower().Equals(name.ToLower()))
					return true;
			}
			return false;
		}

		/// <summary>Gibt das zu einem Namen gehörige Felditem zurück.</summary>
		/// <param name="name">Der Name nach dem gesucht werden soll.</param>
		private ListViewItem getCustomField(string name) {
			foreach (ListViewItem lviCF in lvwCustomFields.Items) {
				if (lviCF.Text.ToLower().Equals(name.ToLower()))
					return lviCF;
			}
			return null;
		}

		#endregion

		#region " Create Updatepackage "

		//private updatePackage _newPackage;

		private void beginCreateUpdate() {
			//Alle Panel verstecken
			foreach (Control control in Controls) {
				if (control is Panel && control.Name.StartsWith("pnl"))
					control.Hide();
			}
			//Alle Actionlabel im entsprechenden Panel zurücksetzen
			foreach (Control control in pnlBuildPackage.Controls) {
				if (control is actionLabel)
					(control as actionLabel).State = actionLabelStates.Waiting;
			}

			//Controls deaktivieren
			tvwContent.Enabled = false;
			btnOk.Enabled = false;

			//Statusseite anzeigen
			pnlBuildPackage.Show();
			aclBuildPackage.State = actionLabelStates.Progress;       


			//Mit dem Erstellen beginnen
			bgwBuildPackage.RunWorkerAsync(new object[] {createNewUpdatePackage(), _changelogDe, _changelogEn});
			lblErrorText.Hide();
		}

		private void bgwBuildPackage_DoWork(object sender, DoWorkEventArgs e) {
			try {
				var args = (object[]) e.Argument;
				var package = (updatePackage) args[0];
				Session.updateFactory.buildUpdatePackage(
					package,
					(string) args[1],
					(string) args[2]
					);
				e.Result = package;
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwBuildPackage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if(e.Result is updatePackage) { //Update war erfolgreich
				var package = (updatePackage) e.Result;
				if(!_onEdit)
					Session.currentProject.updatePackages.Add(package);

				Result = package;
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lblErrorText.Show();
				lblErrorText.Text = (e.Result as Exception).Message;
				aclBuildPackage.State = actionLabelStates.Failure;
				btnOk.Enabled = tvwContent.Enabled = true;
			}
		}

		#endregion

		#region " Drag&Drop Events "

		private void lvwActions_ItemDrag(object sender, ItemDragEventArgs e) {
			DoDragDrop(lvwActions.SelectedItems[0], DragDropEffects.Copy);
		}

		private void tvwContent_DragDrop(object sender, DragEventArgs e) {
			var lviAction = (ListViewItem) e.Data.GetData(typeof (ListViewItem));

			addAction((KeyValuePair<actionBase, administrationEditorAttribute>) lviAction.Tag);
		}

		private void tvwContent_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(typeof (ListViewItem)))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		#endregion

		#region Localization

		public override void localizeDialog() {
			base.localizeDialog();

			localizeTreeView();

			//Custom fields ListView
			lvwCustomFields.Columns[0].Text = localizeListViewColumn(lvwCustomFields, "clmKey");
			lvwCustomFields.Columns[1].Text = localizeListViewColumn(lvwCustomFields, "clmValue");
		}

		private void localizeTreeView() {
			string treeViewLocalizationRoot = string.Format("{0}.{1}.{2}.{3}.Text", applicationSession.SECTION_NAME_DIALOGS, Name,
			                                                tvwContent.Name, "{0}");
			tvwContent.Nodes["nodeGeneral"].Text =
				Session.getLocalizedString(string.Format(treeViewLocalizationRoot, "nodeGeneral"));
			tvwContent.Nodes["nodeChanges"].Text =
				Session.getLocalizedString(string.Format(treeViewLocalizationRoot, "nodeChanges"));
			tvwContent.Nodes["nodeCustomFields"].Text =
				Session.getLocalizedString(string.Format(treeViewLocalizationRoot, "nodeCustomFields"));
		}

		#endregion

	}
}