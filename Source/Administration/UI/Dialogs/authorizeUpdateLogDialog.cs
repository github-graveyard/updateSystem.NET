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
