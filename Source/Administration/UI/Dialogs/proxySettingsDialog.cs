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
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class proxySettingsDialog : dialogBase {
		public proxySettingsDialog() {
			InitializeComponent();
		}
		public override void initializeData() {
			
			//Proxytyp setzen
			switch(Session.Settings.proxySettings.proxyMode) {
				case proxyModes.useSystemDefaults:
					rbSystemProxy.Checked = true; break;
				case proxyModes.useCustomSettings:
					rbCustomProxy.Checked = true; break;
			}

			//Server und Port setzen
			txtServer.Text = Session.Settings.proxySettings.Server;
			txtPort.Text = Session.Settings.proxySettings.Port.ToString();

			//Anmeldung setzen
			switch(Session.Settings.proxySettings.Authentication) {
				case proxyAuthentication.None:
					rbNoAuth.Checked = true; break;
				case proxyAuthentication.NetworkCredentials:
					rbWinAuth.Checked = true; break;
				case proxyAuthentication.Custom:
					rbCustomAuth.Checked = true; break;
			}

			//Benutzername und Password setzen
			txtUsername.Text = Session.Settings.proxySettings.Username;
			txtPassword.Text = Session.Settings.proxySettings.Password;

		}

		private void rbCustomProxy_CheckedChanged(object sender, System.EventArgs e) {
			grpCustomProxy.Enabled = rbCustomProxy.Checked;
		}

		private void rbCustomAuth_CheckedChanged(object sender, System.EventArgs e) {
			pnlCredentials.Enabled = rbCustomAuth.Checked;
		}

		private void btnSaveSettings_Click(object sender, System.EventArgs e) {
			var newProxySettings = new proxySettings {
			                                         	Server = txtServer.Text,
			                                         	Port = int.Parse(txtPort.Text),
			                                         	Username = txtUsername.Text,
			                                         	Password = txtPassword.Text,
			                                         	proxyMode =
			                                         		rbSystemProxy.Checked
			                                         			? proxyModes.useSystemDefaults
			                                         			: proxyModes.useCustomSettings
			                                         };

			if (rbNoAuth.Checked)
				newProxySettings.Authentication = proxyAuthentication.None;
			else if (rbWinAuth.Checked)
				newProxySettings.Authentication = proxyAuthentication.NetworkCredentials;
			else if (rbCustomAuth.Checked)
				newProxySettings.Authentication = proxyAuthentication.Custom;

			Result = newProxySettings;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
