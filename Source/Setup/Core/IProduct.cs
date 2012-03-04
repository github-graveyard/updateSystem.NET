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