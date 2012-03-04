using System.Collections.Generic;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateRegistryAction : applyUpdateBase {
		private string oldVersion = string.Empty;

		private string uninstallHive =
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";

		private string uninstallHiveX86 =
			@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";

		public applyUpdateRegistryAction(actionBase action, InternalConfig config)
			: base(action, config, new updatePackage()) {
		}

		public override string actionName {
			get { return Language.GetString("applyUpdateRegistryAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			//Ohne Adminrechte keine Schreibrechte in der Registry im HKEY_LOCAL_MACHINE HIVE
			if (!isAdmin)
				return;

			//Überprüfe ob der Schlüssel existiert
			RegistryKey key = Registry.LocalMachine.OpenSubKey(uninstallHive + currentConfiguration.ServerConfiguration.setupId,
			                                                   true);

			if (key == null) {
				key = Registry.LocalMachine.OpenSubKey(uninstallHiveX86 + currentConfiguration.ServerConfiguration.setupId, true);
			}

			if (key == null)
				return;

			if (new List<string>(key.GetValueNames()).Contains("DisplayVersion")) {
				oldVersion = (string) key.GetValue("DisplayVersion");
				key.SetValue("DisplayVersion", (Action as updateRegistryAction).newVersion, RegistryValueKind.String);
			}
		}

		public override void rollbackAction() {
			if (!string.IsNullOrEmpty(oldVersion)) {
				RegistryKey key = Registry.LocalMachine.OpenSubKey(
					uninstallHive + currentConfiguration.ServerConfiguration.setupId, true);
				if (key == null) {
					key = Registry.LocalMachine.OpenSubKey(uninstallHiveX86 + currentConfiguration.ServerConfiguration.setupId, true);
				}

				key.SetValue("DisplayVersion", oldVersion, RegistryValueKind.String);
			}
		}
	}
}