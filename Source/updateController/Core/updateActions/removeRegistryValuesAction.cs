using System;
using System.Collections.Generic;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum entfernen eines oder mehreren Registrywerten.
	/// </summary>
	[Serializable]
	[administrationEditor("Registry", "value_delete",
		"Entfernt einen oder mehrere Werte aus der Registry des Zielcomputers.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.removeRegistryValuesActionEditor")]
	public sealed class removeRegistryValuesAction : registryActionBase {
		private List<string> m_valueNames = new List<string>();

		/// <summary>
		/// Gibt eine Liste mit den Namen der Werte zurück die entfernt werden sollen oder legt diese fest.
		/// </summary>
		public List<string> valueNames {
			get { return m_valueNames; }
			set { m_valueNames = value; }
		}

		/// <summary>
		/// Gibt den Name der Updateaction zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Registrywerte entfernen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (!string.IsNullOrEmpty(base.Path) &&
			    m_valueNames.Count > 0) {
				return true;
			}
			return false;
		}
	}
}