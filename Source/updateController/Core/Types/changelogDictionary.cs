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
using System.Collections.Generic;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Ein Dictionary welches eine Auflistung von Changelogs anhand erweiterter Versionsinformationen bereitstellt.
	/// </summary>
	public class changelogDictionary : Dictionary<enhancedVersion, changelogDocument> {
		/// <summary>
		/// Gibt ein Array von <see cref="changelogDocument"/> zurück, da es mehrere Changelogdokumente mit der gleichen Versionsnummer aber unterschiedlichlicher Zielplattform geben kann.
		/// </summary>
		/// <param name="version">Der Versionsstring für welchen die Changelogs zurückgegeben werden sollen.</param>
		/// <returns>Gibt ein Array von <see cref="changelogDocument"/> zurück, da es mehrere Changelogdokumente mit der gleichen Versionsnummer aber unterschiedlichlicher Zielplattform geben kann.</returns>
		public changelogDocument[] this[string version] {
			get {
				var changelogs = new List<changelogDocument>();

				foreach (var item in this) {
					if (item.Key.releaseInfo.ToString().Equals(version))
						changelogs.Add(item.Value);
				}
				return changelogs.ToArray();
			}
		}

		/// <summary>
		/// Gibt ein <see cref="changelogDocument"/> passend zum übergebenen Updatepaket zurück.
		/// </summary>
		/// <param name="package">Das Updatepaket zu welchem der Changelog gesucht werden soll.</param>
		/// <returns>Gibt ein <see cref="changelogDocument"/> zurück.</returns>
		public changelogDocument this[updatePackage package] {
			get {
				foreach (var item in this) {
					if (package.releaseInfo.Equals(item.Key.releaseInfo) && package.TargetArchitecture == item.Key.Architecture)
						return item.Value;
				}

				return null;
			}
		}
	}
}