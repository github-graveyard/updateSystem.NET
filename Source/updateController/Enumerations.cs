/*
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
using System.ComponentModel;

namespace updateSystemDotNet {
	/// <summary>
	/// Enumeration der verfügbaren Sprachen
	/// </summary>
	[Serializable]
	public enum Languages {
		/// <summary>
		/// Versucht die Sprache des Systems automatisch zu ermitteln. Wird die Systemsprache nicht unterstützt, wird <see cref="Languages.English"/> verwendet.
		/// </summary>
		Auto = 0,

		/// <summary>
		/// Benutzt 'Deutsch' als Sprache für den UpdateClient
		/// </summary>
		Deutsch = 1,

		/// <summary>
		/// Benutzt 'Englisch' als Sprache für den UpdateClient
		/// </summary>
		English = 2
	}

	/// <summary>
	/// Der Interval nach dem nach Updates gesucht werden soll
	/// </summary>
	[TypeConverter(typeof (EnumConverter))]
	public enum Interval {
		/// <summary>
		/// Führt bei jedem Aufruf einen Updatecheck aus
		/// </summary>
		Always = -1,

		/// <summary>
		/// Führt einmal pro Tag einen Updatecheck aus
		/// </summary>
		Daily = 0,

		/// <summary>
		/// Führt einmal pro Woche einen Updatecheck aus
		/// </summary>
		Weekly = 1,

		/// <summary>
		/// Führt einmal pro Monat einen Updatechek aus
		/// </summary>
		Monthly = 2,

		/// <summary>
		/// Führt zu einem Benutzerdefiniertem Zeitpunkt einen Updatecheck aus
		/// </summary>
		Custom = 3
	}

	/// <summary>
	/// Enumeration mit verfügbaren Authentifizierungsmodi für die Updatesuche und den Download.
	/// </summary>
	public enum authenticationModes {
		/// <summary>
		/// Verwenden Sie diese Option wenn keine Authentifizierung erforderlich ist.
		/// </summary>
		None = 0,

		/// <summary>
		/// Authentifizierung mit Benutzername und Passwort.
		/// </summary>
		Credentials = 1
	}

	/// <summary>
	/// <para>Enumeration mit Sicherheitsleveln welche angewendet werden können, wenn während des Updatevorgangs</para>
	/// <para>ein Prozess mittels <see cref="Core.updateActions.startProcessAction.needElevatedRights"/> erhöhte Rechte anfordert.</para>
	/// </summary>
	public enum processSafetyLevel {
		/// <summary>
		/// Zeigt dem Benutzer sowohl bei signierten wie auch bei unsignierten Dateien einen Sicherheitsdialog an, der Bestätigt werden muss.
		/// </summary>
		AskAlways = 0,

		/// <summary>
		/// Zeigt dem Benutzer nur bei unsignierten Dateien einen Sicherheitsdialog an, der Bestätigt werden muss.
		/// </summary>
		AskIfUnsigned = 1,

		/// <summary>
		/// Zeigt dem Benutzer weder bei signierten noch bei unsignierten Dateien einen Bestätigungsdialog an.
		/// </summary>
		AskNever = 2
	}

	/// <summary>
	/// Eine Enumeration mit den verfügbaren Releasetypen.
	/// </summary>
	/// <remarks>Neu in V.:1.1.</remarks>
	[Flags]
	public enum releaseTypes {
		/// <summary>
		/// Unfertige und instabile Version.
		/// </summary>
		Alpha = 0,

		/// <summary>
		/// Unfertigere Version.
		/// </summary>
		Beta = 1,

		/// <summary>
		/// Finale Version.
		/// </summary>
		Final = 2
	}
}