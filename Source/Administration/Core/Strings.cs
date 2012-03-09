#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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