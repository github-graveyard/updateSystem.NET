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

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Flags zum Dateihandling.
	/// </summary>
	public enum fileCopyFlags {
		/// <summary>
		/// Die Datei soll immer kopiert werden auch wenn diese bereits existiert (Default)
		/// </summary>
		AlwaysOverwrite = 0,

		/// <summary>
		/// Die Datei soll nur kopiert werden, wenn die Datei bereits auf dem Zielcomputer existiert.
		/// </summary>
		OnlyIfExists = 1,

		/// <summary>
		/// Die Datei soll nur kopiert werden, wenn die Datei auf dem Zielcomputer noch nicht existiert.
		/// </summary>
		OnlyIfNotExists = 2,
	}

	/// <summary>
	/// Objekt welches verschiedene Informationen zu einer Datei enthält
	/// </summary>
	[Serializable]
	public class FileType : ICloneable {
		/// <summary>
		/// Das Zielverzeichnis auf dem Client-System
		/// </summary>
		private string m_Destination = "$approot";

		/// <summary>
		/// Der Dateiname
		/// </summary>
		private string m_Filename = string.Empty;

		/// <summary>
		/// Der vollständige Pfad zur Datei auf dem Entwicklungssystem
		/// </summary>
		private string m_Fullpath = string.Empty;

		/// <summary>
		/// Der eindeutige Hashwert der Datei, als Hashmethode wird MD5 verwendet.
		/// </summary>
		private string m_Hash = string.Empty;

		/// <summary>
		/// Die ID welche die Datei eindeutig identifiziert
		/// </summary>
		private string m_ID = string.Empty;

		/// <summary>
		/// Die Version der Datei, falls vorhanden.
		/// </summary>
		private string m_fVersion = string.Empty;

		private fileCopyFlags m_flag = fileCopyFlags.AlwaysOverwrite;

		#region " Eigenschaften "

		/// <summary>
		/// Gibt die eindeutige ID dieses Objektes zurück oder legt diese fest.
		/// </summary>
		public string ID {
			get { return m_ID; }
			set { m_ID = value; }
		}

		/// <summary>
		/// Gibt den vollständigen Pfad der Datei auf dem Entwicklungsrechner zurück oder legt diesen fest.
		/// </summary>
		public string Fullpath {
			get { return m_Fullpath; }
			set { m_Fullpath = value; }
		}

		/// <summary>
		/// Gibt den Namen der Datei zurück oder legt diesen fest.
		/// </summary>
		public string Filename {
			get { return m_Filename; }
			set { m_Filename = value; }
		}

		/// <summary>
		/// Gibt den Ziel-Rootordner der Datei an oder legt diesen fest.
		/// </summary>
		public string Destination {
			get { return m_Destination; }
			set { m_Destination = value; }
		}

		/// <summary>
		/// Gibt den Hashwert der Datei (MD5) zurück oder legt diesen fest.
		/// </summary>
		public string Hash {
			get { return m_Hash; }
			set { m_Hash = value; }
		}

		/// <summary>
		/// Gibt die Version der Datei zurück oder legt diese fest.
		/// </summary>
		public string fileVersion {
			get { return m_fVersion; }
			set { m_fVersion = value; }
		}

		/// <summary>
		/// Gibt die copyFlag für diese Datei zurück oder legt diese fest.
		/// </summary>
		public fileCopyFlags copyFlag {
			get { return m_flag; }
			set { m_flag = value; }
		}

		#endregion

		#region ICloneable Member

		/// <summary>
		/// Gibt eine Kopie des Filetypobjekts zurück.
		/// </summary>
		/// <returns></returns>
		public object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}