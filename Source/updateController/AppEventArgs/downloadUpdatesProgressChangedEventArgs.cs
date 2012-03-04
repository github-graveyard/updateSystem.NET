using System.ComponentModel;

namespace updateSystemDotNet.appEventArgs {
	/// <summary>
	/// Stellt Daten für das <see cref="updateController.downloadUpdatesProgressChanged"/>-Event des <see cref="updateController"/> bereit.
	/// </summary>
	public class downloadUpdatesProgressChangedEventArgs : ProgressChangedEventArgs {
		internal downloadUpdatesProgressChangedEventArgs(int percentDone)
			: base(percentDone, new object()) {
		}
	}
}