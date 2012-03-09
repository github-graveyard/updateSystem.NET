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
using System.Xml.Serialization;
using System.Drawing;
using System.IO;

namespace updateSystemDotNet.Administration.Core.Application {
	
	[Serializable]
	[XmlRoot("applicationSettings")]
	public class applicationSettings : ICloneable {

		public applicationSettings() {
			windowPositions = new serializableDictionary<string, Point>();
			windowSizes = new serializableDictionary<string, Size>();
			columnSizes = new serializableDictionary<string, int>();
			proxySettings = new proxySettings();
			enableLogging = true;
			showToolBar = true;
			statisticRequestDocument = "Default.ashx";
			updateChannelIndex = 1;
			checkForUpdatesAtStartup = true;
		}

		/// <summary>Gibt eine Auflistung der gespeicherten Fenstergrößen zurück.</summary>
		public serializableDictionary<string, Size> windowSizes { get; set; }

		/// <summary>Gibt eine Auflistung der gespeicherten Fensterpositionen zurück.</summary>
		public serializableDictionary<string, Point> windowPositions { get; set; }

		/// <summary>Gibt eine Auflistung mit Columnnamen und deren Breite zurück.</summary>
		public serializableDictionary<string, int> columnSizes { get; set; }

		/// <summary>Gibt an ob Anwendungsereignisse geloggt werden sollen.</summary>
		public bool enableLogging { get; set; }

		/// <summary>Legt fest ob die Antworten vom FTP-Server geloggt werden sollen.</summary>
		public bool logFtpOutput { get; set; }

		/// <summary>Legt fest ob die Requests und Responses vom updateLog-Server geloggt werden sollen.</summary>
		public bool logUpdatelog { get; set; }

		/// <summary>Gibt den gespeicherten Namen zurück der beim senden der Feedbacks verwendet wurde oder legt diesen fest.</summary>
		public string feedbackName { get; set; }

		/// <summary>Gibt die verwendete E-Mailadresse zurück die beim senden des Feedbacks verwendet wurde, oder legt diese fest.</summary>
		public string feedbackEMail { get; set; }

		/// <summary>Die Konfiguration des Proxyservers für alle WebRequests und die Updatesuche.</summary>
		public proxySettings proxySettings { get; set; }

		/// <summary>Gibt an, ob auf der Hauptform die ToolBar angezeigt werden soll oder nicht.</summary>
		public bool showToolBar { get; set; }

		/// <summary>Gibt das Dokument auf dem Statistikserver zurück, an das die Anfragen gesendet werden sollen. Default ist hier Default.ashx</summary>
		public string statisticRequestDocument { get; set; }

		/// <summary>Gibt den Updatekanal zurück der verwendet werden soll.</summary>
		public int updateChannelIndex { get; set; }

		/// <summary>Legt fest, ob beim Programmstart nach Updates gesucht werden soll.</summary>
		public bool checkForUpdatesAtStartup { get; set; }

		#region I/O

		private static string settingsPath{get { return Path.Combine(Strings.settingsDirectory, "Administration.Settings.xml"); }}

		public static void Save(applicationSettings instance) {
			if (!Directory.Exists(Strings.settingsDirectory))
				Directory.CreateDirectory(Strings.settingsDirectory);

			secureSerializer.Serialize(settingsPath, instance);

		}

		public static applicationSettings Load() {

			if (File.Exists(settingsPath))
				return secureSerializer.Deserialize<applicationSettings>(settingsPath);

			return new applicationSettings();

		}

		#endregion


		#region ICloneable Member

		public object Clone() {
			return new applicationSettings {
			                               	windowPositions = (serializableDictionary<string, Point>) windowPositions.Clone(),
			                               	windowSizes = (serializableDictionary<string, Size>) windowSizes.Clone(),
			                               	columnSizes = (serializableDictionary<string, int>) columnSizes.Clone(),
			                               	enableLogging = enableLogging,
			                               	feedbackName = feedbackName,
			                               	feedbackEMail = feedbackEMail,
			                               	proxySettings = (proxySettings) proxySettings.Clone(),
			                               	logFtpOutput = logFtpOutput,
			                               	logUpdatelog = logUpdatelog,
			                               	showToolBar = showToolBar,
			                               	statisticRequestDocument = statisticRequestDocument,
			                               	updateChannelIndex = updateChannelIndex,
			                               	checkForUpdatesAtStartup = checkForUpdatesAtStartup
			                               };
		}

		#endregion
	}
}
