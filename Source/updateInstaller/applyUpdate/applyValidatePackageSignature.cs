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