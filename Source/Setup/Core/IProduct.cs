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

namespace updateSystemDotNet.Setup.Core {
	internal interface IProduct {
		/// <summary>Gibt den Namen des Programms zurück welches nach dem Setup gestartet werden soll.</summary>
		string mainExecutable { get; }

		/// <summary>Ermittelt den Namen des Setups für die Deinstallation.</summary>
		string setupName { get; }

		/// <summary>Gibt die Kontaktemail zurück.</summary>
		string Contact { get; }

		/// <summary>Gibt die aktuell installierte Version zurück.</summary>
		Version currentVersion { get; }

		/// <summary>Gibt die Beschreibung der Anwendung zurück.</summary>
		string Description { get; }

		/// <summary>Gibt die neueste Version der Anwendung zurück.</summary>
		Version newVersion { get; }

		/// <summary>Gibt den Namen des Produktes zurück.</summary>
		string Product { get; }

		/// <summary>Gibt den Namen des Herausgebers zurück.</summary>
		string Publisher { get; }

		/// <summary>Gibt eine Internetadresse zurück an welcher Supportinformationen über das Produkt zu finden sind.</summary>
		string supportUrl { get; }

		/// <summary>Gibt eine Zeichenfolge im GUID-Format zurück mit welcher das Produkt eindeutig Identifiziert werden kann.</summary>
		string applicationID { get; }
	}
}