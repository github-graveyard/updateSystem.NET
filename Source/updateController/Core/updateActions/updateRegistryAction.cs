using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Klasse zum aktualsieren der Registryversion
	/// </summary>
	[Serializable]
	public class updateRegistryAction : actionBase {
		/// <summary>
		/// Gibt die neue Version zurück welche in die Registry eingetragen werden soll oder legt diese fest.
		/// </summary>
		public string newVersion { get; set; }

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			throw new NotImplementedException();
		}
	}
}