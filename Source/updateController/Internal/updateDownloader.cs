/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal {
	/// <summary>
	/// Client zum herunterladen der Updates.
	/// </summary>
	internal class updateDownloader {
		private readonly updateConfiguration _currentConfiguration;
		private readonly updateController _currentInstance;
		private readonly string _highestVersion;
		private readonly string _tempDirectory;
		private readonly List<string> _urls;
		private readonly WebClient _wclDownload = new WebClient();
		private int _downloadCount;
		private bool _downloadFinished;
		private bool _statisticsSent;

		public updateDownloader(updateController instance, UpdateResult result) {
			_currentConfiguration = result.Configuration;
			_currentInstance = instance;
			_highestVersion = result.newUpdatePackages[result.newUpdatePackages.Count - 1].releaseInfo.Version;

			//WebClient initialisieren
			_wclDownload = new WebClient();

			_wclDownload.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

			//Proxyeinstellungen setzen
			if (instance.proxyEnabled) {
				_wclDownload.Proxy = new WebProxy(instance.proxyUrl, instance.proxyPort);
				if (!string.IsNullOrEmpty(instance.proxyUsername))
					_wclDownload.Proxy.Credentials = new NetworkCredential(instance.proxyUsername, instance.proxyPassword);
				else if (instance.proxyUseDefaultCredentials)
					_wclDownload.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
			}

			//Falls eine Authentifizierung erforderlich ist
			if (instance.authenticationMode == authenticationModes.Credentials) {
				_wclDownload.Credentials = new NetworkCredential(
					instance.authenticationUsername,
					instance.authenticationPassword);
			}

			//SSLFehler umleiten und ignorieren
			ServicePointManager.ServerCertificateValidationCallback += OnCheckSSLCert;

			//Urls erzeugen
			//updateInstaller 
			//UpdateInstaller - Manifest
			_urls = new List<string> {
										internalHelper.prepareUpdateLocation(instance.updateLocation) + "updateInstaller.zip",
										internalHelper.prepareUpdateLocation(instance.updateLocation) + "updateInstaller.xml"
									 };

			//Urls der Updatepakete erzeugen
			foreach (updatePackage package in result.newUpdatePackages)
				_urls.Add(internalHelper.prepareUpdateLocation(instance.updateLocation, "updates") + package.getFilename());

			_wclDownload.DownloadFileCompleted += _wclDownload_DownloadFileCompleted;
			_wclDownload.DownloadProgressChanged += _wclDownload_DownloadProgressChanged;

			//Temporäres Verzeichnis erstellen
			_tempDirectory = instance.internalSettings.downloadLocation;
			if (!Directory.Exists(_tempDirectory)) {
				Directory.CreateDirectory(_tempDirectory);
			}
		}

		public bool isBusy {
			get { return _wclDownload.IsBusy; }
		}

		#region " Downloadstatistiken "

		private BackgroundWorker _statisticWorker;

		private void sendStatistics() {
			_statisticWorker = new BackgroundWorker();
			_statisticWorker.DoWork += _statisticWorker_DoWork;
			_statisticWorker.RunWorkerCompleted += _statisticWorker_RunWorkerCompleted;

			_statisticWorker.RunWorkerAsync();
		}

		private void _statisticWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			_statisticsSent = true;
			if (_downloadFinished) {
				sFinalize();
				if (downloadUpdatesCompleted != null) {
					downloadUpdatesCompleted(this, new AsyncCompletedEventArgs(null, false, new object()));
				}
			}
		}

		private void _statisticWorker_DoWork(object sender, DoWorkEventArgs e) {
			try {
				var log = new updateLogRequest(_currentInstance, _currentConfiguration);
				lock (log)
					log.sendRequest(1);
			}
			catch {
			}
		}

		#endregion

		public event downloadUpdatesProgressChangedEventHandler downloadUpdatesProgressChanged;
		public event downloadUpdatesCompletedEventHandler downloadUpdatesCompleted;

		public void startDownload() {
			try {
				if (_currentInstance.showTaskBarProgress) {
					taskBarManager.Instance.setTaskBarProgressState(taskBarProgressState.Normal);
				}
				if (!_wclDownload.IsBusy) {
					if (_statisticWorker == null) {
						sendStatistics();
					}
					_wclDownload.DownloadFileAsync(new Uri(_urls[_downloadCount]),
												   Path.Combine(_tempDirectory, extractFilename(_urls[_downloadCount])));
					Log.Instance.writeKeyValue("Downloading", _urls[_downloadCount]);
				}
				else {
					throw new InvalidOperationException();
				}
			}
			catch (Exception eX) {
				sFinalize();
				if (downloadUpdatesCompleted != null) {
					downloadUpdatesCompleted(this, new AsyncCompletedEventArgs(eX, true, null));
				}
			}
		}

		public void cancelDownload() {
			if (_wclDownload.IsBusy) {
				_wclDownload.CancelAsync();
			}
		}

		/// <summary>
		/// Führt Abschließende Funktionen aus.
		/// </summary>
		private void sFinalize() {
			if (_currentInstance.showTaskBarProgress) {
				taskBarManager.Instance.setTaskBarProgressState(taskBarProgressState.NoProgress);
			}
		}

		private void _wclDownload_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			if (downloadUpdatesProgressChanged != null) {
				/*downloadUpdatesProgressChanged(this, new updateSystemDotNet.AppEventArgs.downloadUpdatesProgressChangedEventArgs(
					(e.ProgressPercentage + (100 * _downloadCount))));*/

				int percentDone = Percent((e.ProgressPercentage + (100*_downloadCount)), (100*_urls.Count));

				downloadUpdatesProgressChanged(this, new downloadUpdatesProgressChangedEventArgs(
														percentDone));
				if (_currentInstance.showTaskBarProgress) {
					taskBarManager.Instance.setTaskBarProgressState(taskBarProgressState.Normal);
					taskBarManager.Instance.setTaskBarProgressValue((ulong) percentDone, 100);
				}
			}
		}

		/// <summary>
		/// Diese Funktion berechnet den Prozentsatz aus zwei Werten.
		/// </summary>
		/// <param name="CurrVal">Der aktuelle Wert.</param>
		/// <param name="MaxVal">Der maximalwert</param>
		/// <returns>Gibt den Prozentsatz aus den beiden gegebenen Werten zurück.</returns>
		protected int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}

		private void _wclDownload_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
			try {
				if ((_downloadCount < _urls.Count - 1) &&
					e.Error == null &&
					(!e.Cancelled)) {
					_downloadCount++;
					startDownload();
				}
				else {
					_downloadFinished = true;
					if (_statisticsSent) {
						Log.Instance.writeEntry("Download finished.");
						sFinalize();
						if (downloadUpdatesCompleted != null) {
							downloadUpdatesCompleted(this, e);
						}
					}
				}
			}
			catch (Exception ex) {
				sFinalize();
				if (downloadUpdatesCompleted != null) {
					downloadUpdatesCompleted(this, new AsyncCompletedEventArgs(ex, true, null));
				}
			}
		}

		private static bool OnCheckSSLCert(object sender, X509Certificate certificate, X509Chain chain,
										   SslPolicyErrors sslPolicyErrors) {
			return true;
		}

		/// <summary>
		/// Extrahiert den Dateinamen aus einer Url
		/// </summary>
		/// <param name="url">Die Url welche einen Dateinamen am Ende enthält</param>
		/// <returns>Gibt den Dateinamen ohne Url zurück</returns>
		private string extractFilename(string url) {
			//return url.Substring(url.LastIndexOf("/") + 1);
			var uri = new Uri(url);
			return uri.Segments[uri.Segments.Length - 1];
		}

		/// <summary>
		/// Kombiniert zwei Url's miteinander
		/// </summary>
		/// <param name="url1">Die erste Url</param>
		/// <param name="url2">Die zweite Url</param>
		/// <returns>Gibt eine aus den beiden Url's kombinierte Url mit einem '/' am Ende zurück</returns>
		[Obsolete]
		public static string CombineURL(string url1, string url2) {
			if (url1.EndsWith("/") == false) {
				url1 = url1 + "/";
			}
			if (url2.StartsWith("/")) {
				url2 = url2.Substring(1);
			}
			if (url2.EndsWith("/") == false) {
				url2 = url2 + "/";
			}
			return url1 + url2;
		}

		/// <summary>
		/// Gibt die größe einer Datei in einem formatiertem String wieder.
		/// </summary>
		/// <param name="lenght">Die Größe der Datei in Bytes</param>
		/// <returns></returns>
		public static string GetFileSize(double lenght) {
			try {
				if (lenght < 1024) {
					return string.Format("{0} Bytes", lenght.ToString());
				}
				if (lenght > 1023 && lenght < 1048576) {
					double c_lenght = lenght/1024;
					return string.Format("{0} KB", c_lenght.ToString("###0.00"));
				}
				if (lenght >= 1048576 && lenght <= 1043741825) {
					double c_lenght = lenght/(float) (Math.Pow(1024, 2));
					return string.Format("{0} MB", c_lenght.ToString("###0.00"));
				}

				return "0 Bytes";
			}
			catch {
				return "0 Bytes";
			}
		}
	}
}