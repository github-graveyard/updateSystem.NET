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

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal sealed partial class updatePage : basePage {

		private ToolStripButton _tsBtnNewUpdatePackage;

		public updatePage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = Core.resourceHelper.getImage("updates.png");
			displayOrder = 300;
			extendsToolStrip = true;
		}

		public override void initializeData() {
			txtSearchTerm.Text = Session.currentProject.viewFilter.filterTerm;
			chkHideUnpublishedUpdates.Checked = Session.currentProject.viewFilter.hideNonReleasedPackages;
			chkShowServicePacksOnly.Checked = Session.currentProject.viewFilter.showOnlyServicePacks;
		}

		public override void initializeToolStripButtons() {
			_tsBtnNewUpdatePackage = createToolStripButton("tsBtnNewUpdatePackage");
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
