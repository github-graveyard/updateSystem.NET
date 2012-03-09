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
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class deleteFilesActionEditor : actionEditorBase {
		private deleteFilesAction _action;

		public deleteFilesActionEditor() {
			InitializeComponent();

			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				txtPath.AutoCompleteCustomSource.Add(item.Value);
			}
			lvwFileNames.Columns[0].Width = lvwFileNames.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwFileNames.SelectedIndexChanged += lvwFileNames_SelectedIndexChanged;
		}

		private void lvwFileNames_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveEntry.Enabled = (lvwFileNames.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			_action = (updateAction as deleteFilesAction);
			txtPath.Text = _action.Path;
			foreach (string item in _action.filesToRemove) {
				lvwFileNames.Items.Add(item);
			}
		}

		private void btnAddEntry_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtFileName.Text) || _action.filesToRemove.Contains(txtFileName.Text))
				return;

			lvwFileNames.Items.Add(txtFileName.Text);
			_action.filesToRemove.Add(txtFileName.Text);
			txtFileName.Text = string.Empty;
		}

		private void btnRemoveEntry_Click(object sender, EventArgs e) {
			if (lvwFileNames.SelectedItems.Count > 0) {
				_action.filesToRemove.Remove(lvwFileNames.SelectedItems[0].Text);
				lvwFileNames.Items.Remove(lvwFileNames.SelectedItems[0]);
			}
		}

		private void lnkVarInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			var sbVars = new StringBuilder();
			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				sbVars.AppendLine(string.Format("{0}: {1}", item.Value, item));
			}
			Session.showMessage(
				this,
				sbVars.ToString(),
				"Verfügbare Pfadvariablen",
				MessageBoxIcon.Information,
				MessageBoxButtons.OK
				);
		}

		private void txtPath_TextChanged(object sender, EventArgs e) {
			_action.Path = txtPath.Text;
		}
	}
}