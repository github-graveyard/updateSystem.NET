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
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Internal;
using updateSystemDotNet.Internal.Designer;
using updateSystemDotNet.Internal.UI;
using updateSystemDotNet.Internal.updateUI;
using updateSystemDotNet.Internal.updateUI.Views;
using updateSystemDotNet.appEventArgs;
using updateSystemDotNet.appExceptions;

namespace updateSystemDotNet {
	/// <summary>
	/// Updatekomponente zum herunterladen und installieren von Programmaktualisierungen.
	/// </summary>
	[Designer(typeof (ControllerDesigner), typeof (IDesigner))]
	[ToolboxBitmap(typeof (updateController), "updateController.png")]
	[DefaultEvent("checkForUpdatesCompleted")]
	public sealed class updateController : Component, ICloneable {
		#region " Events "

		/// <summary>
		/// <para>Tritt ein, wenn die Updatesuche abgeschlossen wurde.</para>
		/// </summary>
		public event checkForUpdatesCompletedEventHandler checkForUpdatesCompleted;

		/// <summary>
		/// <para>Tritt ein, wenn der Updatedownload abgeschlossen wurde.</para>
		/// </summary>
		public event downloadUpdatesCompletedEventHandler downloadUpdatesCompleted;

		/// <summary>
		/// Tritt ein, wenn sich der Fortschritt des Updatedownloads ändert.
		/// </summary>
		public event downloadUpdatesProgressChangedEventHandler downloadUpdatesProgressChanged;

		/// <summary>
		/// <para>Tritt ein, wenn über die <see cref="checkForUpdatesAsync"/>-Methode ein oder mehrere Aktualisierungen gefunden wurden.</para>
		/// </summary>
		public event updateFoundEventHandler updateFound;

		/// <summary>
		/// Tritt ein, wenn der updateInstaller gestartet wurde.
		/// </summary>
		public event updateInstallerStartedEventHandler updateInstallerStarted;

		/// <summary>
		/// Tritt ein, wenn während der Updatesuche ein neues Updatepaket gefunden wurde, welches neuer als die lokale Version ist.
		/// <para>Durch das Abonieren dieses Events kann mit der Rückgabe von True bzw. False im EventHandler dieses Paket bestätigt respekive abgelehnt werden.</para>
		/// </summary>
		public event confirmUpdatePackageEventHandler confirmUpdatePackage;

		#endregion

		#region " Private Variablen "

		private readonly UpdateSettings _updateSettings = new UpdateSettings();

		#endregion

		#region " Konstruktor "

		/// <summary>
		/// Initialisiert eine neue Instanz des <see cref="updateController"/>.
		/// </summary>
		public updateController()
			: this(string.Empty, string.Empty, string.Empty) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz des <see cref="updateController"/>.
		/// </summary>
		/// <param name="updateLocation">Die Internetadresse der Updatekonfiguration.</param>
		public updateController(string updateLocation)
			: this(updateLocation, string.Empty, string.Empty) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz des <see cref="updateController"/>.
		/// </summary>
		/// <param name="updateLocation">Die Internetadresse der Updatekonfiguration.</param>
		/// <param name="currentVersion">Die aktuell Installierte Version der Anwendung (String.Empty wenn diese automatisch ermittelt werden soll).</param>
		public updateController(string updateLocation, string currentVersion)
			: this(updateLocation, currentVersion, string.Empty) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz des <see cref="updateController"/>.
		/// </summary>
		/// <param name="updateLocation">Die Internetadresse der Updatekonfiguration.</param>
		/// <param name="currentVersion">Die aktuell Installierte Version der Anwendung (String.Empty wenn diese automatisch ermittelt werden soll)</param>
		/// <param name="sPublicKey">Der öffentliche Schlüssel welcher zum Überprüfen der Updatepakete und der Updatekonfiguration verwendet werden soll.</param>
		public updateController(string updateLocation, string currentVersion, string sPublicKey) {
			//Standardwerte setzen
			releaseInfo = new releaseInfo();
			releaseFilter = new releaseFilterType();
			requestElevation = true;
			showTaskBarProgress = true;
			projectId = Guid.Empty.ToString();
			proxyPort = 8080;

			this.updateLocation = updateLocation;
			releaseInfo.Version = currentVersion;
			publicKey = sPublicKey;
		}

		#endregion

		#region " CheckForUpdates "

		#region " CheckForUpdates (NoGUI, Synchron) "

		/// <summary>
		/// <para>Sucht nach verfügbaren Aktualisierungen.</para>
		/// <para>Informationen über die Updates können über die Eigenschaft <see cref="currentUpdateResult"/> abgerufen werden.</para>
		/// </summary>
		/// <returns>Gibt true zurück wenn ein Update gefunden wurde, andernfalls false.</returns>
		public bool checkForUpdates() {
			var schedueller = new ScheduledStart(
				_updateSettings.ProjektID,
				_updateSettings.Updateinterval,
				_updateSettings.CustomUpdateInterval);

			if (!schedueller.CanCheck()) {
				return false;
			}

			//Updatesuche vorbereiten
			prepareUpdateCheck();

			//Suchprovider initialisieren
			var sProvider = new searchProvider(this);

			//Updatesuche durchführen
			sProvider.executeSearch();
			schedueller.WriteCurrentDate();


			//Ergebnis auswerten
			if (sProvider.foundUpdates.Count > 0) {
				currentUpdateResult = new UpdateResult(
					sProvider.foundUpdates,
					sProvider.currentConfiguration,
					sProvider.correspondingChangelogs);
				return true;
			}
			currentUpdateResult = new UpdateResult(new List<updatePackage>(), sProvider.currentConfiguration,
			                                       new changelogDictionary());

			return false;
		}

		#endregion

		#region " CheckForUpdates (NoGUI, Asynchron) "

		private BackgroundWorker _updateSearchWorker;

		/// <summary>
		/// <para>Sucht nach verfügbaren Aktualisierungen.</para>
		/// <para>Informationen über die Updates können über die Eigenschaft <see cref="currentUpdateResult"/> abgerufen werden.</para>
		/// <para>Diese Methode blockiert nicht den aufrufenden Thread.</para>
		/// </summary>
		public void checkForUpdatesAsync() {
			//Updatesuche vorbereiten
			prepareUpdateCheck();

			//Überprüfe ob bereits eine Updatesuche läuft
			if (_updateSearchWorker != null) {
				if (_updateSearchWorker.IsBusy) {
					throw new InvalidOperationException("Es wird bereits eine Updatesuche ausgeführt.");
				}
			}

			//Backgroundworker initialisieren
			_updateSearchWorker = new BackgroundWorker();
			_updateSearchWorker.RunWorkerCompleted += _updateSearchWorker_RunWorkerCompleted;
			_updateSearchWorker.DoWork += _updateSearchWorker_DoWork;

			//Asynchrone Updatesuche starten
			_updateSearchWorker.RunWorkerAsync();
		}

		private void _updateSearchWorker_DoWork(object sender, DoWorkEventArgs e) {
			try {
				var schedueller = new ScheduledStart(
					_updateSettings.ProjektID,
					_updateSettings.Updateinterval,
					_updateSettings.CustomUpdateInterval);
				if (!schedueller.CanCheck()) {
					e.Result = new UpdateResult(
						new List<updatePackage>(),
						new updateConfiguration(),
						new changelogDictionary());

					return;
				}

				//Searchprovider initialisieren
				var sProvider = new searchProvider(this);

				//Updatesuche durchführen
				sProvider.executeSearch();
				schedueller.WriteCurrentDate();

				//Result zurückgeben
				e.Result = new UpdateResult(
					sProvider.foundUpdates,
					sProvider.currentConfiguration,
					sProvider.correspondingChangelogs);
			}
			catch (Exception ex) {
				e.Result = ex;
			}
		}

		private void _updateSearchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			//Events deregistrieren
			_updateSearchWorker.DoWork -= _updateSearchWorker_DoWork;
			_updateSearchWorker.RunWorkerCompleted -= _updateSearchWorker_RunWorkerCompleted;

			if (e.Result is UpdateResult) //Updatesuche wurde erfolgreich ausgeführt
			{
				currentUpdateResult = (e.Result as UpdateResult);
				if (checkForUpdatesCompleted != null) {
					checkForUpdatesCompleted(this,
					                         new checkForUpdatesCompletedEventArgs(null, false, currentUpdateResult.UpdatesAvailable));
				}
				if (currentUpdateResult.UpdatesAvailable) {
					if (updateFound != null) {
						updateFound(this, new updateFoundEventArgs(currentUpdateResult));
					}
				}
			}
			else //Es ist ein Fehler aufgetreten
			{
				if (checkForUpdatesCompleted != null) {
					checkForUpdatesCompleted(this,
					                         new checkForUpdatesCompletedEventArgs((e.Result as Exception), e.Cancelled, false));
				}
			}
		}

		#endregion

		#region " CheckForUpdates (GUI, Asynchron) "

		/// <summary>
		/// Sucht nach Aktualisierungen während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <returns><see cref="DialogResult.OK"/> wenn Aktualisierungen gefunden wurden, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		public DialogResult checkForUpdatesDialog() {
			return checkForUpdatesDialog(null);
		}

		/// <summary>
		/// Sucht nach Aktualisierungen während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <returns><see cref="DialogResult.OK"/> wenn Aktualisierungen gefunden wurden, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		public DialogResult checkForUpdatesDialog(IWin32Window owner) {
			prepareUpdateCheck();

			/*using (var dialog = new updateViewDialog(this)) {
				dialog.ShowInTaskbar = showDialogsInTaskbar;
				dialog.availableViewStates = updateViewStates.Search;
				dialog.loadView<viewUpdateCheck>();
				return dialog.ShowDialog(owner);
			}*/

			// Old 1.5 Stuff - Obsolete
			using (var searchDlg = new updateSearchDialog(this)) {
				searchDlg.ShowInTaskbar = showDialogsInTaskbar;
				//Dialog anzeigen
				DialogResult cachedResult = searchDlg.ShowDialog(owner);

				currentUpdateResult = new UpdateResult(
					searchDlg.Result,
					searchDlg.Config,
					searchDlg.Changelogs);

				if (currentUpdateResult.UpdatesAvailable && alwaysRaiseUpdateFoundEvent) {
					if (updateFound != null)
						updateFound(this, new updateFoundEventArgs(currentUpdateResult));
				}

				return cachedResult;
			}
		}

		#endregion

		#endregion

		#region " showUpdateDialog "

		/// <summary>
		/// Zeigt Informationen über die gefunden Updates in einem modalen Dialog an.
		/// </summary>
		/// <returns><see cref="DialogResult.OK"/>wenn der Benutzer auf 'Update installieren' geklickt hat, andernfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult showUpdateDialog() {
			return showUpdateDialog(null);
		}

		/// <summary>
		/// Zeigt Informationen über die gefunden Updates in einem modalen Dialog an.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <returns><see cref="DialogResult.OK"/>wenn der Benutzer auf 'Update installieren' geklickt hat, andernfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult showUpdateDialog(IWin32Window owner) {
			prepareShowUpdateDialog();

			/*using(var dialog = new updateViewDialog(this)) {
				dialog.ShowInTaskbar = showDialogsInTaskbar;
				dialog.availableViewStates = updateViewStates.Display;
				dialog.loadView<viewUpdatesAvailable>();
				return dialog.ShowDialog(owner);
			}*/

			//Old 1.5 Stuff
			using (var updateDialog = new updatePreviewDialog(
				_updateSettings,
				currentUpdateResult.newUpdatePackages,
				currentUpdateResult.Configuration,
				currentUpdateResult.Changelogs,
				requestElevation)) {
				updateDialog.ShowInTaskbar = showDialogsInTaskbar;
				return updateDialog.ShowDialog(owner);
			}
		}

		#endregion

		#region " DownloadUpdates "

		#region " DownloadUpdates (NoGUI, Asynchron) "

		private updateDownloader _updateDownloader;

		/// <summary>
		/// <para>Lädt die gefundenen Aktualisierungen asychron herunter.</para>
		/// <para>Diese Methode blockiert nicht den aufrufenden Thread.</para>
		/// </summary>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn der Updatedownload bereits läuft.</exception>
		public void downloadUpdates() {
			//Updatedownload vorbereiten
			prepareUpdateDownload();

			//Überprüfe ob der bereits läuft
			if (_updateDownloader != null) {
				if (_updateDownloader.isBusy) {
					throw new InvalidOperationException("Es läuft bereits ein Updatedownload.");
				}
			}

			_updateDownloader = new updateDownloader(this, currentUpdateResult);
			_updateDownloader.downloadUpdatesProgressChanged += _updateDownloader_downloadUpdatesProgressChanged;
			_updateDownloader.downloadUpdatesCompleted += _updateDownloader_downloadUpdatesCompleted;

			_updateDownloader.startDownload();
		}

		/// <summary>
		/// Bricht den Updatedownload ab.
		/// </summary>
		/// <exception cref="InvalidOperationException">
		/// <para>Tritt ein, wenn bereits ein anderer Updatedownload läuft.</para>
		/// <para>Kann mit <see cref="isUpdateDownloaderBusy"/> vorhher überprüft und damit abgefangen werden.</para>
		/// </exception>
		public void cancelUpdateDownload() {
			if (_updateDownloader != null && _updateDownloader.isBusy) {
				_updateDownloader.cancelDownload();
			}
			else {
				throw new InvalidOperationException("Es läuft bereits ein Updatedownload.");
			}
		}

		/// <summary>
		/// Gibt true zurück wenn bereits ein Updatedownload läuft, andernfalls false.
		/// </summary>
		[Browsable(false)]
		public bool isUpdateDownloaderBusy {
			get {
				if (_updateDownloader == null) {
					return false;
				}
				return _updateDownloader.isBusy;
			}
		}

		private void _updateDownloader_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			if (downloadUpdatesCompleted != null) {
				downloadUpdatesCompleted(this, e);
			}
		}

		private void _updateDownloader_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
			if (downloadUpdatesProgressChanged != null) {
				downloadUpdatesProgressChanged(this, e);
			}
		}

		#endregion

		#region " DownloadUpdates (GUI, Asynchron) "

		/// <summary>
		/// Lädt die gefunden Aktualisierungen herunter während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <returns><see cref="DialogResult.OK"/>wenn der Download erfolgreich abgeschlossen wurde, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult downloadUpdatesDialog() {
			return downloadUpdatesDialog(null, null);
		}

		/// <summary>
		/// Lädt die gefunden Aktualisierungen herunter während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <returns><see cref="DialogResult.OK"/>wenn der Download erfolgreich abgeschlossen wurde, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult downloadUpdatesDialog(IWin32Window owner) {
			return downloadUpdatesDialog(owner, null);
		}

		/// <summary>
		/// Lädt die gefunden Aktualisierungen herunter während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <param name="downloadDialog">Ein beliebiges Objekt, das <see cref="updateDownloadBaseForm"/> implementiert und den Fortschritt des Downloads dem Benutzer anzeigt.</param>
		/// <returns><see cref="DialogResult.OK"/>wenn der Download erfolgreich abgeschlossen wurde, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult downloadUpdatesDialog(updateDownloadBaseForm downloadDialog) {
			return downloadUpdatesDialog(null, downloadDialog);
		}

		/// <summary>
		/// Lädt die gefunden Aktualisierungen herunter während dem Benutzer ein modaler Dialog angezeigt wird.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <param name="downloadDialog">Ein beliebiges Objekt, das <see cref="updateDownloadBaseForm"/> implementiert und den Fortschritt des Downloads dem Benutzer anzeigt.</param>
		/// <returns><see cref="DialogResult.OK"/>wenn der Download erfolgreich abgeschlossen wurde, anderfalls <see cref="DialogResult.Cancel"/>.</returns>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		public DialogResult downloadUpdatesDialog(IWin32Window owner, updateDownloadBaseForm downloadDialog) {
			prepareUpdateDownload();

			//Überprüfe ob ein eigener Downloaddialog verwendet werden soll. Ansonsten neuen Dialog instanzieren.
			if (downloadDialog == null) {
				downloadDialog = new updateDownloadDialog();
			}

			//Fenstertitel setzen
			downloadDialog.Text = currentUpdateResult.Configuration.applicationName;

			//Downloaddialog initialisieren
			downloadDialog.initializeForm(this, currentUpdateResult);

			downloadDialog.ShowInTaskbar = showDialogsInTaskbar;

			//Downloaddialog anzeigen
			DialogResult cachedDialogResult = downloadDialog.ShowDialog(owner);
			return cachedDialogResult == DialogResult.OK && downloadDialog.downloadCompleted
			       	? DialogResult.OK
			       	: DialogResult.Cancel;
		}

		#endregion

		#endregion

		#region " StartUpdate "

		[DllImport("shell32.dll")]
		private static extern bool IsUserAnAdmin();

		/// <summary>
		/// Startet die Aktualisierung.
		/// </summary>
		/// <exception cref="appExceptions.invalidSignatureException">Tritt ein, wenn der Updatedownload fehlerhaft war.</exception>
		/// <exception cref="InvalidOperationException">Tritt ein, wenn keine Updates verfügbar sind oder das <see cref="currentUpdateResult"/> null ist.</exception>
		/// <exception cref="DirectoryNotFoundException">Tritt ein, wenn das Downloadverzeichnis nicht gefunden werden konnte.</exception>
		/// <exception cref="FileNotFoundException">Tritt ein, wenn der updateInstaller oder ein Updatepaket nicht gefunden wurde.</exception>
		public void applyUpdate() {
			/*
			 * Nicht damit ich den Fehler nochmal mache:
			 * Ich rufe die prepareUpdate-Methode bereits im new ProcessStartInfo auf !!!(!)
			 */

			var psiUpdateInstaller = new ProcessStartInfo(prepareUpdate());

			if (!IsUserAnAdmin() && requestElevation && Environment.OSVersion.Version.Major >= 5) {
				psiUpdateInstaller.Verb = "runas";
			}

			var processUpdateInstaller = new Process {StartInfo = psiUpdateInstaller};

			try {
				if (processUpdateInstaller.Start()) {
					if (autoCloseHostApplication) {
						Process.GetCurrentProcess().Kill();
					}
					else {
						if (updateInstallerStarted != null)
							updateInstallerStarted(this,
							                       new updateInstallerStartedEventArgs(
							                       	processUpdateInstaller.Handle));
					}
				}
			}
			catch (Win32Exception) {
				//UAC-Dialog abgebrochen, nicht behandeln, der Benutzer weiß schon was er tut.
			}
		}

		#endregion

		#region " UpdateInteractive "

		/// <summary>
		/// Benutzt die Built-In Dialoge um den Benutzer durch den kompletten Updateprozess zu führen.
		/// </summary>
		public void updateInteractive() {
			updateInteractive(null, null);
		}

		/// <summary>
		/// Benutzt die Built-In Dialoge um den Benutzer durch den kompletten Updateprozess zu führen.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		public void updateInteractive(IWin32Window owner) {
			updateInteractive(owner, null);
		}

		/// <summary>
		/// Benutzt die Built-In Dialoge um den Benutzer durch den kompletten Updateprozess zu führen.
		/// </summary>
		/// <param name="downloadDialog">Ein beliebiges Objekt, das <see cref="updateDownloadBaseForm"/> implementiert und den Fortschritt des Downloads dem Benutzer anzeigt.</param>
		public void updateInteractive(updateDownloadBaseForm downloadDialog) {
			updateInteractive(null, downloadDialog);
		}

		/// <summary>
		/// Benutzt die Built-In Dialoge um den Benutzer durch den kompletten Updateprozess zu führen.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <param name="downloadDialog">Ein beliebiges Objekt, das <see cref="updateDownloadBaseForm"/> implementiert und den Fortschritt des Downloads dem Benutzer anzeigt.</param>
		public void updateInteractive(IWin32Window owner, updateDownloadBaseForm downloadDialog) {
			//Nach Updates suchen
			if (checkForUpdatesDialog(owner) != DialogResult.OK) {
				return;
			}

			if (currentUpdateResult.UpdatesAvailable && alwaysRaiseUpdateFoundEvent) {
				if (updateFound != null)
					updateFound(this, new updateFoundEventArgs(currentUpdateResult));
			}

			//Updatedialog anzeigen
			if (showUpdateDialog(owner) != DialogResult.OK) {
				return;
			}

			//Updates herunterladen
			if (downloadUpdatesDialog(owner, downloadDialog) != DialogResult.OK) {
				return;
			}

			//Updates anwenden
			applyUpdate();
		}

		#endregion

		#region " Properties "

		#region " Konstanten für das PropertyGrid "

		private const string _pgrdDefault = "Allgemein";
		private const string _pgrdAuthentification = "Authentifikation";
		private const string _pgrdProxy = "Proxy";
		private const string _pgrdInterval = "Updateintervall";

		#endregion

		/// <summary>
		/// Gibt den öffentlichen Schlüssel für die Signaturüberprüfung der Updatedaten zurück oder legt diesen fest.
		/// </summary>
		[Category(_pgrdDefault), Description("Der öffentliche Schlüssel für die Signaturüberprüfung der Updatedaten."),
		 DefaultValue(""), Editor(typeof (largeTextEditor), typeof (UITypeEditor))]
		public string publicKey {
			get { return _updateSettings.PublicKey; }
			set { _updateSettings.PublicKey = value; }
		}

		/// <summary>
		/// Gibt die Projekt-Id zurück oder legt diese fest.
		/// </summary>
		[Category(_pgrdDefault), Description("Die Projekt-Id für die Statistikdaten und den Updateinterval."),
		 DefaultValue("00000000-0000-0000-0000-00000000000")]
		public string projectId {
			get { return _updateSettings.ProjektID; }
			set { _updateSettings.ProjektID = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob die Anwendung nach dem Update automatisch gestartet werden soll.
		/// </summary>
		[Category(_pgrdDefault), Description("Startet die Anwendung nach dem Update automatisch neu."), DefaultValue(false)]
		public bool restartApplication {
			get { return _updateSettings.restartApplication; }
			set { _updateSettings.restartApplication = value; }
		}

		/// <summary>
		/// Gibt die Sprache der Updatedialoge zurück oder legt diese fest.
		/// </summary>
		[Category(_pgrdDefault), Description("Legt die Sprache der Updatedialoge fest."), DefaultValue(Languages.Deutsch)]
		public Languages Language {
			get { return _updateSettings.Language; }
			set { _updateSettings.Language = value; }
		}

		/// <summary>
		/// <para>Gibt die Adresse der Updatekonfiguration zurück oder legt diese fest. Dies kann entweder eine Url oder ein UNC Pfad sein.</para>
		/// <para>Zum Beispiel: http://meinServer.de/meinProdukt/updates/ oder C:\Anwendung\ oder \\meineFreigabe\123\MeinProgramm</para>
		/// </summary>
		[Category(_pgrdDefault), Description("Die Adresse der Updatekonfiguration."), DefaultValue(""),
		 Editor(typeof (updateLocationEditor), typeof (UITypeEditor))]
		[Obsolete("Eigenschaft ist veraltet. Bitte updateLocation verwenden.")]
		[Browsable(false)]
		public string updateUrl {
			get { return _updateSettings.Update_URL; }
			set { _updateSettings.Update_URL = value; }
		}

		/// <summary>
		/// <para>Gibt die Adresse der Updatekonfiguration zurück oder legt diese fest. Dies kann entweder eine Url oder ein UNC Pfad sein.</para>
		/// <para>Zum Beispiel: http://meinServer.de/meinProdukt/updates/ oder C:\Anwendung\ oder \\meineFreigabe\123\MeinProgramm</para>
		/// </summary>
		[Category(_pgrdDefault), Description("Die Adresse der Updatekonfiguration."), DefaultValue(""),
		 Editor(typeof(updateLocationEditor), typeof(UITypeEditor))]
		public string updateLocation {
			get { return _updateSettings.Update_URL; }
			set { _updateSettings.Update_URL = value; }
		}

		/// <summary>
		/// <para>Gibt zurück oder legt fest ob die Argumente der aufrufenden Anwendung nach Abschluss des Updates erneut übergeben werden sollen.</para>
		/// <para>Diese Eigenschaft wird nur Berücksichtigt wenn <see cref="restartApplication"/> true ist.</para>
		/// </summary>
		[Category(_pgrdDefault), Description("Kopiert automatisch die Befehlszeilenargumente der Hostanwendung."),
		 DefaultValue(false)]
		public bool autoCopyCommandlineArguments { get; set; }

		/// <summary>
		/// <para>Gibt zurück oder legt fest, ob der updateInstaller während des Starts Administratorrechte einfordern soll.</para>
		/// <para>Setzen Sie diese Eigenschaft nur auf false, wenn Sie sicher sind, dass während dem Update zu keiner Zeit erhöhte Recht erforderlich sind. Anderfalls schlägt die Aktualisierung fehl.</para>
		/// </summary>
		[Browsable(false)]
		public bool requestElevation { get; set; }

		/// <summary>
		/// Gibt zurück oder legt fest, ob auch als Beta markierte Versionen bei der Updatesuche berücksichtigt werden sollen.
		/// </summary>
		[Browsable(false), Obsolete("Bitte nur noch releaseFilter.CheckForBeta verwenden.", false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool allowBetaversions {
			get { return _updateSettings.allowBetaversions; }
			set { _updateSettings.allowBetaversions = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob der updateInstaller direkt nach der Aktualisierung geschlossen werden soll.
		/// </summary>
		[Category(_pgrdDefault), Description("Legt fest ob der updateInstaller automatisch geschlossen werden soll."),
		 DefaultValue(false)]
		public bool autoCloseUpdateInstaller {
			get { return _updateSettings.SkipOK; }
			set { _updateSettings.SkipOK = value; }
		}

		/// <summary>
		/// <para>Gibt die aktuelle Version der Anwendung zurück oder legt diese fest.</para>
		/// <para>Lassen Sie diesen Wert frei oder setzen Sie die Eigenschaft <see cref="retrieveHostVersion"/> auf true wenn die Version automatisch aus der aufrufenden Anwendung ermitteln werden soll.</para>
		/// </summary>
		[Browsable(false), Obsolete("Verwenden Sie anstelle updateController.releaseInfo.Version", false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Version {
			get { return releaseInfo.Version; }
			set { releaseInfo.Version = value; }
		}

		/// <summary>
		/// Gibt den Releasestatus zurück oder legt diesen fest.
		/// </summary>
		/// <remarks>Neu in V.: 1.1.</remarks>
		[Category(_pgrdDefault), Description("Der lokale Releasestatus der Anwendung."),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public releaseInfo releaseInfo {
			get { return _updateSettings.releaseInfo; }
			set { _updateSettings.releaseInfo = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, welche Releasetypen bei der Suche nach neuen Updates berücksichtigt werden sollen.
		/// </summary>
		/// <remarks>Neu in V.: 1.1.</remarks>
		[Category(_pgrdDefault),
		 Description("Legt fest, welche Releasetypen bei der Suche nach neuen Updates berücksichtigt werden sollen."),
		 Editor(typeof (releaseFilter), typeof (UITypeEditor)),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public releaseFilterType releaseFilter {
			get { return _updateSettings.releaseFilter; }
			set { _updateSettings.releaseFilter = value; }
		}

		/// <summary>
		/// <para>Gibt das Stammverzeichnis der Anwendung zurück oder legt dieses fest.</para>
		/// <para>Lassen Sie diese Eigenschaft leer, wenn das Stammverzeichnis automatisch anhand der aufrufenden Anwendung ermittelt werden soll.</para>
		/// </summary>
		[Browsable(false)]
		public string applicationLocation {
			get { return _updateSettings.AppLocation; }
			set { _updateSettings.AppLocation = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob als <see cref="Version"/> die Version der aufrufenden Anwendung verwendet werden soll.
		/// </summary>
		[Category(_pgrdDefault),
		 Description("Legt fest, ob die lokale Version automatisch aus der Hostanwendung bezogen werden soll."),
		 DefaultValue(false)]
		public bool retrieveHostVersion { get; set; }

		/// <summary>
		/// Gibt das <see cref="UpdateResult"/> des letzten UpdateChecks zurück.
		/// </summary>
		[Browsable(false)]
		public UpdateResult currentUpdateResult { get; internal set; }

		/// <summary>
		/// <para>Gibt das Sicherheitslevel zurück welches verwendet wird, wenn via <see cref="Core.updateActions.startProcessAction.needElevatedRights"/> erhöhte Rechte angefordert werden oder legt dieses fest.</para>
		/// </summary>
		[DefaultValue(processSafetyLevel.AskAlways), Browsable(false)]
		public processSafetyLevel processSafetyLevel {
			get { return _updateSettings.processSafetyLevel; }
			set { _updateSettings.processSafetyLevel = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob der Abbrechenbutton des updateInstallers deaktiviert werden soll.
		/// </summary>
		[Category(_pgrdDefault),
		 Description("Bietet die Möglichkeit den Abbrechenbutton des updateInstallers zu deaktivieren."), DefaultValue(false)]
		public bool disableCancel {
			get { return _updateSettings.disableCancel; }
			set { _updateSettings.disableCancel = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob die Anwendung automatisch vom updateController geschlossen werden soll nachdem der updateInstaller gestartet wurde.
		/// <para>Hat die Eigenschaft den Wert True, so wird das Event <see cref="updateInstallerStarted"/> nicht aufgerufen.</para>
		/// </summary>
		[Category(_pgrdDefault),
		 Description("Bietet die Möglichkeit die Anwendung automatisch vom updateController schließen zu lassen"),
		 DefaultValue(false)]
		public bool autoCloseHostApplication { get; set; }

		/// <summary>
		/// <para>Gibt an oder legt fest, ob der Fortschritt von dem Updatedownload und der Updateinstallation</para>
		/// <para>unter Windows 7 zusätzlich in dem TaskBarButton angezeigt werden soll.</para>
		/// </summary>
		/// <remarks>
		/// <para>Der updateController und Installer überprüft automatisch ob das ausführende Betriebssystem Windows 7 oder</para>
		/// <para>höher ist. Diese Eigenschaft kann daher auch bei Betriebssystemen die älter als Windows 7 sind auf True gesetzt werden,</para>
		/// <para>es findet dann jedoch keine Aktion statt.</para>
		/// </remarks>
		[Category(_pgrdDefault),
		 Description(
		 	"Zeigt den Fortschritt des Updatedownload und der Installation unter Windows 7 zusätzlich in der TaskBar an."),
		 DefaultValue(true)]
		public bool showTaskBarProgress {
			get { return _updateSettings.showTaskBarProgress; }
			set { _updateSettings.showTaskBarProgress = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest ob die Aktionen des updateControllers und updateInstallers geloggt werden soll.
		/// <para>Wenn aktiviert werden die Logs nach %TMP%\updateSystem.Net.Logs geschrieben.</para>
		/// </summary>
		[Category(_pgrdDefault), Description("Aktiviert die Loggingfunktion des updateControllers."), DefaultValue(false)]
		public bool enableLogging {
			get { return _updateSettings.enableLogging; }
			set {
				_updateSettings.enableLogging = value;
				if (!DesignMode) {
					Log.Instance.Enabled = value;
				}
			}
		}

		/// <summary>
		/// Gibt das Datum der letzten erfogreichen Updatesuche zurück.
		/// </summary>
		[Browsable(false)]
		public DateTime lastSuccessfullUpdateCheck {
			get {
				try {
					return
						DateTime.Parse(new ScheduledStart(projectId, updateCheckInterval, customUpdateCheckInterval).RetrieveLastDate());
				}
				catch {
					return DateTime.MinValue;
				}
			}
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob die Updatedialoge in der Taskleiste angezeigt werden soll.
		/// </summary>
		[Category(_pgrdDefault)]
		[Description("Legt fest, ob die Updatedialoge in der Taskleiste angezeigt werden sollen.")]
		[DefaultValue(false)]
		public bool showDialogsInTaskbar { get; set; }

		/// <summary>
		/// Gibt zurück oder legt fest, ob das <see cref="updateFound"/>-Event auch bei der Updatesuche mittels den Updatedialogen gefeuert werden soll.
		/// </summary>
		[Category(_pgrdDefault)]
		[Description(
			"Gibt an ob das updateFound-Event auf bei der Updatesuche mittels den Updatedialogen gefeuert werden soll.")]
		[DefaultValue(false)]
		public bool alwaysRaiseUpdateFoundEvent { get; set; }

		#region " Authentication (Web) "

		/// <summary>
		/// <para>Gibt den authentificationMode für die Updatesuche und den Download zurück oder legt diesen fest.</para>
		/// <remarks>Verwenden Sie <see cref="authenticationModes.Credentials"/>, wenn Sie den Zugang zu den Updatedateien beispielsweise mit .htaccess verwalten.</remarks>
		/// </summary>
		[Category(_pgrdAuthentification),
		 Description("Legt die Authentifizierungsmodus für die Updatesuche und den Download fest, falls benötigt."),
		 DefaultValue(authenticationModes.None)]
		public authenticationModes authenticationMode {
			get { return _updateSettings.authenticationMode; }
			set { _updateSettings.authenticationMode = value; }
		}

		/// <summary>
		/// Gibt den Benutzernamen zurück welcher für die Authentifizierung verwendet werden soll oder legt diesen fest.
		/// </summary>
		[Category(_pgrdAuthentification),
		 Description("Der Benutzername welcher für die Authentifizierung verwendet werden soll."), DefaultValue("")]
		public string authenticationUsername {
			get { return _updateSettings.authenticationUsername; }
			set { _updateSettings.authenticationUsername = value; }
		}

		/// <summary>
		/// Gibt das Password zurück welches für die Authentifizierung verwendet werden soll oder legt dieses fest.
		/// </summary>
		[Category(_pgrdAuthentification), Description("Das Passwort welches für die Authentifizierung verwendet werden soll.")
		, PasswordPropertyText(true), DefaultValue("")]
		public string authenticationPassword {
			get { return _updateSettings.authenticationPassword; }
			set { _updateSettings.authenticationPassword = value; }
		}

		#endregion

		#region " Authentication (Windows) DEAKTIVIERT "

		///// <summary>
		///// Gibt zurück oder legt fest, ob für den Updatevorgang ein anderer Windowsaccount verwendet werden soll.
		///// </summary>
		//[Category(_pgrdwinAuthentification),Description("Legt fest, ob für den Updatevorgang ein anderer Windowsaccount verwendet werden soll"), DefaultValue(false)]
		//public bool windowsAuthentificationEnabled { get { return _updateSettings.windowsAuthenticationEnabled; } set { _updateSettings.windowsAuthenticationEnabled = value; } }

		///// <summary>
		///// Gibt den Benutzernamen zurück welcher für die Windowsauthentifikation benutzt werden soll oder legt diesen fest.
		///// </summary>
		//[Category(_pgrdwinAuthentification),Description("Der Benutzername welcher für die Windowsauthentifikation verwendet werden soll."), DefaultValue("")]
		//public string windowsAuthenticationUsername { get { return _updateSettings.windowsAuthenticationUsername; } set { _updateSettings.windowsAuthenticationUsername = value; } }

		///// <summary>
		///// Gibt das Passwort zurück welches für die Windowsauthentifikation verwendet werden soll oder legt dieses fest.
		///// </summary>
		//[Category(_pgrdwinAuthentification), Description("Das Passwort welches für die Windowsauthentifikation verwendet werden soll."), PasswordPropertyText(true), DefaultValue("")]
		//public string windowsAuthenticationPassword { get { return _updateSettings.windowsAuthenticationPassword; } set { _updateSettings.windowsAuthenticationPassword = value; } }

		///// <summary>
		///// Gibt die Domäne zurück welche für die Windowsauthentifikation verwendet werden soll oder legt diese fest.
		///// </summary>
		//[Category(_pgrdwinAuthentification), Description("Die Domäne welche für die Windowsauthentifikation verwendet werden soll."), DefaultValue("")]
		//public string windowsAuthenticationDomain { get { return _updateSettings.windowsAuthenticationDomain; } set { _updateSettings.windowsAuthenticationDomain = value; } }

		#endregion

		#region " Updateintervall "

		/// <summary>
		/// Gibt das Interval für die Updatesuchen zurück oder legt dieses fest.
		/// </summary>
		[Category(_pgrdInterval), Description("Legt den Updateinterval fest."), DefaultValue(Interval.Always)]
		public Interval updateCheckInterval {
			get { return _updateSettings.Updateinterval; }
			set { _updateSettings.Updateinterval = value; }
		}

		/// <summary>
		/// <para>Das Benutzerdefinierte Suchinterval in Tagen.</para>
		/// <para>Wird nur Berücksichtigt, wenn <see cref="updateCheckInterval"/> auf <see cref="Interval.Custom"/> gesetzt wurde.</para>
		/// </summary>
		[Category(_pgrdInterval), Description("Legt den Benutzerdefinierten Updateinterval in Tagen fest."), DefaultValue(0)]
		public int customUpdateCheckInterval {
			get { return _updateSettings.CustomUpdateInterval; }
			set { _updateSettings.CustomUpdateInterval = value; }
		}

		#endregion

		#region " Proxy "

		/// <summary>
		/// Gibt zurück oder legt fest, ob für die Updatesuche und den Download ein Proxy verwendet werden soll.
		/// </summary>
		[Category(_pgrdProxy), Description("Legt fest ob ein Proxyserver verwendet werden soll."), DefaultValue(false)]
		public bool proxyEnabled {
			get { return _updateSettings.proxyEnabled; }
			set { _updateSettings.proxyEnabled = value; }
		}

		/// <summary>
		/// Gibt die Adresse für den Proxyserver zurück oder legt diese fest.
		/// </summary>
		[Category(_pgrdProxy), Description("Die Url des Proxyservers."), DefaultValue("")]
		public string proxyUrl {
			get { return _updateSettings.proxyUrl; }
			set { _updateSettings.proxyUrl = value; }
		}

		/// <summary>
		/// Gibt den Port des Proxyservers zurück oder legt diesen fest.
		/// </summary>
		[Category(_pgrdProxy), Description("Der Port des Proxyservers."), DefaultValue(8080)]
		public int proxyPort {
			get { return _updateSettings.proxyPort; }
			set { _updateSettings.proxyPort = value; }
		}

		/// <summary>
		/// <para>Gibt den Benutzernamen für den Proxyserver zurück oder legt diesen fest.</para>
		/// <para>Optional, wenn der Server eine Authentifizierung benötigt.</para>
		/// </summary>
		[Category(_pgrdProxy), Description("Der Benutzername für die Anmeldung am Proxyserver."), DefaultValue("")]
		public string proxyUsername {
			get { return _updateSettings.proxyUsername; }
			set { _updateSettings.proxyUsername = value; }
		}

		/// <summary>
		/// <para>Gbt das Passwort für den Proxyserver zurück oder legt dieses fest.</para>
		/// <para>Optional, wenn der Server eine Authentifizierung benötigt.</para>
		/// </summary>
		[Category(_pgrdProxy), Description("Das Passwort für die Anmeldung am Proxyserver."), PasswordPropertyText(true),
		 DefaultValue("")]
		public string proxyPassword {
			get { return _updateSettings.proxyPassword; }
			set { _updateSettings.proxyPassword = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob für die Proxyauthentifizierung die aktuellen Benutzercredentials verwendet werden sollen.
		/// <para>Setzen Sie diese Eigenschaft auf True wenn Sie Probleme mit der Kommunikation durch einen Microsoft ISA haben.</para>
		/// </summary>
		[Category(_pgrdProxy), Description("Nutzt für die Proxyauthentifizierung die aktuellen Benutzerdaten."),
		 DefaultValue(false)]
		public bool proxyUseDefaultCredentials {
			get { return _updateSettings.proxyUseDefaultCredentials; }
			set { _updateSettings.proxyUseDefaultCredentials = value; }
		}

		#endregion

		#endregion

		#region " Hilfsmethoden "

		/// <summary>
		/// Hilfsmethode welche vor jedem UpdateCheck aufgerufen werden muss.
		/// </summary>
		private void prepareUpdateCheck() {
			Log.Instance.writeEntry("Initializing Updatecheck.", "updateController");
			//Updateresultat auf null setzen
			currentUpdateResult = null;
			Internal.Language.Set_Language(_updateSettings.Language);

			if (string.IsNullOrEmpty(releaseInfo.Version) ||
			    retrieveHostVersion) {
				Log.Instance.writeEntry("Retrieving Host Version", "updateController");
				releaseInfo.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
				Log.Instance.writeEntry(string.Format("Version is Set to {0}", releaseInfo.Version), "updateController");
			}

			Log.Instance.writeEntry("Updatecheck initialized.", "updateController");
		}

		/// <summary>
		/// Hilfsmethode welche vor dem Anzeigen des UpdateDialogs aufgerufen werden muss.
		/// </summary>
		private void prepareShowUpdateDialog() {
			if (currentUpdateResult == null) {
				throw new InvalidOperationException(
					"Sie müssen erst nach Updates suchen bevor Sie die Updateinformationen anzeigen lassen können.");
			}
			if (!currentUpdateResult.UpdatesAvailable) {
				throw new InvalidOperationException("Es gibt keine Updates die angezeigt werden können");
			}
		}

		/// <summary>
		/// Hilfsmethode welche vor dem Updatedownload aufgerufen werden muss.
		/// </summary>
		private void prepareUpdateDownload() {
			//Überprüfe ob es Aktualisierungen gibt
			if (currentUpdateResult == null) {
				throw new InvalidOperationException(
					"Der Updatedownload kann nicht aufgerufen werden, da dass Objekt 'currentUpdateResult' null ist");
			}
			if (!currentUpdateResult.UpdatesAvailable) {
				throw new InvalidOperationException("Es gibt keine Updates die herunter geladen werden könnten");
			}

			//Neue SessionId für den Updatedownload erstellen
			_updateSettings.sessionID = Guid.NewGuid().ToString("n");
			_updateSettings.downloadLocation = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), _updateSettings.sessionID);
		}

		/// <summary>
		/// Hilfsmethode welche vor der Updateinstallation aufgerufen werden muss.
		/// </summary>
		/// <returns>Gibt des updateInstallers zurück.</returns>
		private string prepareUpdate() {
			//Überprüfe ob es Aktualisierungen gibt die heruntergeladen werden könnten
			if (currentUpdateResult == null) {
				throw new InvalidOperationException("Das Update kann nicht installiert werden, da es keine Updates gibt");
			}
			if (!currentUpdateResult.UpdatesAvailable) {
				throw new InvalidOperationException("Es gibt keine Updates die installiert werden könnten");
			}

			Log.Instance.writeEntry("Initializing Update", "updateController");

			//Downloadverzeichnis zusammenstellen
			string downloadDirectory = _updateSettings.downloadLocation;
			Log.Instance.writeKeyValue("Workingdirectory", downloadDirectory);

			//Überprüfen ob das Downloadverzeichnis existiert
			if (!Directory.Exists(downloadDirectory)) {
				throw new DirectoryNotFoundException("Das Downloadverzeichnis konnte nicht gefunden werden.");
			}

			//Öffentlichen Schlüssel erstellen
			string spublicKey = (string.IsNullOrEmpty(_updateSettings.PublicKey)
			                     	? currentUpdateResult.Configuration.PublicKey
			                     	: _updateSettings.PublicKey);

			//Validiere Updatepakete
			foreach (updatePackage package in currentUpdateResult.newUpdatePackages) {
				//Updatepaketpfad zusammenstellen
				string packagePath = Path.Combine(downloadDirectory, package.getFilename());

				//Überprüfe ob das Updatepaket existiert
				if (!File.Exists(packagePath)) {
					throw new FileNotFoundException("Ein Updatepaket konnte nicht gefunden werden", packagePath);
				}

				//string packageHash = Convert.ToBase64String(SHA512Managed.Create().ComputeHash(File.ReadAllBytes(packagePath)));
				//if (!Core.RSA.validateSign(packageHash, package.packageSignature, spublicKey))
				//{
				//    throw new appExceptions.invalidSignatureException(packagePath);
				//}
				if (new FileInfo(packagePath).Length != package.packageSize) {
					throw new invalidSignatureException(packagePath);
				}
			}

			//Überprüfe den updateInstaller
			string updateInstallerPath = Path.Combine(downloadDirectory, "updateInstaller.zip");
			string updateInstallerExecutablePath = Path.Combine(downloadDirectory, "updateInstaller.exe");
			if (!File.Exists(updateInstallerPath) && !File.Exists(updateInstallerExecutablePath)) {
				throw new FileNotFoundException("Der updateInstaller konnte nicht gefunden werden.", updateInstallerPath);
			}

			//updateInstaller umbenennen
			if (File.Exists(updateInstallerPath))
				File.Move(updateInstallerPath, updateInstallerExecutablePath);

			//Digitale Signatur des updateInstallers überprüfen
			/*if (!Internal.WinTrust.VerifyEmbeddedSignature(updateInstallerExecutablePath))
			{
				throw new appExceptions.invalidSignatureException(updateInstallerExecutablePath);
			}*/

			//Hashsumme des updateInstallers überprüfen
			validateUpdateInstallerChecksum(downloadDirectory);

			//Aufrufende Anwendung zwecks Neustart ermitteln
			_updateSettings.applicationPath = Assembly.GetEntryAssembly().Location;

			//Stammverzeichnis für die Anwendungsdaten anhand der AppDomain bestimmen, wenn diese nicht vom Benutzer festgelgt wurde
			if (string.IsNullOrEmpty(applicationLocation)) {
				applicationLocation = AppDomain.CurrentDomain.BaseDirectory;
			}

			//Kommandozeilenparameter kopieren
			if (autoCopyCommandlineArguments && restartApplication && Environment.GetCommandLineArgs().Length > 1) {
				var sbArgs = new StringBuilder();
				for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++) {
					sbArgs.Append(string.Format("{0}{1}", Environment.GetCommandLineArgs()[i],
					                            (i < Environment.GetCommandLineArgs().Length - 1 ? " " : "")));
				}
				_updateSettings.commandlineArguments = sbArgs.ToString();
			}
			else {
				_updateSettings.commandlineArguments = string.Empty;
			}


			//Settings speichern
			_updateSettings.Result = currentUpdateResult.newUpdatePackages;
			_updateSettings.Config = currentUpdateResult.Configuration;

			using (var configWriter = new StreamWriter(
				Path.Combine(downloadDirectory, "update.xml"),
				false,
				Encoding.UTF8)) {
				var settingsSerializer = new XmlSerializer(typeof (UpdateSettings));
				settingsSerializer.Serialize(configWriter, _updateSettings);
				configWriter.Flush();
			}

			return updateInstallerExecutablePath;
		}

		private void validateUpdateInstallerChecksum(string workingPath) {
			string executablePath = Path.Combine(workingPath, "updateInstaller.exe");
			string xmlManifestPath = Path.Combine(workingPath, "updateInstaller.xml");

			var xManifest = new XmlDocument();
			xManifest.Load(xmlManifestPath);

			XmlNode xHashNode = xManifest.SelectSingleNode("updateSystemDotNet.updateInstaller/Hash");
			if (xHashNode == null || string.IsNullOrEmpty(xHashNode.InnerText))
				//Ältere Version, Node nicht vorhanden, abbrechen.
				return;

			SHA512 sha = SHA512.Create();
			byte[] hash = sha.ComputeHash(File.ReadAllBytes(executablePath));
			var hashCode = new StringBuilder();
			foreach (byte b in hash) {
				hashCode.Append(b.ToString("x"));
			}

			if (!string.Equals(xHashNode.InnerText, hashCode.ToString()))
				throw new corruptUpdateInstallerException();
		}

		internal bool onConfirmUpdatePackage(confirmUpdatePackageEventArgs e) {
			if (confirmUpdatePackage != null)
				return confirmUpdatePackage(this, e);
			return true;
		}

		internal UpdateSettings internalSettings {
			get { return _updateSettings; }
		}

		#endregion

		#region " Test "

#pragma warning disable

		public void showNewUpdateDialog() {
			using (var dialog = new updateViewDialog((updateController) Clone())) {
				dialog.availableViewStates = updateViewStates.Display |
				                             updateViewStates.Download |
				                             updateViewStates.Search;
				dialog.loadView<viewUpdateCheck>();
				dialog.ShowDialog();
			}
		}

#pragma warning enable

		#endregion

		#region ICloneable Members

		/// <summary>Erstellt eine identische Kopie des updateController-Objektes</summary>
		public object Clone() {
			var clone = new updateController {
			                                 	updateUrl = updateUrl,
			                                 	publicKey = publicKey,
			                                 	releaseFilter =
			                                 		new releaseFilterType {
			                                 		                      	checkForAlpha = releaseFilter.checkForAlpha,
			                                 		                      	checkForBeta = releaseFilter.checkForBeta,
			                                 		                      	checkForFinal = releaseFilter.checkForFinal
			                                 		                      },
			                                 	releaseInfo =
			                                 		new releaseInfo(releaseInfo.Version, releaseInfo.Type, releaseInfo.Step),
			                                 	requestElevation = requestElevation,
			                                 	restartApplication = restartApplication,
			                                 	retrieveHostVersion = retrieveHostVersion,
			                                 	showDialogsInTaskbar = showDialogsInTaskbar,
			                                 	showTaskBarProgress = showTaskBarProgress,
			                                 	updateCheckInterval = updateCheckInterval,
			                                 	proxyUsername = proxyUsername,
			                                 	proxyUrl = proxyUrl,
			                                 	proxyPort = proxyPort,
			                                 	proxyPassword = proxyPassword,
			                                 	proxyEnabled = proxyEnabled,
			                                 	projectId = projectId,
			                                 	processSafetyLevel = processSafetyLevel,
			                                 	Language = Language,
			                                 	enableLogging = enableLogging,
			                                 	disableCancel = disableCancel,
			                                 	customUpdateCheckInterval = customUpdateCheckInterval,
			                                 	autoCopyCommandlineArguments = autoCopyCommandlineArguments,
			                                 	autoCloseUpdateInstaller = autoCloseUpdateInstaller,
			                                 	autoCloseHostApplication = autoCloseHostApplication,
			                                 	authenticationUsername = authenticationUsername,
			                                 	authenticationPassword = authenticationPassword,
			                                 	authenticationMode = authenticationMode,
			                                 	applicationLocation = applicationLocation,
			                                 	alwaysRaiseUpdateFoundEvent = alwaysRaiseUpdateFoundEvent
			                                 };

			return clone;
		}

		#endregion
	}
}