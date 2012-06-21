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
using System.ServiceProcess;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyStopServiceAction : applyUpdateBase {
		public applyStopServiceAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyStopServiceAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (stopServiceAction) Action;
			ServiceController[] services = ServiceController.GetServices();
			var timeout = new TimeSpan(0, 0, 10);

			foreach (ServiceController service in services) {
				if (string.Equals(service.ServiceName.ToLower(), action.serviceName.ToLower())) {
					//Überprüfe ob der Dienst läuft
					if (service.Status == ServiceControllerStatus.Running) {
						//Status senden
						onProgressChanged(string.Format(Language.GetString("applyStopServiceAction_stopService"), service.DisplayName),
						                  100);
						service.Stop();
						service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
						if (service.Status != ServiceControllerStatus.Stopped) {
							throw new stopServiceException(service.DisplayName);
						}
					}
					break;
				}
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}