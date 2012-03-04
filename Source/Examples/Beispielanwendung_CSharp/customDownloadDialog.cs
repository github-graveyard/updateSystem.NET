using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet;
using updateSystemDotNet.appEventArgs;

namespace Beispielanwendung_CSharp {
	public sealed partial class customDownloadDialog : updateDownloadBaseForm {
		public customDownloadDialog() {
			InitializeComponent();
			Font = SystemFonts.MessageBoxFont;

			downloadUpdatesCompleted += customDownloadDialog_downloadUpdatesCompleted;
			downloadUpdatesProgressChanged += customDownloadDialog_downloadUpdatesProgressChanged;
			Shown += customDownloadDialog_Shown;
		}

		private void customDownloadDialog_Shown(object sender, EventArgs e) {
			startDownload();
		}

		private void customDownloadDialog_downloadUpdatesProgressChanged(object sender,
		                                                                 downloadUpdatesProgressChangedEventArgs e) {
			prgDownload.Value = e.ProgressPercentage;
		}

		private void customDownloadDialog_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			if (e.Error != null) {
				if (!e.Cancelled)
					MessageBox.Show(string.Format("Whoops, da ist was beim Download schiefgegangen:\r\n{0}", e.Error.Message),
					                "Test Anwendung",
					                MessageBoxButtons.OK, MessageBoxIcon.Error);

				DialogResult = DialogResult.Cancel;
			}
			else
				DialogResult = DialogResult.OK;

			Close();
		}

		private void btnCancelUpdate_Click(object sender, EventArgs e) {
			if (isBusy)
				cancelDownload();
		}
	}
}