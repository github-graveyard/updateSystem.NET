/**
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

			registerValidationEntry(txtUsername, validationTypes.NotNull, "Username");
			if (_userAccount != null) {
				txtUsername.Text = _userAccount.Username;

				chkIsActive.Checked = _userAccount.userIsActive;
				chkIsAdmin.Checked = _userAccount.userIsAdmin;
				nmdMaxProjects.Value = _userAccount.maxProjects;

				txtPassword.cueText = "leave empty if you don't want to change it";

			}
			else {
				permanentlyDisableControl(chkIsActive);
				chkIsActive.Checked = true;
				registerValidationEntry(txtPassword, validationTypes.NotNull, "Password");
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

				//Either add a new user or edit an existing one
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

				//Import: Save the new Userdata as Result because they need to be updated in the projectconfig
				Result = new[] {txtUsername.Text, txtPassword.Text};

				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lockUi(true);

				Session.showMessage(this, ((Exception) e.Result).Message, Session.localizeMessage("serverError", this),
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
