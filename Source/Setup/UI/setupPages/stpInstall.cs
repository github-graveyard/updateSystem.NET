using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpInstall : basePage, ISetupPage {
		public stpInstall() {
			InitializeComponent();
			bgwCopy.ProgressChanged += bgwCopy_ProgressChanged;
			bgwCopy.RunWorkerCompleted += bgwCopy_RunWorkerCompleted;
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Die Installation wird durchgeführt"; }
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
			taskBarManager.Instance.setTaskBarProgressState(taskBarProgressState.Normal);
			bgwCopy.RunWorkerAsync(Context);
		}

		private void bgwCopy_DoWork(object sender, DoWorkEventArgs e) {
			try {
				//Dateien kopieren
				var package = new setupPackage(
					e.Argument as setupContext);
				package.fileProgressChanged += package_fileProgressChanged;
				package.copyFiles();
			}
			catch (Exception exc) {
				e.Result = exc;
			}
		}

		private void package_fileProgressChanged(object sender, ProgressChangedEventArgs e) {
			bgwCopy.ReportProgress(e.ProgressPercentage);
		}

		//Kopieren der Dateien beendet
		private void bgwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			taskBarManager.Instance.setTaskBarProgressState(taskBarProgressState.NoProgress);
			if (e.Result == null) {
				// mit Erfolg

				try {
					//Verknüpfungen erstellen
					string administrationPath = Path.Combine(Context.installationDirectory, Context.Product.mainExecutable);

					// Auf dem Desktop
					if (Context.createDesktopShortcut) {
						var shortcutDesktop =
							new ShellShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
							                               "updateSystem.NET Administration.lnk"))
							{IconIndex = 0, IconPath = administrationPath, Path = administrationPath};
						shortcutDesktop.Save();
					}

					//Im Startmenu
					if (Context.createStartMenuShortcut) {
						var shortcutStartMenu =
							new ShellShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
							                               "updateSystem.NET Administration.lnk"))
							{IconIndex = 0, IconPath = administrationPath, Path = administrationPath};
						shortcutStartMenu.Save();
					}

					//Uninstalldaten in die Registry schreiben
					if (IsUserAnAdmin()) {
						ProgramsAndFeaturesHelper.Add(Context);
					}

					//Installer zwecks deinstallation ins Programmverzeichnis kopieren
					File.Copy(Application.ExecutablePath, Path.Combine(Context.installationDirectory, Context.Product.setupName), true);

					//Nur in Releaseversion Dateitypen registrieren
					if (Context.Product.GetType() == typeof (productRTM)) {
						//Neuen UDPROJX-Type registrieren
						FileAssociation.Associate(
							".udprojx",
							Context.Product.applicationID,
							"updateSystem.NET Projektdatei",
							Path.Combine(Context.installationDirectory, "Project.ico"),
							administrationPath);

						//Alten UDPROJ-Type registrieren wenn dieser nicht bereits von der alten Installation registriert wurde
						if (!FileAssociation.IsAssociated(".udproj")) {
							FileAssociation.Associate(
								".udproj",
								Context.Product.applicationID,
								"Alte updateSystem.NET Projektdatei",
								Path.Combine(Context.installationDirectory, "Project.ico"),
								administrationPath);
						}

						//Shell aktualisieren
						FileAssociation.refreshDesktop();
					}

					//"Fertig"-Seite anzeigen
					onChangePage(new changePageEventArgs(typeof (stpInstalled)));
				}
				catch (Exception exc) {
					Context.setupException = exc;
					onChangePage(new changePageEventArgs(typeof (stpInterrupted)));
				}
			}
			else {
				// mit Exception
				Context.setupException = (e.Result as Exception);
				onChangePage(new changePageEventArgs(typeof (stpInterrupted)));
			}
		}

		private void bgwCopy_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			prgCopyFiles.Value = e.ProgressPercentage;
			taskBarManager.Instance.setTaskBarProgressValue((ulong) e.ProgressPercentage, 100);
		}
	}
}