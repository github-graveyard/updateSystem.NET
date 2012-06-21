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
using System.Windows.Forms;
using System;
using System.Diagnostics;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class applicationSettingsDialog : dialogBase {

		private proxySettings _cachedProxySettings;

		public applicationSettingsDialog() {
			InitializeComponent();
		}

		public override void initializeData() {

			foreach (var channel in Session.updateReleaseChannels)
				cboUpdateChannel.Items.Add(channel);

			chkEnableApplicationLog.Checked = Session.Settings.enableLogging;
			chkLogUpdateLog.Checked = Session.Settings.logUpdatelog;
			chkLogFtp.Checked = Session.Settings.logFtpOutput;
			chkCheckForUpdates.Checked = Session.Settings.checkForUpdatesAtStartup;

			cboUpdateChannel.SelectedIndex = Session.Settings.updateChannelIndex;
		}

		private void saveSettings() {
			Session.Settings.enableLogging = chkEnableApplicationLog.Checked;
			Session.Settings.logUpdatelog = chkLogUpdateLog.Checked;
			Session.Settings.logFtpOutput = chkLogFtp.Checked;
			Session.Settings.checkForUpdatesAtStartup = chkCheckForUpdates.Checked;
			Session.Settings.updateChannelIndex = cboUpdateChannel.SelectedIndex;

			if (_cachedProxySettings != null)
				Session.Settings.proxySettings = _cachedProxySettings;
		}

		private void btnOk_Click(object sender, EventArgs e) {
			saveSettings();
			Session.onSettingsChanged(EventArgs.Empty);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnOpenLogDirectory_Click(object sender, EventArgs e) {
			try {
				Process.Start("explorer.exe", Session.Log.logDirectory);
			}
			catch (Exception exc) {
				Session.showMessage(string.Format("Fehler beim Öffnen des Logverzeichnisses:\r\n{0}", exc.Message));
			}
		}

		private void btnProxySettings_Click(object sender, EventArgs e) {
			if(Session.showDialog<proxySettingsDialog>(this)== DialogResult.OK) {
				_cachedProxySettings = (proxySettings)Session.dialogResultCache[typeof (proxySettingsDialog)];
			}
		}

		private void chkEnableApplicationLog_CheckedChanged(object sender, EventArgs e) {
			pnlLogSettings.Enabled = chkEnableApplicationLog.Checked;
		}

	}
}