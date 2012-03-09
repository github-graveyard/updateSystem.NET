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
namespace updateSystemDotNet.Administration.Core.Publishing {

	/// <summary>Klasse welche erweiterte Eigenschaften und Einstellungen für den PublishProvider bereitstellt.</summary>
	public sealed class publishSettings : ICloneable{
		
		/// <summary>
		/// Initialisert eine neue Instanz der publishSettings.
		/// </summary>
		public publishSettings() {
			isActive = true;
			customSettings = new serializableDictionary<string, string>();
			lastPublished = DateTime.MinValue;
		}

		/// <summary>Eindeutige ID um die einzelnen Provider identifizieren zu können.</summary>
		public string Id { get; set; }

		/// <summary>ID des Publishproviders.</summary>
		public string parentId { get; set; }

		/// <summary>Gibt den Namen für den PublishProvider zurück oder legt diesen fest.</summary>
		public string Name { get; set; }

		/// <summary>Gibt True zurück wenn der Provider aktiv ist, andernfalls False.</summary>
		public bool isActive { get; set; }

		/// <summary>Gibt das Datum zurück an dem der Provider das letzte Mal benutzt wurde.</summary>
		public DateTime lastPublished { get; set; }

		/// <summary>Hier werden je nach Provider unterschiedliche Einstellungen gespeichert, wie z.B. die Zugangsdaten zum FTP Server o.ä.</summary>
		public serializableDictionary<string, string> customSettings { get; set; }


		#region ICloneable Member

		public object Clone() {
			return new publishSettings {
			                           	customSettings = (serializableDictionary<string, string>) customSettings.Clone(),
			                           	isActive = isActive,
			                           	Name = Name,
			                           	parentId = parentId,
			                           	Id = Id,
										lastPublished = lastPublished
			                           };
		}

		#endregion
	}
}
