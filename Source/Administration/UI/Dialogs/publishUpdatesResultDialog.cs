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
using System;
using updateSystemDotNet.Administration.Core.Publishing;
using System.Windows.Forms;
using System.Drawing;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class publishUpdatesResultDialog : dialogBase {
		private publishResultList _results;

		public publishUpdatesResultDialog() {
			InitializeComponent();
			Closing += publishUpdatesResultDialog_Closing;
		}

		void publishUpdatesResultDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			saveColumnHeaderSizes(lvwResult);
			Session.currentProject.hidePublishResult = chkHidePublishResult.Checked;
		}

		public override void initializeData() {
			_results = (Argument as publishResultList);
			restoreColumnHeaderSizes(lvwResult);

			if (_results == null)
				throw new InvalidOperationException("Argument is null");

			foreach (var result in _results) {

				var item = new ListViewItem {Text = result.Provider.Settings.Name};
				item.SubItems.Add(Session.publishFactory.availableProvider[result.Provider.GetType()].Name);
				if(result.Successful) {
					item.SubItems.Add("-");
					item.Group = lvwResult.Groups["grpSuccess"];
					item.ForeColor = Color.Green;
				}
				else {
					item.SubItems.Add(result.Error.Message);
					item.Group = lvwResult.Groups["grpFailed"];
					item.ForeColor = Color.DarkRed;
				}
				lvwResult.Items.Add(item);
			}
			chkHidePublishResult.Checked = Session.currentProject.hidePublishResult;
		}

		public override void localizeDialog() {
			base.localizeDialog();
			lvwResult.Columns[0].Text = localizeListViewColumn(lvwResult, "clmName");
			lvwResult.Columns[1].Text = localizeListViewColumn(lvwResult, "clmInterface");
			lvwResult.Columns[2].Text = localizeListViewColumn(lvwResult, "clmErrorMessage");
			lvwResult.Groups["grpSuccess"].Header = localizeListViewColumn(lvwResult, "grpSuccess");
			lvwResult.Groups["grpFailed"].Header = localizeListViewColumn(lvwResult, "grpFailed");
			mnuExportCSV.Text =
				Session.getLocalizedString(string.Format("{0}.{1}.{2}.Text", applicationSession.SECTION_NAME_DIALOGS, Name, mnuExportCSV.Name));
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void mnuExportCSV_Click(object sender, EventArgs e) {
			using(var dialog = new SaveFileDialog()) {
				dialog.Filter = "CSV-Files|*.csv";
				if (dialog.ShowDialog(this) == DialogResult.OK)
					lvwResult.exportAsCSV(dialog.FileName);
			}
		}

	}
}
