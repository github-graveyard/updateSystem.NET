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
using updateSystemDotNet.Administration.UI.Controls;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.updateLog.Responses;

namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	internal partial class statisticSettingsSubPage : statisticSubBasePage {

		private string projectStateTemplate = string.Empty;
		private string unknownProjectState = string.Empty;

		public statisticSettingsSubPage() {
			InitializeComponent();
			pageSymbol = resourceHelper.getImage("projectEdit.png");
			Id = "7cd67d4c-667c-457f-8089-51464c5bea56";
			dtpCleanup.Value = DateTime.Now.AddMonths(-3);
			dtpCleanup.MaxDate = DateTime.Now;
		}

		public override void initializeLocalization() {
			base.initializeLocalization();
			projectStateTemplate = Session.localizeMessage("projectStateTemplate", this);
			unknownProjectState = Session.localizeMessage("unknownProjectState", this);
			aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Unknown"));
			lblStateDescription.Text = unknownProjectState;
		}

		private void btnUpdateState_Click(object sender, EventArgs e) {
			beginUpdateState();
		}

		/// <summary>Starts the Serverrequest for determining the Projectstate.</summary>
		private void beginUpdateState() {
			
			//Update controls
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Updating", this));

			//Send Request
			bgwUpdateState.RunWorkerAsync();

		}

		/// <summary>Sets the Projectstate based on the Object returned by the BackgroundWorker.</summary>
		private void endUpdateState(object result) {
			
			//Update statuscontrols
			aclState.State = actionLabelStates.Waiting;
			flpStatusControls.Enabled = true;

			//Check if the Request was successfull
			string stateText = string.Format(projectStateTemplate, Session.localizeMessage("Unknown"));
			string stateDescription = unknownProjectState;
			if(result is updateLogProject || result == null) {

				//Reset Controls
				btnAddProject.Hide();
				btnRemoveProject.Hide();
				grpMaintenance.Enabled = false;

				var project = result as updateLogProject;
				if(project != null) { //The Project exists on the Server
					
					//Show the Button for deleting the Project
					btnRemoveProject.Show();

					//Show Maintenancetasks
					grpMaintenance.Enabled = true;

					stateText = string.Format(projectStateTemplate, Session.localizeMessage("Present", this));
					Session.currentProject.updateLogEnabled = true;
					stateDescription = Session.localizeMessage("presentDescription", this);
					aclState.State = actionLabelStates.Success;
				}
				else { //The Project doesn't exists yet
					btnAddProject.Show();
					Session.currentProject.updateLogEnabled = false;
					stateText = string.Format(projectStateTemplate, Session.localizeMessage("notPresent", this));
					stateDescription = Session.localizeMessage("notPresent", this);
				}
			}
			else { //Error
				showServerError(result as Exception);
			}
			aclState.Text = stateText;
			lblStateDescription.Text = stateDescription;
		}

		private void bgwUpdateState_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				e.Result = Session.updateLogFactory.getProject(Session.currentProject.projectId);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}
		
		private void bgwUpdateState_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			endUpdateState(e.Result);
		}

		private void beginAddProject() {
			//Update Controls
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Adding",this));

			//Send Request
			bgwAddProject.RunWorkerAsync();
		}

		private void endAddProject(object result) {
			
			if(result == null) { // No error while adding the Project
				//Update status
				beginUpdateState();
			}
			else {
				//enable Controls
				flpStatusControls.Enabled = true;
				aclState.State = actionLabelStates.Waiting;
				aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Unknown"));

				showServerError(result as Exception);
			}
		}

		private void bgwAddProject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				Session.updateLogFactory.addProject(
					Session.currentProject.projectId,
					Session.currentProject.projectName,
					true
					);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwAddProject_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			endAddProject(e.Result);
		}

		private void btnAddProject_Click(object sender, EventArgs e) {
			beginAddProject();
		}

		private void beginDeleteProject() {
		
			//Update Controls
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Deleting", this));

			//Send request
			bgwDeleteProject.RunWorkerAsync();
		}

		private void endDeleteProject(object result) {
			if (result == null) { //No error while deleting
				//Update status
				beginUpdateState();
			}
			else {
				//enable Controls
				flpStatusControls.Enabled = true;
				aclState.State = actionLabelStates.Waiting;
				aclState.Text = string.Format(projectStateTemplate, Session.localizeMessage("Unknown"));

				showServerError( result as Exception );
			}
		}

		private void bgwDeleteProject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				Session.updateLogFactory.deleteProject(Session.currentProject.projectId);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwDeleteProject_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			endDeleteProject(e.Result);
		}

		private void btnRemoveProjekt_Click(object sender, EventArgs e) {
			if (Session.showMessage(ParentForm, Session.localizeMessage("confirmDeleteBody", this), Session.localizeMessage("confirmDeleteCaption", this), MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			beginDeleteProject();
		}

		#region Cleanup

		private void btnCleanup_Click(object sender, EventArgs e) {
			if (!beginCleanup())
				return;

			//disable UI
			grpState.Enabled = false;
			btnCleanup.Enabled = false;
			dtpCleanup.Enabled = false;

			//show Status
			aclCleanup.Show();
			aclCleanup.State = actionLabelStates.Progress;
			
			//Execute Request
			bgwCleanup.RunWorkerAsync(dtpCleanup.Value);

		}
		private bool beginCleanup() {
			return Session.showMessage(this, string.Format(Session.localizeMessage("confirmCleanupBody", this), dtpCleanup.Value.ToShortDateString()), Session.localizeMessage("confirmCleanupCaption", this), MessageBoxIcon.Exclamation,
				                    MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		private void bgwCleanup_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				e.Result = Session.updateLogFactory.cleanupLog(Session.currentProject.projectId, (DateTime) e.Argument);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}
		private void bgwCleanup_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			endCleanup(e.Result);
		}
		private void endCleanup(object result) {
			
			//Hide status
			aclCleanup.State = actionLabelStates.Waiting;
			aclCleanup.Hide();

			//enable UI
			grpState.Enabled = true;
			btnCleanup.Enabled = true;
			dtpCleanup.Enabled = true;

			if (result != null && result is cleanupLogResponse) {
				Session.showMessage(string.Format(Session.localizeMessage("cleanupSuccessfull", this), (result as cleanupLogResponse).removedEntries),
									MessageBoxIcon.Information, MessageBoxButtons.OK);
			}
			else {
				showServerError((Exception)result);
			}
		}

		#endregion
	}
}
