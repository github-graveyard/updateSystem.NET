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