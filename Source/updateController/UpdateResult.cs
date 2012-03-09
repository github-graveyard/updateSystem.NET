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
using System.Collections.Generic;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet {
	/// <summary>
	/// Resultat welches von der Funktion 'CheckForUpdates' zurückgegeben wird.
	/// </summary>
	public class UpdateResult {
		/// <summary>
		/// Die heruntergeladene Serverkonfiguration
		/// </summary>
		private readonly updateConfiguration m_config;

		private readonly List<updatePackage> m_newUpdates = new List<updatePackage>();

		/// <summary>
		/// Initialisiert eine neue Instanz des <see cref="UpdateResult"/>.
		/// </summary>
		/// <param name="Result">Das Suchresultat</param>
		/// <param name="Configuration">Die heruntergeladene Updatekonfiguration</param>
		/// <param name="changelogs">Ein Dictionary mit den Heruntergeladenen Changelogs.</param>
		public UpdateResult(List<updatePackage> Result, updateConfiguration Configuration, changelogDictionary changelogs) {
			m_newUpdates = Result;
			m_config = Configuration;
			Changelogs = changelogs;
		}

		/// <summary>
		/// Gibt 'True' zurück wenn Aktualisierungen gefunden wurden, andernfalls 'False'.
		/// </summary>
		public bool UpdatesAvailable {
			get { return (m_newUpdates.Count > 0); }
		}

		/// <summary>
		/// Die heruntergeladene Updatekonfiguration.
		/// </summary>
		public updateConfiguration Configuration {
			get { return m_config; }
		}

		/// <summary>
		/// Gibt eine Auflistung mit den gefundenen Updatepakten zurück.
		/// </summary>
		public List<updatePackage> newUpdatePackages {
			get { return m_newUpdates; }
		}

		///// <summary>
		///// Gibt die Changelogs für die Updatepakete zurück oder legt diese fest.<para />
		///// Der Key dieses Dictionarys ist die Versionsnummer des Updatepaketes, die Value ist der Changelog als XmlDocument.
		///// </summary>
		//internal Dictionary<string, XmlDocument> InternalChangelogs
		//{
		//    get;
		//    set;
		//}

		/// <summary>
		/// Gibt die Changelogs für die Updatepakete zurück oder legt diese fest.<para />
		/// Der Key dieses Dictionarys ist die Versionsnummer des Updatepaketes, die Value ist der Changelog als <see cref="changelogDocument"/>.
		/// </summary>
		public changelogDictionary Changelogs { get; internal set; }
	}
}