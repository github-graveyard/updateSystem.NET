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
