using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet;
using updateSystemDotNet.appEventArgs;
using updateSystemDotNet.Core.Types;

namespace Beispielanwendung_CSharp {
	public sealed partial class mainForm : Form {
		public mainForm() {
			InitializeComponent();
			Font = SystemFonts.MessageBoxFont;

			//Assemblyversion ermitteln
			lblAssemblyVersion.Text = string.Format(lblAssemblyVersion.Text,
			                                        Assembly.GetExecutingAssembly().GetName().Version);
			lblReleaseInfo.Text = string.Format(lblReleaseInfo.Text, upctrlMain.releaseInfo.Type,
			                                    (upctrlMain.releaseInfo.Type != releaseTypes.Final
			                                     	? "(" + upctrlMain.releaseInfo.Step + ")"
			                                     	: ""));
			lblFilter.Text = string.Format(lblFilter.Text, string.Format("Final: {0}, Beta: {1}, Alpha: {2}",
			                                                             upctrlMain.releaseFilter.checkForFinal ? "Ja" : "Nein",
			                                                             upctrlMain.releaseFilter.checkForBeta ? "Ja" : "Nein",
			                                                             upctrlMain.releaseFilter.checkForAlpha ? "Ja" : "Nein"));


			//Dieses Event wird benötigt, um die Anwendung selbstständig schließen zu können.
			//Dies ist für den Updateprozess notwendig da die Anwendungsdateuen während der
			//Ausführung ja nicht überschrieben werden können.
			//Alternativ kann auch die Eigenschaft "autoCloseHostApplication" des updateControllers
			//auf true gesetzt werden. Dann wird die Anwendung automatisch geschlossen aber es gibt
			//keine Möglichkeit um z.B. Einstellungen zu speichern.
			upctrlMain.updateInstallerStarted += upctrlMain_updateInstallerStarted;
		}

		private void upctrlMain_updateInstallerStarted(object sender, updateInstallerStartedEventArgs e) {
			Close();
		}

		#region " updateInteractive						"

		private void btnRunUpdateInteractive_Click(object sender, EventArgs e) {
			upctrlMain.updateInteractive(this);
		}

		#endregion

		#region " Updatedialoge										"

		private void btnRunDialogs_Click(object sender, EventArgs e) {
			//Natürlich könnte man auch immer auf == DialogResult.OK prüfen, aber das würde
			//die Abfragen zu sehr verschachteln, letztendlich nur eine Geschmacksfrage :-)

			//Nach Updates suchen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann gibt es keine Updates
			if (upctrlMain.checkForUpdatesDialog(this) != DialogResult.OK)
				return;

			//Dem Benutzer die Updatenachricht anzeigen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann möchte
			//er die Updates nicht installieren.
			if (upctrlMain.showUpdateDialog(this) != DialogResult.OK)
				return;

			//Die Updates herunterladen. Wenn das zurückgegebene DialogResult nicht "OK" ist, dann wurde der Download abgebrochen (Fehler oder Benutzer).
			if (upctrlMain.downloadUpdatesDialog(this) != DialogResult.OK)
				return;

			//Wenn wir bis hier hin gekommen sind, kann das Update nun eingespielt werden. Diese Methode
			//startet den updateInstaller und feuert das im Konstruktor abonierte "updateInstallerStarted"-Event
			//damit wir wissen wann die Anwendung geschlossen werden soll.
			upctrlMain.applyUpdate();
		}

		#endregion

		#region " Asynchroner Updatespaß "

		private void btnRunAsync_Click(object sender, EventArgs e) {
			//Events einhängen
			upctrlMain.checkForUpdatesCompleted += upctrlMain_checkForUpdatesCompleted;
			upctrlMain.updateFound += upctrlMain_updateFound;

			//Updatesuche anstoßen
			upctrlMain.checkForUpdatesAsync();
		}

		//Dieses Event wird in jedem Falle nach Abschluß der Updatesuche gefeuert.
		//Also bei gefundenen Updates, keinen neuen Updates und auch im Fehlerfall.
		private void upctrlMain_checkForUpdatesCompleted(object sender, checkForUpdatesCompletedEventArgs e) {
			upctrlMain.checkForUpdatesCompleted -= upctrlMain_checkForUpdatesCompleted;

			//Überprüfen ob ein Fehler auftrat:
			if (e.Error != null) {
				//könnte man auch ne MessageBox anzeigen, aber das ist jedem selber überlassen.
				throw e.Error;
			}
		}

		//Dieses Event wird ausschließlich gefeuert, wenn bei der Updatesuche neue Aktualisierungen gefunden wurden.
		private void upctrlMain_updateFound(object sender, updateFoundEventArgs e) {
			upctrlMain.updateFound -= upctrlMain_updateFound;

			//Dem Benutzer anzeigen das es neue Updates gibt, dazu bauen wir uns erst den Changelog zusammen
			var sbChangelog = new StringBuilder();
			foreach (updatePackage package in e.Result.newUpdatePackages) {
				sbChangelog.AppendLine(string.Format("Änderungen in Version {0}:", package.releaseInfo.Version));
				sbChangelog.AppendLine(e.Result.Changelogs[package].germanChanges);
				sbChangelog.AppendLine();
			}

			//Neueste Version ermitteln
			string latestVersion = e.Result.newUpdatePackages[e.Result.newUpdatePackages.Count - 1].releaseInfo.Version;

			if (
				MessageBox.Show(
					string.Format(
						"Es ist für Ihre Anwendung eine neue Version verfügbar: {0}\r\nChangelog:\r\n{1}Möchten Sie das Update jetzt installieren?",
						latestVersion, sbChangelog), "Testanwendung", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
				DialogResult.Yes) {
				upctrlMain.downloadUpdatesCompleted += upctrlMain_downloadUpdatesCompleted;
				upctrlMain.downloadUpdatesProgressChanged += upctrlMain_downloadUpdatesProgressChanged;
				upctrlMain.downloadUpdates();
			}
		}

		//Event welches den Fortschritt des Downloads in % anzeigt.
		private void upctrlMain_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
			prgDownloadProgress.Value = e.ProgressPercentage;
		}

		//Event welches eintritt, wenn der Download fertig ist (tritt auch bei Fehlern ein!)
		private void upctrlMain_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			upctrlMain.downloadUpdatesCompleted -= upctrlMain_downloadUpdatesCompleted;
			upctrlMain.downloadUpdatesProgressChanged -= upctrlMain_downloadUpdatesProgressChanged;

			//Überprüfen ob das Update durch einen Fehler oder den Benutzer abgebrochen wurde
			if (e.Error != null)
				throw e.Error;

			//Download war erfolgreich, dann den Updateprozess starten
			upctrlMain.applyUpdate();
		}

		#endregion

		#region " Custom Downloaddialog	 "

		private void btnRunCustomDownloadDialog_Click(object sender, EventArgs e) {
			//Hier ähnelt alles stark dem Updaten mit dem manuellen Aufrufen der Updatedialoge,
			//bis auf eine zusätzliche Überladung der downloadUpdatesDialog-Methode

			//Natürlich könnte man auch immer auf == DialogResult.OK prüfen, aber das würde
			//die Abfragen zu sehr verschachteln, letztendlich nur eine Geschmacksfrage :-)

			//Nach Updates suchen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann gibt es keine Updates
			if (upctrlMain.checkForUpdatesDialog(this) != DialogResult.OK)
				return;

			//Dem Benutzer die Updatenachricht anzeigen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann möchte
			//er die Updates nicht installieren.
			if (upctrlMain.showUpdateDialog(this) != DialogResult.OK)
				return;

			//Die Updates herunterladen. Wenn das zurückgegebene DialogResult nicht "OK" ist, dann wurde der Download abgebrochen (Fehler oder Benutzer).
			if (upctrlMain.downloadUpdatesDialog(this, new customDownloadDialog()) != DialogResult.OK)
				return;

			//Wenn wir bis hier hin gekommen sind, kann das Update nun eingespielt werden. Diese Methode
			//startet den updateInstaller und feuert das im Konstruktor abonierte "updateInstallerStarted"-Event
			//damit wir wissen wann die Anwendung geschlossen werden soll.
			upctrlMain.applyUpdate();
		}

		#endregion
	}
}