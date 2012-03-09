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
using System.Collections.Generic;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Updater {
	/// <summary>
	/// Interne Klasse welche die Updatesettings und die Serverkonfiguration beinhaltet.
	/// </summary>
	internal class InternalConfig {
		/// <summary>
		/// Das Suchresultat welches in der UpdateHelper-Library erstellt wurde.
		/// </summary>
		public List<updatePackage> Result;

		/// <summary>
		/// Die Heruntergeladene Serverkonfiguration
		/// </summary>
		public updateConfiguration ServerConfiguration;

		/// <summary>
		/// Die Updateeinstellung die der Benutzer in der UpdateHelper-Library vorgenommen hat.
		/// </summary>
		public UpdateSettings Settings;
	}
}