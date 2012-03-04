using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Internal.updateUI.Controls;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal.UI {
	internal partial class updateDownloadDialog : updateDownloadBaseForm {
		public updateDownloadDialog() {
			InitializeComponent();
			//Systemschriftart ermitteln
			base.Font = SystemFonts.MessageBoxFont;
			base.Text = string.Format("{0} Updateinstaller", string.Empty);

			lblInfo.Text = Language.GetString("DownloadDialog_lblInfo_text");
			btnCancel.Text = Language.GetString("general_button_cancel");
			lblTop.Text = Language.GetString("DownloadDialog_lblTop_text");

			aclDownload.State = statusLabelStates.Progress;
			aclDownload.Text = string.Format(Language.GetString("updateDownloadDialog_aclDownload"), "0");
			aclApply.Text = Language.GetString("updateDownloadDialog_aclApply");

			downloadUpdatesCompleted += DownloadDialog_downloadUpdatesCompleted;
			downloadUpdatesProgressChanged += DownloadDialog_downloadUpdatesProgressChanged;

			Shown += DownloadDialog_Shown;
		}

		private void DownloadDialog_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
			prgGlobal.Value = e.ProgressPercentage;
			aclDownload.Text = string.Format(Language.GetString("updateDownloadDialog_aclDownload"), e.ProgressPercentage);
		}

		private void DownloadDialog_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			if ((!e.Cancelled) && e.Error == null) {
				DialogResult = DialogResult.OK;
				Close();
			}
			else if (e.Error != null) {
				if (!e.Cancelled) {
					MessageBox.Show(this,
					                string.Format(Language.GetString("DownloadDialog_exception_text"), e.Error.Message)
					                , "updateSystem.Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		private void DownloadDialog_Shown(object sender, EventArgs e) {
			Text = Result.Configuration.applicationName;

			//Download starten wenn die Form komplett fertig geladen ist
			startDownload();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			cancelDownload();
			btnCancel.Enabled = false;
		}
	}
}