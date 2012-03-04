using System;
using System.Windows.Forms;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class removeRegistryValuesActionEditor : registryActionEditorBase {
		private removeRegistryValuesAction _action;

		public removeRegistryValuesActionEditor() {
			InitializeComponent();
			lvwValues.Columns[0].Width = lvwValues.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwValues.SelectedIndexChanged += lvwValues_SelectedIndexChanged;
		}

		private void lvwValues_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveEntry.Enabled = (lvwValues.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			base.initializeActionContent();
			_action = (updateAction as removeRegistryValuesAction);
			foreach (string item in _action.valueNames) {
				lvwValues.Items.Add(item);
			}
		}

		private void btnAddEntry_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtValueName.Text) || _action.valueNames.Contains(txtValueName.Text))
				return;

			lvwValues.Items.Add(txtValueName.Text);
			_action.valueNames.Add(txtValueName.Text);
			txtValueName.Text = string.Empty;
		}

		private void btnRemoveEntry_Click(object sender, EventArgs e) {
			if (lvwValues.SelectedItems.Count > 0) {
				_action.valueNames.Remove(lvwValues.SelectedItems[0].Text);
				lvwValues.Items.Remove(lvwValues.SelectedItems[0]);
			}
		}
	}
}