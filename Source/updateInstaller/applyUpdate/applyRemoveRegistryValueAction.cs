using System.Collections.Generic;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyRemoveRegistryValueAction : applyUpdateBase {
		#region " Rollbackdata "

		private readonly List<registryRollbackItem> m_removedValues = new List<registryRollbackItem>();
		private string m_registryPath = string.Empty;
		private RegistryKey m_rootKey;

		#endregion

		public applyRemoveRegistryValueAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyRemoveRegistryValueAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (removeRegistryValuesAction) Action;
			RegistryKey rootKey = getRegistryRoot(action.rootHive);

			//Daten sichern
			m_rootKey = rootKey;
			m_registryPath = action.Path;

			int itemCount = 0;
			foreach (string item in action.valueNames) {
				onProgressChanged(
					string.Format(Language.GetString("applyRemoveRegistryValueAction_progress"), item),
					Percent(itemCount, action.valueNames.Count));

				object itemValue = rootKey.OpenSubKey(action.Path).GetValue(item, null);
				if (itemValue != null) {
					m_removedValues.Add(new registryRollbackItem(item, itemValue,
					                                             rootKey.OpenSubKey(action.Path, false).GetValueKind(item)));
					rootKey.OpenSubKey(action.Path, true).DeleteValue(item, false);
				}
				itemCount++;
			}
		}

		public override void rollbackAction() {
			int itemCount = 0;
			foreach (registryRollbackItem rbItem in m_removedValues) {
				onProgressChanged(string.Format(Language.GetString("applyRemoveRegistryValueAction_rollback"), rbItem.Name),
				                  Percent(itemCount, m_removedValues.Count));
				m_rootKey.OpenSubKey(m_registryPath).SetValue(rbItem.Name, rbItem.Value, rbItem.valueKind);
				itemCount++;
			}
		}

		#region Nested type: registryRollbackItem

		private struct registryRollbackItem {
			private readonly string m_name;
			private readonly RegistryValueKind m_valueKind;
			private object m_value;

			public registryRollbackItem(string Name, object value, RegistryValueKind valueKind) {
				m_name = Name;
				m_value = value;
				m_valueKind = valueKind;
			}

			public string Name {
				get { return m_name; }
			}

			public object Value {
				get { return m_valueKind; }
			}

			public RegistryValueKind valueKind {
				get { return m_valueKind; }
			}
		}

		#endregion
	}
}