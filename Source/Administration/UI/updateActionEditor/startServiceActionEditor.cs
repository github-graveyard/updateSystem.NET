using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class startServiceActionEditor : actionEditorBase {
		private startServiceAction _action;

		public startServiceActionEditor() {
			InitializeComponent();

			txtServiceName.TextChanged += delegate { _action.serviceName = txtServiceName.Text; };
			txtArguments.TextChanged += delegate { _action.Arguments = txtArguments.Text; };
			chkRestartIfRunnig.CheckedChanged += delegate { _action.restartIfRunnig = chkRestartIfRunnig.Checked; };
		}

		public override void initializeActionContent() {
			_action = (updateAction as startServiceAction);
			txtServiceName.Text = _action.serviceName;
			txtArguments.Text = _action.Arguments;
			chkRestartIfRunnig.Checked = _action.restartIfRunnig;
		}
	}
}