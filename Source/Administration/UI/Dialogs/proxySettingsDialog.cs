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
