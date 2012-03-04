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
