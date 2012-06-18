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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Publishing;
using updateSystemDotNet.Administration.Core.Updates;
using updateSystemDotNet.Administration.Core.updateLog;
using updateSystemDotNet.Administration.UI.Dialogs;
using System.Collections.Generic;
using System.IO;
using updateSystemDotNet.Administration.UI.Popups;
using System.Threading;
using Microsoft.Win32;
using updateSystemDotNet.Localization;

namespace updateSystemDotNet.Administration.Core.Application {
	internal sealed partial class applicationSession {

		#region Private Fields

		private readonly Dictionary<Type, dialogBase> _openDialogs;
		private readonly Dictionary<Type, popupBase> _openPopups;

		#endregion

		#region Events

		public event EventHandler<EventArgs> projectClosed;

		public event EventHandler<EventArgs> projectTitleChanged;

		/// <summary>Dieses Event wird ausgelöst, wenn der Inhalt auf den Contentseiten neu geladen werden soll, z.B. nach dem Laden oder Öffnen eines Projektes.</summary>
		public event EventHandler<EventArgs> contentUpdateRequired;

		/// <summary>Dieses Event wird ausgelöst, wenn der Benutzer die Updates publizieren möchte.</summary>
		public event EventHandler<EventArgs> startPublishing;

		/// <summary>Dieses Event wird ausgelöst, wenn ein aufgerufener Popupdialog geschlossen wurde.</summary>
		public event popupClosedEventHandler popupClosed;

		/// <summary>Occours after the User changed the Applicationsettings.</summary>
		public event EventHandler settingsChanged;

		#endregion

		#region Eventinvocation

		public void onProjectClosed(EventArgs e) {
			var handler = projectClosed;
			if (handler != null) handler(this, e);
		}

		public void onContentUpdateRequired(EventArgs e) {
			var handler = contentUpdateRequired;
			if (handler != null) handler(this, e);
		}

		public void onProjectTitleChanged(EventArgs e) {
			var handler = projectTitleChanged;
			if (handler != null) handler(this, e);
		}

		public void onStartPublishing(EventArgs e) {
			var handler = startPublishing;
			if (handler != null) handler(this, e);
		}

		public void onPopupClosed(popupBase sender, popupClosedEventArgs e) {
			popupClosedEventHandler handler = popupClosed;
			if (handler != null) handler(sender, e);
		}

		public void onSettingsChanged(EventArgs e) {
			EventHandler handler = settingsChanged;
			if (handler != null) handler(this, e);

			//Refresh Sessionsettings
			refreshApplicationSettings();
		}

		#endregion

		public applicationSession() {

			_openDialogs = new Dictionary<Type, dialogBase>();
			_openPopups = new Dictionary<Type, popupBase>();
			dialogResultCache = new Dictionary<Type, object>();
			Settings = applicationSettings.Load();
			publishFactory = new publishFactory(this);
			updateFactory = new updateFactory(this);
			webServices = new onlineServices(this);
			Log = new applicationLog(this);
			updateLogFactory = new updateLogFactory(this);
			localizationFile = new localizationFile();

			//Initialize Updatechannel
			updateReleaseChannels = new List<updateReleaseChannel>(new[] {
			                                                             	new updateReleaseChannel {
			                                                             	                         	Name = "Release",
			                                                             	                         	updateLocation =
			                                                             	                         		"https://updates.updatesystem.net/1.6/release"
			                                                             	                         },
			                                                             	new updateReleaseChannel {
			                                                             	                         	Name = "Beta",
			                                                             	                         	updateLocation =
			                                                             	                         		"https://updates.updatesystem.net/1.6/beta"
			                                                             	                         },

			                                                             });
		}

		#region Dialogdisplay

		/// <summary>Zeigt einen Dialog an.</summary>
		/// <typeparam name="T">Der Type des Dialogs von dem eine Instanz erzeugt werden soll.</typeparam>
		public DialogResult showDialog<T>() where T : dialogBase {
			return showDialog<T>(null, null);
		}

		/// <summary>Zeigt einen Dialog an.</summary>
		/// <typeparam name="T">Der Type des Dialogs von dem eine Instanz erzeugt werden soll.</typeparam>
		public DialogResult showDialog<T>(object argument) where T : dialogBase {
			return showDialog<T>(null, argument);
		}

		/// <summary>Zeigt einen Dialog an.</summary>
		/// <typeparam name="T">Der Type des Dialogs von dem eine Instanz erzeugt werden soll.</typeparam>
		public DialogResult showDialog<T>(IWin32Window owner) where T : dialogBase {
			return showDialog<T>(owner, null);
		}

		/// <summary>Shows an Dialog.</summary>
		/// <typeparam name="T">The Type of the Dialog which should be displayed.</typeparam>
		public DialogResult showDialog<T>(IWin32Window owner, object argument) where T : dialogBase {

			//Check if this Dialog isn't already oben
			if (_openDialogs.ContainsKey(typeof (T))) {
				//Bring that instance to front
				_openDialogs[typeof (T)].Focus();
				return DialogResult.None;
			}
			dialogBase dialogInstance = Activator.CreateInstance<T>();
			try {
				dialogInstance.Session = this;
				dialogInstance.Argument = argument;

				//Clear Resultcache
				if (dialogResultCache.ContainsKey(typeof (T)))
					dialogResultCache.Remove(typeof (T));

				//Load saved Windowsize
				if (Settings.windowSizes.ContainsKey(dialogInstance.Name) &&
					dialogInstance.FormBorderStyle != FormBorderStyle.FixedDialog)
					dialogInstance.Size = Settings.windowSizes[dialogInstance.Name];

				//Load saved Windowlocation
				if (Settings.windowPositions.ContainsKey(dialogInstance.Name) && owner == null) {
					dialogInstance.StartPosition = FormStartPosition.Manual;
					dialogInstance.Location = Settings.windowPositions[dialogInstance.Name];
				}
				else
					dialogInstance.StartPosition = FormStartPosition.CenterParent;

				//Execute Localization
				dialogInstance.localizeDialog();

				//Initialize Dialogspecific stuff
				dialogInstance.initializeData();               

				//Replace [appname] with the current Applicationtitle
				dialogInstance.Text = dialogInstance.Text.Replace("[appname]", Strings.applicationName);

				//Write to log
				Log.writeKeyValue(logLevel.Info, "applicationSession.showDialog", dialogInstance.GetType().ToString());

				//Display the Dialog and wait until it's closed
				DialogResult dlgResult = dialogInstance.ShowDialog(owner);

				//Write DialogResult to log
				Log.writeKeyValue(logLevel.Info, string.Format("application.showDialog.{0}.DialogResult", dialogInstance.GetType()),
								  dlgResult.ToString());

				//Save the extended Dialogresult (custom data etc.)
				if (dialogInstance.Result != null)
					dialogResultCache.Add(typeof (T), dialogInstance.Result);


				//Save size
				if (Settings.windowSizes.ContainsKey(dialogInstance.Name))
					Settings.windowSizes[dialogInstance.Name] = dialogInstance.Size;
				else
					Settings.windowSizes.Add(dialogInstance.Name, dialogInstance.Size);

				//Save position
				if (Settings.windowPositions.ContainsKey(dialogInstance.Name))
					Settings.windowPositions[dialogInstance.Name] = dialogInstance.Location;
				else
					Settings.windowPositions.Add(dialogInstance.Name, dialogInstance.Location);

				dialogInstance.Dispose();
				return dlgResult;
			}
			finally {
				//Make sure the Dialogs is removed from the "Open Dialogs"-List
				if (_openDialogs.ContainsKey(typeof (T)))
					_openDialogs.Remove(typeof (T));
			}
		}
		
		#endregion

		#region Popupanzeige

		public void showPopup<TPopup>(Control anchor) where TPopup : popupBase {
			showPopup<TPopup>(anchor, null);
		}

		public void showPopup<TPopup>(Control anchor, dataContainer argument) where TPopup : popupBase {

			//Überprüfen, ob das Popup bereits angezeigt wird
			if (_openPopups.ContainsKey(typeof (TPopup))) {
				_openPopups[typeof (TPopup)].BringToFront();
				return;
			}

			//Instanz erzeugen
			var popup = (popupBase) Activator.CreateInstance<TPopup>();
			popup.Session = this;
			popup.popupArgument = argument;
			popup.BackColor = Color.White;

			//Benötigte Events registrieren
			popup.FormClosing += popup_FormClosing;
			popup.Deactivate += popup_Deactivate;

			//Position setzen
			popup.Location = anchor.Parent.PointToScreen(new Point(
															anchor.Location.X,
															(anchor.Location.Y + anchor.Height)
															));

			//Result mit Argument initialisieren
			if (argument != null)
				foreach (var kv in argument.internalList)
					popup.popupResult[kv.Key] = kv.Value;

			//Daten initialisieren
			popup.initializeData();

			//Popup anzeigen
			_openPopups.Add(typeof (TPopup), popup);
			popup.Show(anchor);
		}

		//Popup schließen, wenn dieses den Fokus verliert
		private void popup_Deactivate(object sender, EventArgs e) {
			((popupBase) sender).Close();
		}

		private void popup_FormClosing(object sender, FormClosingEventArgs e) {
			//Popup aus der Liste der offenen Popupinstanzen austragen
			var pSender = (popupBase) sender;
			if (_openPopups.ContainsKey(pSender.GetType()))
				_openPopups.Remove(pSender.GetType());

			//Event auslösen, das weitergibt, dass dieses Popup geschlossen wurde.
			onPopupClosed(pSender, new popupClosedEventArgs(pSender.popupResult));

		}

		#endregion

		#region Runtime
		
		/// <summary>Initializes the Main Applicationfeatures.</summary>
		public void initializeApplication(string[] arguments) {

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			System.Windows.Forms.Application.ThreadException += Application_ThreadException;

			currentProject = updateFactory.createNewProject();

			initializeLocalization();
			initializeUpdateController();
		}

		//.NET Exceptionhandler
		void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			showUnhandledExceptionDialog(e.Exception);
		}
		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			showUnhandledExceptionDialog((Exception)e.ExceptionObject);
		}

		/// <summary>Wird beim beenden der Anwendung aufgerufen.</summary>
		public void finalizeApplication() {
			//Einstellungen speichern
			applicationSettings.Save(Settings);

			//Log abschließen
			Log.finalizeLogSession();

			//Anwendung beenden
			//System.Windows.Forms.Application.Exit();
		}

		/// <summary>Zeigt einen Fehlerdialog an und schreibt den aufgetretenen Fehler in die Logdatei.</summary>
		public void showUnhandledExceptionDialog(Exception exception) {
			Log.writeException(exception);
			showDialog<applicationErrorDialog>(null, exception);
		}

		/// <summary>Refreshes or Initializes the Settings of some Applicationcomponents.</summary>
		private void refreshApplicationSettings() {

			updateController.updateLocation = updateReleaseChannels[Settings.updateChannelIndex].updateLocation;

			switch (Settings.proxySettings.proxyMode) {
				case proxyModes.useSystemDefaults:
					updateController.proxyEnabled = false;
					break;
				case proxyModes.useCustomSettings:
					updateController.proxyEnabled = true;
					updateController.proxyUrl = Settings.proxySettings.Server;
					updateController.proxyPort = Settings.proxySettings.Port;

					updateController.proxyUseDefaultCredentials = (Settings.proxySettings.Authentication ==
																   proxyAuthentication.NetworkCredentials);

					if (Settings.proxySettings.Authentication == proxyAuthentication.Custom) {
						updateController.proxyUsername = Settings.proxySettings.Username;
						updateController.proxyPassword = Settings.proxySettings.Password;
					}
					else {
						updateController.proxyUsername = string.Empty;
						updateController.proxyPassword = string.Empty;
					}


					break;
			}

		}

		#endregion

		#region Properties

		/// <summary>Returns the Name of the Application.</summary>
		public string applicationName { get { return "updateSystem.NET Administration"; } }

		public string applicationCodeName { get { return "swordfish"; } }

		/// <summary>Returns the unqiue Applicationid.</summary>
		public string applicationId { get { return "5a822d25-9e3c-46ad-bb62-3af7b3c8d2fd"; } }

		/// <summary>Bietet Zugriff auf die Anwendungseinstellungen.</summary>
		public applicationSettings Settings { get; private set; }

		/// <summary>Bietet Zugriff auf das aktuelle Updateprojekt.</summary>
		/// <remarks>Kann null sein.</remarks>
		public updateProject currentProject { get; private set; }

		/// <summary>Gibt den Pfad zum aktuell geöffneten Projekt zurück.</summary>
		public string currentProjectPath { get; private set; }

		/// <summary>Gibt das Verzeichnis zurück in welchem sich das aktuelle Updateprojekt befindet.</summary>
		public string currentProjectDirectory {
			get { return File.Exists(currentProjectPath) ? Path.GetDirectoryName(currentProjectPath) : string.Empty; }
		}

		/// <summary>Bietet Zugriff auf die Publishfactory.</summary>
		public publishFactory publishFactory { get; private set; }

		/// <summary>Factory zum Erstellen und Verwalten von Updatepaketen.</summary>
		public updateFactory updateFactory { get; private set; }

		/// <summary>Factory zur Verwaltung der Updatestatistiken.</summary>
		public updateLogFactory updateLogFactory { get; private set; }

		/// <summary>Returns the default path for new projects.</summary>
		public string defaultProjectLocation {
			get {
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
									string.Format("updateSystem.NET{0}Projects", Path.DirectorySeparatorChar));
			}
		}

		/// <summary>Stellt einen Cache bereit in welchem die erweiterten Dialogresultate gespeichert werden.</summary>
		public Dictionary<Type, object> dialogResultCache { get; private set; }

		/// <summary>Bietet Zugriff auf alle Dienste die Daten ins Web senden können.</summary>
		public onlineServices webServices { get; private set; }

		/// <summary>Bietet Zugriff auf den Anwendungslog.</summary>
		public applicationLog Log { get; private set; }

		/// <summary>Bietet Zugriff auf den Updatecontroller.</summary>
		public updateController updateController { get; private set; }

		/// <summary>Returns all available Updatechannel for this Project.</summary>
		public List<updateReleaseChannel> updateReleaseChannels { get; private set; }

		/// <summary>Returns if the current PC is my Developing machine. This will unlock some stuff.</summary>
		public bool isDevEnvironment {
			get {
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\updateSystem.NET",false);
				return (key != null && (string) key.GetValue("isDev", "nope") == "jau");
			}
		}

		#endregion

		#region Projekt

		/// <summary>Öffnet ein Updateprojekt.</summary>
		public void openProject(string projectFilename) {
			if (string.IsNullOrEmpty(projectFilename))
				throw new ArgumentException("projectFilename");

			currentProject = updateFactory.loadProject(projectFilename);
			currentProjectPath = projectFilename;
			onContentUpdateRequired(EventArgs.Empty);
			onProjectTitleChanged(EventArgs.Empty);
		}

		/// <summary>Speichert ein Updateprojekt unter einem angegebenen Dateinamen.</summary>
		public void saveProject(string projectFilename) {
			if (string.IsNullOrEmpty(projectFilename))
				throw new ArgumentException("projectFilename");

			updateFactory.saveProject(projectFilename, currentProject);
			currentProjectPath = projectFilename;
			onContentUpdateRequired(EventArgs.Empty);
		}

		/// <summary>Speichert ein Updateprojekt unter dem aktuell verwendeten Dateinamen</summary>
		public void saveProject() {
			saveProject(currentProjectPath);
		}

		/// <summary>Schließt das aktuelle Projekt und entfernt alle evtl. vorhandnen Verweise.</summary>
		public void closeProject() {
			currentProjectPath = string.Empty;
			currentProject = updateFactory.createNewProject();
			onProjectClosed(EventArgs.Empty);
		}

		/// <summary>Gibt zurück ob aktuell ein Projekt geladen und gespeichert ist.</summary>
		public bool isProjectLoaded {
			get { return !string.IsNullOrEmpty(currentProjectPath) && File.Exists(currentProjectPath); }
		}

		/// <summary>Schließt das aktuelle und erstellt ein neues Projekt.</summary>
		public void newProject() {
			closeProject();
			currentProject = updateFactory.createNewProject();
			onContentUpdateRequired(EventArgs.Empty);
		}

		/// <summary>Kopiert den öffentlichen Schlüssel und die Projekt-Id in die Zwischenablage.</summary>
		public void copyProjectDataToClipboard() {
			var sbClipboardData = new StringBuilder();
			sbClipboardData.AppendLine(string.Format("publicKey#{0}", currentProject.keyPair.publicKey));
			sbClipboardData.AppendLine(string.Format("projectId#{0}", currentProject.projectId));
			Clipboard.SetData("UPDATEDATAv3", sbClipboardData.ToString());
		}

		#endregion

		#region Applicationupdates

		private void initializeUpdateController() {
			updateController = new updateController {
														updateLocation = "https://updates.updatesystem.net/1.6/beta",
														projectId = "a1836990-a407-4b7d-925f-66b970ff8baf",
														publicKey =
															"<RSAKeyValue><Modulus>5SKTVlel98X+yybUszedBjR1JI8cqEjiffbleW2bN/k9h2PcCTjCRp9SvZU+kEyCd2JQTLCVMyfTV0TScT3UoRGF+eXONCy6uitfHv+vtrFka1Emy2aJpY4pElPrLd3KLD1U10B4Jcplv8L7EorOdihzTH2y21Uq254kH2f8tctBgwlM97/xiXCU7aMrsxW8E/GTZRen2I+92S261pWt+mGCDY49mjsQZvx2leYE/mKuassLWL/k7mxyFjN0Zeo9UphVo89IsSPF58LtcrpUQ7Lxihx72CXeL42ajn9/Zb9jv4ITwd7jKR6FNWFepweJvzBkGitnddAcvfbPK/7Mvw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
														restartApplication = true,
														retrieveHostVersion = true
													};
			refreshApplicationSettings();
		}

		#endregion

	}
}