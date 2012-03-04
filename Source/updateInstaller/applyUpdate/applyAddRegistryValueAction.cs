using System.Collections.Generic;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyAddRegistryValueAction : applyUpdateBase {
		#region " Rollback Data "

		private readonly List<registryRollbackItem> m_addedValues = new List<registryRollbackItem>();
		private string m_registryPath = string.Empty;
		private RegistryKey m_rootKey;

		#endregion

		public applyAddRegistryValueAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyAddRegistryValueAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (addRegistryValueAction) Action;

			RegistryKey rootKey = getRegistryRoot(action.rootHive);
			m_rootKey = rootKey;
			m_registryPath = action.Path;

			//Überprüfen ob Basisschlüssel existiert
			if (!registryKeyExists(rootKey, action.Path)) {
				rootKey.CreateSubKey(action.Path);
			}

			int itemCount = 0;
			foreach (addRegistryValueAction.registryItem item in action.Items) {
				onProgressChanged(Language.GetString("applyAddRegistryValueAction_progress"), Percent(itemCount, action.Items.Count));
				object currentData = rootKey.OpenSubKey(action.Path).GetValue(item.Name, null);

				object newValue = item.Value;
				if (item.Type == registryValueTypes.REG_SZ)
					newValue = ParsePath((string) newValue);

				rootKey.OpenSubKey(action.Path, true).SetValue(item.Name, newValue, getRegistryValueKind(item.Type));

				if (currentData != null) {
					m_addedValues.Add(new registryRollbackItem(item.Name, currentData,
					                                           rootKey.OpenSubKey(action.Path).GetValueKind(item.Name)));
				}
				else {
					m_addedValues.Add(new registryRollbackItem(item.Name, null, RegistryValueKind.Unknown));
				}
				itemCount++;
			}
		}

		public override void rollbackAction() {
			int itemCount = 0;
			foreach (registryRollbackItem item in m_addedValues) {
				onProgressChanged(string.Format(Language.GetString("applyAddRegistryValueAction_rollback"), item.Name),
				                  Percent(itemCount, m_addedValues.Count));

				if (item.Value != null) {
					m_rootKey.OpenSubKey(m_registryPath, true).SetValue(item.Name, item.Value, item.valueKind);
				}
				else {
					m_rootKey.OpenSubKey(m_registryPath, true).DeleteValue(item.Name, false);
				}

				itemCount++;
			}
		}

		#region Nested type: registryRollbackItem

		private struct registryRollbackItem {
			private readonly string m_name;
			private readonly object m_value;
			private readonly RegistryValueKind m_valueKind;

			public registryRollbackItem(string Name, object Value, RegistryValueKind valueKind) {
				m_name = Name;
				m_value = Value;
				m_valueKind = valueKind;
			}

			public string Name {
				get { return m_name; }
			}

			public object Value {
				get { return m_value; }
			}

			public RegistryValueKind valueKind {
				get { return m_valueKind; }
			}
		}

		#endregion
	}
}