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
using System.Threading;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUserInteractionAction : applyUpdateBase {
		public applyUserInteractionAction(actionBase action, InternalConfig config, updatePackage currentPackage)
			: base(action, config, currentPackage) {
		}

		public override string actionName {
			get { return Language.GetString("applyUserInteractionAction_name"); }
		}

		public override void executeAction(actionBase Action) {
			var action = (userInteractionAction) Action;
			string title = string.Empty;
			string message = string.Empty;

			if (Thread.CurrentThread.CurrentCulture.Name.StartsWith("de")) {
				title = action.germanTitle;
				message = action.germanMessage;
			}
			else {
				title = action.englishTitle;
				message = action.englishMessage;
			}

			onProgressChanged("", 100);
			if (showInteractionDialog(action.Buttons, title, message) != DialogResult.OK) {
				throw new userCancelledException();
			}
		}

		public override void rollbackAction() {
			return;
		}
	}
}