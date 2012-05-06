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
			
		}
		void lvwPublish_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
			saveColumnHeaderSizes(lvwPublish);
		}

		public override void initializeToolStripButtons() {
			_tsBtnAddProvider = createToolStripButton("tsBtnAddProvider");
			_tsBtnEditProvider = createToolStripButton("tsBtnEditProvider");
			_tsBtnRemoveProvider = createToolStripButton("tsBtnRemoveProvider");
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
					provider.Settings.lastPublished == DateTime.MinValue ? Session.localizeMessage("Never") : Session.relativeDate(provider.Settings.lastPublished));
				lvwPublish.Items.Add(item);
			}

			lvwPublish.ColumnWidthChanged += lvwPublish_ColumnWidthChanged;
			lvwPublish.ItemChecked += lvwPublish_ItemChecked;
		}

		public override void initializeLocalization() {
			base.initializeLocalization();
			lvwPublish.Columns[0].Text = localizeListViewColumn(lvwPublish, "clmName");
			lvwPublish.Columns[1].Text = localizeListViewColumn(lvwPublish, "clmLastPublished");
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