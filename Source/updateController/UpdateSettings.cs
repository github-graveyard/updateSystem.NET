using System;
using System.Collections.Generic;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet {

	#region " UpdateSettings "

	/// <summary>
	/// Die Einstellungen die an den UpdateClient übergeben werden sollen.
	/// </summary>
	[Serializable]
	public class UpdateSettings {
		#region Private Fields

		private string m_URL = string.Empty;

		private bool m_allowBeta;
		private string m_applicationPath = string.Empty;
		private string m_authenticationPassword = string.Empty;
		private string m_authenticationUsername = string.Empty;
		private authenticationModes m_authenticationmode = authenticationModes.None;

		private updateConfiguration m_config = new updateConfiguration();
		private int m_cust_interval;
		private string m_id = "00000000-0000-0000-0000-000000000000";
		private Interval m_interval = Interval.Always;
		private Languages m_language = Languages.Deutsch;
		private string m_location = string.Empty;
		private string m_pbk = string.Empty;
		private bool m_restartApp;

		private List<updatePackage> m_result = new List<updatePackage>();

		private string m_sessionID = string.Empty;
		private bool m_skipOK;
		private string m_version = string.Empty;

		#endregion

		#region Kontruktor

		/// <summary>
		/// Kontruktor
		/// </summary>
		public UpdateSettings() {
			releaseInfo = new releaseInfo();
			releaseFilter = new releaseFilterType();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Die URL an der nach Updates gesucht werden soll
		/// </summary>
		public string Update_URL {
			get { return m_URL; }
			set { m_URL = value; }
		}

		/// <summary>
		/// Die zuverwendende Sprache
		/// </summary>
		public Languages Language {
			get { return m_language; }
			set { m_language = value; }
		}

		/// <summary>
		/// Der Pfad an welchem die aufrufende Anwendung zu finden ist
		/// </summary>
		public string AppLocation {
			get { return m_location; }
			set { m_location = value; }
		}

		/// <summary>
		/// Die aktuell installierte Version
		/// </summary>
		public string LocalVersion {
			get { return releaseInfo.Version; }
			set { releaseInfo.Version = value; }
		}

		/// <summary>
		/// Öffentlicher Schlüssel zur Validierung der Updatekonfiguration und der Updatepakete
		/// </summary>
		public string PublicKey {
			get { return m_pbk; }
			set { m_pbk = value; }
		}

		/// <summary>
		/// Gibt die GUID zum eindeutigen Identifizieren des Projektes wieder oder legt diese fest
		/// </summary>
		public string ProjektID {
			get { return m_id; }
			set { m_id = value; }
		}

		/// <summary>
		/// Gibt den Interval an, nach welchem nach Updates gesucht werden soll oder legt diesen Fest
		/// </summary>
		public Interval Updateinterval {
			get { return m_interval; }
			set { m_interval = value; }
		}

		/// <summary>
		/// Der Benutzerdefinierte Updateinterval in Tagen.
		/// </summary>
		public int CustomUpdateInterval {
			get { return m_cust_interval; }
			set { m_cust_interval = value; }
		}

		/// <summary>
		/// Die Updatekonfiguration
		/// </summary>
		public updateConfiguration Config {
			get { return m_config; }
			set { m_config = value; }
		}

		/// <summary>
		/// Das Suchresultat
		/// </summary>
		public List<updatePackage> Result {
			get { return m_result; }
			set { m_result = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob der Updateinstaller nach dem Fertigstellen des Updates
		/// automatisch geschlossen werden soll.
		/// </summary>
		public bool SkipOK {
			get { return m_skipOK; }
			set { m_skipOK = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob Betaversionen bei der Updatesuche berücksichtigt werden.
		/// </summary>
		public bool allowBetaversions {
			get { return m_allowBeta; }
			set { m_allowBeta = value; }
		}

		/// <summary>
		/// Gibt die SessionID zurück oder legt diese fest.
		/// </summary>
		public string sessionID {
			get { return m_sessionID; }
			set { m_sessionID = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest ob die Anwendung nach dem Update neu gestartet werden soll.
		/// </summary>
		public bool restartApplication {
			get { return m_restartApp; }
			set { m_restartApp = value; }
		}

		/// <summary>
		/// Gibt die ausgelesenen Befehlszeilenargumente zurück oder legt diese fest.
		/// </summary>
		public string commandlineArguments { get; set; }

		/// <summary>
		/// Gibt den Pfad der Anwendung zurück, die nach dem Update neu gestartet werden soll oder legt diesen fest.
		/// </summary>
		public string applicationPath {
			get { return m_applicationPath; }
			set { m_applicationPath = value; }
		}

		/// <summary>
		/// Gibt den Authentifizierungsmodus für die Updatesuche und den Download zurück oder legt diese fest.
		/// </summary>
		public authenticationModes authenticationMode {
			get { return m_authenticationmode; }
			set { m_authenticationmode = value; }
		}

		/// <summary>
		/// Gibt den Benutzernamen für die Authentifizierung zurück oder legt diesen fest.
		/// </summary>
		public string authenticationUsername {
			get { return m_authenticationUsername; }
			set { m_authenticationUsername = value; }
		}

		/// <summary>
		/// Gibt das Passwort für die Authentifizierung zurück oder legt dieses fest.
		/// </summary>
		public string authenticationPassword {
			get { return m_authenticationPassword; }
			set { m_authenticationPassword = value; }
		}

		/// <summary>
		/// Gibt den Pfad des Ordners zurück in welchen die Dateien heruntergeladen werden.<para />
		/// </summary>
		public string downloadLocation { get; set; }

		/// <summary>
		/// Gibt an ob ein Proxy verwendet werden soll oder legt dieses fest.
		/// </summary>
		public bool proxyEnabled { get; set; }

		/// <summary>
		/// Gibt die ProxyUrl zurück oder legt diese fest.
		/// </summary>
		public string proxyUrl { get; set; }

		/// <summary>
		/// Gibt den Port für den Proxyserver zurück oder legt diesen fest.
		/// </summary>
		public int proxyPort { get; set; }

		/// <summary>
		/// Gibt den Benutzernamen für den Proxy zurück oder legt diesen fest.
		/// </summary>
		public string proxyUsername { get; set; }

		/// <summary>
		/// Gibt das Passwort für den Proxy zurück oder legt dieses fest.
		/// </summary>
		public string proxyPassword { get; set; }

		/// <summary>
		/// Gibt an oder legt fest ob für die Proxyauthentifizierung die Default Networkcredentials verwendet werden sollen.
		/// </summary>
		public bool proxyUseDefaultCredentials { get; set; }

		///// <summary>
		///// Gibt an oder legt fest, ob für den Updatevorgang ein anderer Windowsaccount verwendet werden soll.
		///// </summary>
		//public bool windowsAuthenticationEnabled { get; set; }

		///// <summary>
		///// Gibt den Benutzernamen zurück oder legt diesen fest.
		///// </summary>
		//public string windowsAuthenticationUsername { get; set; }

		///// <summary>
		///// Gibt das Passwort zurück oder legt dieses fest.
		///// </summary>
		//public string windowsAuthenticationPassword { get; set; }

		///// <summary>
		///// Gibt die Domäne zurück oder legt diese fest.
		///// </summary>
		//public string windowsAuthenticationDomain { get; set; }

		/// <summary>
		/// Gibt den Sicherheitslevel für Prozesse mit erhöhten Rechten zurück oder legt diesen fest.
		/// </summary>
		public processSafetyLevel processSafetyLevel { get; set; }

		/// <summary>
		/// Gibt an oder legt fest, ob der Abbrechenbutton im updateInstaller deaktiviert werden soll.
		/// </summary>
		public bool disableCancel { get; set; }

		/// <summary>
		/// Gibt an oder legt fest, ob der Fortschritt von dem Updatedownload und der Updateinstallation unter Windows 7 zusätzlich in dem TaskBarButton angezeigt werden soll.
		/// </summary>
		public bool showTaskBarProgress { get; set; }

		/// <summary>
		/// Gibt an oder legt fest ob die Aktionen der Updatesuchen geloggt werden sollen.
		/// <para>Die Logs werden nach %TMP%\updateSystem.Net.Logs geschrieben.</para>
		/// </summary>
		public bool enableLogging { get; set; }

		/// <summary>
		/// Gibt den Releasestatus zurück oder legt diesen fest.
		/// </summary>
		public releaseInfo releaseInfo { get; set; }

		/// <summary>
		/// Gibt den Filter zurück welcher bestimmte Releaseversionen bei der Updatesuche ausschließt oder legt diesen fest.
		/// </summary>
		public releaseFilterType releaseFilter { get; set; }

		#endregion
	}

	#endregion
}