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