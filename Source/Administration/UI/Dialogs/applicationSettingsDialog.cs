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