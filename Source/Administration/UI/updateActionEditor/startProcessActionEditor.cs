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

using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class startProcessActionEditor : actionEditorBase {
		private startProcessAction _action;

		public startProcessActionEditor() {
			InitializeComponent();

			txtPath.TextChanged += delegate { _action.Path = txtPath.Text; };
			txtArguments.TextChanged += delegate { _action.Arguments = txtArguments.Text; };
			chkWaitForExit.CheckedChanged += delegate { _action.waitForExit = chkWaitForExit.Checked; };
			chkElevatedRights.CheckedChanged += delegate { _action.needElevatedRights = chkElevatedRights.Checked; };
			chkDontStartIfExists.CheckedChanged += delegate { _action.dontRunIfExists = chkDontStartIfExists.Checked; };
		}

		public override void initializeActionContent() {
			_action = (updateAction as startProcessAction);
			txtPath.Text = _action.Path;
			txtArguments.Text = _action.Arguments;
			chkDontStartIfExists.Checked = _action.dontRunIfExists;
			chkElevatedRights.Checked = _action.needElevatedRights;
			chkWaitForExit.Checked = _action.waitForExit;
		}
	}
}