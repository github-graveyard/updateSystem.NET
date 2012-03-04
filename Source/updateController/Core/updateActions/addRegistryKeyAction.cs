using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum erstellen eines Registryschlüssels.
	/// </summary>
	[Serializable]
	[administrationEditor("Registry", "key_add", "Erstellt einen neuen Schlüssel in der Registry des Zielcomputers.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.addRegistryKeyActionEditor")]
	public sealed class addRegistryKeyAction : registryActionBase {
		/// <summary>
		/// Gibt den Namen der Aktion zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Registryschlüssel erstellen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return (!string.IsNullOrEmpty(base.Path));
		}
	}
}