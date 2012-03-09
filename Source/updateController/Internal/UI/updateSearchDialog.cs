/*
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Internal.updateUI.Controls;

namespace updateSystemDotNet.Internal.UI {
	internal partial class updateSearchDialog : Form {
		private readonly updateController _controller;
		//private readonly Exception m_searchException;
		private changelogDictionary m_changelog;
		private updateConfiguration m_config;
		private List<updatePackage> m_result = new List<updatePackage>();

		public updateSearchDialog(updateController controller) {
			InitializeComponent();

			//Systemschriftart ermitteln
			base.Font = SystemFonts.MessageBoxFont;
			lblStatus.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12);

			//Initialisiere Strings
			lblStatus.Text = Language.GetString("SearchDialog_lblStatus_search");
			aclSearch.State = statusLabelStates.Progress;
			aclSearch.Text = lblStatus.Text = Language.GetString("SearchDialog_lblStatus_search");
			lblCurrentVersion.Text = string.Format(Language.GetString("SearchDialog_lblCurrentVersion_text"),
			                                       controller.releaseInfo.Version);
			if (controller.releaseInfo.Type != releaseTypes.Final) {
				lblCurrentVersion.Text += string.Format(" ({0} {1})", controller.releaseInfo.Type.ToString(),
				                                        controller.releaseInfo.Step.ToString());
			}

			btnCancel.Text = Language.GetString("general_button_cancel");

			//Setze private Variable
			_controller = controller;

			//Initialisiere Events
			Shown += SearchDialog_Shown;
			bgwSearch.RunWorkerCompleted += bgwSearch_RunWorkerCompleted;
		}


		public List<updatePackage> Result {
			get { return m_result; }
		}

		public updateConfiguration Config {
			get { return m_config; }
		}

		public changelogDictionary Changelogs {
			get { return m_changelog; }
		}

		//public Exception searchException {
		//    get { return m_searchException; }
		//}

		public new DialogResult ShowDialog(IWin32Window owner) {
			if (owner == null) StartPosition = FormStartPosition.CenterScreen;

			//TopMost Workaround
			try {
				var fParent = (Form) owner;
				PropertyInfo pTopMost = fParent.GetType().GetProperty("TopMost");
				TopMost = (bool) pTopMost.GetValue(fParent, null);
			}
			catch {
			}

			return base.ShowDialog(owner);
		}

		private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (IsDisposed)
				return;

			if (e.Result != null) {
				if (e.Result is List<updatePackage>) {
					m_result = (List<updatePackage>) e.Result;
					if (m_result.Count > 0) {
						DialogResult = DialogResult.OK;
						Close();
						return;
					}
				}
				else {
					MessageBox.Show(this,
					                string.Format(Language.GetString("SearchDialog_exception_text"), (e.Result as Exception).Message),
					                "updateSystem.NET",
					                MessageBoxButtons.OK,
					                MessageBoxIcon.Error);

					DialogResult = DialogResult.Cancel;
					Close();
				}
			}

			lblStatus.Text = Language.GetString("SearchDialog_lblStatus_noNewUpdates");
			aclSearch.Text = Language.GetString("SearchDialog_lblNoUpdates_text");
			aclSearch.State = statusLabelStates.Success;
			btnCancel.Text = Language.GetString("general_button_close");

			if (m_config != null)
				Text = m_config.applicationName;
		}

		private void SearchDialog_Shown(object sender, EventArgs e) {
			bgwSearch.RunWorkerAsync();
		}

		private void bgwSearch_DoWork(object sender, DoWorkEventArgs e) {
			try {
				/*Internal.Search.Provider provider = new updateSystemDotNet.Internal.Search.Provider((UpdateSettings)e.Argument);
				provider.Search();
				m_config = provider.Configuration;
				e.Result = provider.Result;
				m_changelog = provider.Changelogs;*/
				var sProvider = new searchProvider(_controller);
				sProvider.executeSearch();

				var s = new ScheduledStart(_controller.projectId, _controller.updateCheckInterval,
				                           _controller.customUpdateCheckInterval);
				s.WriteCurrentDate();

				m_config = sProvider.currentConfiguration;
				m_changelog = sProvider.correspondingChangelogs;
				e.Result = sProvider.foundUpdates;
			}
			catch (Exception ex) {
				e.Result = ex;
			}
		}
		private void SearchDialog_Load(object sender, EventArgs e) {
		}
	}
}