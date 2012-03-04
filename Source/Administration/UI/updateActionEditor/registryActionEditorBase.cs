using System;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class registryActionEditorBase : actionEditorBase {
		private registryActionBase _action;

		public registryActionEditorBase() {
			InitializeComponent();

			foreach (string item in Enum.GetNames(typeof (registryHives))) {
				cboRegistryRoot.Items.Add(item);
			}
			cboRegistryRoot.SelectedIndex = 0;
			cboRegistryRoot.SelectedIndexChanged += cboRegistryRoot_SelectedIndexChanged;
			txtRegistryPath.TextChanged += txtRegistryPath_TextChanged;
		}

		private void txtRegistryPath_TextChanged(object sender, EventArgs e) {
			_action.Path = txtRegistryPath.Text;
		}

		private void cboRegistryRoot_SelectedIndexChanged(object sender, EventArgs e) {
			_action.rootHive = (registryHives) cboRegistryRoot.SelectedIndex;
		}

		public override void initializeActionContent() {
			_action = (registryActionBase) updateAction;
			cboRegistryRoot.SelectedIndex = (int) _action.rootHive;
			txtRegistryPath.Text = _action.Path;
		}
	}
}