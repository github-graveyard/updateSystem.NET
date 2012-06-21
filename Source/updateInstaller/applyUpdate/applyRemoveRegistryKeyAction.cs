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
using System.Collections.Generic;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyRemoveRegistryKeyAction : applyUpdateBase {
		private readonly List<string> m_removedKeys = new List<string>();
		private readonly List<rollbackRegistryItem> m_removedValues = new List<rollbackRegistryItem>();
		private RegistryKey m_rootKey;


		public applyRemoveRegistryKeyAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyRemoveRegistryKeyAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (removeRegistryKeyAction) Action;

			RegistryKey rootKey = getRegistryRoot(action.rootHive);
			m_rootKey = rootKey;

			//Erstelle ein Backup des Registryschlüssels einschl. aller Unterschlüssel
			getSubKeys(m_removedKeys, rootKey, action.Path);
			//Sichere Registrywerte in dem Rootschlüssel
			m_removedKeys.Add(action.Path);
			onProgressChanged(Language.GetString("applyRemoveRegistryKeyAction_progressStep_1"), 30);
			foreach (string baseRegVal in rootKey.OpenSubKey(action.Path).GetValueNames()) {
				m_removedValues.Add(new rollbackRegistryItem(action.Path, baseRegVal,
				                                             rootKey.OpenSubKey(action.Path).GetValue(baseRegVal),
				                                             rootKey.OpenSubKey(action.Path).GetValueKind(baseRegVal)));
			}
			//Sichere Registrywerte in allen Unterschlüsseln
			onProgressChanged(Language.GetString("applyRemoveRegistryKeyAction_progressStep_2"), 60);
			foreach (string Item in m_removedKeys) {
				foreach (string regVal in rootKey.OpenSubKey(Item).GetValueNames()) {
					m_removedValues.Add(new rollbackRegistryItem(Item, regVal, m_rootKey.OpenSubKey(Item).GetValue(regVal),
					                                             m_rootKey.OpenSubKey(Item).GetValueKind(regVal)));
				}
			}

			//Registryschlüssel löschen
			onProgressChanged(
				string.Format(Language.GetString("applyRemoveRegistryKeyAction_progressStep_3"), rootKey, action.Path), 100);
			rootKey.DeleteSubKeyTree(action.Path);
		}

		/// <summary>
		/// Funktion zum rekursiven Durchsuchen von Registryschlüsseln.
		/// </summary>
		/// <param name="subKeys">List<string> in welche die Unterschlüssel kopiert werden sollen.<param>
		/// <param name="root">Der Stammschlüssel.</param>
		/// <param name="basePath">Das Basispfad.</param>
		private void getSubKeys(List<string> subKeys, RegistryKey root, string basePath) {
			try {
				foreach (string subKey in root.OpenSubKey(basePath).GetSubKeyNames()) {
					subKeys.Add(basePath + @"\" + subKey);
					getSubKeys(subKeys, root, basePath + @"\" + subKey);
				}
			}
			catch {
			}
		}

		public override void rollbackAction() {
			int itemCount = 0;
			int totalCount = m_removedKeys.Count + m_removedValues.Count;

			//Schlüssel anlegen
			foreach (string rbKey in m_removedKeys) {
				onProgressChanged(string.Format(Language.GetString("applyRemoveRegistryKeyAction_rollbackStep_1"), rbKey),
				                  Percent(itemCount, totalCount));
				m_rootKey.CreateSubKey(rbKey);
				itemCount++;
			}

			//Werte zurückschreiben
			foreach (rollbackRegistryItem rbValue in m_removedValues) {
				onProgressChanged(string.Format(Language.GetString("applyRemoveRegistryKeyAction_rollbackStep_2"), rbValue.Name),
				                  Percent(itemCount, totalCount));
				m_rootKey.OpenSubKey(rbValue.Path).SetValue(rbValue.Name, rbValue.Value, rbValue.ValueKind);
				itemCount++;
			}
		}

		#region Nested type: rollbackRegistryItem

		private struct rollbackRegistryItem {
			private readonly string m_Name;
			private readonly string m_Path;
			private readonly object m_Value;
			private readonly RegistryValueKind m_ValueKind;

			public rollbackRegistryItem(string path, string name, object value, RegistryValueKind valueKind) {
				m_Path = path;
				m_Name = name;
				m_Value = value;
				m_ValueKind = valueKind;
			}

			public string Path {
				get { return m_Path; }
			}

			public string Name {
				get { return m_Name; }
			}

			public object Value {
				get { return m_Value; }
			}

			public RegistryValueKind ValueKind {
				get { return m_ValueKind; }
			}
		}

		#endregion
	}
}