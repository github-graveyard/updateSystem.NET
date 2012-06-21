/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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

			//Clear fields if the Feedback has been successfully sent
			if (e.Result == null) {
				txtMessage.Text = string.Empty;
				Session.showMessage(Session.localizeMessage("feedbackSent", this));
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
