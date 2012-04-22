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
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.updateLog;
using updateSystemDotNet.Administration.Core.DataValidation;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class manageUpdateLogProjectDialog : dialogBase {
		private updateLogProject _project;

		public manageUpdateLogProjectDialog() {
			InitializeComponent();
		}
		public override void initializeData() {
			permanentlyDisableControl(txtProjectId);

			if(Argument == null)
				throw new ArgumentException("Your argument is invalid! -> updateProject");

			_project = (updateLogProject) Argument;
			txtProjectId.Text = _project.projectId;
			txtProjectName.Text = _project.projectName;
			chkIsActive.Checked = _project.isActive;
			registerValidationEntry(txtProjectName, validationTypes.NotNull, "Displayname");
		}

		private void bgwEditProject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var args = (object[]) e.Argument;
				Session.updateLogFactory.editProject(
					Session.currentProject.projectId,
					(string) args[0],
					(bool) args[1]
					);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (validateDialog()) {
				lockUi(false);
				bgwEditProject.RunWorkerAsync(new object[] {
				                                           	txtProjectName.Text,
				                                           	chkIsActive.Checked
				                                           });
			}
		}

		private void bgwEditProject_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if(e.Result == null) {
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lockUi(true);
				Session.showMessage(this,
				                    ((Exception) e.Result).Message, Session.localizeMessage("serverError", this),
				                    MessageBoxIcon.Error, MessageBoxButtons.OK);
			}
		}
	}
}
