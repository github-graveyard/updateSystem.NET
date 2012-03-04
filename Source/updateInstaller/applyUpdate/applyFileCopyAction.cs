using System;
using System.Collections.Generic;
using System.IO;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyFileCopyAction : applyUpdateBase {
		private readonly List<rollbackFile> m_rollbackFiles = new List<rollbackFile>();

		public applyFileCopyAction(actionBase action, InternalConfig config, updatePackage currentPackage)
			: base(action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyFileCopyAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (fileCopyAction) Action;

			//Pfad zu dem heruntergeladenen Updatepaket erstellen.
			string packageFile = Path.Combine(currentConfiguration.Settings.downloadLocation, currentPackage.getFilename());

			//Temporäres Verzeichnis zum sichern von Dateien
			string tempDirectory = currentConfiguration.Settings.downloadLocation;

			//Wenn das Updatepaket nicht exisitiert, dann eine FileNotFoundException werfen.
			if (!File.Exists(packageFile)) {
				throw new FileNotFoundException(packageFile);
			}

			var rnd = new Random(Environment.TickCount);

			int fileCounter = 0;
			foreach (FileType file in action.Files) {
				string fileDirectory = ParsePath(file.Destination);
				string fileCompletePath = Path.Combine(fileDirectory, file.Filename);

				//Überprüfe die filecopyflags
				switch (file.copyFlag) {
					case fileCopyFlags.OnlyIfExists:
						if (!File.Exists(fileCompletePath)) {
							fileCounter++;
							continue;
						}
						break;
					case fileCopyFlags.OnlyIfNotExists:
						if (File.Exists(fileCompletePath)) {
							fileCounter++;
							continue;
						}
						break;
				}

				//Überprüfe ob Verzeichnis existiert
				if (!Directory.Exists(fileDirectory)) {
					Directory.CreateDirectory(fileDirectory);
					SetDirectoryAccessControl(fileDirectory);
				}

				//Überprüfe ob die Datei existiert
				if (File.Exists(fileCompletePath)) {
					string rbFilename = Path.Combine(tempDirectory,
					                                 string.Format("{0}_rollback_{1}", file.Filename, rnd.Next(5000, 10000)));
					//Wenn die Datei noch nicht gesichert wurde, dann sichern.
					if (!rbFileExists(fileCompletePath)) {
						onProgressChanged(string.Format(Language.GetString("applyFileCopyAction_progressStep_1"), file.Filename),
						                  Percent(fileCounter, action.Files.Count));
						copyFile(fileCompletePath, rbFilename);
					}

					//Versuche Datei zu löschen
					if (deleteFile(fileCompletePath)) {
						m_rollbackFiles.Add(new rollbackFile(fileCompletePath, rbFilename));
					}
					else {
						throw new userCancelledException();
					}
				}
				else {
					m_rollbackFiles.Add(new rollbackFile(fileCompletePath, string.Empty));
				}

				onProgressChanged(string.Format(Language.GetString("applyFileCopyAction_progressStep_2"), file.Filename),
				                  Percent(fileCounter, action.Files.Count));
				byte[] data = Decompress(accessUpdatePackage(packageFile, file.ID));
				onProgressChanged(string.Format(Language.GetString("applyFileCopyAction_progressStep_3"), file.Filename),
				                  Percent(fileCounter, action.Files.Count));
				File.WriteAllBytes(fileCompletePath, data);

				SetFileAccessControl(fileCompletePath);

				//NGen Image erzeugen
				//if (Core.Helper.IsNetAssembly(fileCompletePath))
				//{
				//    //onProgressChanged(string.Format("Optimiere .Net Assembly '{0}'...", file.Filename), Percent(fileCounter, action.Files.Count));
				//    //NGenUninstall(fileCompletePath);
				//    //NGenInstall(fileCompletePath);
				//}

				if (fileCompletePath.EndsWith(".exe") && currentConfiguration.ServerConfiguration.generateNativeImages &&
				    assemblyInfo.FromFile(fileCompletePath) != null) {
					onProgressChanged(Language.GetString("applyFileCopyAction_progressStep_4"),
					                  Percent(fileCounter, action.Files.Count));
					NGenUninstall(fileCompletePath);
					NGenInstall(fileCompletePath);
				}

				fileCounter++;
			}
		}

		/// <summary>
		/// Funktion zum Überprüfen, ob bereits eine Datei mit dem gleichen Pfad an der Rollback-List vorhanden ist.
		/// </summary>
		/// <param name="path">Der Pfad der Überprüft werden soll.</param>
		/// <returns>Gibt True zurück wenn diese Datei bereits existiert, andernfalls False.</returns>
		private bool rbFileExists(string path) {
			foreach (rollbackFile item in m_rollbackFiles) {
				if (path.Equals(item.realPath)) {
					return true;
				}
			}
			return false;
		}

		public override void rollbackAction() {
			int fileCounter = 0;
			foreach (rollbackFile rbFile in m_rollbackFiles) {
				onProgressChanged(
					string.Format(Language.GetString("applyFileCopyAction_rollback"), new FileInfo(rbFile.realPath).Name),
					Percent(fileCounter, m_rollbackFiles.Count));
				if (!string.IsNullOrEmpty(rbFile.tempPath)) {
					File.Delete(rbFile.realPath);
					copyFile(rbFile.tempPath, rbFile.realPath);
				}
				else {
					File.Delete(rbFile.realPath);
				}
				fileCounter++;
			}
		}

		#region Nested type: rollbackFile

		private struct rollbackFile {
			private readonly string m_realPath;
			private readonly string m_tempPath;

			public rollbackFile(string realPath, string tempPath) {
				m_realPath = realPath;
				m_tempPath = tempPath;
			}

			public string realPath {
				get { return m_realPath; }
			}

			public string tempPath {
				get { return m_tempPath; }
			}
		}

		#endregion
	}
}