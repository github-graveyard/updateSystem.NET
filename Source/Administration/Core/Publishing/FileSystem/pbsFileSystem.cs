using System.IO;
using System;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.Application;
namespace updateSystemDotNet.Administration.Core.Publishing.FileSystem {
	
	[publishProviderDescription(Description = "Veröffentlicht Ihre Aktualisierungen an einem Ort im Windowsdateisystem oder einer Netzwerkfreigabe.", Name = "Dateisystem")]
	internal sealed class pbsFileSystem : publishBase {
		
		public override publishResult publishUpdates() {
			var result = new publishResult {Provider = this};
			try {
				//Benötigte Verzeichnisse erstellen
				createRequiredDirectories();

				//Für diesen Provider notwendige Updatepakete ermitteln
				var updates = updatePackages;
				int maxFileCount = updates.Count + 2; // +2 wegen der Updatekonfiguration und dem updateInstaller
				int currentFileCount = 0;

				//Eine Liste mit allen Dateien die Veröffentlicht wurden, alle Dateien im Updateverzeichnis
				//die nicht auf dieser Liste stehen, werden gelöscht.
                var publishedFiles = new List<string>();


				//Updates übertragen               
				foreach(var package in updates) {
					currentFileCount++;
					
					//Status mitteilen
					onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
					                                                                           	currentFile = currentFileCount,
					                                                                           	currentFilename = package.getFilename(),
					                                                                           	maxFileCount = maxFileCount
					                                                                           });

					publishedFiles.Add(package.getFilename());
					publishedFiles.Add(package.getChangelogFilename());

					string localUpdateFilename = Path.Combine(localUpdateDirectory, package.getFilename());
					string remoteUpdateFilename = Path.Combine(Path.Combine(targetDirectory, "updates"), package.getFilename());

					//Wenn die entfernte Datei existiert, vergleichen wir die beiden Updatepakete, ob eine Übertragung wirklich notwendig ist.
					if(File.Exists(remoteUpdateFilename)) {
						var fiLocal = new FileInfo(localUpdateFilename);
						var fiRemote = new FileInfo(remoteUpdateFilename);
						if(fiLocal.Length == fiRemote.Length)
							continue;
					}

					//Updatepaket kopieren
					writeLogEntry(logLevel.Info, string.Format("FileCopy {0} -> {1}", localUpdateFilename, remoteUpdateFilename));
					File.Copy(localUpdateFilename, remoteUpdateFilename, true);

					//Changelog kopieren
					string localChangelogFilename = Path.Combine(localUpdateDirectory, package.getChangelogFilename());
					string remoteChangelogFilename = Path.Combine(Path.Combine(targetDirectory, "updates"),
					                                              package.getChangelogFilename());

					writeLogEntry(logLevel.Info, string.Format("FileCopy {0} -> {1}", localChangelogFilename, remoteChangelogFilename));
					File.Copy(localChangelogFilename, remoteChangelogFilename, true);

					package.publishDate = DateTime.UtcNow;
				}

				//Updatekonfiguration übertragen
				using(var fsConfiguration = new FileStream(Path.Combine(targetDirectory, configurationFilename), FileMode.Create)) {

					//Status mitteilen
					currentFileCount++;
					onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
					                                                                           	currentFile = currentFileCount,
					                                                                           	currentFilename = configurationFilename,
					                                                                           	maxFileCount = maxFileCount
					                                                                           });

					//Updatekonfiguration erstellen
					byte[] configuration = buildConfiguration();
					writeLogEntry(logLevel.Info, string.Format("WriteFile {0}", configurationFilename));
					fsConfiguration.Write(configuration, 0, configuration.Length);
				}

				//updateInstaller aktualisieren
				currentFileCount++;
				onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
				                                                                         	currentFile = currentFileCount,
				                                                                         	currentFilename = configurationFilename,
				                                                                         	maxFileCount = maxFileCount
				                                                                         });
				bool updateInstallerUpdateRequired = true;
				if(File.Exists(Path.Combine(targetDirectory, updateInstallerRemoteFilename))) {
					var fiLocalUpdateInstaller = new FileInfo(localUpdateInstallerPath);
					var fiRemoteUpdateInstaller = new FileInfo(Path.Combine(targetDirectory, updateInstallerRemoteFilename));
					updateInstallerUpdateRequired = (fiLocalUpdateInstaller.Length != fiRemoteUpdateInstaller.Length);
				}
				if(updateInstallerUpdateRequired) {
					//updateInstaller aktualisieren
					writeLogEntry(logLevel.Info,string.Format("FileCopy {0} -> {1}", localUpdateInstallerPath, updateInstallerRemoteFilename));
					File.Copy(localUpdateInstallerPath, Path.Combine(targetDirectory, updateInstallerRemoteFilename), true);

					//updateInstaller Manifest aktualisieren                   
					using(var fsUpdateInstallerManifest = new FileStream(Path.Combine(targetDirectory, updateInstallerManifestFilename), FileMode.Create)) {
						byte[] updateInstallerManifest = buildUpdateInstallerManifest();
						fsUpdateInstallerManifest.Write(updateInstallerManifest, 0, updateInstallerManifest.Length);
					}
				}

				//Updateverzeichnis aufräumen
				foreach (string file in Directory.GetFiles(Path.Combine(targetDirectory, "updates")))
					if (!publishedFiles.Contains(Path.GetFileName(file))) {
						writeLogEntry(logLevel.Info, string.Format("FileDelete {0}", file));
						File.Delete(file);
					}

				//Datum der letzten Veröffentlichung setzen
				Settings.lastPublished = DateTime.UtcNow;

			}
			catch(Exception exc) {
				writeLogException(exc);
				result.Error = exc;
			}
			return result;
		}

		public override string Id {
			get { return "{3cc9c6c7-4cfe-4168-a8ad-6de6bb833528}"; }
		}

		public override Type settingsView {
			get { return typeof (pbsfsSettingsControl); }
		}

		protected override void createRequiredDirectories() {
			string target = targetDirectory;
			if (string.IsNullOrEmpty(target))
				throw new publishException("Es wurde kein Zielverzeichnis angegeben.", this);

			//Stammverzeichnis anlegen, wenn's nicht exisitent.
			if (!Directory.Exists(target)) {
				writeLogEntry(logLevel.Info,string.Format("CreateDirectory {0}", target));
				Directory.CreateDirectory(target);
			}

			//Unterverzeichnisse anlegen
			foreach(string subfolder in requiredDirectories) {
				string subDirectory = Path.Combine(target, subfolder);
				if (!Directory.Exists(subDirectory)) {
					writeLogEntry(logLevel.Info, string.Format("CreateDirectory {0}", subDirectory));
					Directory.CreateDirectory(subDirectory);
				}
			}
		}

		private string targetDirectory { get { return getSetting("target", string.Empty); } }

	}
}
