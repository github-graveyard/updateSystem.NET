using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Klasse zum validieren der Signatur eines Updatepaketes.
	/// </summary>
	[Serializable]
	public sealed class validatePackageAction : actionBase {
		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return true;
		}
	}
}