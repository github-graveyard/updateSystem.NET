using System;
using System.Collections.Generic;
using System.Xml;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Bietet direkten Zugriff auf die Daten eines updateSystem.Net Changelogs im Xml-Format.
	/// </summary>
	public class changelogDocument {
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="changelogDocument"/>-Klasse.
		/// </summary>
		/// <param name="changelogXml"></param>
		public changelogDocument(XmlDocument changelogXml) {
#pragma warning disable
			changelogItems = new List<changelogDocumentItem>();
			rawChangelog = changelogXml;

			XmlNodeList changeNodes = changelogXml.SelectNodes("updateSystemDotNet.Changelog/Items/Item");

			if (changeNodes.Count > 0)
				germanChanges = changeNodes[0].SelectSingleNode("Change").InnerText;
			if (changeNodes.Count > 1)
				englishChanges = changeNodes[1].SelectSingleNode("Change").InnerText;

			foreach (XmlNode node in changelogXml.SelectNodes("updateSystemDotNet.Changelog/Items/Item")) {
				try {
					changelogItems.Add(new changelogDocumentItem(
					                   	node.SelectSingleNode("Developer").InnerText,
					                   	node.SelectSingleNode("Type").InnerText,
					                   	node.SelectSingleNode("Language").InnerText,
					                   	node.SelectSingleNode("Change").InnerText
					                   	));
#pragma warning enable
				}
				catch (NullReferenceException) {
				}
			}
		}

		/// <summary>
		/// Gibt die Änderungen in deutscher Sprache zurück.
		/// </summary>
		public string germanChanges { get; private set; }

		/// <summary>
		/// Gibt die Änderungen in englischer Sprache zurück.
		/// </summary>
		public string englishChanges { get; private set; }

		/// <summary>
		/// Gibt eine Liste von <see cref="changelogDocumentItem"/> zurück.
		/// </summary>
		[Obsolete(
			"Bitte germanChanges bzw. englishChanges verwenden. Diese Eigenschaft wird mit dem nächsten Release entfernt.", false
			)]
		public List<changelogDocumentItem> changelogItems { get; private set; }

		/// <summary>
		/// Gibt das original Changelogdokument zurück.
		/// </summary>
		public XmlDocument rawChangelog { get; private set; }
	}
}