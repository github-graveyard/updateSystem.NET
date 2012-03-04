namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspGeneral : settingSubBasePage {
		public sspGeneral() {
			InitializeComponent();
		}
		public override void initializeData() {
			chkNativeImage.Checked = Session.currentProject.generateNativeImages;
			chkServicePackIsDefault.Checked = Session.currentProject.setServicePackAsDefault;
		}
		private void chkNativeImage_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.generateNativeImages = chkNativeImage.Checked;
		}

		private void chkServicePackIsDefault_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.setServicePackAsDefault = chkServicePackIsDefault.Checked;
		}
	}
}
