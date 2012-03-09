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

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum umbennen einer Datei.
	/// </summary>
	[Serializable]
	[administrationEditor("Dateien und Verzeichnisse", "file_rename", "Benennt eine Datei auf dem Zielcomputer um.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.renameFileActionEditor")]
	public sealed class renameFileAction : actionBase {
		private string m_newFilename = string.Empty;
		private string m_path = string.Empty;

		/// <summary>
		/// Gibt den vollständigen Pfad zu der Datei die umbenannt werden soll zurück oder legt diesen fest.
		/// </summary>
		public string Path {
			get { return m_path; }
			set { m_path = value; }
		}

		/// <summary>
		/// Gibt den neuen Dateinamen an oder legt diesen fest.
		/// </summary>
		public string newFilename {
			get { return m_newFilename; }
			set { m_newFilename = value; }
		}


		/// <summary>
		/// Gibt den Namen der Aktion zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Datei umbennen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (!string.IsNullOrEmpty(Path) &&
			    !string.IsNullOrEmpty(newFilename)) {
				return true;
			}
			return false;
		}
	}
}