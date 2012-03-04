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