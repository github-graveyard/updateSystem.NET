#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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