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
using updateSystemDotNet.Administration.Core;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.updateLog;
using System.Drawing;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal partial class statisticPage : basePage {

		private DateTime _dateFrom;
		private DateTime _dateTo;
		private List<updateLogEntry> _cachedResult;
		private int _osMajor;
		private int _osMinor;
		private int _selectedOSIndex;

		public statisticPage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = resourceHelper.getImage("statistics.png");
			displayOrder = 600;

			_dateFrom = DateTime.Now.Date.AddDays(-14);
			_dateTo = DateTime.Now.Date.AddDays(1);
			_osMajor = -1;
			_osMinor = -1;
			_selectedOSIndex = 0;

			uscMain.Color1 = Color.LightBlue;
			uscMain.Color2 = Color.LightSalmon;

		}

		public override void initializeData() {
			flpControl.Enabled = (Session.currentProject.updateLogUser.Verified);
		}

		public override void initializeSubPages() {
			subPages.Clear();
			Node.Nodes.Clear();

			if (Session.currentProject.updateLogUser.Verified) {
				// Einstellungen
				var settingsSubPage = createSubPage<statisticSubPages.statisticSettingsSubPage>(null);
				var projectsSubPage = createSubPage<statisticSubPages.statisticProjectsSubPage>(null);
				var usersSubPage = createSubPage<statisticSubPages.statisticUsersSubPage>(null);

				subPages.AddRange(new baseSubPage[] {settingsSubPage, projectsSubPage, usersSubPage});
				Node.Nodes.AddRange(new[] {settingsSubPage.Node, projectsSubPage.Node, usersSubPage.Node});
			}
		}

		void Session_popupClosed(Popups.popupBase sender, Popups.popupClosedEventArgs e) {
			//Event deregistrieren
			Session.popupClosed -= Session_popupClosed;
					   
			//Veränderte Daten setzen
			_dateFrom = (DateTime) e.Result[Popups.statisticFilterPopup.DCKEY_DATE_FROM];
			_dateTo = (DateTime) e.Result[Popups.statisticFilterPopup.DCKEY_DATE_TO];
			_osMajor = (int) e.Result[Popups.statisticFilterPopup.DCKEY_OS_MAJOR];
			_osMinor = (int) e.Result[Popups.statisticFilterPopup.DCKEY_OS_MINOR];
			_selectedOSIndex = (int) e.Result[Popups.statisticFilterPopup.DCKEY_SELECTED_OS_INDEX];

		}

		private void bgwGetLog_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				//Serverrequest abschicken
				e.Result = Session.updateLogFactory.getLog(
					_dateFrom,
					_dateTo,
					_osMajor,
					_osMinor,
					Session.currentProject.projectId,
					string.Empty,
					string.Empty);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void processData() {
			
			var requests = new Dictionary<DateTime, int>();
			var downloads = new Dictionary<DateTime, int>();

			//Zeitspanne ermitteln
			TimeSpan timespan = _dateTo.Subtract(_dateFrom);

			//Dummydaten eintragen
			for (int i = 0; i < timespan.Days+1; i++) {
				DateTime currentDate = _dateFrom.AddDays(i);
				requests.Add(currentDate, 0);
				downloads.Add(currentDate, 0);
			}

			//Echte Daten eintragen
			foreach (var entry in _cachedResult) {
				if (entry.requestType == 0)
					requests[entry.timeStamp.Date]++;
				else
					downloads[entry.timeStamp.Date]++;
			}

			//Diagramm aktualisieren
			uscMain.BeginUpdate();
			uscMain.Data1 = requests;
			uscMain.Data2 = downloads;
			uscMain.EndUpdate();

		}

		private void bgwGetLog_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			flpControl.Enabled = true;
			if (e.Result is List<updateLogEntry>) {
				_cachedResult = e.Result as List<updateLogEntry>;
				processData();
			}
			else
				Session.showMessage(
					this,
					((Exception) e.Result).Message,
					"Während der Serveranfrage ist ein Problem aufgetreten!",
					MessageBoxIcon.Error,
					MessageBoxButtons.OK
					);
		}

		private void fbtnRefresh_Click(object sender, EventArgs e) {
			bgwGetLog.RunWorkerAsync();
			flpControl.Enabled = false;
		}

		private void fBtnShowFilter_Click(object sender, EventArgs e) {
			var args = new dataContainer();
			args[Popups.statisticFilterPopup.DCKEY_DATE_FROM] = _dateFrom;
			args[Popups.statisticFilterPopup.DCKEY_DATE_TO] = _dateTo;
			args[Popups.statisticFilterPopup.DCKEY_SELECTED_OS_INDEX] = _selectedOSIndex;

			Session.showPopup<Popups.statisticFilterPopup>(sender as Control, args);
			Session.popupClosed += Session_popupClosed;
		}

	}
}
