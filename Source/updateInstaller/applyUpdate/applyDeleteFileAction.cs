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
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyDeleteFileAction : applyUpdateBase {
		private readonly Dictionary<string, string> m_backupFiles = new Dictionary<string, string>();

		public applyDeleteFileAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyDeleteFileAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (deleteFilesAction) Action;
			string basePath = ParsePath(action.Path);
			string tempPath = currentConfiguration.Settings.downloadLocation;
			int fileCount = 0;

			foreach (string file in action.filesToRemove) {
				string filePath = Path.Combine(basePath, file);
				if (File.Exists(filePath)) {
					//Status senden
					onProgressChanged(string.Format(Language.GetString("applyDeleteFileAction_progress"), file),
					                  Percent(fileCount, action.filesToRemove.Count));

					//Datei sichern
					string tempFilename = Path.Combine(tempPath, file);
					copyFile(filePath, tempFilename);

					//Versuchen die Datei zu löschen
					if (deleteFile(filePath)) {
						m_backupFiles.Add(filePath, tempFilename);
					}
					else {
						throw new IOException(string.Format(Language.GetString("applyDeleteFileAction_exception"), filePath));
					}
				}
				fileCount++;
			}
		}

		public override void rollbackAction() {
			int fileCount = 0;
			foreach (var backupFile in m_backupFiles) {
				onProgressChanged(string.Format(Language.GetString("applyDeleteFileAction_rollback"), backupFile.Key),
				                  Percent(fileCount, m_backupFiles.Count));
				copyFile(backupFile.Value, backupFile.Key);
				File.Delete(backupFile.Value);
				fileCount++;
			}
		}
	}
}