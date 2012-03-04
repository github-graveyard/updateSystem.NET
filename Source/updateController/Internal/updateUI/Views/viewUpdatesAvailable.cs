using System.Drawing;
using System.Windows.Forms;

namespace updateSystemDotNet.Internal.updateUI.Views {
	internal sealed class viewUpdatesAvailable : updateBaseView {
		private Label lblCurrentVersion;
		private Label lblNewVersion;
		private Label lblSize;
		private TextBox txtChanges;

		public viewUpdatesAvailable() {
			Title = "Für Ihre Anwendung sind Aktualisierungen verfügbar!";
		}

		public override bool showInstallButton {
			get { return true; }
		}

		public override bool showCancelButton {
			get { return true; }
		}

		protected override void initializeComponents() {
			//Text für den Changelog hinzufügen
			txtChanges = new TextBox {
			                         	Text = "Changelog goes here....",
			                         	Height = 170,
			                         	ScrollBars = ScrollBars.Vertical,
			                         	ReadOnly = true,
			                         	Multiline = true,
			                         	BackColor = Color.White,
			                         	Cursor = Cursors.Default
			                         };
			addControl(txtChanges);

			//Label mit gesamtgröße aller Updates
			lblSize = new Label {
			                    	Text = "Updategröße: 2,13 MB (fake)"
			                    };
			addControl(lblSize);

			//Label mit aktuell installierter Version hinzufügen
			lblCurrentVersion = new Label {
			                              	Text = "Installierte Version: 0.0.0.0 (fake)"
			                              };
			addControl(lblCurrentVersion);

			//Label mit neuester Version setzen
			lblNewVersion = new Label {
			                          	Text = "Neueste Version: 1.0.0.0 (fake)",
			                          	Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold)
			                          };

			addControl(lblNewVersion);
		}
	}
}