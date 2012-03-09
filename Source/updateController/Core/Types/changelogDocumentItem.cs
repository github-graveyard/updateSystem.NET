/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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