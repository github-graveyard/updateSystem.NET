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
using System.IO;
using System;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.Application;
namespace updateSystemDotNet.Administration.Core.Publishing.FileSystem {
	
	[publishProviderDescription(Description = "publishProvider.pbsFileSystem.Description", Name = "publishProvider.pbsFileSystem.Name")]
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
				Settings.lastPublished = DateTime.Now;

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
