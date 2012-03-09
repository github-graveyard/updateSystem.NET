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
