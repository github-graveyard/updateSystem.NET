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