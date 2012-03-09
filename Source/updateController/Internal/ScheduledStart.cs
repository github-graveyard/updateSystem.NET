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
using Microsoft.Win32;

namespace updateSystemDotNet.Internal {
	/// <summary>
	/// Verwaltungsklasse für die geplanten UpdateStarts
	/// </summary>
	internal class ScheduledStart {
		#region " Private Properties "

		private readonly int m_custominterval;
		private readonly Interval m_interval = Interval.Always;
		private readonly string m_proj_id = string.Empty;

		#endregion

		/// <summary>
		/// Kontruktor
		/// </summary>
		/// <param name="ProjektID">ProjektID nach welcher der letzte Updateaufruf ermittelt werden soll</param>
		/// <param name="interval">Der Interval nach welchem nach Updates gesucht werden soll</param>
		/// <param name="custom_interval">Der Benutzerdefinierte Updateinterval in Tagen</param>
		public ScheduledStart(string ProjektID, Interval interval, int custom_interval) {
			m_proj_id = ProjektID;
			m_interval = interval;
			m_custominterval = custom_interval;
		}

		/// <summary>
		/// Funktion die True zurückgibt, wenn der Zeitpunkt der nächsten Updatesuche erreicht ist
		/// </summary>
		/// <returns></returns>
		public bool CanCheck() {
			if (m_interval == Interval.Always)
				return true;

			if (string.IsNullOrEmpty(m_proj_id)) //Überprüfe ob die Projekt-ID leer ist
				return true;

			try {
				string last_date_string = RetrieveLastDate();
				DateTime last_date = DateTime.Parse(last_date_string); //Das letzte Datum an dem nach Updates gesucht worden ist

				DateTime next_check = last_date; //Das Datum an welchem das nächste mal nach Update gesucht werden soll
				switch (m_interval) {
					case Interval.Daily:
						next_check = next_check.AddDays(1);
						break;
					case Interval.Weekly:
						next_check = next_check.AddDays(7);
						break;
					case Interval.Monthly:
						next_check = next_check.AddMonths(1);
						break;
					case Interval.Custom:
						next_check = next_check.AddDays(m_custominterval);
						break;
				}


				if (next_check.Date <= DateTime.Now) {
					return true;
				}

				return false;
			}
			catch //Im Fehlerfall True zurückgeben und aktuelles Datum in Registry schreiben
			{
				WriteCurrentDate();
				return true;
			}
		}

		/// <summary>
		/// Gibt das Datum des nächsten Updatechecks zurück
		/// </summary>
		/// <returns></returns>
		public DateTime Next_Date() {
			try {
				if (m_interval == Interval.Always) {
					return DateTime.Now.Date;
				} //Aktuelles Datum zurückgeben wenn jeden Immer nach Updates gesucht werden soll
				if (string.IsNullOrEmpty(m_proj_id)) {
					return DateTime.Now.Date;
				} //Aktuelles Datum zurückgeben wenn keine Projekt-ID angegeben wurde

				string last_date_string = RetrieveLastDate(); //Letzten Updatecheck aus der Registry auslesen
				if (string.IsNullOrEmpty(last_date_string)) {
					return DateTime.Now.Date;
				} //Aktuelles Datum zurückgeben wenn das auslesen Fehlerhaft war

				DateTime last_date = DateTime.Parse(last_date_string);

				DateTime next_check = last_date;
				switch (m_interval) {
					case Interval.Daily:
						next_check = last_date.AddDays(1);
						break;
					case Interval.Weekly:
						next_check = last_date.AddDays(7);
						break;
					case Interval.Monthly:
						next_check = last_date.AddMonths(1);
						break;
					case Interval.Custom:
						next_check = last_date.AddDays(m_custominterval);
						break;
				}

				return next_check;
			}
			catch {
				return DateTime.MinValue;
			} //Im Fehlerfall das aktuelle Datum zurückgeben
		}

		/// <summary>
		/// Funktion welche das letzte Datum zurückgibt an welchem nach Updates gesucht wurde
		/// </summary>
		/// <returns></returns>
		public string RetrieveLastDate() {
			try {
				//Erstelle Root-Element
				Registry.CurrentUser.CreateSubKey(Strings.AppRegHive);

				string[] value_names = Registry.CurrentUser.OpenSubKey(Strings.AppRegHive, true).GetValueNames();
				foreach (string itm in value_names) {
					if (string.Equals(itm, string.Format("{0}", m_proj_id))) {
						return Registry.CurrentUser.OpenSubKey(Strings.AppRegHive, false).GetValue(itm).ToString();
					}
				}
				return string.Empty;
			}
			catch // Im Fehlerfall einen leeren String zurückgeben
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Schreibt das aktuelle Datum in die Registry
		/// </summary>
		public void WriteCurrentDate() {
			try {
				//Erstelle Root-Element
				Registry.CurrentUser.CreateSubKey(Strings.AppRegHive);

				//Schreibe aktuelles Datum in die Registry
				Registry.CurrentUser.OpenSubKey(Strings.AppRegHive, true).SetValue(string.Format("{0}", m_proj_id),
				                                                                   DateTime.Now.ToString(), RegistryValueKind.String);
			}
			catch {
			}
		}
	}
}