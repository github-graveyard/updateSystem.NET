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