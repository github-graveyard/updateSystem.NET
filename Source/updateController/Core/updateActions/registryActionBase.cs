/*
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
	/// Enumeration mit allen unterstützten Registryzweigen.
	/// </summary>
	public enum registryHives {
		/// <summary>
		/// Unter diesem Hauptschlüssel befindet sich für jeden registrierten Dateityp ein Unterschlüssel. Dieser wiederum kann eine Reihe weiterer Unterschlüssel wie zum Beispiel „ShellEx”, „ShellNew”, „OpenWithList” und viele mehr enthalten.
		/// </summary>
		HKEY_CLASSES_ROOT = 0,

		/// <summary>
		/// Der Hauptschlüssel HKEY_CURRENT_USER wird auch als „HKCU“ abgekürzt und enthält die benutzerspezifischen Konfigurationsdaten für den aktuell angemeldeten Benutzer.
		/// </summary>
		HKEY_CURRENT_USER = 1,

		/// <summary>
		/// Dieser Hauptschlüssel enthält alle computerspezifischen Einstellungen. Er wird auch als „HKLM“ abgekürzt.
		/// </summary>
		HKEY_LOCAL_MACHINE = 2
	}

	/// <summary>
	/// Enumeration mit allen unterstützten Datentypen für die Registrywerte.
	/// </summary>
	public enum registryValueTypes {
		/// <summary>
		/// REG_SZ, reiner, beliebiger Klartext (Zeichenkette).
		/// </summary>
		REG_SZ = 0,

		/// <summary>
		/// REG_BINARY, binär, dezimal und hexadezimal.
		/// </summary>
		REG_BINARY = 1,

		/// <summary>
		/// REG_DWORD, Werte von 4 Byte (Doppelwort = Double-Word), Zahlenwert zwischen 0 und 255 (Dezimal) oder 00 und FF (Hexadezimal).
		/// </summary>
		REG_DWORD = 2,

		/// <summary>
		/// REG_EXPAND_SZ (expandierbarer Text), eine erweiterbare Zeichenkette mit Variablen wie %SYSTEMROOT%, die durch die jeweils aktuellen Werte ersetzt werden, wenn ein Programm oder ein Dienst darauf zugreift (nur Windows XP).
		/// </summary>
		REG_EXPAND_SZ = 3,

		/// <summary>
		/// REG_MULTI_SZ, eine mehrzeilige Zeichenkette (Mehrfachzeichenkette), zum Beispiel eine Liste, in der die Einträge durch Leerzeichen, Kommas oder andere Trennzeichen voneinander getrennt werden (nur Windows XP).
		/// </summary>
		REG_MULTI_SZ = 4
	}


	/// <summary>
	/// Abstrakte Klasse welche als Grundlage für alle Registryactions dient.
	/// </summary>
	[Serializable]
	public abstract class registryActionBase : actionBase {
		private string m_Path = string.Empty;
		private registryHives m_rootHive;

		/// <summary>
		/// Gibt den Basisschlüssel für die Registryaction zurück oder legt diesen fest.
		/// </summary>
		public registryHives rootHive {
			get { return m_rootHive; }
			set { m_rootHive = value; }
		}

		/// <summary>
		/// Gibt den Pfad zu dem Schlüssel in der Registry zurück oder legt diesen fest.
		/// </summary>
		public string Path {
			get { return m_Path; }
			set { m_Path = value; }
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public abstract override bool Validate();
	}
}