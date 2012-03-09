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
using System.Drawing;
using System;
using updateSystemDotNet.Internal.updateUI.Controls;

namespace updateSystemDotNet.Internal.UI {
	internal partial class updateLocationControl : UserControl {
		private readonly updateController _controller;
		private readonly ToolTip _ttError;

		public updateLocationControl(string value, updateController controller) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			_ttError = new ToolTip();
			_controller = controller;
			txtUpdateUri.Text = value;

			bgwCheckConnection.RunWorkerCompleted += bgwCheckConnection_RunWorkerCompleted;
			txtUpdateUri.TextChanged += txtUpdateUri_TextChanged;
		}

		void txtUpdateUri_TextChanged(object sender, EventArgs e) {
			aclCheckConnection.Hide();
		}

		void bgwCheckConnection_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if (IsDisposed)
				return;

			txtUpdateUri.Enabled = true;
			btnCheckConnection.Enabled = true;

			if(e.Result == null) { //Überprüfung hat geklappt
				aclCheckConnection.State = statusLabelStates.Success;
				aclCheckConnection.Text = "Die Adresse ist erreichbar.";
			}
			else { // Überprüfung ist fehlgeschlagen
				aclCheckConnection.State = statusLabelStates.Failure;
				aclCheckConnection.Text = "Die Adresse ist nicht erreichbar.";
				var exception = (e.Result as Exception);
				if (exception != null)
					_ttError.SetToolTip(aclCheckConnection, exception.Message);
			}
		}

		public string Value { get { return txtUpdateUri.Text; } }

		private void bgwCheckConnection_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				//WebClient erstellen
				var client = internalHelper.buildBaseWebClient(_controller);
				client.DownloadData(internalHelper.prepareUpdateLocation(e.Argument.ToString()) + "update.xml");
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void btnCheckConnection_Click(object sender, EventArgs e) {
			btnCheckConnection.Enabled = false;
			txtUpdateUri.Enabled = false;
			_ttError.SetToolTip(aclCheckConnection, string.Empty);

			aclCheckConnection.Show();
			aclCheckConnection.State = statusLabelStates.Progress;
			aclCheckConnection.Text = "Überprüfe Erreichbarkeit...";

			bgwCheckConnection.RunWorkerAsync(txtUpdateUri.Text);
		}
	}
}
