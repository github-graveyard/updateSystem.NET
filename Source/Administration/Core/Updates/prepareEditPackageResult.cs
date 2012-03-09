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
