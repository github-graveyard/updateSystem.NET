/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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