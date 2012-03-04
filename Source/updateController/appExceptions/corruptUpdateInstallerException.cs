using System;
using updateSystemDotNet.Internal;

namespace updateSystemDotNet.appExceptions {
	/// <summary>
	/// Die Ausnahme die ausgelöst wird, wenn die Prüfsumme des updateInstallers nicht bestätigt werden konnte.
	/// </summary>
	public sealed class corruptUpdateInstallerException : Exception {
		/// <summary>
		/// Gibt eine Nachricht zurück welche den Fehler näher beschreibt.
		/// </summary>
		public override string Message {
			get { return Language.GetString("exception_corruptUpdateInstaller"); }
		}
	}
}