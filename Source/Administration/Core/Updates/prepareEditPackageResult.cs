using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.Updates {
	/// <summary>Klasse welche Information für zu bearbeitende Updatepakete bereitstellt.</summary>
	internal sealed class prepareEditPackageResult {

		/// <summary>Gibt den Pfad zurück in welchem sich die temporär gespeicherten Updatedaten befinden.</summary>
		public string tempPackagePath { get; set; }

		/// <summary>Gibt das zu bearbeitende Updatepaket zurück.</summary>
		public updatePackage updatePackage { get; set; }

		/// <summary>Gibt den deutschen Changelog zurück.</summary>
		public string changelogGerman { get; set; }

		/// <summary>Gibt den englischen Changelog zurück.</summary>
		public string changelogEnglish { get; set; }

	}
}
