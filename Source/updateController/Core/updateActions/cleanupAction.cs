using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Klasse zum aufräumen der Updatedateien.
	/// </summary>
	[Serializable]
	public class cleanupAction : actionBase {
		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return true;
		}
	}
}