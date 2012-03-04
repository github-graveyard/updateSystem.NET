using System.IO;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyRenameFileAction : applyUpdateBase {
		private string m_originalPath = string.Empty;
		private string m_renamedPath = string.Empty;

		public applyRenameFileAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyRenameFileAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (renameFileAction) Action;

			string rPath = ParsePath(action.Path);
			string newPath = Path.Combine(Path.GetDirectoryName(rPath), action.newFilename);

			if (File.Exists(rPath)) {
				onProgressChanged(string.Format(Language.GetString("applyRenameFileAction_progress"), new FileInfo(rPath).Name), 100);

				copyFile(rPath, newPath);
				deleteFile(rPath);
				m_originalPath = rPath;
				m_renamedPath = newPath;
			}
		}

		public override void rollbackAction() {
			onProgressChanged(
				string.Format(Language.GetString("applyRenameFileAction_rollback"), new FileInfo(m_renamedPath).Name), 100);
			copyFile(m_renamedPath, m_originalPath);
			deleteFile(m_renamedPath);
		}
	}
}