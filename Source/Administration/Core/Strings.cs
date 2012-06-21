/**
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
using System.IO;

namespace updateSystemDotNet.Administration.Core {
	internal static class Strings {
		/// <summary>Gibt den Dateinamenfilter für OpenFileDialoge zurück.</summary>
		public const string fileOpenDialogProjectFilter = "Updateprojekte|*.udprojx;*.udproj";

		/// <summary>Gibt den Dateinamenfilter für SaveFileDialoge zurück.</summary>
		public const string fileSaveDialogProjectFilter = "Updateprojekte|*.udprojx";

		/// <summary>Gibt den Namen der Anwendung zur Anzeige in Fenstertiteln etc. zurück.</summary>
		public static string applicationName {
			get { return "updateSystem.NET Administration BETA"; }
		}

		/// <summary>Gibt den internen Namen der Anwendung für Ordner- und Registrynamen zurück.</summary>
		public static string applicationInternalName {
			get { return "updateSystem.NET"; }
		}

		/// <summary>Gibt der Verzeichnis der Anwendungseinstellungen zurück.</summary>
		public static string settingsDirectory {
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), applicationInternalName); }
		}

		/// <summary>Gibt den vollständigen Pfad zu den Anwendungseinstellungen zurück.</summary>
		public static string settingsPath {
			get { return Path.Combine(settingsDirectory, applicationName + ".bin"); }
		}

		/// <summary>Gibt die Version der Projektdateien zurück auf welche nach kompatibilität geprüft werden kann.</summary>
		public static double projectVersion {
			get { return 0.1; }
		}

		/// <summary>Gibt eine Auflistung mit allen Verzeichnissen zurück, welche auf dem FTP Server erstellt werden sollen.</summary>
		public static string[] requieredFtpDirectories {
			get { return new[] {"updates"}; }
		}

		/// <summary>Gibt den Namen der Updatekonfigurationsdatei zurück.</summary>
		public static string configurationFilename {
			get { return "update.xml"; }
		}

		/// <summary>Gibt den Namen der Manifestdatei des updateInstallers zurück welche Hash und Versionsnummer enthällt.</summary>
		public static string updateInstallerManifestFileName {
			get { return "updateInstaller.xml"; }
		}

		/// <summary>Gibt den Dateinamen des updateInstallers auf dem PC zurück.</summary>
		public static string updateInstallerLocalFileName {
			get { return "updateInstaller.exe"; }
		}

		/// <summary>Gibt den Dateinamen des updateInstallers im Web zurück.</summary>
		public static string updateInstallerWebFileName {
			get { return "updateInstaller.zip"; }
		}

		/// <summary>Gibt den vollständigen Pfad des updateInstallers auf dem PC zurück.</summary>
		public static string updateInstallerPath {
			get { return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"), updateInstallerLocalFileName); }
		}

		/// <summary>Gibt den Basispfad für die Dateien des Asp.Net Statistikservers zurück.</summary>
		public static string statisticBasePathAsp {
			get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updateService\\Asp.Net"); }
		}

		/// <summary>Gibt den Basispfad für die Dateien des Php Statistikservers zurück.</summary>
		public static string statisticBasePathPhp {
			get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updateService\\Php"); }
		}

		/// <summary>Gibt den Namen des Dokuments zurück welches aufgerufen wird um bei einem neuen Statistikserver die Datenbank zu installieren.</summary>
		public static string statisticServerSetupDocument {
			get { return "Install/Install"; }
		}

		/// <summary>Gibt den Namen des Dokuments zurück welches aufgerufen wird um Benutzernamen und Passwort zu verifizieren.</summary>
		public static string statisticServerAuthenticateDocument {
			get { return "Authenticate"; }
		}

		/// <summary>Gibt den Namen des Dokuments zurück welches aufgerufen wird um die Statistikdaten herunterzuladen.</summary>
		public static string statisticServerDownloadDocument {
			get { return "getStatistics"; }
		}

		/// <summary>Gibt den Link zur Übersichtsseite der Onlinehilfe zurück.</summary>
		public static string urlHelpMain {
			get { return "http://updatesystem.net/help/"; }
		}

		/// <summary>Gibt den Link zu der Spendenseite zurück.</summary>
		public static string urlDonate {
			get { return "http://updatesystem.net/help/donate.aspx"; }
		}
	}
}