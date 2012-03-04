using System;

namespace updateSystemDotNet.appEventArgs {
	/// <summary>
	/// Stellt Daten für das <see cref="updateController.updateFound"/>-Event des <see cref="updateController"/> bereit.
	/// </summary>
	public class updateFoundEventArgs : EventArgs {
		internal updateFoundEventArgs(UpdateResult result) {
			Result = result;
		}

		/// <summary>
		/// <para>Das Suchresultat welches die gefundenen Aktualisierungen beinhaltet.</para>
		/// <para>Alternativ kann das Resultat auch der Eigenschaft <see cref="updateController.currentUpdateResult"/> des <see cref="updateController"/> entnommen werden.</para>
		/// </summary>
		public UpdateResult Result { get; private set; }
	}
}