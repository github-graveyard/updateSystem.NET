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