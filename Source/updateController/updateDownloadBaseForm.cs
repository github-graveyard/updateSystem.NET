/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Internal;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet {
	/// <summary>
	/// Basisform für alle Updatedownloadforms.
	/// </summary>
	public class updateDownloadBaseForm : Form {
		private updateDownloader _updateDownloader;

		#region " Events "

		/// <summary>
		/// Tritt ein, wenn der Updatedownload abgeschlossen wurde.
		/// </summary>
		public event downloadUpdatesCompletedEventHandler downloadUpdatesCompleted;

		/// <summary>
		/// Tritt ein, wenn sich der Fortschritt des Updatedownloads ändert.
		/// </summary>
		public event downloadUpdatesProgressChangedEventHandler downloadUpdatesProgressChanged;

		#endregion

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="updateDownloadBaseForm"/>.
		/// </summary>
		public updateDownloadBaseForm() {
			StartPosition = FormStartPosition.CenterParent;
		}

		/// <summary>
		/// Bietet Zugriff auf das Suchresultat.
		/// </summary>
		protected UpdateResult Result { get; private set; }

		/// <summary>
		/// Gibt true zurück wenn der Updatedownload läuft, andernfalls false.
		/// </summary>
		protected bool isBusy {
			get { return _updateDownloader.isBusy; }
		}

		internal bool downloadCompleted { get; private set; }

		/// <summary>
		/// Initialisiert die Updateform. Diese Methode wird automatisch vom <see cref="updateController"/> aufgerufen und muss daher nicht manuell aufgerufen werden.
		/// </summary>
		/// <param name="instance">Die Instanz des updateControllers</param>
		/// <param name="result">Das Suchresultat des UpdateControllers.</param>
		internal void initializeForm(updateController instance, UpdateResult result) {
			_updateDownloader = new updateDownloader(instance, result);

			_updateDownloader.downloadUpdatesCompleted += _updateDownloader_downloadUpdatesCompleted;
			_updateDownloader.downloadUpdatesProgressChanged += _updateDownloader_downloadUpdatesProgressChanged;

			Result = result;
		}

		private void _updateDownloader_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
			if (downloadUpdatesProgressChanged != null)
				downloadUpdatesProgressChanged(sender, e);
		}

		private void _updateDownloader_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
			if (e.Error == null && !e.Cancelled) {
				downloadCompleted = true;
			}
			if (downloadUpdatesCompleted != null)
				downloadUpdatesCompleted(sender, e);
		}

		/// <summary>
		/// Zeigt das Formular als modales Dialogfeld an.
		/// </summary>
		/// <param name="owner">Ein beliebiges Objekt, das <see cref="IWin32Window"/> implementiert, das das Fenster der obersten Ebene und damit den Besitzer des modalen Dialogfelds darstellt.</param>
		/// <returns>Einer der DialogResult-Werte.</returns>
		public new DialogResult ShowDialog(IWin32Window owner) {
			if (owner == null) StartPosition = FormStartPosition.CenterScreen;

			//TopMost Workaround
			try {
				var fParent = (Form) owner;
				PropertyInfo pTopMost = fParent.GetType().GetProperty("TopMost");
				TopMost = (bool) pTopMost.GetValue(fParent, null);
			}
			catch {
			}

			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Beginnt mit dem Download der Updates.
		/// </summary>
		protected void startDownload() {
			_updateDownloader.startDownload();
		}

		/// <summary>
		/// Bricht den Updatedownload ab.
		/// </summary>
		protected void cancelDownload() {
			_updateDownloader.cancelDownload();
		}

		/// <summary>
		/// Überschriebene Closing-Methode welche den aktiven Updatedownload erst beendet und dann das Event weiterreicht.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnFormClosing(FormClosingEventArgs e) {
			if (_updateDownloader.isBusy) {
				_updateDownloader.cancelDownload();
			}
			base.OnFormClosing(e);
		}
	}
}