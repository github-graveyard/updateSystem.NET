using System;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Klasse welche Informationen über die einzelnen Changelogeinträge bereitstellt.
	/// <para>Wird von <see cref="changelogDocument"/> benötigt.</para>
	/// </summary>
	public class changelogDocumentItem {
		internal changelogDocumentItem(string sDeveloper, string sItemType, string sLanguage, string sChange) {
			Developer = sDeveloper;
			itemType = sItemType;
			Change = sChange;

			try {
				Language = (Languages) Enum.Parse(typeof (Languages), sLanguage);
			}
			catch {
				Language = Languages.English;
			}
		}

		/// <summary>
		/// Gibt den Namen des Entwicklers zurück.
		/// </summary>
		public string Developer { get; private set; }

		/// <summary>
		/// Gibt den Typ des Eintrages zurück. Zum Beispiel "Bug" oder "Verbesserung".
		/// </summary>
		public string itemType { get; private set; }

		/// <summary>
		/// Gibt die Sprache des Eintrages zurück.
		/// <para>Hinweis: Der Enumwert <see cref="Languages.Auto"/> wird nie verwendet.</para>
		/// </summary>
		public Languages Language { get; private set; }

		/// <summary>
		/// Gibt den Text der Änderung zurück.
		/// </summary>
		public string Change { get; private set; }
	}
}