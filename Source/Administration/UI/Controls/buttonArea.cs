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

using System.Drawing;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class buttonArea : FlowLayoutPanel {
		
		public buttonArea() {
			Size = new Size(200, 50);
			FlowDirection = FlowDirection.RightToLeft;
			Padding = new Padding(0, 10, 12, 0);
			Dock = DockStyle.Bottom;
			Paint += buttonArea_Paint;
		}
		void buttonArea_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(SystemColors.Control);
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(0, 0),
				new Point(e.ClipRectangle.Width, 0));
		}

	}
}
