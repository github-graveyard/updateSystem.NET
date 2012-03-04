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