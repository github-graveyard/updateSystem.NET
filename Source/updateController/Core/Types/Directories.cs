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
using System.Collections.Generic;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Klasse welche Verzeichnisse bereitstellt die durch Umgebungsvariabeln ersetzt werden.
	/// </summary>
	public class Directories {
		private readonly Dictionary<string, string> availableDirectories = new Dictionary<string, string>();

		/// <summary>
		/// Konstruktor
		/// </summary>
		public Directories() {
			availableDirectories.Add("$approot", "Programmverzeichnis");
			availableDirectories.Add("$tempdir", "Temporäresverzeichnis");
			availableDirectories.Add("$windir", "Windowsverzeichnis");
			availableDirectories.Add("$appdata", "Anwendungsdaten");
			availableDirectories.Add("$commonAppdata", "Gemeinsame Anwendungsdateien");
		}

		/// <summary>
		/// Gibt alle verfügbaren Verzeichnisse in einem ObjektArray zurück
		/// </summary>
		/// <returns></returns>
		public object[] GetDirectories() {
			var retVal = new List<object>();

			foreach (var item in availableDirectories) {
				retVal.Add(new DirectoryItem(item.Value, item.Key));
			}

			return retVal.ToArray();
		}

		/// <summary>
		/// Konvertiert einen Pfad aus variablen zu einem "echten" Pfad
		/// </summary>
		/// <param name="path">Der Pfad der konvertiert werden soll</param>
		/// <param name="appLocation">Der Pfad der aufrufenden Anwendung</param>
		/// <returns></returns>
		public string ParsePath(string path, string appLocation) {
			path = path.Replace("$approot", appLocation);
			path = path.Replace("$tempdir", Environment.GetEnvironmentVariable("TEMP"));
			path = path.Replace("$windir", Environment.GetEnvironmentVariable("windir"));
			path = path.Replace("$appdata", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			path = path.Replace("$commonAppdata", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

			return path;
		}

		/// <summary>
		/// Kombiniert zwei Pfadangaben miteinander.
		/// </summary>
		/// <param name="rootPath">Das Stammverzeichnis</param>
		/// <param name="subPath">Das Unterverzeichnis</param>
		/// <returns></returns>
		public string CombinePath(string rootPath, string subPath) {
			if (!rootPath.EndsWith(@"\")) {
				rootPath += @"\";
			}
			if (subPath.StartsWith(@"\")) {
				subPath = subPath.Substring(1);
			}
			if (!string.IsNullOrEmpty(subPath)) {
				if (!subPath.EndsWith(@"\")) {
					subPath += @"\";
				}
			}

			return rootPath + subPath;
		}

		/// <summary>
		/// Gibt den Anzeigenamen anhand des Wertes wieder
		/// </summary>
		/// <param name="value">Der Wert</param>
		/// <returns></returns>
		public string GetDisplayname(string value) {
			return availableDirectories[value];
		}

		/// <summary>
		/// Gibt den Wert anhand des Anzeigenamens wieder
		/// </summary>
		/// <param name="displayName">Der Anzeigename</param>
		/// <returns></returns>
		public string GetValue(string displayName) {
			foreach (var itm in availableDirectories) {
				if (displayName.Equals(itm.Value)) {
					return itm.Key;
				}
			}

			return string.Empty;
		}

		#region Nested type: DirectoryItem

		/// <summary>
		/// Directoryitem zum anzeigen in der ComboBox.
		/// </summary>
		public struct DirectoryItem {
			private readonly string m_displayText;
			private readonly string m_value;

			/// <summary>
			/// Konstruktor
			/// </summary>
			/// <param name="displayText">Der Text der angezeigt werden soll.</param>
			/// <param name="Value">Der eigentliche Wert</param>
			public DirectoryItem(string displayText, string Value) {
				m_value = Value;
				m_displayText = displayText;
			}

			/// <summary>
			/// Gibt den Wert des Items zurück.
			/// </summary>
			public string Value {
				get { return m_value; }
			}

			/// <summary>
			/// Gibt den Wert zum anzeigen in der Combobox zurück
			/// </summary>
			/// <returns></returns>
			public override string ToString() {
				return m_displayText;
			}
		}

		#endregion
	}
}