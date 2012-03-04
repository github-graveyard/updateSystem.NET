using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaktion zum entfernen eines Registryschlüssels.
	/// </summary>
	[Serializable]
	[administrationEditor("Registry", "key_delete", "Entfernen einen Schlüssel in der Registry des Zielcomputers.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.removeRegistryKeyActionEditor")]
	public sealed class removeRegistryKeyAction : registryActionBase {
		/// <summary>
		/// Gibt den Namen der Action zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Registryschlüssel entfernen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return !string.IsNullOrEmpty(base.Path);
		}
	}
}