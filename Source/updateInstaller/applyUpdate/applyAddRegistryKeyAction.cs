/**
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
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyAddRegistryKeyAction : applyUpdateBase {
		private string m_path = string.Empty;
		private RegistryKey m_rootKey;

		public applyAddRegistryKeyAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyAddRegistryKayAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (addRegistryKeyAction) Action;

			m_path = action.Path;

			RegistryKey root = getRegistryRoot(action.rootHive);
			m_rootKey = root;
			onProgressChanged(
				string.Format(Language.GetString("applyAddRegistryKeyAction_progress"), action.Path, action.rootHive.ToString()),
				100);
			root.CreateSubKey(action.Path);
		}

		public override void rollbackAction() {
			onProgressChanged(string.Format(Language.GetString("applyAddRegistryKeyAction_rollback"), m_path), 100);

			if (m_rootKey.OpenSubKey(m_path).GetSubKeyNames().Length > 0 ||
			    m_rootKey.OpenSubKey(m_path).GetValueNames().Length > 0) {
				return;
			}
			m_rootKey.DeleteSubKey(m_path, false);
		}
	}
}