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