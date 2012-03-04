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