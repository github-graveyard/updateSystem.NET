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
using System;
using updateSystemDotNet.Administration.Core.updateLog;
using System.Windows.Forms;
namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class authorizeUpdateLogDialog : dialogBase {
		public authorizeUpdateLogDialog() {
			InitializeComponent();
			bgwLogin.RunWorkerCompleted += bgwLogin_RunWorkerCompleted;
		}

		void bgwLogin_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if ((e.Result is userAccount)) {
				Result = (e.Result as userAccount);
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lockUi(true);
				Session.showMessage(this, ((Exception) e.Result).Message, "Während dem Login ist ein Problem aufgetreten",
				                    MessageBoxIcon.Error, MessageBoxButtons.OK);
			}
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			lockUi(false);
			bgwLogin.RunWorkerAsync(new[] {
			                              	txtServerUrl.Text,
			                              	txtUsername.Text,
			                              	txtPassword.Text
			                              });
		}

		private void bgwLogin_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var arguments = (string[])e.Argument;
				e.Result = Session.updateLogFactory.Login(arguments[0], arguments[1], arguments[2]);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}
	}
}
