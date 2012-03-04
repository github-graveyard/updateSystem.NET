using System;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Erweiterte Versionsklasse
	/// </summary>
	[Serializable]
	public class VersionEx {
		/// <summary>
		/// Die Build Versionsnummer
		/// </summary>
		public int Build;

		/// <summary>
		/// Die Major Versionsnummer
		/// </summary>
		public int Major;

		/// <summary>
		/// Die Minor Versionsnummer
		/// </summary>
		public int Minor;

		/// <summary>
		/// Die Revision Versionsnummer
		/// </summary>
		public int Revision;

		/// <summary>
		/// Default-Kontruktor
		/// </summary>
		public VersionEx() {
		}

		/// <summary>
		/// Kontruktor
		/// </summary>
		/// <param name="vMajor">Der Major Versionsnummer</param>
		/// <param name="vMinor">Die Minor Versionsnummer</param>
		/// <param name="vBuild">Die Build Versionsnummer</param>
		/// <param name="vRevision">Die Revisions Versionsnummer</param>
		public VersionEx(int vMajor, int vMinor, int vBuild, int vRevision) {
			Major = vMajor;
			Minor = vMinor;
			Build = vBuild;
			Revision = vRevision;
		}

		/// <summary>
		/// Kontruktor
		/// </summary>
		/// <param name="VersionString">Ein String welcher die komplette Versionsnummer enthält</param>
		public VersionEx(string VersionString) {
			string[] parts = VersionString.Split(new[] {char.Parse(".")});
			if (parts.Length >= 1) {
				Major = int.Parse(parts[0]);
			}
			if (parts.Length >= 2) {
				Minor = int.Parse(parts[1]);
			}
			if (parts.Length >= 3) {
				Build = int.Parse(parts[2]);
			}
			if (parts.Length >= 4) {
				Revision = int.Parse(parts[3]);
			}
		}

		/// <summary>
		/// Gibt die vollständig formatierte Versionsnummer zurück
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return string.Format("{0}.{1}.{2}.{3}",
			                     new[] {Major.ToString(), Minor.ToString(), Build.ToString(), Revision.ToString()});
		}

		/// <summary>
		/// Gibt die einzelnen Versionsnummer in einem 'Version'-Objekt zurück
		/// </summary>
		/// <returns></returns>
		public Version ToVersion() {
			return new Version(Major, Minor, Build, Revision);
		}
	}
}