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
