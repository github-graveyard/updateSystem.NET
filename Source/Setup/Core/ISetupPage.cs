#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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