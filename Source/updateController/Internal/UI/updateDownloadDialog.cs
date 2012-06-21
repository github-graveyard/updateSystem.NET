/*
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Internal.updateUI.Controls;
using updateSystemDotNet.appEventArgs;
using updateSystemDotNet.Localization;

namespace updateSystemDotNet.Internal.UI {
	internal partial class updateDownloadDialog : updateDownloadBaseForm {
		public updateDownloadDialog() {
			InitializeComponent();
			//Systemschriftart ermitteln
			base.Font = SystemFonts.MessageBoxFont;
			base.Text = string.Format("{0} updateinstaller", string.Empty);

			lblInfo.Text = localizationHelper.Instance.controlText(lblInfo);
			btnCancel.Text = localizationHelper.Instance.controlText(btnCancel);
			lblTop.Text = localizationHelper.Instance.controlText(lblTop);

			aclDownload.State = statusLabelStates.Progress;
			aclDownload.Text = string.Format(localizationHelper.Instance.controlText(aclDownload), "0");
			aclApply.Text = localizationHelper.Instance.controlText(aclApply);

			downloadUpdatesCompleted += DownloadDialog_downloadUpdatesCompleted;
			downloadUpdatesProgressChanged += DownloadDialog_downloadUpdatesProgressChanged;

			Shown += DownloadDialog_Shown;
		}

		private void DownloadDialog_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
			prgGlobal.Value = e.ProgressPercentage;
			aclDownload.Text = string.Format(localizationHelper.Instance.controlText(aclDownload), e.ProgressPercentage);
		}

		private void DownloadDialog_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			if ((!e.Cancelled) && e.Error == null) {
				DialogResult = DialogResult.OK;
				Close();
			}
			else if (e.Error != null) {
				if (!e.Cancelled) {
					MessageBox.Show(this,
					                string.Format(localizationHelper.Instance.exceptionMessage("updateDownloadFailed"), e.Error.Message)
					                , "updateSystem.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		private void DownloadDialog_Shown(object sender, EventArgs e) {
			Text = Result.Configuration.applicationName;

			//Download starten wenn die Form komplett fertig geladen ist
			startDownload();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			cancelDownload();
			btnCancel.Enabled = false;
		}
	}
}