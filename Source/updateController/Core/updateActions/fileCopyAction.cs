/*
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
using System.Collections.Generic;
using System.IO;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// updateAction welche zum Kopieren von Dateien verwendet wird.
	/// </summary>
	[Serializable]
	[administrationEditorAttribute("catFilesAndFolders", "file_add",
		"Kopiert oder ersetzt Dateien auf dem Zielcomputer.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.fileCopyActionEditor")]
	public sealed class fileCopyAction : actionBase {
		private List<FileType> m_files = new List<FileType>();

		/// <summary>
		/// Gibt eine Liste mit Dateien zurück oder legt diese fest.
		/// </summary>
		public List<FileType> Files {
			get { return m_files; }
			set { m_files = value; }
		}

		/// <summary>
		/// Überschriebene ToString()-Funktion welche den Namen der Aktion zurückgibt.
		/// </summary>
		/// <returns>Gibt den Namen der Aktion zurück.</returns>
		public override string ToString() {
			return "Dateien kopieren oder ersetzen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (m_files.Count > 0 &&
			    validateFiles()) {
				return true;
			}

			return false;
		}

		private bool validateFiles() {
			foreach (FileType file in m_files) {
				if (!File.Exists(file.Fullpath) ||
				    string.IsNullOrEmpty(file.Destination)) {
					return false;
				}
			}
			return true;
		}
	}
}