using System;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Enumeration mit verfügbaren Statistiktechnologien.
	/// </summary>
	public enum statisticServerTypes {
		/// <summary>
		/// Ein ASP.Net und Microsoft SQL Webdienst.
		/// </summary>
		AspNet = 0,

		/// <summary>
		/// Ein PHP und MySql Webdienst.
		/// </summary>
		Php = 1
	}

	/// <summary>
	/// Stellt Informationen über den Statistikserver bereit.
	/// </summary>
	[Serializable]
	public class statisticServerType : ICloneable {
		/// <summary>
		/// Initialisiert eine neue Instanz der statisticServerType-Klasse.
		/// </summary>
		public statisticServerType() {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der statisticServerType-Klasse.
		/// </summary>
		/// <param name="Url">Die Url unter welcher der Webservice erreichbar ist.</param>
		/// <param name="sType">Der Typ der Technologie die auf dem Server zur Verwaltung der Statistiken verwendet wird.</param>
		public statisticServerType(string Url, statisticServerTypes sType) {
			serverUrl = Url;
			serverType = sType;
		}

		/// <summary>
		/// Gibt den Anzeigenamen für den Statistikserver zurück oder legt diesen fest.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gibt eine ID zurück welche das Element Identifiziert oder legt diese fest.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gibt die Url des Webservice zurück oder legt diese fest.
		/// </summary>
		public string serverUrl { get; set; }

		/// <summary>
		/// Gibt die verwendete Technologie zurück oder legt diese fest.
		/// </summary>
		public statisticServerTypes serverType { get; set; }

		#region ICloneable Members

		/// <summary>
		/// Gibt eine Kopie des statisticServerType zurück.
		/// </summary>
		/// <returns></returns>
		public virtual object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}