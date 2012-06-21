/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Ein Klasse welche erweiterte Versionsinformationen bereitstellt.
	/// </summary>
	[Serializable]
	public sealed class enhancedVersion {
		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="enhancedVersion"/>.
		/// </summary>
		/// <param name="rInfo">Das Versionsobjekt welches für diese Instanz verwendeten werden soll.</param>
		internal enhancedVersion(releaseInfo rInfo)
			: this(rInfo, updatePackage.SupportedArchitectures.Both) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="enhancedVersion"/>.
		/// </summary>
		/// <param name="rInfo">Das Versionsobjekt welches für diese Instanz verwendeten werden soll.</param>
		/// <param name="architecture">Die Prozessorarchitektur für welche dieses Versionsobjekt gültig ist.</param>
		internal enhancedVersion(releaseInfo rInfo, updatePackage.SupportedArchitectures architecture) {
			releaseInfo = rInfo;
			Architecture = architecture;
		}

		/// <summary>
		/// Gibt die Versionsnummer zurück oder legt diese fest.
		/// </summary>
		public releaseInfo releaseInfo { get; internal set; }

		/// <summary>
		/// Gibt die Prozessorarchitektur dieser Version zurück oder legt diese fest.
		/// </summary>
		public updatePackage.SupportedArchitectures Architecture { get; internal set; }
	}
}