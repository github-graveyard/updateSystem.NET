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
