using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using updateSystemDotNet.Updater.UI.Components;

namespace updateSystemDotNet.Updater.UI.Forms {
	internal partial class fileAccessDialog : dlgTemplate {
		public fileAccessDialog() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			imgExclamation.Image = SystemIcons.Exclamation.ToBitmap();
			Shown += fileAccessDialog_Shown;

			lblTitle.Text = Language.GetString("fileAccessDialog_lblTitle_text");
			btnRetry.Text = Language.GetString("fileAccessDialog_btnRetry_text");
			btnAbort.Text = Language.GetString("fileAccessDialog_btnAbort_text");
		}

		private void fileAccessDialog_Shown(object sender, EventArgs e) {
			SystemSounds.Exclamation.Play();
		}

		public DialogResult ShowDialog(IWin32Window Owner, string Path) {
			lblInfo.Text = string.Format(
				Language.GetString("fileAccessDialog_lblInfo_text")
				, Path);

			return base.ShowDialog(Owner);
		}
	}
}