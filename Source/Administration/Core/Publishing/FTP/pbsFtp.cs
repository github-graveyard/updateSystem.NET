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
using System.Collections.Generic;
using System.Net.FtpClient;
using System.IO;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.Core.Publishing.FTP {

	[publishProviderDescription(Description = "publishProvider.pbsFtp.Description", Name = "publishProvider.pbsFtp.Name")]
	internal sealed class pbsFtp : publishBase {

		#region Konstanten für die Einstellungen

		public const string pbsFtpSetting_Host = "Host";
		public const string pbsFtpSetting_Port = "Port";
		public const string pbsFtpSetting_Protocol = "Protocol";
		public const string pbsFtpSetting_ConnectionType = "ConnectionType";
		public const string pbsFtpSetting_Username = "Username";
		public const string pbsFtpSetting_Password = "Password";
		public const string pbsFtpSetting_Directory = "Directory";

		#endregion

		public override publishResult publishUpdates() {
			var result = new publishResult {Provider = this};
			try {
				
				var updates = updatePackages;
				int maxFileCount = updates.Count + 2; // +2 wegen der Updatekonfiguration und dem updateInstaller
				int currentFileCount = 0;

				//Status übertragen
				onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
					currentFile = currentFileCount,
					currentFilename = string.Empty,
					maxFileCount = maxFileCount
				});

				//Stammverzeichnisse erstellen
				createRequiredDirectories();

				var client = buildFtpClient();
				var updateRootDirectory = getSetting(pbsFtpSetting_Directory);
				const string updateDirectory = "updates";
				var publishedFiles = new List<string>();
				try {

					//Client verbinden
					client.Connect();

					//Updatepakete und deren Changelogs übertragen
					client.SetWorkingDirectory(updateRootDirectory);
					client.SetWorkingDirectory(updateDirectory);
					foreach (var update in updates) {

						string localFilename = Path.Combine(localUpdateDirectory, update.getFilename());
						string remoteFilename = update.getFilename();

						string localChangelogFilename = Path.Combine(localUpdateDirectory, update.getChangelogFilename());
						string remoteChangelogFilename = update.getChangelogFilename();

						publishedFiles.Add(update.getFilename());
						publishedFiles.Add(update.getChangelogFilename());
						currentFileCount++;

						//Status übertragen
						onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
							currentFile = currentFileCount,
							currentFilename = update.getFilename(),
							maxFileCount = maxFileCount
						});

						//Überprüfen ob die Datei auf dem Server mit der lokalen identisch ist););
						if (client.FileExists(remoteFilename)) {
							long localFileSize = new FileInfo(localFilename).Length;
							long remoteFileSite = client.GetFileSize(remoteFilename);

							if (localFileSize == remoteFileSite)
								continue;
						}

						//Updatepaket übertragen
						using (var fsPackage = File.OpenRead(localFilename)) {
							writeLogEntry(logLevel.Info, string.Format("Upload {0}->{1}", localFilename, remoteFilename));
							client.Upload(fsPackage, remoteFilename);
						}

						//Changelog übertragen
						using (var fsChangelog = File.OpenRead(localChangelogFilename)) {
							writeLogEntry(logLevel.Info, string.Format("Upload {0}", remoteChangelogFilename));
							client.Upload(fsChangelog, remoteChangelogFilename);
						}
						update.publishDate = DateTime.UtcNow;
					}

					//Updatekonfiguration übertragen
					using (var msConfiguration = new MemoryStream(buildConfiguration())) {

						//Status übertragen
						currentFileCount++;
						onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
							currentFile = currentFileCount,
							currentFilename =
								configurationFilename,
							maxFileCount = maxFileCount
						});

						//Arbeitsverzeichnis ändern
						client.SetWorkingDirectory(updateRootDirectory);

						//Upload
						writeLogEntry(logLevel.Info, string.Format("Upload {0}", configurationFilename));
						client.Upload(msConfiguration, configurationFilename);
					}

					//updateInstaller übertragen
					//Status übertragen
					currentFileCount++;
					onPublishUpdateProgressChanged(new publishUpdateProgressChangedEventArgs {
						currentFile = currentFileCount,
						currentFilename =
							configurationFilename,
						maxFileCount = maxFileCount
					});

					bool updateInstallerUpdateRequired = true;
					if (client.FileExists(updateInstallerRemoteFilename)) {
						long localUpdateInstallerFileSize = new FileInfo(localUpdateInstallerPath).Length;
						long remoteUpdateInstallerFileSize = client.GetFileSize(updateInstallerRemoteFilename);

						//updateInstaller nur aktualisieren wenn sich die Dateien unterscheiden
						updateInstallerUpdateRequired = (localUpdateInstallerFileSize != remoteUpdateInstallerFileSize);
					}

					if (updateInstallerUpdateRequired) {
						// updateInstaller
						using (var fsUpdateInstaller = File.OpenRead(localUpdateInstallerPath)) {
							writeLogEntry(logLevel.Info, string.Format("Upload {0}", updateInstallerRemoteFilename));
							client.Upload(fsUpdateInstaller, updateInstallerRemoteFilename);
						}

						// updateInstaller-Manifest (enthällt Hash zum vergleichen)
						using (var msUpdateInstallerManifest = new MemoryStream(buildUpdateInstallerManifest())) {
							writeLogEntry(logLevel.Info, string.Format("Upload {0}", updateInstallerManifestFilename));
							client.Upload(msUpdateInstallerManifest, updateInstallerManifestFilename);
						}
					}

					//Updateverzeichnis aufräumen
					client.SetWorkingDirectory(updateDirectory);
					foreach (var remoteFile in client.GetListing())
						if (!publishedFiles.Contains(remoteFile.Name)) {
							writeLogEntry(logLevel.Info, string.Format("RemoveFile {0}", remoteFile.Name));
							client.RemoveFile(remoteFile.Name);
						}

					Settings.lastPublished = DateTime.Now;
				}
				finally { // In jedem Fall immer dafür sorgen, dass die Verbindung korrekt geschlossen wird.
					if (client.Connected)
						client.Disconnect();
					client.Dispose();
				}

			}
			catch (Exception exc) {
				writeLogException(exc);
				result.Error = exc;
			}
			return result;
		}

		public override string Id {
			get { return "{f0fc7fdd-cc06-4f94-b625-46af5535fa93}"; }
		}

		public override Type settingsView {
			get { return typeof(pbsftpSettingsControl); }
		}

		protected override void createRequiredDirectories() {
			var client = buildFtpClient();
			try {
				client.Connect();
				string directory = getSetting(pbsFtpSetting_Directory);

				//TODO: 1.7 Rekursiv den FTP-Verzeichnisbaum durchgehen und nicht vorhandene Ordner erstellen

				//Basisverzeichnis erstelllen
				if ((!client.DirectoryExists(directory) || !client.FileExists(directory)) && directory.Length > 1) {
					writeLogEntry(logLevel.Info, string.Format("Create Directory {0}", directory));
					//client.CreateDirectory(directory);
					createFtpDirectory(client, directory);
				}

				//Unterverzeichnisse erstellen
				client.SetWorkingDirectory(directory);
				foreach (string folder in requiredDirectories)
					if (!client.DirectoryExists(folder)) {
						writeLogEntry(logLevel.Info, string.Format("CreateDirectory {0}", folder));
						//client.CreateDirectory(folder);
						createFtpDirectory(client, folder);
					}
			}
			finally {
				if (client.Connected)
					client.Disconnect();
				client.Dispose();
			}
		}

		private void createFtpDirectory(FtpClient client, string directory) {
			try {
				if (!client.DirectoryExists(directory) && directory.Length > 1)
					client.CreateDirectory(directory);
			}
			catch (FtpException ftpExc) {
				if (ftpExc.Message.Contains("file or directory already exists"))
					writeLogEntry(logLevel.Error, string.Format("client.CreateDirectory fehlgeschlagen: {0}", ftpExc.Message));
				else
					throw;
			}
		}

		/// <summary>Erstellt aus den Einstellungen eine neue Instanz des FtpClient.</summary>
		private FtpClient buildFtpClient() {
			var client = new FtpClient {
				Server = getSetting(pbsFtpSetting_Host),
				Port = int.Parse(getSetting(pbsFtpSetting_Port, "21")),
				Username = getSetting(pbsFtpSetting_Username),
				Password = getSetting(pbsFtpSetting_Password),
				ReadTimeout = 5000,
				WriteTimeout = 5000
			};

			switch (getSetting(pbsFtpSetting_Protocol, "0")) {
				case "0":
					client.SslMode = FtpSslMode.None; break;
				case "1":
					client.SslMode = FtpSslMode.Explicit; break;
				case "2":
					client.SslMode = FtpSslMode.Implicit; break;
			}

			client.DataChannelType = (getSetting(pbsFtpSetting_ConnectionType, "0") == "0"
										? FtpDataChannelType.Passive
										: FtpDataChannelType.Active);
			
			

			client.InvalidCertificate += client_InvalidCertificate;
			client.ResponseReceived += client_ResponseReceived;
			return client;
		}

		void client_ResponseReceived(string status, string response) {
			if(Session.Settings.logFtpOutput)
				writeLogEntry(logLevel.Info, string.Format("[{0}] {1}", status, response));
		}

		void client_InvalidCertificate(FtpChannel c, InvalidCertificateInfo e) {
			e.Ignore = true;
		}

	}
}