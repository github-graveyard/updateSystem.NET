using System;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateProgressChangedEventArgs : EventArgs {
		private readonly string m_description = string.Empty;
		private readonly string m_name = string.Empty;
		private readonly int m_percentDone;

		public applyUpdateProgressChangedEventArgs(string aName, string aDescription, int progressPercentage) {
			m_name = aName;
			m_description = aDescription;
			m_percentDone = progressPercentage;
		}

		/// <summary>
		/// Gibt den Namen der Aktion zurück.
		/// </summary>
		public string actionName {
			get { return m_name; }
		}

		/// <summary>
		/// Gibt die genauere Beschreibung der Aktion zurück.
		/// </summary>
		public string actionDescription {
			get { return m_description; }
		}

		/// <summary>
		/// Gibt den Fortschritt der Aktion in Prozent zurück.
		/// </summary>
		public int percentDone {
			get { return m_percentDone; }
		}
	}
}