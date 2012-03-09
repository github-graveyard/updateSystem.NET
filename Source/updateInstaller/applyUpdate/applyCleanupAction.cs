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
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyCleanupAction : applyUpdateBase {
		private string _registryHive =
			@"SOFTWARE\updateSystem.Net\obsoleteInstallations";

		public applyCleanupAction(actionBase action, InternalConfig config)
			: base(action, config, new updatePackage()) {
		}

		public override string actionName {
			get { return Language.GetString("applyCleanupAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			try {
				var updateFiles =
					new List<string>(Directory.GetFiles(currentConfiguration.Settings.downloadLocation, "*",
					                                    SearchOption.AllDirectories));
				int fileCounter = 0;
				foreach (string file in updateFiles) {
					try {
						onProgressChanged(string.Format(Language.GetString("applyCleanupAction_progress"), Path.GetFileName(file)),
						                  Percent(fileCounter, updateFiles.Count));
						fileCounter++;
						File.Delete(file);
					}
					catch {
						continue;
					}
				}

				//Alte Updatedateien löschen
				cleanObsoleteData();
				//Aktuelle Installation zur liste alter Daten hinzufügen
				writeObsoleteData();
			}
			catch {
				return;
			}
		}

		private void cleanObsoleteData() {
			try {
				//Alte Items auslesen
				string[] itemIDs = Registry.CurrentUser.OpenSubKey(_registryHive).GetValueNames();
				foreach (string item in itemIDs) {
					var oldDirectoryPath =
						(string) Registry.CurrentUser.OpenSubKey(_registryHive).GetValue(item, string.Empty);

					//Altes Verzeichnis löschen
					if (Directory.Exists(oldDirectoryPath)) {
						Directory.Delete(oldDirectoryPath, true);
					}

					Registry.CurrentUser.OpenSubKey(_registryHive, true).DeleteValue(item);
				}
			}
			catch //Catchen bringt hier eh nichts mehr.
			{
			}
		}

		private void writeObsoleteData() {
			try {
				Registry.CurrentUser.CreateSubKey(_registryHive);

				Registry.CurrentUser.OpenSubKey(_registryHive, true).SetValue(
					currentConfiguration.Settings.ProjektID,
					currentConfiguration.Settings.downloadLocation);
			}
			catch // Auch hier bringt das catchen nichts.
			{
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}