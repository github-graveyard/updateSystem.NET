using System;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.appEventArgs {
	/// <summary>
	/// Stellt Daten für das <see cref="updateController.confirmUpdatePackage"/>-Event des <see cref="updateController"/> bereit.
	/// </summary>
	public class confirmUpdatePackageEventArgs : EventArgs {
		internal confirmUpdatePackageEventArgs(updatePackage package) {
			updatePackage = package;
		}

		/// <summary>
		/// Gibt das Updatepaket zurück, welches Bestätigt werden soll.
		/// </summary>
		public updatePackage updatePackage { get; private set; }
	}
}