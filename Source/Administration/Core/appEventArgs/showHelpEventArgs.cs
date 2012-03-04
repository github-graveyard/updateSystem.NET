using System;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	/// <summary>Stellt Informationen für das showHelp-Event bereit.</summary>
	internal sealed class showHelpEventArgs : EventArgs {
		public showHelpEventArgs(string text) {
			helpText = text;
		}

		/// <summary>Der Hilfetext welcher angezeigt werden soll.</summary>
		public string helpText { get; private set; }
	}
}