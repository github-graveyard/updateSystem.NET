using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Internal.updateUI.Controls;

namespace updateSystemDotNet.Internal.updateUI.Views {
	internal sealed class viewUpdateDownloadAndApply : updateBaseView {
		private ProgressBar prgUpdate;
		private statusLabel staApply;
		private statusLabel staDownload;

		public viewUpdateDownloadAndApply() {
			Title = "Die Aktualisierungen für Ihre Anwendung werden nun heruntergeladen und installiert";
		}

		public override bool showInstallButton {
			get { return false; }
		}

		public override bool showCancelButton {
			get { return true; }
		}

		protected override void initializeComponents() {
			//Progressbar
			prgUpdate = new ProgressBar {
			                            	Height = 15,
			                            	Value = 60
			                            };
			addControl(prgUpdate);

			//StatusLabel Installation
			staApply = new statusLabel {
			                           	Text = "Updates werden installiert",
			                           	State = statusLabelStates.Waiting,
			                           	Size = new Size(Width, 30)
			                           };
			addControl(staApply);

			//StatusLabel Download
			staDownload = new statusLabel {
			                              	Text = "Updates werden heruntergeladen (60% abgeschlossen)",
			                              	State = statusLabelStates.Progress,
			                              	Size = new Size(Width, 30)
			                              };
			addControl(staDownload);
		}
	}
}