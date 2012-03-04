using System.IO;
using System.Text;
using System.Xml.Serialization;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Core {
	/// <summary>
	/// Klasse welche Funktionen zur de-/serialisierung von Projektdateien bereistellt
	/// </summary>
	public class Serializer {
		/// <summary>
		/// Serialisiert die Konfigurationsdatei und gibt diese als String zurück
		/// </summary>
		/// <param name="Config">The Configurationinstance</param>
		/// <returns>string</returns>
		public static string Serialize(updateConfiguration Config) {
			using (var msData = new MemoryStream()) {
				using (var swData = new StreamWriter(msData, Encoding.UTF8)) {
					var xs = new XmlSerializer(typeof (updateConfiguration));
					xs.Serialize(swData, Config);
				}
				return Encoding.UTF8.GetString(msData.ToArray());
			}
		}

		/// <summary>
		/// Deserialisiert die Konfigurationsdatei aus einem String
		/// </summary>
		/// <param name="data">Der String welcher die Konfigurationsdatei enthält</param>
		/// <returns>Types.updateConfig</returns>
		public static updateConfiguration Deserialize(string data) {
			using (var msData = new MemoryStream(Encoding.UTF8.GetBytes(data))) {
				using (var srData = new StreamReader(msData, Encoding.UTF8)) {
					var xs = new XmlSerializer(typeof (updateConfiguration));
					var config = (updateConfiguration) xs.Deserialize(srData);

					return config;
				}
			}
		}
	}
}