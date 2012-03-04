using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Objekt welches eine Auflistung aller Optionen und Dateien enthält
	/// </summary>
	[Serializable]
	public class updateConfiguration : ICloneable {
		private string m_AppName = string.Empty;

		private string m_AppURL = string.Empty;

		private bool m_EnableStatistics;
		private string m_Identifer = string.Empty;
		private string m_PublicKey = string.Empty;
		private List<updatePackage> m_packages = new List<updatePackage>();

		/// <summary>
		/// 
		/// </summary>
		public updateConfiguration() {
			statisticServer = new statisticServerType();
		}

		/// <summary>
		/// Gibt den Namen der Anwendung zurück oder legt diesen fest.
		/// </summary>
		public string applicationName {
			get { return m_AppName; }
			set { m_AppName = value; }
		}

		/// <summary>
		/// Gibt die vollqualifizierte Adresse zur Updatekonfigurationsdatei zurück oder legt diese fest.
		/// </summary>
		public string updateUrl {
			get { return m_AppURL; }
			set { m_AppURL = value; }
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob bei der Updatesuche und dem Download Statistiken an den Statistikserver übermittelt werden sollen.
		/// </summary>
		public bool enableStatistics {
			get { return m_EnableStatistics; }
			set { m_EnableStatistics = value; }
		}

		/// <summary>
		/// Gibt den verwendeten Statistikserver zurück oder legt diesen fest.
		/// </summary>
		public statisticServerType statisticServer { get; set; }

		/// <summary>
		/// Gibt den öffentlichen Schlüssel zurück, der für die Validierung der Updatepakete und der Updatekonfiguration verwendet werden soll, oder legt diesen fest.
		/// </summary>
		public string PublicKey {
			get { return m_PublicKey; }
			set { m_PublicKey = value; }
		}

		/// <summary>
		/// Gibt eine Auflistung mit allen verfügbaren Updatepaketen zurück oder legt diese fest.
		/// </summary>
		public List<updatePackage> updatePackages {
			get { return m_packages; }
			set { m_packages = value; }
		}

		/// <summary>
		/// Gibt den Identifer für diese Updatekonfiguration zurück oder legt diesen fest.
		/// </summary>
		public string projectId {
			get { return m_Identifer; }
			set { m_Identifer = value; }
		}

		/// <summary>
		/// Legt den Parameter fest, der bei einem erfolgreichem Update an die aufrufende Anwendung übergeben werden soll, oder gibt diesen zurück.
		/// <para>Vorraussetzung dafür ist, dass die Eigenschaft <see cref="updateController.restartApplication"/> den Wert True besitzt.</para>
		/// </summary>
		public string startParameterSuccess { get; set; }

		/// <summary>
		/// Legt den Parameter fest, der bei einem fehlgeschlagenen oder abgebrochenem Update an die Aufrufende Anwendung übergeben werden soll, oder gibt diesen zurück.
		/// <para>Vorraussetzung dafür ist, dass die Eigenschaft <see cref="updateController.restartApplication"/> den Wert True besitzt.</para>
		/// </summary>
		public string startParameterFailed { get; set; }

		/// <summary>
		/// Gibt die SetupId zurück oder legt diese fest welche verwendet wird um die Programversion in der Registry zu aktualisieren.
		/// </summary>
		public string setupId { get; set; }

		/// <summary>
		/// Legt fest, ob während der Updateinstallation von .NET Assemblies native abbilder erstellt werden sollen.
		/// </summary>
		public bool generateNativeImages { get; set; }

		/// <summary>Gibt den Verknüpften Statistikaccount zurück oder legt diesen fest.</summary>
		public updateLogLinkedAccount linkedUpdateLogAccount { get; set; }

		#region ICloneable Member

		/// <summary>
		/// Gibt eine genaue Kopie der Updatekonfiguration zurück.
		/// </summary>
		/// <returns></returns>
		public object Clone() {
			using (var msClone = new MemoryStream()) {
				var bfClone = new BinaryFormatter();
				bfClone.Serialize(msClone, this);

				msClone.Position = 0;
				return bfClone.Deserialize(msClone);
			}
		}

		#endregion

		///// <summary>
		///// Gibt das Base64 kodierte Anwendungssymbol zurück oder legt dieses fest.
		///// </summary>
		//public string applicationSymbol
		//{
		//    get;
		//    set;
		//}

		///// <summary>
		///// Gibt zurück oder legt ob die HostValidation aktiviert ist.
		///// </summary>
		//public bool hostValidationEnabled
		//{
		//    get;
		//    set;
		//}

		///// <summary>
		///// Gibt den öffentlichen Schlüssel zurück, der bei der HostValidation überprüft werden soll.
		///// </summary>
		//public string hostValidationKey
		//{
		//    get;
		//    set;
		//}
	}
}