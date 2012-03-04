using System;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Internal.updateUI.Controls;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal.updateUI.Views {
	internal class viewUpdateCheck : updateBaseView {
		private readonly ToolTip _ttError = new ToolTip();
		private statusLabel _staCheckForUpdates;

		public viewUpdateCheck() {
			Title = "Suche nach Aktualisierungen für Meine Super Beispielanwendung...";
		}

		public override bool showInstallButton {
			get { return false; }
		}

		public override bool showCancelButton {
			get { return true; }
		}

		protected override void initializeComponents() {
			_staCheckForUpdates = new statusLabel {
			                                      	Text = "Suche nach Aktualisierungen...",
			                                      	Location = new Point(0, 0),
			                                      	State = statusLabelStates.Progress
			                                      };

			Controls.AddRange(new Control[] {_staCheckForUpdates});
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			_staCheckForUpdates.Size = new Size(ClientRectangle.Width, 50);
		}

		public override void Execute() {
			controllerInstance.checkForUpdatesCompleted += controllerInstance_checkForUpdatesCompleted;
			controllerInstance.checkForUpdatesAsync();
		}

		private void controllerInstance_checkForUpdatesCompleted(object sender, checkForUpdatesCompletedEventArgs e) {
			//Während der Suche ist ein Fehler aufgetreten
			if (e.Error != null) {
				_staCheckForUpdates.State = statusLabelStates.Failure;
				_staCheckForUpdates.Text = "Während der Updatesuche ist ein Problem aufgetreten,\r\nversuchen Sie es später erneut.";
				_ttError.SetToolTip(_staCheckForUpdates, e.Error.Message);
				return;
			}

			//Es gibt Updates
			if (e.Result) {
				//Nachschauen ob die Updatebenachrichtigung angezeigt werden soll
				if ((availableViewStates & updateViewStates.Display) == updateViewStates.Display) {
					onChangeUpdateView(typeof (viewUpdatesAvailable));
				}
				else {
					//wenn nicht dann den Dialog mit entsprechendem Result schließen
					onCloseDialog(new closeDialogEventArgs(
					              	DialogResult.OK
					              	));
				}
			}
			else {
				//Es gibt keine Updates
				Title = "Keine Updates verfügbar";
				_staCheckForUpdates.State = statusLabelStates.Success;
				_staCheckForUpdates.Text =
					"Ihre Version ist auf dem neuesten Stand.\r\nDenken Sie daran, regelmäßig nach neuen Updates zu suchen.";
			}
		}
	}
}