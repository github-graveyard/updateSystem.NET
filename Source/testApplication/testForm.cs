using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;

namespace testApplication
{
	public partial class testForm : Form
	{
		public testForm(string[] arguments)
		{
			InitializeComponent();
			//Events registrieren
			updateController1.checkForUpdatesCompleted += new updateSystemDotNet.checkForUpdatesCompletedEventHandler(updateController1_checkForUpdatesCompleted);
			updateController1.downloadUpdatesCompleted += new updateSystemDotNet.downloadUpdatesCompletedEventHandler(updateController1_downloadUpdatesCompleted);
			updateController1.downloadUpdatesProgressChanged += new updateSystemDotNet.downloadUpdatesProgressChangedEventHandler(updateController1_downloadUpdatesProgressChanged);
			updateController1.updateFound += new updateSystemDotNet.updateFoundEventHandler(updateController1_updateFound);
			updateController1.updateInstallerStarted += new updateSystemDotNet.updateInstallerStartedEventHandler(updateController1_updateInstallerStarted);
			updateController1.confirmUpdatePackage += new updateSystemDotNet.confirmUpdatePackageEventHandler(updateController1_confirmUpdatePackage);

			foreach (string argument in arguments) { txtArgs.AppendText(argument + "\r\n"); }

			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			lblLastUpdateCheck.Text = string.Format("Letzte Updatesuche: {0}", updateController1.lastSuccessfullUpdateCheck.ToString());
		}

		bool updateController1_confirmUpdatePackage(object sender, updateSystemDotNet.appEventArgs.confirmUpdatePackageEventArgs e)
		{
			/*
			if (MessageBox.Show("Confirm Version: " + e.updatePackage.releaseInfo.ToString(), "testApplication", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				return true;
			else
				return false;*/
			return true;
		}

		void updateController1_updateInstallerStarted(object sender, updateSystemDotNet.appEventArgs.updateInstallerStartedEventArgs e)
		{
			//if (!updateController1.autoCloseHostApplication) { this.Close(); }
		}

		void updateController1_updateFound(object sender, updateSystemDotNet.appEventArgs.updateFoundEventArgs e)
		{
			StringBuilder sbChanges = new StringBuilder();
			foreach (KeyValuePair<updateSystemDotNet.Core.Types.enhancedVersion, updateSystemDotNet.Core.Types.changelogDocument> chlgDoc in e.Result.Changelogs)
			{
				sbChanges.AppendLine(chlgDoc.Value.germanChanges);
			}

			if (MessageBox.Show(
				string.Format("Es wurden Aktualisierungen gefunden!\r\nNeueste Version: {0}\r\nÄnderungen:\r\n{1}\r\nMöchten Sie die Updates jetzt installieren", e.Result.newUpdatePackages[e.Result.newUpdatePackages.Count - 1].releaseInfo.Version,sbChanges.ToString()),
				"Updatebenachrichtigung",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information) == DialogResult.Yes)
			{
				updateController1.downloadUpdates();
			}
			foreach (updatePackage package in updateController1.currentUpdateResult.newUpdatePackages) {
				string wert = package.customFields["wert"];
			}
		}

		void updateController1_downloadUpdatesProgressChanged(object sender, updateSystemDotNet.appEventArgs.downloadUpdatesProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		void updateController1_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null)
			{
				updateController1.applyUpdate();
			}
			else if (e.Error != null && !e.Cancelled)
			{
				MessageBox.Show("Whoops, beim Updatedownload is was schiefgegangen:\r\n" + e.Error);
			}
		}

		void updateController1_checkForUpdatesCompleted(object sender, updateSystemDotNet.appEventArgs.checkForUpdatesCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show("Whoops, bei der Updatesuche is was schiefgegangen:\r\n" + e.Error.Message);
			}
		}

		private void btnCheckForUpdates_Click(object sender, EventArgs e)
		{
			updateController1.checkForUpdatesAsync();
		}

		private void btnCancelUpdate_Click(object sender, EventArgs e)
		{
			if (updateController1.isUpdateDownloaderBusy) { updateController1.cancelUpdateDownload(); }
		}

		private void btnUpdateInteractive_Click(object sender, EventArgs e)
		{
			updateController1.updateInteractive(this);
			//updateController1.showNewUpdateDialog();
		}

		private void btnUpdateInteractive2_Click(object sender, EventArgs e)
		{
			updateController1.updateInteractive(this, new myDownloadForm());
		}

		private void testForm_Load(object sender, EventArgs e)
		{
			
		}

		private void btnCheckForUpdatesSync_Click(object sender, EventArgs e) {
			if(updateController1.checkForUpdates()) {
				if(updateController1.showUpdateDialog(this) == System.Windows.Forms.DialogResult.OK)
					if(updateController1.downloadUpdatesDialog(this)== System.Windows.Forms.DialogResult.OK)
						updateController1.applyUpdate();
			}
		}
	}
}
