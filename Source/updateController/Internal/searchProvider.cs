using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using updateSystemDotNet.Core;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal {
	internal sealed class searchProvider {
		private readonly updateController _controllerInstance;

		private WebClient _wcl;

		public searchProvider(updateController instance) {
			_controllerInstance = instance;
			foundUpdates = new List<updatePackage>();
		}

		private WebClient webclient {
			get {
				if (_wcl == null) {
					_wcl = new WebClient();
					_wcl.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

					//SSLFehler umleiten und ignorieren
					ServicePointManager.ServerCertificateValidationCallback += OnCheckSSLCert;

					//Proxy setzen, falls notwendig
					if (_controllerInstance.proxyEnabled) {
						_wcl.Proxy = new WebProxy(_controllerInstance.proxyUrl, _controllerInstance.proxyPort);
						if (!string.IsNullOrEmpty(_controllerInstance.proxyUsername))
							_wcl.Proxy.Credentials = new NetworkCredential(_controllerInstance.proxyUsername,
							                                               _controllerInstance.proxyPassword);
						else if (_controllerInstance.proxyUseDefaultCredentials)
							_wcl.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
					}

					//Anmeldeinformationen setzen, falls notwendig
					if (_controllerInstance.authenticationMode == authenticationModes.Credentials)
						_wcl.Credentials = new NetworkCredential(_controllerInstance.authenticationUsername,
						                                         _controllerInstance.authenticationPassword);
				}
				return _wcl;
			}
		}

		public updateConfiguration currentConfiguration { get; private set; }

		public List<updatePackage> foundUpdates { get; set; }

		public changelogDictionary correspondingChangelogs { get; set; }

		private static bool OnCheckSSLCert(object sender, X509Certificate certificate, X509Chain chain,
		                                   SslPolicyErrors sslPolicyErrors) {
			return true;
		}

		private void downloadConfig() {
			//Updatekonfiguration herunterladen
			byte[] rawUpdateConfiguration =
				webclient.DownloadData(internalHelper.prepareUpdateLocation(_controllerInstance.updateLocation) + "update.xml");
			var sContainer = new SecureContainer();
			sContainer.Load(rawUpdateConfiguration);
			currentConfiguration = Serializer.Deserialize(sContainer.Content);

			//Signatur der Updatekonfiguration überprüfen
			/*string publicKey = (string.IsNullOrEmpty(_controllerInstance.publicKey) ? currentConfiguration.PublicKey : _controllerInstance.publicKey);
			if (!Core.RSA.validateSign(sContainer.Content, sContainer.Signature, publicKey))
				throw new Exception(Language.GetString("searchProvider_invalidSignatureException"));*/

			//Sende Statistiken über die Updateanfrage
			var log = new updateLogRequest(_controllerInstance, currentConfiguration);
			lock (log)
				log.sendRequest(0);
		}

		private void checkForNewPackages() {
			var newUpdates = new SortedList<releaseInfo, updatePackage>();

			//Alle Pakete vorher schon sortieren, um den "SP-Bug" zu beheben.
			var allUpdates = new SortedList<releaseInfo, updatePackage>();
			foreach (updatePackage uPackage in currentConfiguration.updatePackages)
				allUpdates.Add(uPackage.releaseInfo, uPackage);

			foreach (var package in allUpdates) {
				//Überspringe Update wenn noch nicht veröffentlicht
				if (!package.Value.Published)
					continue;

				//Überprüfe ob die Zielarchitektur stimmt
				if (package.Value.TargetArchitecture != updatePackage.SupportedArchitectures.Both &&
				    package.Value.TargetArchitecture != Helper.GetArchitecture())
					continue;

				if (package.Value.releaseInfo > _controllerInstance.releaseInfo) {
					//Überspringe das Update wenn der Releasetyp nicht zum eingestellten Filter passt.
					if (!_controllerInstance.releaseFilter.Contains(package.Value.releaseInfo.Type))
						continue;

					//Anfrage an das Programm schicken, ob das Update bestätigt werden soll.
					if (!_controllerInstance.onConfirmUpdatePackage(new confirmUpdatePackageEventArgs(package.Value)))
						continue;

					//Wenn dieses Updatepaket nur für bestimmte Versionen verfügbar sein soll
					if (package.Value.UseOwnVersionList) {
						bool versionFound = false;

						foreach (VersionEx version in package.Value.OwnVersionList)
							if (version.ToVersion().Equals(new Version(_controllerInstance.releaseInfo.Version))) {
								versionFound = true;
								break;
							}

						if (!versionFound)
							continue;
					}

					//Wenn das aktuelle Update ein ServicePack ist, dann alle vorherigen entfernen
					if (package.Value.isServicePack)
						newUpdates.Clear();
					newUpdates.Add(package.Value.releaseInfo, package.Value);
				}
			}

			foundUpdates.Clear();
			foreach (var item in newUpdates) {
				foundUpdates.Add(item.Value);
			}
		}

		private void downloadChangelogs() {
			correspondingChangelogs = new changelogDictionary();
			foreach (updatePackage package in foundUpdates) {
				//Changelog herunterladen
				byte[] rawChangelogData = webclient.DownloadData(string.Format("{0}{1}",
				                                                               internalHelper.prepareUpdateLocation(
				                                                               	_controllerInstance.updateLocation, "updates"),
				                                                               package.getChangelogFilename()));
				using (var msXmlStream = new MemoryStream(rawChangelogData)) {
					var xmlChangelog = new XmlDocument();
					xmlChangelog.Load(msXmlStream);
					correspondingChangelogs.Add(new enhancedVersion(package.releaseInfo, package.TargetArchitecture),
					                            new changelogDocument(xmlChangelog));
				}
			}
		}

		public void executeSearch() {
			//STEP 1: Updatekonfiguration herunterladen
			downloadConfig();

			//STEP 2: Nach neuen Updates suchen
			checkForNewPackages();

			//STEP 3: Changelogs herunterladen
			if (foundUpdates.Count > 0)
				downloadChangelogs();
		}
	}
}