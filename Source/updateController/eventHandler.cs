/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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