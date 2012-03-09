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
