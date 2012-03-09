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
using System.Diagnostics;
using System.IO;
using System.Security;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;
using updateSystemDotNet.Updater.Win32;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyStartProcessAction : applyUpdateBase {
		public applyStartProcessAction(actionBase action, InternalConfig config, updatePackage currentPackage)
			: base(action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyStartProcessAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (startProcessAction) Action;

			string filePath = ParsePath(action.Path);
			string processVerb = string.Empty;

			//Wenn die Datei nicht existiert, Aktion abbrechen
			if (!File.Exists(filePath)) {
				return;
			}

			//Wenn der Prozess bereits läuft und ein entsprechendes Flag gesetzt ist, dann Abbrechen
			if (action.dontRunIfExists && isProcessRunnig(new FileInfo(filePath).Name)) {
				return;
			}

			onProgressChanged(
				string.Format(Language.GetString("applyStartProcessAction_progress"), new FileInfo(filePath).Name), 100);

			//Überprüfe, ob der Prozess Administratorrechte einfordert
			if (action.needElevatedRights) {
				//Wenn der aktuelle Prozess bereits über Adminrechte verfügt
				if (isAdmin) {
					//Digitale Signatur überprüfen, wenn das fehlschlägt Exception werfen
					//SecurityLevel auswerten
					switch (currentConfiguration.Settings.processSafetyLevel) {
						case processSafetyLevel.AskAlways:
							if (!Security.VerifySignedFile(ownerForm, filePath, true, true)) {
								throw new SecurityException(string.Format(Language.GetString("applyStartProcessAction_exception"), filePath));
							}
							break;
						case processSafetyLevel.AskIfUnsigned:
							if (!Security.VerifySignedFile(ownerForm, filePath, true, false)) {
								throw new SecurityException(string.Format(Language.GetString("applyStartProcessAction_exception"), filePath));
							}
							break;
					}
				}
				else {
					processVerb = "runas";
				}
			}
			else {
				if (isVistaOrLater && isAdmin)
					//Wenn Vista und der Benutzer Administrator ist, dann einen Prozess ohne Admintoken erstellen
				{
					IntPtr hProcess = IntPtr.Zero;
					int success = Security.ExecRequireNonAdmin(ownerForm, filePath, action.Arguments, out hProcess);

					if (action.waitForExit) //Auf das Ende des Prozesses warten
					{
						if (success == 0) {
							Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(filePath));
							if (processes.Length > 0) {
								processes[0].WaitForExit();
							}
						}
					}
					//Testen!!!!
					//Marshal.Release(hProcess);

					//Funktion hier abbrechen
					return;
				}
			}

			var p = new Process();
			var psi = new ProcessStartInfo();
			psi.FileName = filePath;
			psi.Arguments = action.Arguments;
			psi.Verb = processVerb;
			p.StartInfo = psi;
			p.Start();

			if (action.waitForExit) {
				p.WaitForExit();
			}
		}

		/// <summary>
		/// Überprüft ob ein Prozess läuft.
		/// </summary>
		/// <param name="filename">Der Name des Prozesses der Überprüft werden soll.</param>
		/// <returns>Gibt True zurück wenn der Prozess bereits läuft, andernfalls False.</returns>
		private bool isProcessRunnig(string filename) {
			try {
				string processname = filename;

				//Entferne die Endung der Datei wenn diese vorhanden ist.
				processname = processname.Replace(".exe", "");

				return (Process.GetProcessesByName(processname).Length > 0);
			}
			catch {
				return false;
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}