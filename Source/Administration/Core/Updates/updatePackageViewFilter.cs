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
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.Updates {
	[Serializable]
	public sealed class updatePackageViewFilter : ICloneable {

		/// <summary>Gibt den Suchbegriff zurück, nachdem die Updateauflistung gefiltert werden soll oder legt diesen fest.</summary>
		public string filterTerm { get; set; }

		/// <summary>Gibt an, dass alle nicht veröffentlichten Updatepakete ausgeblendet werden sollen.</summary>
		public bool hideNonReleasedPackages { get; set; }

		/// <summary>Gibt an, dass nur ServicePacks angezeigt werden sollen.</summary>
		public bool showOnlyServicePacks { get; set; }

		/// <summary>Überprüft ob die ausgewählten Filterkriterien an einem Updatepaket.</summary>
		/// <param name="package">Das Updatepaket was überprüft werden soll.</param>
		/// <returns>Gibt True zurück wenn die Filterkriterien erfüllt werden, andernfalls False.</returns>
		public bool appliesFilter(updatePackage package) {
			if(!string.IsNullOrEmpty(filterTerm)) {
				var comparsionText = (package.Description + package.releaseInfo.Version).ToLower();
				return comparsionText.Contains(filterTerm.ToLower());
			}
			if (hideNonReleasedPackages && !package.Published)
				return false;
			if (showOnlyServicePacks && !package.isServicePack)
				return false;

			return true;
		}

		#region ICloneable Member

		public object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}
