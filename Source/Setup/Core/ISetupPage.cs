using System;
using updateSystemDotNet.Setup.UI.setupPages;

namespace updateSystemDotNet.Setup.Core {
	internal interface ISetupPage {
		/// <summary>Gibt das aktuelle Setupcontext zurück welches erweiterte Informationen über die Anwendung bereitstellt.</summary>
		setupContext Context { get; set; }

		/// <summary>Gibt den Titel der aktuellen Seite zurück.</summary>
		string Title { get; }

		/// <summary>Gibt an, ob der Assistent beim Klick auf Weiter geschlossen werden soll</summary>
		bool isLastPage { get; }

		/// <summary>Gibt das Steuerelement zurück welches zur Anzeige im Setup verwendet werden soll.</summary>
		basePage View { get; }

		/// <summary>Der Type der Assistentenseite die beim Klick auf "Zurück" geladen werden soll.</summary>
		/// <remarks>Null zurückgeben um die Funktionalität zu deaktivieren.</remarks>
		Type forwardPage { get; }

		/// <summary>Der Type der Assistentenseite die beim Klick auf "Weiter" geladen werden soll.</summary>
		/// <remarks>Null zurückgeben um die Funktionalität zu deaktivieren.</remarks>
		Type backwardPage { get; }
	}
}