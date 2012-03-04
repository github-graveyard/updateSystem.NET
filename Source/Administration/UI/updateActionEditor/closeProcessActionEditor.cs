using System;
using System.Windows.Forms;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class closeProcessActionEditor : actionEditorBase {
		private closeProcessAction _action;

		public closeProcessActionEditor() {
			InitializeComponent();
			lvwProcesses.Columns[0].Width = lvwProcesses.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwProcesses.SelectedIndexChanged += lvwProcesses_SelectedIndexChanged;
		}

		private void lvwProcesses_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveProcess.Enabled = (lvwProcesses.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			_action = (updateAction as closeProcessAction);
			foreach (string item in _action.processList) {
				lvwProcesses.Items.Add(item);
			}
		}

		private void btnAddProcess_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtName.Text) || _action.processList.Contains(txtName.Text))
				return;

			lvwProcesses.Items.Add(txtName.Text);
			_action.processList.Add(txtName.Text);
			txtName.Text = string.Empty;
		}

		private void btnRemoveProcess_Click(object sender, EventArgs e) {
			if (lvwProcesses.SelectedItems.Count > 0) {
				_action.processList.Remove(lvwProcesses.SelectedItems[0].Text);
				lvwProcesses.Items.Remove(lvwProcesses.SelectedItems[0]);
			}
		}
	}
}