using System;
namespace updateSystemDotNet.Administration.UI.Popups {
	internal partial class updateVersionPopup : popupBase {
		public const string DCKEY_VERSION = "current_version";
		public const string DCKEY_PUBLISHED = "update_published";
		public const string DCKEY_SERVICE_PACK = "update_is_servicepack";

		public updateVersionPopup() {
			InitializeComponent();
		}

		public override void initializeData() {
			txtVersion.Text = popupArgument[DCKEY_VERSION].ToString();
			chkPublished.Checked = (bool) popupArgument[DCKEY_PUBLISHED];
			chkServicePack.Checked = (bool) popupArgument[DCKEY_SERVICE_PACK];
		}

		private void txtVersion_TextChanged(object sender, EventArgs e) {
			if (txtVersion.TextLength > 0 && isValidVersion(txtVersion.Text))
				popupResult[DCKEY_VERSION] = txtVersion.Text;
		}
		private void chkPublished_CheckedChanged(object sender, EventArgs e) {
			popupResult[DCKEY_PUBLISHED] = chkPublished.Checked;
		}
		private void chkServicePack_CheckedChanged(object sender, EventArgs e) {
			popupResult[DCKEY_SERVICE_PACK] = chkServicePack.Checked;
		}

		private bool isValidVersion(string version) {
			try {
				new Version(version);
				return true;
			}
			catch {
				return false;
			}
		}

	}
}
