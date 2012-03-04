using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class eapLoginDialog : dialogBase {
		public eapLoginDialog() {
			InitializeComponent();
			bgwLogin.RunWorkerCompleted += bgwLogin_RunWorkerCompleted;
		}

		void bgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Result is bool && (bool) e.Result) {
				DialogResult = DialogResult.OK;
				Close();
			}
			else
				btnOk.Enabled = true;
		}

		private void bgwLogin_DoWork(object sender, DoWorkEventArgs e) {
			string[] args = (string[]) e.Argument;
			try {
				e.Result = Session.webServices.eapLogin(args[0], args[1]);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			btnOk.Enabled = false;
			bgwLogin.RunWorkerAsync(new[] {txtMail.Text, txtPassword.Text});
		}
	}
}
