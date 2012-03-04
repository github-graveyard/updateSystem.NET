using System;

namespace updateSystemDotNet.appEventArgs {
	/// <summary>
	/// Stellt Daten für das <see cref="updateController.updateInstallerStarted"/>-Event des <see cref="updateController"/> bereit.
	/// </summary>
	public class updateInstallerStartedEventArgs : EventArgs {
		internal updateInstallerStartedEventArgs(IntPtr updaterHandle) {
			Handle = updaterHandle;
		}

		/// <summary>
		/// Gibt das Handle des updateInstaller-Prozesses zurück.
		/// </summary>
		public IntPtr Handle { get; internal set; }
	}
}