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