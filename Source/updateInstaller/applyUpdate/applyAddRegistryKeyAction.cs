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