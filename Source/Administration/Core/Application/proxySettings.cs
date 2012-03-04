using System;

namespace updateSystemDotNet.Administration.Core.Application {

	public enum proxyModes {
		useSystemDefaults,
		useCustomSettings
	}
	public enum proxyAuthentication {
		None,
		NetworkCredentials,
		Custom
	}

	[Serializable]
	public sealed class proxySettings : ICloneable {

		public proxySettings() {
			proxyMode = proxyModes.useSystemDefaults;
			Authentication= proxyAuthentication.None;
			Server = string.Empty;
			Port = 8080;
			Username = string.Empty;
			Password = string.Empty;
		}

		/// <summary>Legt den Proxytyp fest oder gibt diesen zurück.</summary>
		public proxyModes proxyMode { get; set; }

		/// <summary>Gibt den Authentifizierungstyp für die eigenen Proxykonfiguration zurück.</summary>
		public proxyAuthentication Authentication { get; set; }

		/// <summary>Gibt die Adresse des Proxyservers zurück oder legt diese fest.</summary>
		public string Server { get; set; }

		/// <summary>Gibt den Port des Proxyservers zurück oder legt diesen fest.</summary>
		public int Port { get; set; }

		/// <summary>Gibt den Benutzernamen für die Anmeldung am Proxyserver zurück oder legt diesen fest.</summary>
		public string Username { get; set; }

		/// <summary>Gibt das Passwort für die Anmeldung am Proxyserver zurück oder legt dieses fest.</summary>
		[encryptProperty]
		public string Password { get; set; }

		#region ICloneable Member

		public object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}
