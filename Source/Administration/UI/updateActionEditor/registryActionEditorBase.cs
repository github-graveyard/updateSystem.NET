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