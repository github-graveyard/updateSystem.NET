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
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using updateSystemDotNet.Administration.Core.Application;
using System;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core;
using System.IO;
using RSA = updateSystemDotNet.Core.RSA;

namespace updateSystemDotNet.Administration.Core.Publishing {
	internal abstract class publishBase : IPublishProvider {

		#region IPublishProvider Member

		public event EventHandler<publishUpdateProgressChangedEventArgs> publishUpdateProgressChanged;

		protected void onPublishUpdateProgressChanged(publishUpdateProgressChangedEventArgs e) {
			EventHandler<publishUpdateProgressChangedEventArgs> handler = publishUpdateProgressChanged;
			if (handler != null) handler(this, e);
		}

		public applicationSession Session {
			get;
			set;
		}

		public publishSettings Settings {
			get;
			set;
		}

		public abstract publishResult publishUpdates();

		public abstract string Id { get; }

		public abstract Type settingsView { get; }

		#endregion

		public publishSettingsBaseControl createSettingsControl() {
			var instance = (publishSettingsBaseControl) Activator.CreateInstance(settingsView);
			instance.Session = Session;
			instance.Provider = this;
			return instance;
		}

		#region Eigenschaften 

		/// <summary>Gibt ein Array mit Verzeichnissen zurück die auf dem Zielhost vorhanden sein müssen.</summary>
		protected string[] requiredDirectories { get { return new[] { "updates" }; } }

		/// <summary>Gibt alle Updatepakete zurück, die mit diesem Provider veröffentlicht werden sollen.</summary>
		protected List<updatePackage> updatePackages {
			get {
				var list = new List<updatePackage>();
				foreach (var package in Session.currentProject.updatePackages)
					if (Session.updateFactory.isUpdateLinked(package, this) && package.Published)
						list.Add(package);
				return list;
			}
		}

		/// <summary>Gibt den Namen der Updatekonfiguration zurück.</summary>
		protected string configurationFilename { get { return "update.xml"; } }

		/// <summary>Gibt das lokale Verzeichnis zurück, in welchem alle Updates gespeichert werden.</summary>
		protected string localUpdateDirectory { get { return Path.Combine(Path.GetDirectoryName(Session.currentProjectPath), "Updates"); } }

		/// <summary>Der Name des updateInstallers auf dem Zielsystem.</summary>
		protected string updateInstallerRemoteFilename { get { return "updateInstaller.zip"; } }

		/// <summary>Name der Manifestdatei.</summary>
		protected string updateInstallerManifestFilename { get { return "updateInstaller.xml"; } }

		/// <summary>Der Name des updateInstallers auf dem lokalen PC.</summary>
		protected string updateInstallerFilename { get { return "updateInstaller.exe"; } }

		/// <summary>Der Pfad zum lokal installierten updateInstaller.</summary>
		protected string localUpdateInstallerPath { get { return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"), updateInstallerFilename); } }

		#endregion

		#region Veröffentlichungsprozess

		/// <summary>Erstellt alle benötigten Verzeichnisse.</summary>
		protected abstract void createRequiredDirectories();

		#endregion

		/// <summary>Schreibt einen neuen Providerspezifischen Logeintrag.</summary>
		protected void writeLogEntry(logLevel level, string message) {
			Session.Log.writeKeyValue(level,
			                          string.Format("[{0}] [{1}]", Session.publishFactory.availableProvider[GetType()].Name,
			                                        Settings.Name),
			                          message
				);
		}
		/// <summary>Schreibt eine Exception ins Anwendungslog.</summary>
		protected void writeLogException(Exception exc) {
			writeLogEntry(logLevel.Error, "Excpetion");
			Session.Log.writeException(exc);
		}

		/// <summary>Bietet sicheren Zugriff auf die Einstellungen der Providers.</summary>
		protected string getSetting(string key) {
			return getSetting(key, string.Empty);
		}
		/// <summary>Bietet sicheren Zugriff auf die Einstellungen der Providers.</summary>
		protected string getSetting(string key, string defaultValue) {
			return Settings.customSettings.ContainsKey(key) ? Settings.customSettings[key] : defaultValue;
		}

		/// <summary>Erstellt eine neue Updatekonfiguration mit den aktuellen Daten aus dem Projekt.</summary>
		protected byte[] buildConfiguration() {
			var configuration = new updateConfiguration {
			                                            	projectId = Session.currentProject.projectId,
			                                            	PublicKey = Session.currentProject.keyPair.publicKey,
			                                            	applicationName = Session.currentProject.projectName
			                                            };

			if (Session.currentProject.updateLogEnabled && Session.currentProject.updateLogUser.Verified)
				configuration.linkedUpdateLogAccount = new updateLogLinkedAccount
				                                       {serverUrl = Session.currentProject.updateLogUser.serverUrl};
			else
				configuration.linkedUpdateLogAccount = null;

			configuration.generateNativeImages = Session.currentProject.generateNativeImages;
			configuration.startParameterSuccess = Session.currentProject.updateParameterSuccess;
			configuration.startParameterFailed = Session.currentProject.updateParameterFailed;
			configuration.setupId = Session.currentProject.updateSetupId;

			//Updatepakete hinzufügen
			foreach (var package in updatePackages)
				configuration.updatePackages.Add(package);

			//Konfiguration signieren und speichern
			var configurationContainer = new SecureContainer {Content = Serializer.Serialize(configuration)};
			configurationContainer.Signature = RSA.Sign(configurationContainer.Content, Session.currentProject.keyPair.privateKey);
			return configurationContainer.Save();
		}

		#region updateInstaller Manifest

		protected byte[] buildUpdateInstallerManifest() {
			var manifest = new XmlDocument();
			XmlNode root = manifest.CreateElement("updateSystemDotNet.updateInstaller");
			root.AppendChild(createTextElement(manifest, "Version",
			                                   FileVersionInfo.GetVersionInfo(localUpdateInstallerPath).ProductVersion));
			root.AppendChild(createTextElement(manifest, "Hash", calculateHash(File.ReadAllBytes(localUpdateInstallerPath))));

			manifest.AppendChild(root);
			using (var msManifest = new MemoryStream()) {
				using (var writer = new StreamWriter(msManifest, Encoding.UTF8))
					manifest.Save(writer);
				return msManifest.ToArray();
			}
		}

		private XmlNode createTextElement(XmlDocument document, string name, string text) {
			XmlNode node = document.CreateElement(name);
			node.InnerText = text;
			return node;
		}

		private string calculateHash(byte[] input) {
			byte[] hash = SHA512.Create().ComputeHash(input);
			var hashCode = new StringBuilder();
			foreach (byte b in hash)
				hashCode.Append(b.ToString("x"));
			return hashCode.ToString();
		}

		#endregion

	}
}
