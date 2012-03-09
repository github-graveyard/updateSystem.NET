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

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaktion zum löschen einer oder mehrerer Dateien auf dem Zielsystem.
	/// </summary>
	[Serializable]
	[administrationEditor("Dateien und Verzeichnisse", "file_delete", "Löscht Dateien auf dem Zielcomputer",
		"updateSystemDotNet.Administration.UI.updateActionEditor.deleteFilesActionEditor")]
	public sealed class deleteFilesAction : actionBase {
		private List<string> m_filesToRemove = new List<string>();
		private string m_path = string.Empty;

		/// <summary>
		/// Gibt den Pfad zurück aus welchem die Dateien entfernt werden sollen oder legt diesen fest.
		/// </summary>
		public string Path {
			get { return m_path; }
			set { m_path = value; }
		}

		/// <summary>
		/// Gibt die Namen von den Dateien zurück die entfernt werden sollen oder legt diese fest.
		/// </summary>
		public List<string> filesToRemove {
			get { return m_filesToRemove; }
			set { m_filesToRemove = value; }
		}

		/// <summary>
		/// Gibt den Anzeigenamen der Aktion zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Dateien löschen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (!string.IsNullOrEmpty(m_path) &&
			    m_filesToRemove.Count > 0) {
				return true;
			}
			return false;
		}
	}
}