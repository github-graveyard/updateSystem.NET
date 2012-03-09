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

		private const string projectStateTemplate = "Projektstatus: {0}";
		private const string unknownProjectState = "Der Status für dieses Projekt wurde noch nicht ermittelt. Klicken Sie auf 'Status aktualisieren' um den Projektstatus zu erneuern.";

		public statisticSettingsSubPage() {
			InitializeComponent();
			aclState.Text = string.Format(projectStateTemplate, "Unbekannt");
			lblStateDescription.Text = unknownProjectState;
			pageSymbol = resourceHelper.getImage("projectEdit.png");
			Id = "7cd67d4c-667c-457f-8089-51464c5bea56";
			dtpCleanup.Value = DateTime.Now.AddMonths(-3);
			dtpCleanup.MaxDate = DateTime.Now;
		}

		private void btnUpdateState_Click(object sender, EventArgs e) {
			beginUpdateState();
		}

		/// <summary>Beginnt mit der Aktualisierung des Projektstatusses.</summary>
		private void beginUpdateState() {
			
			//Controls anpassen
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, "Wird aktualisiert...");

			//Serveranfrage starten
			bgwUpdateState.RunWorkerAsync();

		}

		/// <summary>Setzt den Projektstatus anhand des Resultobjektes das vom Backgroundworker übergeben wurde.</summary>
		private void endUpdateState(object result) {
			
			//Statuscontrols anpassen
			aclState.State = actionLabelStates.Waiting;
			flpStatusControls.Enabled = true;

			//Überprüfen ob die Anfrage erfolgreich war
			string stateText = string.Format(projectStateTemplate, "Unbekannt");
			string stateDescription = unknownProjectState;
			if(result is updateLogProject || result == null) {

				//Controls zurücksetzen
				btnAddProject.Hide();
				btnRemoveProjekt.Hide();
				grpMaintenance.Enabled = false;

				var project = result as updateLogProject;
				if(project != null) { //Das Projekt ist bereits auf dem Server vorhanden
					
					//Button zum löschen anzeigen
					btnRemoveProjekt.Show();

					//Wartungsaufgaben anzeigen
					grpMaintenance.Enabled = true;

					stateText = string.Format(projectStateTemplate, "Vorhanden");
					Session.currentProject.updateLogEnabled = true;
					stateDescription = "Dieses Projekt ist auf dem Server vorhanden und es werden Statistikdaten erfasst. Um alle gesammelten Daten sowie das Projekt als solches zu löschen, klicken Sie auf 'Projekt entfernen'.";
					aclState.State = actionLabelStates.Success;
				}
				else { //Das Projekt ist noch nicht auf dem Server vorhanden
					btnAddProject.Show();
					Session.currentProject.updateLogEnabled = false;
					stateText = string.Format(projectStateTemplate, "Nicht vorhanden");
					stateDescription = "Dieses Projekt ist noch nicht auf dem Server vorhanden. Klicken Sie auf 'Projekt hinzufügen' um für dieses Projekt Statistikdaten erfassen zu können.";
				}
			}
			else { //Fehler
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
			//Control anpassen
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, "Wird hinzugefügt...");

			//Server anfrage abschicken
			bgwAddProject.RunWorkerAsync();
		}

		private void endAddProject(object result) {
			
			if(result == null) { //Kein Fehler beim hinzufügen
				//Status aktualisieren
				beginUpdateState();
			}
			else {
				//Controls wieder freischalten
				flpStatusControls.Enabled = true;
				aclState.State = actionLabelStates.Waiting;
				aclState.Text = string.Format(projectStateTemplate, "Unbekannt");

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
		
			//Controls anpassen
			flpStatusControls.Enabled = false;
			aclState.State = actionLabelStates.Progress;
			aclState.Text = string.Format(projectStateTemplate, "Wird entfernt...");

			//Serveranfrage abschicken
			bgwDeleteProject.RunWorkerAsync();

		}

		private void endDeleteProject(object result) {
			if (result == null) { //Kein Fehler beim hinzufügen
				//Status aktualisieren
				beginUpdateState();
			}
			else {
				//Controls wieder freischalten
				flpStatusControls.Enabled = true;
				aclState.State = actionLabelStates.Waiting;
				aclState.Text = string.Format(projectStateTemplate, "Unbekannt");

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
			if (Session.showMessage(ParentForm, "Sind Sie sicher, dass Sie das Projekt wirklich löschen möchten?", "Löschvorgang bestätigen", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			beginDeleteProject();
		}

		#region Cleanup

		private void btnCleanup_Click(object sender, EventArgs e) {
			beginCleanup();

			//UI deaktivieren
			grpState.Enabled = false;
			btnCleanup.Enabled = false;
			dtpCleanup.Enabled = false;

			//Status anzeigen
			aclCleanup.Show();
			aclCleanup.State = actionLabelStates.Progress;
			
			//Backgroundworker starten
			bgwCleanup.RunWorkerAsync(dtpCleanup.Value);

		}
		private void beginCleanup() {
			if (Session.showMessage(this, string.Format("Möchten Sie wirklich alle Logeinträge löschen, die vor dem {0} angelegt wurden?", dtpCleanup.Value.ToShortDateString()), "Löschen bestätigen", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
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
			
			//Status verbergen
			aclCleanup.State = actionLabelStates.Waiting;
			aclCleanup.Hide();

			//UI wieder aktivieren
			grpState.Enabled = true;
			btnCleanup.Enabled = true;
			dtpCleanup.Enabled = true;

			if (result != null && result is cleanupLogResponse) {
				Session.showMessage(string.Format("Der Befehl wurde erfolgreich ausgeführt. Es wurden {0} Einträge vom Server gelöscht.", (result as cleanupLogResponse).removedEntries),
									MessageBoxIcon.Information, MessageBoxButtons.OK);
			}
			else {
				showServerError((Exception)result);
			}
		}

		#endregion
	}
}
