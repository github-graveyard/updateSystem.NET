#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.updateLog;
using System.Collections.Generic;
using System;
using updateSystemDotNet.Administration.Core.DataValidation;
namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class manageUpdateLogUserDialog : dialogBase {
		private userAccount _userAccount;

		public manageUpdateLogUserDialog() {
			InitializeComponent();
			bgwServerRequest.RunWorkerCompleted += bgwServerRequest_RunWorkerCompleted;
		}
		
		public override void initializeData() {
			if (Argument != null && Argument is userAccount)
				_userAccount = (Argument as userAccount);

			registerValidationEntry(txtUsername, validationTypes.NotNull, "Benutzername");
			if (_userAccount != null) {
				txtUsername.Text = _userAccount.Username;

				chkIsActive.Checked = _userAccount.userIsActive;
				chkIsAdmin.Checked = _userAccount.userIsAdmin;
				nmdMaxProjects.Value = _userAccount.maxProjects;

				txtPassword.cueText = "Nur eingeben, wenn Sie Ihr Passwort ändern wollen";

			}
			else {
				permanentlyDisableControl(chkIsActive);
				chkIsActive.Checked = true;

				//Das Passwort darf nur bei neuen Benutzern nicht leer sein
				registerValidationEntry(txtPassword, validationTypes.NotNull, "Passwort");
			}

		}
        
		private Dictionary<string,object> buildServerData() {
			var data = new Dictionary<string, object> {
			                                          	{"new_username", txtUsername.Text},
			                                          	{"new_password", txtPassword.Text},
			                                          	{"is_admin", chkIsAdmin.Checked},
			                                          	{"is_active", chkIsActive.Checked},
			                                          	{"max_projects", (int) nmdMaxProjects.Value},
			                                          	{"is_new", Argument == null}
			                                          };
			if (_userAccount != null)
				data.Add("old_username", _userAccount.Username);

			return data;
		}

		private void bgwServerRequest_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var arguments = (Dictionary<string, object>) e.Argument;

				//Je nachdem ob ein neuer Benutzer angelegt- oder ein bestehender aktualisiert werden soll,
				//eine andere Aktion benutzen.
				if((bool)arguments["is_new"]) {
					Session.updateLogFactory.addUser(
						(string) arguments["new_username"],
						(string) arguments["new_password"],
						(int) arguments["max_projects"],
						(bool) arguments["is_admin"]
						);
				}
				else {
					Session.updateLogFactory.editUser(
						(string)arguments["old_username"],
						(string) arguments["new_username"],
						(string) arguments["new_password"],
						(int) arguments["max_projects"],
						(bool) arguments["is_admin"],
						(bool) arguments["is_active"]
						);
				}

			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}
		void bgwServerRequest_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if (e.Result == null) {

				//Wichtig: Neue Benutzerdaten als Result speichern,
				//damit diese bei einem Update des aktuell angemeldeten Benutzers
				//übertragen werden können
				Result = new[] {txtUsername.Text, txtPassword.Text};

				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lockUi(true);
				Session.showMessage(this, ((Exception) e.Result).Message, "Während der Serveranfrage ist ein Problem aufgetreten!",
				                    MessageBoxIcon.Error, MessageBoxButtons.OK);
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if (validateDialog()) {
				lockUi(false);
				bgwServerRequest.RunWorkerAsync(buildServerData());
			}
		}
	}
}
