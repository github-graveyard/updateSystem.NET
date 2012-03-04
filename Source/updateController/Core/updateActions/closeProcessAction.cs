using System;
using System.Collections.Generic;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaktion zum beenden von Prozessen.
	/// </summary>
	[Serializable]
	[administrationEditor("Prozesse", "stop_process", "Beendet einen oder mehrere Prozesse.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.closeProcessActionEditor")]
	public sealed class closeProcessAction : actionBase {
		private List<string> m_processList = new List<string>();

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="closeProcessAction"/>.
		/// </summary>
		public closeProcessAction() {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="closeProcessAction"/>.
		/// </summary>
		/// <param name="processName">Ein einzelner Prozess welcher zu der Liste der zu schließenden Prozesse hinzugefügt werden soll.</param>
		public closeProcessAction(string processName) {
			m_processList.Add(processName);
		}

		/// <summary>
		/// Gibt die Liste mit Prozessen zurück die beendet werden sollen oder legt diese fest.
		/// </summary>
		public List<string> processList {
			get { return m_processList; }
			set { m_processList = value; }
		}

		/// <summary>
		/// Gibt den Namen der Aktion zurück
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Prozesse beenden";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return m_processList.Count > 0;
		}
	}
}