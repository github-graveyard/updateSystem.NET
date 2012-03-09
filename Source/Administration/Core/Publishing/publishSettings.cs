#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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
