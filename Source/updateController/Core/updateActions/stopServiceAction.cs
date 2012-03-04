using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum stoppen eines Dienstes.
	/// </summary>
	[Serializable]
	[administrationEditor("Dienste", "stop_service", "Stoppt einen Dienst auf dem Zielcomputer.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.stopServiceActionEditor")]
	public sealed class stopServiceAction : actionBase {
		private string m_serviceName = string.Empty;

		/// <summary>
		/// Gibt den Namen des Dienstes zurück oder legt diesen fest.
		/// </summary>
		public string serviceName {
			get { return m_serviceName; }
			set { m_serviceName = value; }
		}

		/// <summary>
		/// Gibt den anzeigenamen der Action zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Dienst stoppen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return !string.IsNullOrEmpty(serviceName);
		}
	}
}