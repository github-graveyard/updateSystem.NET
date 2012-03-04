using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class startProcessActionEditor : actionEditorBase {
		private startProcessAction _action;

		public startProcessActionEditor() {
			InitializeComponent();

			txtPath.TextChanged += delegate { _action.Path = txtPath.Text; };
			txtArguments.TextChanged += delegate { _action.Arguments = txtArguments.Text; };
			chkWaitForExit.CheckedChanged += delegate { _action.waitForExit = chkWaitForExit.Checked; };
			chkElevatedRights.CheckedChanged += delegate { _action.needElevatedRights = chkElevatedRights.Checked; };
			chkDontStartIfExists.CheckedChanged += delegate { _action.dontRunIfExists = chkDontStartIfExists.Checked; };
		}

		public override void initializeActionContent() {
			_action = (updateAction as startProcessAction);
			txtPath.Text = _action.Path;
			txtArguments.Text = _action.Arguments;
			chkDontStartIfExists.Checked = _action.dontRunIfExists;
			chkElevatedRights.Checked = _action.needElevatedRights;
			chkWaitForExit.Checked = _action.waitForExit;
		}
	}
}