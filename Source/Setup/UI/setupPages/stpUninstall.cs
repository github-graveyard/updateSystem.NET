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
using System;
using System.ComponentModel;
using System.IO;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpUninstall : basePage, ISetupPage {
		public stpUninstall() {
			InitializeComponent();
			bgwUninstall.ProgressChanged += bgwUninstall_ProgressChanged;
			bgwUninstall.RunWorkerCompleted += bgwUninstall_RunWorkerCompleted;
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Die Deinstallation wird durchgeführt"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return null; }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		public override void onShow() {
			base.onShow();
			bgwUninstall.RunWorkerAsync(Context);
		}

		private void bgwUninstall_DoWork(object sender, DoWorkEventArgs e) {
			var context = (e.Argument as setupContext);
			try {
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;

				//Zu entfernende Dateien ermitteln
				string[] files = Directory.GetFiles(baseDir, "*", SearchOption.AllDirectories);
				int currentFile = 0;
				//Versuchen Dateien zu löschen
				foreach (string file in files) {
					try {
						//Versuchen das native Abbild der Datei zu entfernen
						if (file.EndsWith(".exe") || file.EndsWith(".dll"))
							nativeImages.Uninstall(file);

						File.Delete(file);
						currentFile++;
						bgwUninstall.ReportProgress(Percent(currentFile, files.Length));
					}
					catch {
					}
				}

				//Programm aus der Systemregistrierung entfernen
				ProgramsAndFeaturesHelper.Remove(context.Product);

				//Settings löschen
				if (context.removeSettings) {
					string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					                                   "updateSystem.NET");
					if (Directory.Exists(settingsPath)) {
						Directory.Delete(settingsPath, true);
					}
				}

				//Verknüpfungen entfernen
				string scDesktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				                                "updateSystem.NET Administration.lnk");
				string scStartMenu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
				                                  "updateSystem.NET Administration.lnk");

				if (File.Exists(scDesktop))
					File.Delete(scDesktop);

				if (File.Exists(scStartMenu))
					File.Delete(scStartMenu);

				//Dateitypeverknüpfungen entfernen (nur in Releaseversion)
				if (context.Product.GetType() == typeof (productRTM)) {
					if (FileAssociation.IsAssociated(".udprojx"))
						FileAssociation.DeleteAssociation(".udprojx");

					if (FileAssociation.IsAssociated(".udproj"))
						FileAssociation.DeleteAssociation(".udproj");

					FileAssociation.refreshDesktop();
				}
			}
			catch (Exception exc) {
				e.Result = exc;
			}
		}

		private int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}

		private void bgwUninstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Result == null) {
				onChangePage(new changePageEventArgs(typeof (stpUninstalled)));
			}
			else {
				Context.setupException = (e.Result as Exception);
				onChangePage(new changePageEventArgs(typeof (stpInterrupted)));
			}
		}

		private void bgwUninstall_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			prgCopyFiles.Value = e.ProgressPercentage;
		}
	}
}