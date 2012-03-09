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

using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class renameFileActionEditor : actionEditorBase {
		private renameFileAction _action;

		public renameFileActionEditor() {
			InitializeComponent();
			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				txtPath.AutoCompleteCustomSource.Add(item.Value);
			}

			txtPath.TextChanged += delegate { _action.Path = txtPath.Text; };
			txtNewFilename.TextChanged += delegate { _action.newFilename = txtNewFilename.Text; };
		}

		public override void initializeActionContent() {
			_action = (updateAction as renameFileAction);
			txtPath.Text = _action.Path;
			txtNewFilename.Text = _action.newFilename;
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
	}
}