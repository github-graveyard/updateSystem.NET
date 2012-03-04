using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Objekt welches Informationen über Updatepaket anbietet
	/// </summary>
	[Serializable]
	public class updatePackage : ICloneable {
		#region SupportedArchitectures enum

		/// <summary>
		/// Enumeration mit unterstützten Prozessorarchitekturen
		/// </summary>
		public enum SupportedArchitectures {
			/// <summary>
			/// Beide Architekturen, x84 und x64
			/// </summary>
			Both = 0,

			/// <summary>
			/// Nur x86
			/// </summary>
			x86 = 1,

			/// <summary>
			/// Nur x64
			/// </summary>
			x64 = 2
		}

		#endregion

		private string m_Description = string.Empty;

		private string m_ID = string.Empty;
		private List<VersionEx> m_OwnVersionList = new List<VersionEx>();
		private long m_PackageSize;
		private string m_ReleaseDate = string.Empty;
		private SupportedArchitectures m_TargetArchitecture = SupportedArchitectures.Both;
		private bool m_UseOwnVersionList;
		private bool m_isBeta;
		private bool m_isServicePack;
		private string m_package_signature = string.Empty;

		private bool m_published = true;

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="updatePackage"/>.
		/// </summary>
		public updatePackage() {
			releaseInfo = new releaseInfo();
			customFields = new serializableDictionary<string, string>();
			publishDate = DateTime.MinValue;
		}

		/// <summary>
		/// Gibt die ID zur Identifizierung zurück oder legt diese fest.
		/// </summary>
		public string ID {
			get { return m_ID; }
			set { m_ID = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob das Update veröffentlicht wurde.
		/// </summary>
		public bool Published {
			get { return m_published; }
			set { m_published = value; }
		}

		/// <summary>
		/// Gibt die Paketbeschreibung zurück oder legt diese fest.
		/// </summary>
		public string Description {
			get { return m_Description; }
			set { m_Description = value; }
		}

		//private string _version;
		/// <summary>
		/// Gibt die Paketversion zurück oder legt diese fest.
		/// </summary>
		//[Obsolete("Ersetzt durch releaseInfo.Version", false)]
		public string Version {
			//get { return _version; }
			//set { _version = value; }
			get { return releaseInfo.Version; }
			set { releaseInfo.Version = value; }
		}

		/// <summary>
		/// Gibt das Datum zurück an welchem das Paket erstellt worden ist oder legt dieses fest.
		/// </summary>
		public string ReleaseDate {
			get { return m_ReleaseDate; }
			set { m_ReleaseDate = value; }
		}

		/// <summary>
		/// Gibt die digitale Signatur zurück welche zur Validierung des Pakets verwendet werden soll oder legt diese fest.
		/// </summary>
		public string packageSignature {
			get { return m_package_signature; }
			set { m_package_signature = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest, ob nur eine bestimmte Liste mit erlaubten Versionen bei der Updatesuche verwendet werden soll.
		/// </summary>
		public bool UseOwnVersionList {
			get { return m_UseOwnVersionList; }
			set { m_UseOwnVersionList = value; }
		}


		/// <summary>
		/// Gibt die Liste mit den erlaubten Versionen zurück oder legt diese fest.
		/// </summary>
		public List<VersionEx> OwnVersionList {
			get { return m_OwnVersionList; }
			set { m_OwnVersionList = value; }
		}


		/// <summary>
		/// Gibt die Prozessorarchitektur zurück für welche dieses Updatepaket ausgelegt ist oder legt diese fest.
		/// </summary>
		public SupportedArchitectures TargetArchitecture {
			get { return m_TargetArchitecture; }
			set { m_TargetArchitecture = value; }
		}

		/// <summary>
		/// Gibt die Paketgröße in Byte zurück oder legt diese fest.
		/// </summary>
		public long packageSize {
			get { return m_PackageSize; }
			set { m_PackageSize = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest, ob es sich bei diesem Updatepaket um eine Betaversion handelt.
		/// </summary>
		public bool isBeta {
			get { return m_isBeta; }
			set { m_isBeta = value; }
		}


		/// <summary>
		/// Gibt zurück oder legt fest, ob es sich bei diesem Updatepaket um ein Service Pack handelt.
		/// </summary>
		public bool isServicePack {
			get { return m_isServicePack; }
			set { m_isServicePack = value; }
		}

		/// <summary>
		/// Gibt den Releasetype für dieses Updatepaket zurück oder legt diesen fest.
		/// </summary>
		/// <remarks>Neu in V.:1.1.</remarks>
		public releaseInfo releaseInfo { get; set; }

		/// <summary>
		/// Gibt an oder legt fest ob für dieses Paket bereits der neue Dateiname verwendet wird.
		/// </summary>
		/// <remarks>Neu in V.:1.1.</remarks>
		public bool useNewFileFormat { get; set; }

		/// <summary>Gibt ein Dictionary mit Benutzerdefinierten Daten zurück oder legt dieses fest.</summary>
		public serializableDictionary<string, string> customFields { get; set; }

		/// <summary>Gibt das Datum zurück an welchem das Update veröffentlicht wurde oder legt dieses fest.</summary>
		public DateTime publishDate { get; set; }

		/// <summary>Erstellt einen Namen aus Versionsnummer und Releasestatus.</summary>
		public override string ToString() {
			var sbName = new StringBuilder();
			sbName.Append(releaseInfo.Version);
			if (releaseInfo.Type != releaseTypes.Final)
				sbName.AppendFormat(" ({0} {1})", releaseInfo.Type, releaseInfo.Step);
			return sbName.ToString();
		}

		/// <summary>
		/// Generiert den Dateinamen des Updatepaketes auf dem Server.
		/// </summary>
		/// <returns></returns>
		/// <remarks>Neu in V.:1.1.</remarks>
		public string getFilename() {
			if (useNewFileFormat) {
				return string.Format("{0}.zip", ID);
			}
			else {
				return string.Format("{0}{1}.version.zip", Helper.getPraefix(TargetArchitecture), releaseInfo.Version);
			}
		}

		/// <summary>
		/// Generiert den Dateinamen des Changelogs auf dem Server
		/// </summary>
		/// <returns></returns>
		/// <remarks>Neu in V.:1.1.</remarks>
		public string getChangelogFilename() {
			if (useNewFileFormat) {
				return string.Format("{0}.xml", ID);
			}
			else {
				return string.Format("{0}{1}.Changelog.Xml", Helper.getPraefix(TargetArchitecture), releaseInfo.Version);
			}
		}

		#region " Updateactions "

		private List<string> m_actionOrder = new List<string>();
		private List<addRegistryKeyAction> m_addRegistryKeyActions = new List<addRegistryKeyAction>();
		private List<addRegistryValueAction> m_addRegistryValueActions = new List<addRegistryValueAction>();
		private List<closeProcessAction> m_closeProcessActions = new List<closeProcessAction>();
		private List<deleteFilesAction> m_deleteFilesActions = new List<deleteFilesAction>();
		private List<fileCopyAction> m_fileCopyActions = new List<fileCopyAction>();
		private List<removeRegistryKeyAction> m_removeRegistryKeyActions = new List<removeRegistryKeyAction>();
		private List<removeRegistryValuesAction> m_removeRegistryValueActions = new List<removeRegistryValuesAction>();
		private List<renameFileAction> m_renameFileActions = new List<renameFileAction>();
		private List<startProcessAction> m_startProcessActions = new List<startProcessAction>();
		private List<startServiceAction> m_startServiceActions = new List<startServiceAction>();
		private List<stopServiceAction> m_stopServiceActions = new List<stopServiceAction>();
		private List<userInteractionAction> m_userInteractionActions = new List<userInteractionAction>();

		/// <summary>
		/// Gibt die Reihenfolge der Updateactions zurück oder legt diese fest.
		/// </summary>
		public List<string> actionOrder {
			get { return m_actionOrder; }
			set { m_actionOrder = value; }
		}

		/// <summary>
		/// Gibt die closeProcessActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<closeProcessAction> closeProcessActions {
			get { return m_closeProcessActions; }
			set { m_closeProcessActions = value; }
		}

		/// <summary>
		/// Gibt die startProcessActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<startProcessAction> startProcessActions {
			get { return m_startProcessActions; }
			set { m_startProcessActions = value; }
		}

		/// <summary>
		/// Gibt die fileCopyActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<fileCopyAction> fileCopyActions {
			get { return m_fileCopyActions; }
			set { m_fileCopyActions = value; }
		}

		/// <summary>
		/// Gibt die renameFileActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<renameFileAction> renameFileActions {
			get { return m_renameFileActions; }
			set { m_renameFileActions = value; }
		}

		/// <summary>
		/// Gibt die deleteFilesActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<deleteFilesAction> deleteFilesActions {
			get { return m_deleteFilesActions; }
			set { m_deleteFilesActions = value; }
		}

		/// <summary>
		/// Gibt die startServiceActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<startServiceAction> startServiceActions {
			get { return m_startServiceActions; }
			set { m_startServiceActions = value; }
		}

		/// <summary>
		/// Gibt die stopServiceActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<stopServiceAction> stopServiceActions {
			get { return m_stopServiceActions; }
			set { m_stopServiceActions = value; }
		}

		/// <summary>
		/// Gibt die addRegistryKeyActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<addRegistryKeyAction> addRegistryKeyActions {
			get { return m_addRegistryKeyActions; }
			set { m_addRegistryKeyActions = value; }
		}

		/// <summary>
		/// Gibt die removeRegistryKeyActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<removeRegistryKeyAction> removeRegistryKeyActions {
			get { return m_removeRegistryKeyActions; }
			set { m_removeRegistryKeyActions = value; }
		}

		/// <summary>
		/// Gibt die addRegistryValueActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<addRegistryValueAction> addRegistryValueActions {
			get { return m_addRegistryValueActions; }
			set { m_addRegistryValueActions = value; }
		}

		/// <summary>
		/// Gibt die removeRegistryValueActions für das Updatetpaket zurück oder legt diese fest.
		/// </summary>
		public List<removeRegistryValuesAction> removeRegistryValueActions {
			get { return m_removeRegistryValueActions; }
			set { m_removeRegistryValueActions = value; }
		}

		/// <summary>
		/// Gibt die userInteractionActions für das Updatepaket zurück oder legt diese fest.
		/// </summary>
		public List<userInteractionAction> userInteractionActions {
			get { return m_userInteractionActions; }
			set { m_userInteractionActions = value; }
		}

		#endregion

		#region ICloneable Member

		/// <summary>
		/// Gibt eine Kopie des Objektes zurück.
		/// </summary>
		/// <returns></returns>
		public object Clone() {
			var bf = new BinaryFormatter();
			using (var msCopy = new MemoryStream()) {
				bf.Serialize(msCopy, this);
				msCopy.Position = 0;
				return bf.Deserialize(msCopy);
			}
		}

		#endregion
	}
}