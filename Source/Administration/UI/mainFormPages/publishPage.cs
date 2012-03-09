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
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Publishing;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal sealed partial class publishPage : basePage {

		private ToolStripButton _tsBtnAddProvider;
		private ToolStripButton _tsBtnEditProvider;
		private ToolStripButton _tsBtnRemoveProvider;

		public publishPage() {
			InitializeComponent();
			pageSymbol = Core.resourceHelper.getImage("publish.png");
			Id = Guid.NewGuid().ToString();
			displayOrder = 500;
			extendsToolStrip = true;
			initializeToolStripButtons();
		}
		void lvwPublish_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
			saveColumnHeaderSizes(lvwPublish);
		}

		protected override void initializeToolStripButtons() {
			_tsBtnAddProvider = createToolStripButton("Veröffentlichungsquelle hinzufügen",
			                                          "Fügt eine neue Veröffentlichungsschnittstelle dem Projekt hinzu.");
			_tsBtnEditProvider = createToolStripButton("Bearbeiten",
			                                           "Öffnet einen Dialog zum bearbeiten der aktuell ausgewählten Veröffentlichungsschnittstelle.");
			_tsBtnRemoveProvider = createToolStripButton("Entfernen",
			                                             "Entfernt alle aktuell ausgewählten Veröffentlichungsschnittstellen aus dem Projekt.");

			_tsBtnEditProvider.Enabled = false;
			_tsBtnRemoveProvider.Enabled = false;

			_tsBtnAddProvider.Click += _tsBtnAddProvider_Click;
			_tsBtnEditProvider.Click += _tsBtnEditProvider_Click;
			_tsBtnRemoveProvider.Click += _tsBtnRemoveProvider_Click;
		}

		void _tsBtnRemoveProvider_Click(object sender, EventArgs e) {
			removePublishProvider();
		}

		void _tsBtnEditProvider_Click(object sender, EventArgs e) {
			editPublishProvider();
		}

		void _tsBtnAddProvider_Click(object sender, EventArgs e) {
			addPublishProvider();
		}

		public override void initializeData() {
			lvwPublish.ColumnWidthChanged -= lvwPublish_ColumnWidthChanged;
			lvwPublish.ItemChecked -= lvwPublish_ItemChecked;

			restoreColumnHeaderSizes(lvwPublish);

			//Gruppen hinzufügen
			lvwPublish.Groups.Clear();
			foreach (var provider in Session.publishFactory.availableProvider)
				lvwPublish.Groups.Add(provider.Value.Name, provider.Value.Name);

			//Provider hinzufügen
			lvwPublish.Items.Clear();
			foreach (var provider in Session.currentProject.publishProvider) {
				var item = new ListViewItem(provider.Settings.Name) {
					Checked = provider.Settings.isActive,
					Tag = provider,
					Group = lvwPublish.Groups[Session.publishFactory.availableProvider[provider.GetType()].Name]
				};

				item.SubItems.Add(
					provider.Settings.lastPublished == DateTime.MinValue ? "<Noch nie>" : Session.relativeDate(provider.Settings.lastPublished));
				lvwPublish.Items.Add(item);
			}

			lvwPublish.ColumnWidthChanged += lvwPublish_ColumnWidthChanged;
			lvwPublish.ItemChecked += lvwPublish_ItemChecked;
		}

		void lvwPublish_ItemChecked(object sender, ItemCheckedEventArgs e) {
			(e.Item.Tag as IPublishProvider).Settings.isActive = e.Item.Checked;
		}

		private void addPublishProvider() {
			if (Session.showDialog<Dialogs.chooseNewPublishProviderDialog>(ParentForm) == DialogResult.OK) {
				var newProvider = Session.publishFactory.publishProviderByType(
					(Type)Session.dialogResultCache[typeof(Dialogs.chooseNewPublishProviderDialog)]);
				Session.currentProject.addPublishProvider(newProvider);
				Session.showDialog<Dialogs.publishProviderSettingsDialog>(this, newProvider);
				initializeData();
			}
		}

		private void lvwPublish_SelectedIndexChanged(object sender, EventArgs e) {
			_tsBtnEditProvider.Enabled = (lvwPublish.SelectedItems.Count == 1);
			_tsBtnRemoveProvider.Enabled = (lvwPublish.SelectedItems.Count > 0);
		}

		private void editPublishProvider() {
			if (lvwPublish.SelectedItems.Count == 1) {
				if (
					Session.showDialog<Dialogs.publishProviderSettingsDialog>(this,
																			  lvwPublish.SelectedItems[0].Tag as IPublishProvider) ==
					DialogResult.OK)
					initializeData();
			}
		}

		private void removePublishProvider() {

			if (Session.showMessage(this, "Sind Sie sicher, dass Sie die ausgewählten Veröffentlichungsschnittstellen wirklich löschen möchten?", "Löschen bestätigen", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			if (lvwPublish.SelectedItems.Count > 0) {
				for (int i = lvwPublish.SelectedItems.Count - 1; i >= 0; i--)
					Session.currentProject.removePublishProvider(lvwPublish.SelectedItems[i].Tag as IPublishProvider);
				initializeData();
			}
		}

		private void btnPublishNow_Click(object sender, EventArgs e) {
			Session.onStartPublishing(EventArgs.Empty);
		}
	}
}