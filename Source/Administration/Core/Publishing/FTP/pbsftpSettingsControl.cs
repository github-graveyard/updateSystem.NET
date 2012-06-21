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
using System.Globalization;

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
			txtPort.Text = port.ToString(CultureInfo.InvariantCulture);

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
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Protocol, cboProtocol.SelectedIndex.ToString(CultureInfo.InvariantCulture));
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_ConnectionType, cboConnectionType.SelectedIndex.ToString(CultureInfo.InvariantCulture));
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Username, txtUsername.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Password, txtPassword.Text);
			addOrUpdateSetting(pbsFtp.pbsFtpSetting_Directory, txtDirectory.Text);

		}

		public override void localizeControl() {
			base.localizeControl();
			lblServerAddress.Text = Session.getLocalizedString(string.Format(localizationPath, lblServerAddress.Name));
			lblPort.Text = Session.getLocalizedString(string.Format(localizationPath, lblPort.Name));
			lblProtocol.Text = Session.getLocalizedString(string.Format(localizationPath, lblProtocol.Name));
			lblConnection.Text = Session.getLocalizedString(string.Format(localizationPath, lblConnection.Name));
			lblUsername.Text = Session.getLocalizedString(string.Format(localizationPath, lblUsername.Name));
			lblPassword.Text = Session.getLocalizedString(string.Format(localizationPath, lblPassword.Name));
			lblDirectory.Text = Session.getLocalizedString(string.Format(localizationPath, lblDirectory.Name));

			cboProtocol.Items.Clear();
			cboProtocol.Items.AddRange(
				(string[])Session.getLocalizedString(string.Format(localizationPath, cboProtocol.Name)).Split(new[] {";"}, StringSplitOptions. RemoveEmptyEntries));

			cboConnectionType.Items.Clear();
			cboConnectionType.Items.AddRange(
				(string[])Session.getLocalizedString(string.Format(localizationPath, cboConnectionType.Name)).Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries));
		}

	}
}
