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
	internal class applyStartServiceAction : applyUpdateBase {
		private readonly TimeSpan m_timeout = new TimeSpan(0, 0, 10); //Timeout für den Service Start/Stopp

		public applyStartServiceAction(actionBase Action, InternalConfig config, updatePackage currentPackage)
			: base(Action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyStartServiceAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (startServiceAction) Action;
			ServiceController[] services = ServiceController.GetServices();

			foreach (ServiceController service in services) {
				if (string.Equals(service.ServiceName.ToLower(), action.serviceName.ToLower())) {
					switch (service.Status) {
						case ServiceControllerStatus.Stopped: //Dienst starten

							//Status senden
							onProgressChanged(
								string.Format(Language.GetString("applyStartServiceAction_startService"), service.DisplayName), 100);

							//Dienst starten
							if (!string.IsNullOrEmpty(action.Arguments)) {
								service.Start(action.Arguments.Split(' '));
							}
							else {
								service.Start();
							}
							//Warten bis der Dienst den Status ändert (max. 10 Sekunden)
							service.WaitForStatus(ServiceControllerStatus.Running, m_timeout);

							//Wenn der Status nicht Runnig ist, dann eine Exception werfen, dass der Dienst nicht gestartet werden konnte
							if (service.Status != ServiceControllerStatus.Running) {
								throw new startServiceException(service.DisplayName);
							}

							break;

						case ServiceControllerStatus.Running:
							if (action.restartIfRunnig)
								//Dienst neu starten wenn dieser bereits läuft und die entsprechende Option gegeben ist
							{
								//Status senden
								onProgressChanged(
									string.Format(Language.GetString("applyStartServiceAction_stopService"), service.DisplayName), 100);
								//Dienst anhalten
								service.Stop();
								//Warten bis der Dienst angehalten wurde (max 10 Sekunden)
								service.WaitForStatus(ServiceControllerStatus.Stopped, m_timeout);

								//Wenn der Dienst gestoppt wurde versuchen diesen neu zu starten
								if (service.Status == ServiceControllerStatus.Stopped) {
									//Status senden
									onProgressChanged(
										string.Format(Language.GetString("applyStartServiceAction_startService"), service.DisplayName), 100);

									//Dienst starten
									if (!string.IsNullOrEmpty(action.Arguments)) {
										service.Start(action.Arguments.Split(' '));
									}
									else {
										service.Start();
									}

									service.WaitForStatus(ServiceControllerStatus.Running, m_timeout);
									if (service.Status != ServiceControllerStatus.Running) {
										throw new stopServiceException(service.DisplayName);
									}
								}
								else //Andernfalls eine Exception werfen, dass der Dienst nicht beendet werden konnte.
								{
									throw new startServiceException(service.DisplayName);
								}
							}
							break;
					}
					return; //Schleife beenden, da Dienst gefunden.
				}
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}