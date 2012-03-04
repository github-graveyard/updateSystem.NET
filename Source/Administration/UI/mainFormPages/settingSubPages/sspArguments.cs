namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspArguments : settingSubBasePage {
		public sspArguments() {
			InitializeComponent();
		}
		public override void initializeData() {
			txtArgumentSuccess.Text = Session.currentProject.updateParameterSuccess;
			txtArgumentFailure.Text = Session.currentProject.updateParameterFailed;
		}

		private void txtArgumentSuccess_TextChanged(object sender, System.EventArgs e) {
			Session.currentProject.updateParameterSuccess = txtArgumentSuccess.Text;
		}

		private void txtArgumentFailure_TextChanged(object sender, System.EventArgs e) {
			Session.currentProject.updateParameterFailed = txtArgumentFailure.Text;
		}
	}
}
