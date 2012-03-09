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