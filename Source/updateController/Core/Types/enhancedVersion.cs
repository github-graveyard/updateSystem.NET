using System;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Ein Klasse welche erweiterte Versionsinformationen bereitstellt.
	/// </summary>
	[Serializable]
	public sealed class enhancedVersion {
		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="enhancedVersion"/>.
		/// </summary>
		/// <param name="rInfo">Das Versionsobjekt welches für diese Instanz verwendeten werden soll.</param>
		internal enhancedVersion(releaseInfo rInfo)
			: this(rInfo, updatePackage.SupportedArchitectures.Both) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="enhancedVersion"/>.
		/// </summary>
		/// <param name="rInfo">Das Versionsobjekt welches für diese Instanz verwendeten werden soll.</param>
		/// <param name="architecture">Die Prozessorarchitektur für welche dieses Versionsobjekt gültig ist.</param>
		internal enhancedVersion(releaseInfo rInfo, updatePackage.SupportedArchitectures architecture) {
			releaseInfo = rInfo;
			Architecture = architecture;
		}

		/// <summary>
		/// Gibt die Versionsnummer zurück oder legt diese fest.
		/// </summary>
		public releaseInfo releaseInfo { get; internal set; }

		/// <summary>
		/// Gibt die Prozessorarchitektur dieser Version zurück oder legt diese fest.
		/// </summary>
		public updatePackage.SupportedArchitectures Architecture { get; internal set; }
	}
}