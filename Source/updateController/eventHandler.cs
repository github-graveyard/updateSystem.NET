using System.ComponentModel;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet {
	// "Klasse" für alle Eventhandler die im updateController verwendet werden.

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.checkForUpdatesCompleted"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="appEventArgs.checkForUpdatesCompletedEventArgs"/>, das die Ereignisdaten enthält.</param>
	public delegate void checkForUpdatesCompletedEventHandler(object sender, checkForUpdatesCompletedEventArgs e);

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.downloadUpdatesCompleted"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="AsyncCompletedEventArgs"/>, das die Ereignisdaten enthält.</param>
	public delegate void downloadUpdatesCompletedEventHandler(object sender, AsyncCompletedEventArgs e);

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.downloadUpdatesProgressChanged"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="appEventArgs.downloadUpdatesProgressChangedEventArgs"/>, das die Ereignisdaten enthält.</param>
	public delegate void downloadUpdatesProgressChangedEventHandler(
		object sender, downloadUpdatesProgressChangedEventArgs e);

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.updateFound"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="appEventArgs.updateFoundEventArgs"/>, das die Ereignisdaten enthält.</param>
	public delegate void updateFoundEventHandler(object sender, updateFoundEventArgs e);

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.updateInstallerStarted"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="appEventArgs"/>, das die Ereignisdaten enthält.</param>
	public delegate void updateInstallerStartedEventHandler(object sender, updateInstallerStartedEventArgs e);

	/// <summary>
	/// Stellt die Methode dar, welche das <see cref="updateController.confirmUpdatePackage"/>-Event des <see cref="updateController"/> behandelt.
	/// </summary>
	/// <param name="sender">Die Quelle des Ereignisses.</param>
	/// <param name="e">Ein <see cref="appEventArgs.confirmUpdatePackageEventArgs"/></param>, das die Ereignisdaten enthält.
	/// <returns>True wenn das Paket in die Liste der neuen Updates übernommen werden soll, False wenn es übersprungen werden soll.</returns>
	public delegate bool confirmUpdatePackageEventHandler(object sender, confirmUpdatePackageEventArgs e);
}