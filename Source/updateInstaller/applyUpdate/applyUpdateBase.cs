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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.BZip2;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;
using updateSystemDotNet.Updater.UI.Components;
using updateSystemDotNet.Updater.UI.Forms;

namespace updateSystemDotNet.Updater.applyUpdate {
	/// <summary>
	/// Abstrakte Klasse, welche als Basis für alle ApplyUpdateActions dient.
	/// </summary>
	/// <remarks>Threadsafe: Ja.</remarks>
	internal abstract class applyUpdateBase {
		private readonly actionBase m_action;
		private readonly BackgroundWorker m_bgwAction = new BackgroundWorker();
		private readonly updatePackage m_currentPackage;
		private InternalConfig m_config;
		private Form m_ownerForm;

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="applyUpdateBase"/>Action.
		/// </summary>
		/// <param name="Action">Die Updateaction.</param>
		public applyUpdateBase(actionBase Action) {
			m_action = Action;

			m_bgwAction.WorkerReportsProgress = true;
			m_bgwAction.WorkerSupportsCancellation = true;
			m_bgwAction.DoWork += m_bgwAction_DoWork;
			m_bgwAction.ProgressChanged += m_bgwAction_ProgressChanged;
			m_bgwAction.RunWorkerCompleted += m_bgwAction_RunWorkerCompleted;
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="applyUpdateBase"/>Action.
		/// </summary>
		/// <param name="Action">Die Updateaction</param>
		/// <param name="Config">Die Konfiguration.</param>
		public applyUpdateBase(actionBase Action, InternalConfig Config, updatePackage currentPackage)
			: this(Action) {
			m_config = Config;
			m_currentPackage = currentPackage;
		}

		public abstract string actionName { get; }

		public Form ownerForm {
			get { return m_ownerForm; }
			set { m_ownerForm = value; }
		}

		/// <summary>
		/// Gibt zurück, ob der der Backgroundworker beschäftigt ist.
		/// </summary>
		public bool isBusy {
			get { return m_bgwAction.IsBusy; }
		}

		/// <summary>
		/// Gibt True zurück wenn es sich bei dem Betriebssystem um Windows Vista oder höher handelt, andernfalls False.
		/// </summary>
		protected bool isVistaOrLater {
			get { return (Environment.OSVersion.Version.Major >= 6); }
		}

		/// <summary>
		/// Gibt True zurück wenn der momentan angemeldete Benutzer über Administorenrechte verfügt, andernfalls False.
		/// </summary>
		protected bool isAdmin {
			get {
				WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
				var wPrincipal = new WindowsPrincipal(currentUser);
				return wPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		public string getTempDirectory {
			get { return Environment.GetEnvironmentVariable("tmp"); }
		}

		public InternalConfig currentConfiguration {
			get { return m_config; }
			set { m_config = value; }
		}

		public updatePackage currentPackage {
			get { return m_currentPackage; }
		}

		public event EventHandler<applyUpdateActionFinishedEventArgs> actionFinished;
		public event EventHandler<applyUpdateProgressChangedEventArgs> progressChanged;
		public event EventHandler<applyUpdateInterfaceInteractionEventArgs> interfaceInteraction;

		public abstract void executeAction(actionBase Action);
		public abstract void rollbackAction();

		private DialogResult requestFileAccess(string Path) {
			onInterfaceInteraction(new applyUpdateInterfaceInteractionEventArgs(ProgressBarState.Error));
			using (var dlg = new fileAccessDialog()) {
				dlg.Text = m_config.ServerConfiguration.applicationName;
				DialogResult result = dlg.ShowDialog(ownerForm, Path);
				onInterfaceInteraction(new applyUpdateInterfaceInteractionEventArgs(ProgressBarState.Normal));
				return result;
			}
		}

		private DialogResult showSafeInteractionDialog(interactionButtons Buttons, string Title, string Message) {
			onInterfaceInteraction(new applyUpdateInterfaceInteractionEventArgs(ProgressBarState.Pause));
			using (var dlg = new interactionDialog(Buttons, Title, Message)) {
				dlg.Text = m_config.ServerConfiguration.applicationName;
				DialogResult result = dlg.ShowDialog(ownerForm);
				onInterfaceInteraction(new applyUpdateInterfaceInteractionEventArgs(ProgressBarState.Normal));
				return result;
			}
		}

		/// <summary>
		/// Funktion zum Aufrufen der Action.
		/// </summary>
		public void runAction() {
			if (!m_bgwAction.IsBusy) {
				m_bgwAction.RunWorkerAsync(m_action);
			}
		}

		/// <summary>
		/// Macht die Änderungen dieser applyUpdateAction Rückgängig.
		/// </summary>
		public void runRollback() {
			if (!m_bgwAction.IsBusy) {
				m_bgwAction.RunWorkerAsync();
			}
		}

		protected void onInterfaceInteraction(applyUpdateInterfaceInteractionEventArgs e) {
			if (interfaceInteraction != null)
				interfaceInteraction(this, e);
		}

		private void m_bgwAction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (actionFinished != null) {
				if (e.Result != null) {
					actionFinished(this, new applyUpdateActionFinishedEventArgs((Exception) e.Result));
				}
				else {
					actionFinished(this, new applyUpdateActionFinishedEventArgs());
				}
			}
		}

		private void m_bgwAction_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			if (progressChanged != null) {
				progressChanged(this,
				                new applyUpdateProgressChangedEventArgs(actionName, (string) e.UserState, e.ProgressPercentage));
			}
		}

		private void m_bgwAction_DoWork(object sender, DoWorkEventArgs e) {
			try {
				//Wenn ein Argument mitgegeben wurde, soll die normale Updateaktion ausgeführt werden
				if (e.Argument != null) {
					executeAction((actionBase) e.Argument);
				}
				else //anderfalls soll ein Rollback durchgeführt werden
				{
					rollbackAction();
				}
			}
			catch (Exception ex) {
				e.Result = ex;
			}
		}

		protected void onProgressChanged(string description, int percentDone) {
			if (m_bgwAction != null && m_bgwAction.IsBusy) {
				m_bgwAction.ReportProgress(percentDone, description);
			}
		}

		/// <summary>
		/// Gibt den Root Registry Key zurück.
		/// </summary>
		/// <param name="root">Der Registryzweig welcher als Root verwendet werden soll.</param>
		/// <returns>Gibt den Registry Root zurück.</returns>
		protected RegistryKey getRegistryRoot(registryHives root) {
			switch (root) {
				case registryHives.HKEY_CLASSES_ROOT:
					return Registry.ClassesRoot;
				case registryHives.HKEY_CURRENT_USER:
					return Registry.CurrentUser;
				case registryHives.HKEY_LOCAL_MACHINE:
					return Registry.LocalMachine;
				default:
					return null;
			}
		}

		/// <summary>
		/// Überprüft ob ein Registryschlüssel existiert.
		/// </summary>
		/// <param name="root">Der Basisschlüssel.</param>
		/// <param name="hive">Der Unterschlüssel.</param>
		/// <returns>Gibt True zurück wenn der Schlüssel existiert, andernfalls False.</returns>
		protected bool registryKeyExists(RegistryKey root, string hive) {
			try {
				root.OpenSubKey(hive).GetValueNames();
				return true;
			}
			catch (NullReferenceException) {
				return false;
			}
		}

		/// <summary>
		/// Gibt den ValueKind eines Registryschlüssels wieder.
		/// </summary>
		/// <param name="valueType">Der ValueType</param>
		/// <returns>Das ValueKind.</returns>
		protected RegistryValueKind getRegistryValueKind(registryValueTypes valueType) {
			switch (valueType) {
				case registryValueTypes.REG_BINARY:
					return RegistryValueKind.Binary;
				case registryValueTypes.REG_DWORD:
					return RegistryValueKind.DWord;
				case registryValueTypes.REG_EXPAND_SZ:
					return RegistryValueKind.ExpandString;
				case registryValueTypes.REG_MULTI_SZ:
					return RegistryValueKind.MultiString;
				case registryValueTypes.REG_SZ:
					return RegistryValueKind.String;
				default:
					return RegistryValueKind.String;
			}
		}

		/// <summary>
		/// Konvertiert einen Pfad aus variablen zu einem "echten" Pfad
		/// </summary>
		/// <param name="path">Der Pfad der konvertiert werden soll</param>
		/// <returns>Gibt den auf diesen Computer angepassten Pfad zurück</returns>
		protected string ParsePath(string path) {
			path = path.Replace("$approot", m_config.Settings.AppLocation);
			path = path.Replace("$tempdir", Environment.GetEnvironmentVariable("TEMP"));
			path = path.Replace("$windir", Environment.GetEnvironmentVariable("windir"));
			path = path.Replace("$appdata", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			path = path.Replace("$commonAppdata", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			path = path.Replace(@"\\", @"\");

			return path;
		}

		/// <summary>
		/// Zeigt einen Informationsdialog an.
		/// </summary>
		/// <param name="Buttons">Die Schaltflächen die auf dem Dialog angezeigt werden soll.</param>
		/// <param name="Title">Der Titel des Dialogs.</param>
		/// <param name="Message">Der Nachrichteninhalt.</param>
		/// <returns>Gibt das vom Benutzer ausgewählte Dialogresult zurück.</returns>
		protected DialogResult showInteractionDialog(interactionButtons Buttons, string Title, string Message) {
			return
				(DialogResult)
				ownerForm.Invoke(new delShowInteractionDialog(showSafeInteractionDialog), new object[] {Buttons, Title, Message});
		}

		/// <summary>
		/// Dekomprimiert eine Datei aus einem Resourcenpaket
		/// </summary>
		/// <param name="input">Das komprimierte byte[]</param>
		/// <returns>Gibt die dekomprimierten Dateien als Bytearray zurück</returns>
		protected byte[] Decompress(byte[] input) {
			using (var inStream = new MemoryStream(input)) {
				using (var outStream = new MemoryStream()) {
					BZip2.Decompress(inStream, outStream);
					return outStream.ToArray();
				}
			}
		}

		/// <summary>
		/// Löscht eine Datei und zeit bei einem Fehler während dem Löschversuch ein Nachrichtenfeld an,
		/// welches es dem Benutzer ermöglicht den Löschvorgang zu wiederholen.
		/// </summary>
		/// <param name="path">Der Pfad zu der Datei die gelöscht werden soll.</param>
		/// <returns>Gibt 'True' zurück wenn die Datei erfolgreich gelöscht wurde, andernfalls 'False'.</returns>
		protected bool deleteFile(string path) {
			try {
				//Möglichen Schreibschutz entfernen
				File.SetAttributes(path, FileAttributes.Normal);

				//Datei löschen
				File.Delete(path);
				return true;
			}
			catch {
				switch ((DialogResult) m_ownerForm.Invoke(new delRequestFileAccess(requestFileAccess), path)) {
					case DialogResult.Abort:
						return false;
					case DialogResult.Retry:
						return deleteFile(path);
					default:
						return false;
				}

				//UI.Components.vTaskDialog.ShowTaskDialogBox("Updateinstaller",
				//    Language.GetString("actionBase_deleteFile_mainInstruction"),
				//    string.Format(Language.GetString("actionBase_deleteFile_content"), Path.GetFileName(path)),
				//    string.Format("{0}\r\n{1}", Language.GetString("actionBase_deleteFile_expandedContent"), path), "", "", "",
				//    Language.GetString("actionBase_deleteFile_commandButtons"),
				//    updateSystemDotNet.Updater.UI.Components.TaskDialogButtons.None,
				//    updateSystemDotNet.Updater.UI.Components.SysIcons.Warning,
				//    updateSystemDotNet.Updater.UI.Components.SysIcons.Warning);
				//switch (UI.Components.vTaskDialog.commandButtonResult)
				//{
				//    case 0: return (deleteFile(path)); //Wiederholen
				//    case 1: return false; //Abbrechen
				//    default: return false;
				//}
			}
		}

		/// <summary>
		/// Bietet Zugriff auf die Resourcen in einem Updatepaket.
		/// </summary>
		/// <param name="packagePath">Der Pfad zu dem Updatepaket.</param>
		/// <param name="resID">Die ID der Resource die ausgelesen werden soll.</param>
		/// <returns>Gibt die Resource in Form eines ByteArrays zurück.</returns>
		protected byte[] accessUpdatePackage(string packagePath, string resID) {
			var resReader = new ResourceReader(packagePath);
			try {
				byte[] outData;
				string outType;
				resReader.GetResourceData(resID, out outType, out outData);
				return outData;
			}
			finally {
				resReader.Close();
			}
		}

		/// <summary>
		/// Diese Funktion berechnet den Prozentsatz aus zwei Werten.
		/// </summary>
		/// <param name="CurrVal">Der aktuelle Wert.</param>
		/// <param name="MaxVal">Der maximalwert</param>
		/// <returns>Gibt den Prozentsatz aus den beiden gegebenen Werten zurück.</returns>
		protected int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}

		/// <summary>
		/// Kopiert eine Datei.
		/// </summary>
		/// <param name="sourceFile">Der Pfad der Quelldatei.</param>
		/// <param name="destinationFile">Der Pfad der Zieldatei.</param>
		protected void copyFile(string sourceFile, string destinationFile) {
			using (FileStream fsSource = File.OpenRead(sourceFile)) {
				using (var fsDestination = new FileStream(destinationFile, FileMode.Create)) {
					var buffer = new byte[fsSource.Length];
					fsSource.Read(buffer, 0, (int) fsSource.Length);
					fsDestination.Write(buffer, 0, buffer.Length);
				}
			}
		}

		/// <summary>
		/// Ermittelt den Hashcode einer Datei.
		/// </summary>
		/// <param name="inputFile">Der vollständige Pfad zu der Datei, aus welcher der Hashcode ermittelt werden soll.</param>
		/// <returns>Gibt den berechneten Hashcode in einem Base64 kodierten String zurück.</returns>
		protected string generateHashcode(string inputFile) {
			MD5 md5 = MD5.Create();
			return Convert.ToBase64String(md5.ComputeHash(File.ReadAllBytes(inputFile)));
		}

		#region " NativeImageSetup "

		private string m_clrDirectory = string.Empty;

		[DllImport("mscoree.dll")]
		private static extern IntPtr GetCORSystemDirectory([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pbuffer,
		                                                   int cchBuffer, ref int dwlength);

		/// <summary>
		/// Ermittelt das Verzeichnis, in welchem die .Net Frameworktools installiert sind.
		/// </summary>
		/// <returns>Gibt das Frameworkverzeichnis zurück.</returns>
		private string GetClrInstallationDirectory() {
			int capacity = 260;
			var pbuffer = new StringBuilder(capacity);
			GetCORSystemDirectory(pbuffer, capacity, ref capacity);
			return pbuffer.ToString();
		}

		/// <summary>
		/// Generiert ein natives Image eines .Net Assemblies
		/// </summary>
		/// <param name="filename">Der Pfad zu dem Assembly das optimiert werden soll.</param>
		protected void NGenInstall(string filename) {
			if (string.IsNullOrEmpty(m_clrDirectory)) {
				m_clrDirectory = GetClrInstallationDirectory();
			}
			var process = new Process();
			process.StartInfo.FileName = Path.Combine(m_clrDirectory, "ngen.exe");
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Arguments = " install \"" + filename + "\" /nologo /silent";
			process.Start();
			process.WaitForExit(60*1000);
		}

		/// <summary>
		/// Entfernt ein Image aus dem Cache der natives Images auf dem Computer.
		/// </summary>
		/// <param name="filename">Der Dateiname zu dem Assembly das entfernt werden soll.</param>
		protected void NGenUninstall(string filename) {
			if (string.IsNullOrEmpty(m_clrDirectory)) {
				m_clrDirectory = GetClrInstallationDirectory();
			}

			var process = new Process();
			process.StartInfo.FileName = Path.Combine(m_clrDirectory, "ngen.exe");
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Arguments = " uninstall \"" + filename + "\" /nologo /silent";
			process.Start();
			process.WaitForExit(60*1000);
		}

		#endregion

		#region " Dateizugriffsberechtigungen "

		/// <summary>
		/// Setzt volle Zugriffsrechte für einen bestimmten Ordner für den angemeldeten Benutzer.
		/// </summary>
		/// <param name="path">Der Ordner für welchen die Zugriffsrechte geändert werden sollen.</param>
		/// <returns>Gibt 'True' zurück wenn die Zugriffsrechte erfolgreich gesetzt wurden, andernfalls 'False'</returns>
		protected bool SetDirectoryAccessControl(string path) {
			try {
				var ds = new DirectorySecurity();
				var fs_rule = new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl,
				                                       AccessControlType.Allow);

				ds.SetAccessRule(fs_rule);

				Directory.SetAccessControl(path, ds);

				return true;
			}
			catch {
				return false;
			}
		}

		/// <summary>
		/// Setzt volle Zugriffsrechte für eine Datei für den angemeldeten Benutzer.
		/// </summary>
		/// <param name="filename">Die Datei von welcher die Zugriffsrechte geändert werden sollen.</param>
		/// <returns>Gibt 'True' zurück wenn die Zugriffsrechte erfolgreich gesetzt wurden, andernfalls 'False'.</returns>
		protected bool SetFileAccessControl(string filename) {
			try {
				var fs = new FileSecurity();
				var fs_rule = new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl,
				                                       AccessControlType.Allow);

				fs.SetAccessRule(fs_rule);

				File.SetAccessControl(filename, fs);

				return true;
			}
			catch {
				return false;
			}
		}

		#endregion

		#region Nested type: delRequestFileAccess

		private delegate DialogResult delRequestFileAccess(string Path);

		#endregion

		#region Nested type: delShowInteractionDialog

		private delegate DialogResult delShowInteractionDialog(interactionButtons Buttons, string Title, string Message);

		#endregion
	}
}