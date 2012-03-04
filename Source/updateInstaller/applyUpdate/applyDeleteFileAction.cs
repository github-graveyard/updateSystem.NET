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