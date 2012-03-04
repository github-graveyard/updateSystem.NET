using System;
using System.Collections.Generic;
using System.IO;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// updateAction welche zum Kopieren von Dateien verwendet wird.
	/// </summary>
	[Serializable]
	[administrationEditorAttribute("Dateien und Verzeichnisse", "file_add",
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