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

using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.Updates {
	/// <summary>Klasse welche Information für zu bearbeitende Updatepakete bereitstellt.</summary>
	internal sealed class prepareEditPackageResult {

		/// <summary>Gibt den Pfad zurück in welchem sich die temporär gespeicherten Updatedaten befinden.</summary>
		public string tempPackagePath { get; set; }

		/// <summary>Gibt das zu bearbeitende Updatepaket zurück.</summary>
		public updatePackage updatePackage { get; set; }

		/// <summary>Gibt den deutschen Changelog zurück.</summary>
		public string changelogGerman { get; set; }

		/// <summary>Gibt den englischen Changelog zurück.</summary>
		public string changelogEnglish { get; set; }

	}
}
