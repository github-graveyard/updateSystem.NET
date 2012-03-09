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