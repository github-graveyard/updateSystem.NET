using System.Collections.Generic;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Updater {
	/// <summary>
	/// Interne Klasse welche die Updatesettings und die Serverkonfiguration beinhaltet.
	/// </summary>
	internal class InternalConfig {
		/// <summary>
		/// Das Suchresultat welches in der UpdateHelper-Library erstellt wurde.
		/// </summary>
		public List<updatePackage> Result;

		/// <summary>
		/// Die Heruntergeladene Serverkonfiguration
		/// </summary>
		public updateConfiguration ServerConfiguration;

		/// <summary>
		/// Die Updateeinstellung die der Benutzer in der UpdateHelper-Library vorgenommen hat.
		/// </summary>
		public UpdateSettings Settings;
	}
}