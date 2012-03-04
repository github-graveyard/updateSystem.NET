namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspSetupId : settingSubBasePage {
		public sspSetupId() {
			InitializeComponent();
		}
		public override void initializeData() {
			txtSetupId.Text = Session.currentProject.updateSetupId;
		}
		private void txtSetupId_TextChanged(object sender, System.EventArgs e) {
			Session.currentProject.updateSetupId = txtSetupId.Text;
		}
	}
}
