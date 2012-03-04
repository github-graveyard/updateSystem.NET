using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateManager {
		/// <summary>
		/// Gibt die Form zurück, welche für UI-Benutzeraktionen verwendet werden soll zurück oder legt diese fest.
		/// </summary>
		private readonly Form m_ownerForm;

		/// <summary>
		/// Liste mit allen durchgeführen Aktionen um diese im Fehlerfall oder beim Benutzerabruch wiederherstellen zu können.
		/// </summary>
		private readonly List<applyUpdateBase> m_performedUpdateActions = new List<applyUpdateBase>();

		/// <summary>
		/// Liste mit allen Updateaktionen die in diesem Update durchgeführt werden sollen.
		/// </summary>
		private readonly List<applyUpdateBase> m_updateActions = new List<applyUpdateBase>();

		/// <summary>
		/// Zähler welcher nach jeder Aktion um 1 erhöht wird um auf die nächste Updateaktion zugreifen zu können.
		/// </summary>
		private int applyUpdateActionCount;

		private bool m_cancellationPending;
		private InternalConfig m_config;

		/// <summary>
		/// Gibt die UpdateAction zurück, die momentan ausgeführt wird.
		/// </summary>
		private applyUpdateBase m_currentAction;

		/// <summary>
		/// Flag welches 'true' gesetzt wird, wenn sich der Updater im Rollbackmodus befindet.
		/// </summary>
		private bool m_onRollback;

		/// <summary>
		/// Der Fehler der während dem Update aufgetreten ist, und am Ende des Rollbackvorganges der MainForm übergeben wird.
		/// </summary>
		private Exception m_updateException;

		private bool m_waitForRollback;

		public applyUpdateManager(Form ownerForm) {
			m_ownerForm = ownerForm;

			//Konfiguration laden
			loadConfig();
		}

		public InternalConfig currentConfig {
			get { return m_config; }
		}

		/// <summary>
		/// Gibt 'True' zurück, wenn der Updatevorgang momentan läuft, andernfalls 'False'.
		/// </summary>
		public bool isBusy {
			get {
				if (m_currentAction != null) {
					return m_currentAction.isBusy;
				}
				else {
					return false;
				}
			}
		}

		/// <summary>
		/// Event welches aufgerufen wird, wenn das Update abgeschlossen- oder durch den Benutzer oder einen Fehler abgebrochen wurde.
		/// </summary>
		public event EventHandler<applyUpdateActionFinishedEventArgs> updateFinished;

		/// <summary>
		/// Event welches aufgerufen wird, wenn sich das Status des Updates verändert hat.
		/// </summary>
		public event EventHandler<applyUpdateProgressChangedEventArgs> updateProgressChanged;

		public event EventHandler<applyUpdateActionFinishedEventArgs> rollbackFinished;

		public event EventHandler<applyUpdateInterfaceInteractionEventArgs> interfaceInteraction;

		/// <summary>
		/// Lädt die Konfigurationsdatei aus dem Anwendungsverzeichnis des Updaters.
		/// </summary>
		private void loadConfig() {
			try {
				var t_config = new InternalConfig();
				var t_settings = new UpdateSettings();
				string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update.xml");

				if (!File.Exists(SettingsPath)) {
					throw new FileNotFoundException(SettingsPath);
				}

				using (var sr = new StreamReader(SettingsPath)) {
					var xs = new XmlSerializer(typeof (UpdateSettings));
					t_settings = (UpdateSettings) xs.Deserialize(sr);
					t_config.Result = t_settings.Result;
					t_config.ServerConfiguration = t_settings.Config;
					t_config.Settings = t_settings;
					m_config = t_config;
				}
			}
				//catch (Exception ex) { raiseException(ex); }
			catch {
				throw;
			}
		}

		/// <summary>
		/// Funktion zum Aufrufen des RollbackFinishedEvents bei einem aufgetretenen Fehler.
		/// </summary>
		/// <param name="ex">Der aufgetretene Fehler.</param>
		private void raiseException(Exception ex) {
			if (rollbackFinished != null) {
				rollbackFinished(this, new applyUpdateActionFinishedEventArgs(ex));
			}
		}

		/// <summary>
		/// Startet den Updatevorgang.
		/// </summary>
		public void runUpdate() {
			foreach (updatePackage currentPackage in m_config.Result) {
				//Füge eine Action zum validieren der Signatur hinzu
				applyUpdateBase validationAction = new applyValidatePackageSignature(new validatePackageAction(), currentConfig,
				                                                                     currentPackage);
				validationAction.actionFinished += action_actionFinished;
				validationAction.progressChanged += action_progressChanged;
				validationAction.ownerForm = m_ownerForm;
				m_updateActions.Add(validationAction);

				//Updateaktionen hinzufügen
				foreach (string id in currentPackage.actionOrder) {
					applyUpdateBase action = getActionById(id, currentPackage);

					if (action == null) {
						continue;
					}

					action.ownerForm = m_ownerForm;
					action.actionFinished += action_actionFinished;
					action.progressChanged += action_progressChanged;
					action.interfaceInteraction += action_interfaceInteraction;
					m_updateActions.Add(action);
				}
			}

			//Registryversion aktualisieren
			if (!string.IsNullOrEmpty(currentConfig.ServerConfiguration.setupId)) {
				string latestVersion =
					currentConfig.ServerConfiguration.updatePackages[currentConfig.ServerConfiguration.updatePackages.Count - 1].
						releaseInfo.Version;
				applyUpdateBase updateReg = new applyUpdateRegistryAction(new updateRegistryAction {newVersion = latestVersion},
				                                                          currentConfig);
				updateReg.actionFinished += action_actionFinished;
				updateReg.progressChanged += action_progressChanged;
				m_updateActions.Add(updateReg);
			}

			//Cleanupaction zum löschen der Updatedateien hinzufügen
			applyUpdateBase cleanup = new applyCleanupAction(new cleanupAction(), currentConfig);
			cleanup.actionFinished += action_actionFinished;
			cleanup.progressChanged += action_progressChanged;
			m_updateActions.Add(cleanup);

			//Erste Aktion ausführen
			m_updateActions[applyUpdateActionCount].runAction();
		}

		private void action_interfaceInteraction(object sender, applyUpdateInterfaceInteractionEventArgs e) {
			if (interfaceInteraction != null)
				interfaceInteraction(sender, e);
		}

		private void action_progressChanged(object sender, applyUpdateProgressChangedEventArgs e) {
			if (updateProgressChanged != null) {
				if (m_onRollback) {
					var rArgs = new applyUpdateProgressChangedEventArgs(
						Language.GetString("applyUpdateManager_rollback"),
						e.actionDescription,
						Percent(e.percentDone + (applyUpdateActionCount*100), m_performedUpdateActions.Count*100));
				}
				else {
					var eArgs = new applyUpdateProgressChangedEventArgs(
						e.actionName,
						e.actionDescription,
						Percent(e.percentDone + (applyUpdateActionCount*100), m_updateActions.Count*100));
					updateProgressChanged(this, eArgs);
				}
			}
		}

		private void action_actionFinished(object sender, applyUpdateActionFinishedEventArgs e) {
			//Sender zur Liste ausgeführter Aktionen hinzufügen
			m_performedUpdateActions.Add((applyUpdateBase) sender);

			//Überprüfe ob während der Aktion ein Fehler aufgetreten ist
			if ((e.actionException != null && !m_onRollback) || (m_cancellationPending && m_waitForRollback)) {
				m_onRollback = true;
				if (e.actionException == null) {
					m_updateException = new userCancelledException();
				}
				else {
					m_updateException = e.actionException;
				}
				applyUpdateActionCount = 0;

				m_currentAction = m_performedUpdateActions[applyUpdateActionCount];
				m_currentAction.runRollback();
				m_waitForRollback = false;
				//m_performedUpdateActions[applyUpdateActionCount].runRollback();
			}
			else {
				applyUpdateActionCount++;
				if (m_onRollback) {
					if (applyUpdateActionCount >= m_updateActions.Count) {
						if (rollbackFinished != null) {
							rollbackFinished(this, new applyUpdateActionFinishedEventArgs(m_updateException));
						}
					}
					else {
						m_currentAction = m_performedUpdateActions[applyUpdateActionCount];
						m_currentAction.runRollback();
						//m_performedUpdateActions[applyUpdateActionCount].runRollback();
					}
				}
				else {
					//Überpüfe ob alle Aktionen abgearbeitet wurden
					if (applyUpdateActionCount >= m_updateActions.Count) {
						if (updateFinished != null) {
							updateFinished(this, e);
						}
					}
					else {
						m_currentAction = m_updateActions[applyUpdateActionCount];
						m_currentAction.runAction();
						//m_updateActions[applyUpdateActionCount].runAction();
					}
				}
			}
		}

		/// <summary>
		/// Funktion welche die UpdateAction zu einer ID sucht.
		/// </summary>
		/// <param name="ID">Die ID nach der gesucht werden soll.</param>
		/// <param name="currentPackage">Das aktuelle Updatepaket.</param>
		/// <returns>Gibt die applyUpdateAction zu der ID zurück.</returns>
		private applyUpdateBase getActionById(string ID, updatePackage currentPackage) {
			foreach (closeProcessAction closeProcessActionItem in currentPackage.closeProcessActions) {
				if (closeProcessActionItem.ID.Equals(ID)) {
					return new applyCloseProcessAction(closeProcessActionItem, m_config, currentPackage);
				}
			}
			foreach (startProcessAction startProcessActionItem in currentPackage.startProcessActions) {
				if (startProcessActionItem.ID.Equals(ID)) {
					return new applyStartProcessAction(startProcessActionItem, m_config, currentPackage);
				}
			}
			foreach (fileCopyAction fileCopyActionItem in currentPackage.fileCopyActions) {
				if (fileCopyActionItem.ID.Equals(ID)) {
					return new applyFileCopyAction(fileCopyActionItem, m_config, currentPackage);
				}
			}
			foreach (renameFileAction renameFileActionItem in currentPackage.renameFileActions) {
				if (renameFileActionItem.ID.Equals(ID)) {
					return new applyRenameFileAction(renameFileActionItem, m_config, currentPackage);
				}
			}
			foreach (deleteFilesAction deleteFileActionItem in currentPackage.deleteFilesActions) {
				if (deleteFileActionItem.ID.Equals(ID)) {
					return new applyDeleteFileAction(deleteFileActionItem, m_config, currentPackage);
				}
			}
			foreach (startServiceAction startServiceActionItem in currentPackage.startServiceActions) {
				if (startServiceActionItem.ID.Equals(ID)) {
					return new applyStartServiceAction(startServiceActionItem, m_config, currentPackage);
				}
			}
			foreach (stopServiceAction stopServiceActionItem in currentPackage.stopServiceActions) {
				if (stopServiceActionItem.ID.Equals(ID)) {
					return new applyStopServiceAction(stopServiceActionItem, m_config, currentPackage);
				}
			}
			foreach (addRegistryKeyAction addRegistryKeyActionItem in currentPackage.addRegistryKeyActions) {
				if (addRegistryKeyActionItem.ID.Equals(ID)) {
					return new applyAddRegistryKeyAction(addRegistryKeyActionItem, m_config, currentPackage);
				}
			}
			foreach (addRegistryValueAction addRegistryValueActionItem in currentPackage.addRegistryValueActions) {
				if (addRegistryValueActionItem.ID.Equals(ID)) {
					return new applyAddRegistryValueAction(addRegistryValueActionItem, m_config, currentPackage);
				}
			}
			foreach (removeRegistryKeyAction removeRegistryKeyActionItem in currentPackage.removeRegistryKeyActions) {
				if (removeRegistryKeyActionItem.ID.Equals(ID)) {
					return new applyRemoveRegistryKeyAction(removeRegistryKeyActionItem, m_config, currentPackage);
				}
			}
			foreach (removeRegistryValuesAction removeRegistryValueActionItem in currentPackage.removeRegistryValueActions) {
				if (removeRegistryValueActionItem.ID.Equals(ID)) {
					return new applyRemoveRegistryValueAction(removeRegistryValueActionItem, m_config, currentPackage);
				}
			}
			foreach (userInteractionAction userInteractionActionItem in currentPackage.userInteractionActions) {
				if (userInteractionActionItem.ID.Equals(ID)) {
					return new applyUserInteractionAction(userInteractionActionItem, m_config, currentPackage);
				}
			}
			return null;
		}

		/// <summary>
		/// Diese Funktion berechnet den Prozentsatz aus zwei Werten.
		/// </summary>
		/// <param name="CurrVal">Der aktuelle Wert.</param>
		/// <param name="MaxVal">Der maximalwert</param>
		/// <returns>Gibt den Prozentsatz aus den beiden gegebenen Werten zurück.</returns>
		private int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}

		/// <summary>
		/// Bricht das Update ab.
		/// </summary>
		public void cancelUpdate() {
			if (isBusy && !m_cancellationPending) {
				m_cancellationPending = true;
				m_waitForRollback = true;
			}
		}
	}
}