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

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal sealed partial class updatePage : basePage {

		private ToolStripButton _tsBtnNewUpdatePackage;

		public updatePage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = Core.resourceHelper.getImage("updates.png");
			displayOrder = 300;
			extendsToolStrip = true;
			initializeToolStripButtons();
		}

		public override void initializeData() {
			txtSearchTerm.Text = Session.currentProject.viewFilter.filterTerm;
			chkHideUnpublishedUpdates.Checked = Session.currentProject.viewFilter.hideNonReleasedPackages;
			chkShowServicePacksOnly.Checked = Session.currentProject.viewFilter.showOnlyServicePacks;
		}

		protected override void initializeToolStripButtons() {
			_tsBtnNewUpdatePackage = createToolStripButton("Neues Updatepaket");
			_tsBtnNewUpdatePackage.Click += _tsBtnNewUpdatePackage_Click;
		}

		void _tsBtnNewUpdatePackage_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(Session.currentProjectPath)) {
				Session.showMessage("Bitte speichern Sie zuerst das Projekt (STRG + S) bevor Sie Updatepakete anlegen.",
									MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
				return;
			}

			if (Session.showDialog<Dialogs.updatePackageDialog>(ParentForm) == DialogResult.OK) {
				Session.onContentUpdateRequired(EventArgs.Empty);
			}
		}

		public override void initializeSubPages() {
			subPages.Clear();
			Node.Nodes.Clear();

			foreach(var updatePackage in Session.currentProject.updatePackages) {
				if(!Session.currentProject.viewFilter.appliesFilter(updatePackage))
					continue;

				var subPage = createSubPage<updateSubPage>(updatePackage);
				subPages.Add(subPage);
				Node.Nodes.Add(subPage.Node);
			}
		}

		private void btnNewUpdatePackage_Click(object sender, EventArgs e) {
			if(string.IsNullOrEmpty(Session.currentProjectPath)) {
				Session.showMessage("Bitte speichern Sie zuerst das Projekt (STRG + S) bevor Sie Updatepakete anlegen.",
				                    MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
				return;
			}

			if(Session.showDialog<Dialogs.updatePackageDialog>(ParentForm) == DialogResult.OK) {
				Session.onContentUpdateRequired(EventArgs.Empty);
			}
		}

		private void txtSearchTerm_TextChanged(object sender, EventArgs e) {
			Session.currentProject.viewFilter.filterTerm = txtSearchTerm.Text;
			initializeSubPages();
		}
		private void chkHideUnpublishedUpdates_CheckedChanged(object sender, EventArgs e) {
			Session.currentProject.viewFilter.hideNonReleasedPackages = chkHideUnpublishedUpdates.Checked;
			initializeSubPages();
		}
		private void chkShowServicePacksOnly_CheckedChanged(object sender, EventArgs e) {
			Session.currentProject.viewFilter.showOnlyServicePacks = chkShowServicePacksOnly.Checked;
			initializeSubPages();
		}

	}
}
