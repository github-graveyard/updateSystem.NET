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
