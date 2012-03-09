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

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal sealed partial class feedbackPage : basePage {
		public feedbackPage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = Core.resourceHelper.getImage("feedback.png");
			displayOrder = 900;
		}

		public override void initializeData() {
			txtName.Text = Session.Settings.feedbackName;
			txtMail.Text = Session.Settings.feedbackEMail;
		}

		private void btnSendFeedback_Click(object sender, EventArgs e) {
			btnSendFeedback.Enabled = false;
			bgwSendFeedback.RunWorkerAsync(new[] {txtName.Text, txtMail.Text, txtMessage.Text});
		}

		private void bgwSendFeedback_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {

			try {
				var args = (string[]) e.Argument;
				Session.webServices.sendFeedback(args[0], args[1], args[2]);
			}
			catch(Exception exc) {
				e.Result = exc;
			}

		}

		public override bool hideFromNavigation {
			get { return false; }
		}

		private void bgwSendFeedback_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			btnSendFeedback.Enabled = true;

			//Versenden hat geklappt, Felder leeren
			if (e.Result == null) {
				txtMessage.Text = string.Empty;
				Session.showMessage("Vielen Dank! Ihr Feedback wurde erfolgreich versendet.");
			}
			//TODO: Exception anzeigen (e.Result...)

		}

		private void txtName_TextChanged(object sender, EventArgs e) {
			Session.Settings.feedbackName = txtName.Text;
		}
		private void txtMail_TextChanged(object sender, EventArgs e) {
			Session.Settings.feedbackEMail = txtMail.Text;
		}
	}
}
