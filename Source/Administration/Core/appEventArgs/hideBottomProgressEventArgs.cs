using System;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class hideBottomProgressEventArgs : EventArgs {
		public hideBottomProgressEventArgs(actionLabelStates state, string message) {
			Message = message;
			State = state;
		}

		/// <summary>Der Status welchen das Label anzeigen soll. Erfolgreich/Fehlgeschlagen</summary>
		public actionLabelStates State { get; private set; }

		/// <summary>Die Nachricht die das Statuslabel anzeigen soll.</summary>
		public string Message { get; private set; }
	}
}