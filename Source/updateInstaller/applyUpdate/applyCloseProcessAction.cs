using System;
using System.Diagnostics;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyCloseProcessAction : applyUpdateBase {
		public applyCloseProcessAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyCloseProcessAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (closeProcessAction) Action;

			//using (UI.Forms.dlgOpenProcesses dlg = new updateSystemDotNet.Updater.UI.Forms.dlgOpenProcesses(action.processList.ToArray()))
			//{
			//    if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			//    {
			//        throw new Exception("Ein oder mehrere Prozesse konnten nicht beendet werden weshalb der Updatevorgang abgebrochen werden musste.");
			//    }

			//}
			foreach (string processItem in action.processList) {
				Process[] processes = Process.GetProcessesByName(processItem);
				if (processes.Length > 0) {
					foreach (Process process in processes) {
						try {
							process.CloseMainWindow();
							process.WaitForExit(5000);
							process.Kill();
						}
						catch (Exception) {
							/* TODO: Unbedingt noch was wegen ner gescheiten Fehlerbehandlung überlegen */
						}
					}
				}
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}