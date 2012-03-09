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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class groupBoxEx : GroupBox {
		private VisualStyleElement _styleElement;

		public groupBoxEx() {
			Padding = new Padding(12, 6, 12, 6);
		}

		private VisualStyleElement styleElement {
			get { return (_styleElement ?? (_styleElement = VisualStyleElement.CreateElement("TASKDIALOG", 8, 0))); }
		}

		[DefaultValue(typeof (Padding), "12,6,12,6")]
		public new Padding Padding {
			get { return base.Padding; }
			set { base.Padding = value; }
		}

		protected override void OnPaint(PaintEventArgs e) {
			Size size = e.Graphics.MeasureString(Text, Font).ToSize();
			var bounds = new Rectangle(size.Width + 1, (size.Height/2) + 1, Width - size.Width, 1);
			TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle.Location, Enabled ? ForeColor : SystemColors.GrayText );
			if (Environment.OSVersion.Version.Major >= 6 && VisualStyleRenderer.IsSupported) {
				new VisualStyleRenderer(styleElement).DrawBackground(e.Graphics, bounds);
			}
			else {
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), bounds);
			}
		}
	}
}