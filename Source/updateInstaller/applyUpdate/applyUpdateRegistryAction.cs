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