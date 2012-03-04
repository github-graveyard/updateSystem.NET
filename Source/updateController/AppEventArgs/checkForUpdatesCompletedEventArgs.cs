using System;
using System.ComponentModel;

namespace updateSystemDotNet.appEventArgs {
	/// <summary>
	/// Stellt Daten für das <see cref="updateController.checkForUpdatesCompleted"/>-Event des <see cref="updateController"/> bereit.
	/// </summary>
	public class checkForUpdatesCompletedEventArgs : AsyncCompletedEventArgs {
		private readonly bool _successfull;

		internal checkForUpdatesCompletedEventArgs(Exception exception, bool cancelled, bool userState)
			: base(exception, cancelled, userState) {
			_successfull = userState;
		}

		/// <summary>
		/// Gibt true zurück wenn Aktualisierungen gefunden wurden, andernfalls false.
		/// </summary>
		public bool Result {
			get {
				return _successfull;
			}
		}
	}
}