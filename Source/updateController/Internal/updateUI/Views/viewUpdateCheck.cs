/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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