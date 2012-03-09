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
using System.IO;
using System.Security.Cryptography;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;
using RSA = updateSystemDotNet.Core.RSA;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyValidatePackageSignature : applyUpdateBase {
		public applyValidatePackageSignature(actionBase action, InternalConfig config, updatePackage package)
			: base(action, config, package) {
		}

		public override string actionName {
			get { return Language.GetString("applyValidatePackageAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			onProgressChanged(Language.GetString("applyValidatePackageAction_progressStep_1"), 50);

			//Paketpfad erstellen
			string packageFile = Path.Combine(currentConfiguration.Settings.downloadLocation, currentPackage.getFilename());

			//Öffentlichen Schlüssel ermitteln
			string publicKey = (string.IsNullOrEmpty(currentConfiguration.Settings.PublicKey)
			                    	? currentConfiguration.ServerConfiguration.PublicKey
			                    	: currentConfiguration.Settings.PublicKey);

			//Hashwert von dem Updatepaket ermitteln
			string packageHash = Convert.ToBase64String(SHA512.Create().ComputeHash(File.ReadAllBytes(packageFile)));

			//Signatur validieren
			if (!RSA.validateSign(packageHash, currentPackage.packageSignature, publicKey)) {
				throw new ApplicationException(string.Format(Language.GetString("applyValidatePackageAction_exception"),
				                                             currentPackage.releaseInfo.Version));
			}

			onProgressChanged(Language.GetString("applyValidatePackageAction_progressStep_2"), 100);
		}

		public override void rollbackAction() {
			return;
		}
	}
}