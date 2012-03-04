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