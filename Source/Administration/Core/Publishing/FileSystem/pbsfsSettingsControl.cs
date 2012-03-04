using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core.Publishing.FileSystem {
	internal partial class pbsfsSettingsControl : publishSettingsBaseControl {
		public pbsfsSettingsControl() {
			InitializeComponent();
		}
		public override void loadSettings() {
			txtPublishDirectory.Text = getSetting("target");
		}
		public override void saveSettings() {
			addOrUpdateSetting("target", txtPublishDirectory.Text);
		}

		private void btnBrowseDirectory_Click(object sender, System.EventArgs e) {
			using(var dialog = new FolderBrowserDialog()) {
				dialog.Description = "Wählen Sie ein Verzeichnis aus, in welchen Sie die Updates veröffentlichen möchten:";
				if (dialog.ShowDialog() == DialogResult.OK)
					txtPublishDirectory.Text = dialog.SelectedPath;
			}
		}
	}
}