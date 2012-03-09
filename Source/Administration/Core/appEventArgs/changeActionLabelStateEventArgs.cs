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
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class changeActionLabelStateEventArgs : EventArgs {
		public changeActionLabelStateEventArgs(string name, actionLabelStates state) {
			actionLabelName = name;
			State = state;
		}

		/// <summary>Der Status auf welchen das ActionLabel aktualisiert werden soll.</summary>
		public actionLabelStates State { get; private set; }

		/// <summary>Der Name des Controls von welchem der Status geändert werden soll.</summary>
		public string actionLabelName { get; private set; }
	}
}