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

namespace updateSystemDotNet.Administration.Core.Publishing.FTP {
	internal partial class pbsftpSettingsControl : publishSettingsBaseControl {

		public pbsftpSettingsControl() {
			InitializeComponent();
		}

		public override void loadSettings() {
			txtHost.Text = getSetting(pbsFtp.pbsFtpSetting_Host);

			int port;
			if (!int.TryParse(getSetting(pbsFtp.pbsFtpSetting_Port, "21"), out port))
				port = 21;
			txtPort.Text = port.ToString();

			int protocol;
			if (!int.TryParse(getSetting(pbsFtp.pbsFtpSetting_Protocol, "0"), out protocol))
				protocol = 0;
			cboProtocol.SelectedIndex = protocol;

			int connectionType;
			if (!int.TryParse(getSetting(pbsFtp.pbsFtpSetting_ConnectionType, "0"), out connectionType))
				connectionType = 0;
			cboConnectionType.SelectedIndex = connectionType;

			txtUsername.Text = getSetting(pbsFtp.pbsFtpSetting_Username);
			txtPassword.Text = getSetting(pbsFtp.pbsFtpSetting_Password);
			txtDirectory.Text = getSetting(pbsFtp.pbsFtpSetting_Directory, "/");

		}
		public override void saveSettings() {
			
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Host, txtHost.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Port, txtPort.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Protocol, cboProtocol.SelectedIndex.ToString());
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_ConnectionType, cboConnectionType.SelectedIndex.ToString());
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Username, txtUsername.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Password, txtPassword.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Directory, txtDirectory.Text);

		}
	}
}
