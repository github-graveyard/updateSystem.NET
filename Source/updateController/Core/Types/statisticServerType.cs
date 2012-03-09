/*
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

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Enumeration mit verfügbaren Statistiktechnologien.
	/// </summary>
	public enum statisticServerTypes {
		/// <summary>
		/// Ein ASP.Net und Microsoft SQL Webdienst.
		/// </summary>
		AspNet = 0,

		/// <summary>
		/// Ein PHP und MySql Webdienst.
		/// </summary>
		Php = 1
	}

	/// <summary>
	/// Stellt Informationen über den Statistikserver bereit.
	/// </summary>
	[Serializable]
	public class statisticServerType : ICloneable {
		/// <summary>
		/// Initialisiert eine neue Instanz der statisticServerType-Klasse.
		/// </summary>
		public statisticServerType() {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der statisticServerType-Klasse.
		/// </summary>
		/// <param name="Url">Die Url unter welcher der Webservice erreichbar ist.</param>
		/// <param name="sType">Der Typ der Technologie die auf dem Server zur Verwaltung der Statistiken verwendet wird.</param>
		public statisticServerType(string Url, statisticServerTypes sType) {
			serverUrl = Url;
			serverType = sType;
		}

		/// <summary>
		/// Gibt den Anzeigenamen für den Statistikserver zurück oder legt diesen fest.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gibt eine ID zurück welche das Element Identifiziert oder legt diese fest.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gibt die Url des Webservice zurück oder legt diese fest.
		/// </summary>
		public string serverUrl { get; set; }

		/// <summary>
		/// Gibt die verwendete Technologie zurück oder legt diese fest.
		/// </summary>
		public statisticServerTypes serverType { get; set; }

		#region ICloneable Members

		/// <summary>
		/// Gibt eine Kopie des statisticServerType zurück.
		/// </summary>
		/// <returns></returns>
		public virtual object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}