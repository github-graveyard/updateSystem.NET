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

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal class baseSubPage : basePage {

		/// <summary>Ein Argument mit spezifischen Daten welches der Page mitgegeben wird.</summary>
		public object Argument { get; set; }

		/// <summary>Die Page von welcher diese Angezeigt wird.</summary>
		public basePage parentPage { get; set; }

		public override bool hideFromNavigation {
			get { return true; }
		}

		public override System.Windows.Forms.TreeNode Node {
			get {
				base.Node.ImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.SelectedImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.Tag = this;
				return base.Node;
			}
		}

	}
}