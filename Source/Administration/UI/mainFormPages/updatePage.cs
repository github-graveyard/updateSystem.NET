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
