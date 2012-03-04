using System;

namespace updateSystemDotNet.appExceptions {
	/// <summary>
	/// Die Ausnahme die ausgelöst wird, wenn die digitale Signatur einer Datei nicht bestätigt werden konnte.
	/// </summary>
	public class invalidSignatureException : Exception {
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="invalidSignatureException"/>.
		/// </summary>
		/// <param name="file">Der vollständige Pfad zu der Datei die nicht validiert werden konnte.</param>
		internal invalidSignatureException(string file)
			: base(string.Format("Die digitale Signatur das Datei \"{0}\" konnte nicht bestätigt werden.", file)) {
		}
	}
}