using System;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class stopServiceActionEditor : actionEditorBase {
		public stopServiceActionEditor() {
			InitializeComponent();
			txtServiceName.TextChanged += txtServiceName_TextChanged;
		}

		private void txtServiceName_TextChanged(object sender, EventArgs e) {
			(updateAction as stopServiceAction).serviceName = txtServiceName.Text;
		}

		public override void initializeActionContent() {
			txtServiceName.Text = (updateAction as stopServiceAction).serviceName;
		}
	}
}