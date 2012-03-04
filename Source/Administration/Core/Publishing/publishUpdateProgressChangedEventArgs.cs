using System;

namespace updateSystemDotNet.Administration.Core.Publishing {
	internal sealed class publishUpdateProgressChangedEventArgs : EventArgs {

		/// <summary>Der Dateiname der aktuell verarbeiteten Datei.</summary>
		public string currentFilename { get; set; }

		/// <summary>Die Anzahl der bereits verarbeiteten Dateien.</summary>
		public int currentFile { get; set; }

		/// <summary>Die Anzahl aller zu verarbeitetenden Dateien.</summary>
		public int maxFileCount { get; set; }

	}
}
