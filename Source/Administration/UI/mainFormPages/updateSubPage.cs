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

using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Administration.Core.Publishing;
using updateSystemDotNet.Administration.Core;
using System;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal sealed partial class updateSubPage : baseSubPage {

		private updatePackage _package;
		private const string lblLastPublishedBase = "Zuletzt Veröffentlicht: ";

		private ToolStripButton _tsBtnEditPackage;
		private ToolStripButton _tsBtnRemovePackage;

		public updateSubPage() {
			InitializeComponent();
			lvwPublishWith.Columns[0].Width = lvwPublishWith.ClientRectangle.Width; // - (SystemInformation.VerticalScrollBarWidth);
			extendsToolStrip = true;
			initializeToolStripButtons();
		}
		public override void initializeData() {
			lvwPublishWith.ItemChecked -= lvwPublishWith_ItemChecked;
			_package = (updatePackage)Argument;
			pageName = _package.ToString();
			Title = string.Format("Updatepaket Version {0}", _package);
			lblSize.Text = string.Format("Größe: {0}", updateSystemDotNet.Core.Helper.GetFileSize(_package.packageSize));

			lblLastPublishedDescription.Text = string.Format("{0}{1}", lblLastPublishedBase,
															 _package.publishDate == DateTime.MinValue
																? "Noch nie"
																: string.Format("{0} (am {1} um {2})",
																				Session.relativeDate(_package.publishDate),
																				_package.publishDate.ToShortDateString(),
																				_package.publishDate.ToShortTimeString()));


			//Veröffentlichungsschnittstellen
			lvwPublishWith.Items.Clear();
			foreach(var pbProvider in Session.currentProject.publishProvider) {
				if(!pbProvider.Settings.isActive)
					continue;

				var item = new ListViewItem {
												Text = string.Format("{0} (via {1})", pbProvider.Settings.Name,
																	 Session.publishFactory.availableProvider[
																		pbProvider.GetType()].Name),
												Checked = Session.updateFactory.isUpdateLinked(_package, pbProvider),
												Tag = pbProvider
											};
				lvwPublishWith.Items.Add(item);
			}

			lvwPublishWith.ItemChecked += lvwPublishWith_ItemChecked;
		}

		protected override void initializeToolStripButtons() {
			_tsBtnEditPackage = createToolStripButton("Updatepaket bearbeiten");
			_tsBtnRemovePackage = createToolStripButton("Entfernen", "Entfernt des Updatepaket aus dem Projekt.");

			_tsBtnEditPackage.Click += _tsBtnEditPackage_Click;
			_tsBtnRemovePackage.Click += _tsBtnRemovePackage_Click;
		}

		void _tsBtnRemovePackage_Click(object sender, EventArgs e) {
			deletePackage();
		}

		void _tsBtnEditPackage_Click(object sender, EventArgs e) {
			beginEditPackage();
		}

		void lvwPublishWith_ItemChecked(object sender, ItemCheckedEventArgs e) {
			var pbProvider = (IPublishProvider) e.Item.Tag;
			if (e.Item.Checked)
				Session.updateFactory.linkUpdate(_package, pbProvider);
			else
				Session.updateFactory.unlinkUpdate(_package, pbProvider);
		}

		public override TreeNode Node {
			get {
				base.Node.Text = Argument.ToString();
				return base.Node;
			}
		}

		private void deletePackage() {
			if (Session.showMessage(ParentForm, "Sind Sie sicher, dass Sie dieses Updatepaket wirklich löschen möchten?", "Löschen bestätigen", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			Session.updateFactory.removeUpdatePackage(_package);

			//Projekt speichern
			Session.saveProject();			
		}

		private void beginEditPackage() {
			//Updatepaket für das Bearbeiten vorbeiten
			var prepareResult = Session.updateFactory.prepareEditUpdatePackage(_package);

			//Dialog zur Bearbeitung des Updatepaketes anzeigen
			if (Session.showDialog<Dialogs.updatePackageDialog>(ParentForm, prepareResult) == DialogResult.OK) {

				//Den alten Paketverweis aus dem Projekt entfernen
				Session.currentProject.updatePackages.Remove(_package);

				_package = (updatePackage)Session.dialogResultCache[typeof(Dialogs.updatePackageDialog)];
				Session.currentProject.updatePackages.Add(_package);

				Session.saveProject();
			}

			//Temporär erzeugte Daten verwerfen
			Session.updateFactory.cleanupEditUpdatePackage(prepareResult);			
		}

		private void fbtnVersionPopup_Click(object sender, EventArgs e) {

			dataContainer arguments = new dataContainer();
			arguments[Popups.updateVersionPopup.DCKEY_VERSION] = _package.releaseInfo.Version;
			arguments[Popups.updateVersionPopup.DCKEY_PUBLISHED] = _package.Published;
			arguments[Popups.updateVersionPopup.DCKEY_SERVICE_PACK] = _package.isServicePack;

			Session.popupClosed += Session_popupClosed;
			Session.showPopup<Popups.updateVersionPopup>((Control) sender, arguments);
			
		}

		void Session_popupClosed(Popups.popupBase sender, Popups.popupClosedEventArgs e) {
			Session.popupClosed -= Session_popupClosed;
			
			if(sender.GetType() == typeof(Popups.updateVersionPopup)) {
				if(!string.IsNullOrEmpty(e.Result[Popups.updateVersionPopup.DCKEY_VERSION].ToString()))
					_package.releaseInfo.Version = e.Result[Popups.updateVersionPopup.DCKEY_VERSION].ToString();
				
				_package.Published = (bool) e.Result[Popups.updateVersionPopup.DCKEY_PUBLISHED];
				_package.isServicePack = (bool) e.Result[Popups.updateVersionPopup.DCKEY_SERVICE_PACK];
				base.Node.Text = _package.ToString();
				initializeData();
			}
		}
	}
}
