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

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Enumeration mit den verfügbaren Buttons für den Nachrichtendialog.
	/// </summary>
	[Serializable]
	public enum interactionButtons {
		/// <summary>
		/// Schließen
		/// </summary>
		Close = 0,

		/// <summary>
		/// Ok, Abbrechen
		/// </summary>
		OkCancel = 1,

		/// <summary>
		/// Ja, Nein (Updateabbruch bei 'Ja')
		/// </summary>
		YesNo_1 = 2,

		/// <summary>
		/// Ja, Nein (Updateabbruch bei 'Nein')
		/// </summary>
		YesNo_2 = 3
	}

	/// <summary>
	/// Action zum Anzeigen von Nachrichten an den Benutzer während des Updateprozesses.
	/// </summary>
	[Serializable]
	public class userInteractionAction : actionBase {
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="userInteractionAction"/>.
		/// </summary>
		public userInteractionAction() {
			Buttons = interactionButtons.Close;
		}

		/// <summary>
		/// Gibt den englischen Titel der Nachricht zurück oder legt diesen fest.
		/// </summary>
		public string englishTitle { get; set; }

		/// <summary>
		/// Gibt den englischen Inhalt der Nachricht zurück oder legt diesen fest.
		/// </summary>
		public string englishMessage { get; set; }

		/// <summary>
		/// Gibt den deutschen Titel der Nachricht zurück oder legt diesen fest.
		/// </summary>
		public string germanTitle { get; set; }

		/// <summary>
		/// Gibt den deutschen Inhalt der Nachricht zurück oder legt diesen fest.
		/// </summary>
		public string germanMessage { get; set; }

		/// <summary>
		/// Gibt die Schaltflächen für die Nachricht zurück oder legt diese fest.
		/// </summary>
		public interactionButtons Buttons { get; set; }

		/// <summary>
		/// Gibt den Namen Action zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Benutzernachricht anzeigen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return true;
		}
	}
}