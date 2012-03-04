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
