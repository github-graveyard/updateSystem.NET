using System;
using System.Xml.Serialization;
namespace updateSystemDotNet.Administration.Core.updateLog {

	/// <summary>Klasse welche die Informationen zu einem updateLog-Benutzeraccount bereitstellt.</summary>
	[Serializable]
	public class userAccount : ICloneable {

		public userAccount() {
			Username = string.Empty;
			Password = string.Empty;
			serverUrl = string.Empty;
			userIsAdmin = false;
			Verified = false;
		}

		/// <summary>Gibt den Namen des Benutzers zurück oder legt diesen fest.</summary>
		public string Username { get; set; }

		/// <summary>Gibt das Benutzerpasswort zurück oder legt dieses fest.</summary>
		[encryptProperty]
		public string Password { get; set; }

		/// <summary>Gibt die Adresse des updateLog-Servers zurück oder legt diese fest.</summary>
		public string serverUrl { get; set; }

		/// <summary>Gibt zurück oder legt fest, ob der Benutzer Serveradministrator ist.</summary>
		[XmlElement("isAdmin")]
		public bool userIsAdmin { get; set; }

		[XmlElement("isActive")]
		public bool userIsActive { get; set; }

		/// <summary>Die maximale Anzahl an Projekten die der Benutzer anlegen kann, gilt nicht wenn der Benutzer ein Administrator ist.</summary>
		public int maxProjects { get; set; }

		/// <summary>Das Konto wurde durch einen Login verifiziert.</summary>
		public bool Verified { get; set; }

		/// <summary>Erstellt eine Kopie des aktuellen Objektes.</summary>
		public object Clone() {
			return MemberwiseClone();
		}
	}
}