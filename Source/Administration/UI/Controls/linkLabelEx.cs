using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class linkLabelEx : LinkLabel {
		public linkLabelEx() {
			LinkColor = SystemColors.HotTrack;
			Font = SystemFonts.MessageBoxFont; // Core.Fonts.defaultFont;
			ActiveLinkColor = SystemColors.Highlight;
			LinkBehavior = LinkBehavior.NeverUnderline;
		}

		public string Url { get; set; }

		private void openFailed() {
			MessageBox.Show(
				"Die Adresse konnte wegen eines Fehlers nicht geöffnet werden:\r\n" + Url,
				"assemblyCompressor",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}

		protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e) {
			if (!string.IsNullOrEmpty(Url)) {
				new Thread(openUrl).Start(Url);
			}
			else {
				base.OnLinkClicked(e);
			}
		}

		private void openUrl(object argument) {
			try {
				Process.Start((argument as string));
			}
			catch {
				Invoke(new delOpenFailed(openFailed));
			}
		}

		#region Nested type: delOpenFailed

		private delegate void delOpenFailed();

		#endregion
	}
}