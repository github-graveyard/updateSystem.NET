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
	internal class seperatorLabel : Label {
		public seperatorLabel() {
			base.TextAlign = ContentAlignment.MiddleLeft;
		}

		public override bool AutoSize {
			get { return false; }
			set { base.AutoSize = value; }
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			SizeF textSize = e.Graphics.MeasureString(Text, Font);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(213, 223, 223)), new Point((int) textSize.Width + 10, Height/2),
			                    new Point(Width, Height/2));
			e.Graphics.DrawLine(Pens.White, new Point((int) textSize.Width + 10, (Height/2) + 1),
			                    new Point(Width, (Height/2) + 1));
		}
	}
}