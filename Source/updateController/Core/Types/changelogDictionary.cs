using System.Collections.Generic;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Ein Dictionary welches eine Auflistung von Changelogs anhand erweiterter Versionsinformationen bereitstellt.
	/// </summary>
	public class changelogDictionary : Dictionary<enhancedVersion, changelogDocument> {
		/// <summary>
		/// Gibt ein Array von <see cref="changelogDocument"/> zurück, da es mehrere Changelogdokumente mit der gleichen Versionsnummer aber unterschiedlichlicher Zielplattform geben kann.
		/// </summary>
		/// <param name="version">Der Versionsstring für welchen die Changelogs zurückgegeben werden sollen.</param>
		/// <returns>Gibt ein Array von <see cref="changelogDocument"/> zurück, da es mehrere Changelogdokumente mit der gleichen Versionsnummer aber unterschiedlichlicher Zielplattform geben kann.</returns>
		public changelogDocument[] this[string version] {
			get {
				var changelogs = new List<changelogDocument>();

				foreach (var item in this) {
					if (item.Key.releaseInfo.ToString().Equals(version))
						changelogs.Add(item.Value);
				}
				return changelogs.ToArray();
			}
		}

		/// <summary>
		/// Gibt ein <see cref="changelogDocument"/> passend zum übergebenen Updatepaket zurück.
		/// </summary>
		/// <param name="package">Das Updatepaket zu welchem der Changelog gesucht werden soll.</param>
		/// <returns>Gibt ein <see cref="changelogDocument"/> zurück.</returns>
		public changelogDocument this[updatePackage package] {
			get {
				foreach (var item in this) {
					if (package.releaseInfo.Equals(item.Key.releaseInfo) && package.TargetArchitecture == item.Key.Architecture)
						return item.Value;
				}

				return null;
			}
		}
	}
}