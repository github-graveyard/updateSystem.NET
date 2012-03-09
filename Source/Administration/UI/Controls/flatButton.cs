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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class flatButton : Label {
		private enum buttonStates {
			Normal,
			Hover,
			Pressed
		}

		private buttonStates _buttonState;

		public flatButton() {
			Font = SystemFonts.MessageBoxFont;
			Padding = new Padding(6);
			_buttonState = buttonStates.Normal;
			DoubleBuffered = true;
			TextAlign = ContentAlignment.MiddleCenter;
		}

		private GraphicsPath RoundRect(int x, int y, int width, int height, int radius, int lw) {
			var path = new GraphicsPath();
			var num = radius * 2;
			path.AddArc(x + lw, y, num, num, 180f, 90f);
			path.AddArc(x + ((width - num) - lw), y, num, num, 270f, 90f);
			path.AddArc(x + ((width - num) - lw), y + ((height - num) - lw), num, num, 360f, 90f);
			path.AddArc(x + lw, y + ((height - num) - lw), num, num, 90f, 90f);
			path.CloseFigure();
			return path;
		}

		protected override void OnPaintBackground(PaintEventArgs pevent) {
			pevent.Graphics.Clear(BackColor);
			var gradientColor = SystemColors.Control;
			switch (_buttonState) {
				case buttonStates.Normal:
					gradientColor = SystemColors.Control;
					break;
				case buttonStates.Hover:
					gradientColor = SystemColors.ControlLightLight;
					break;
				case buttonStates.Pressed:
					gradientColor = SystemColors.ControlLight;
					break;
			}

			var roundedRectangle = RoundRect(1, 1, Width - 2, Height - 2, 2, 2);

			//Außenrahmen Zeichnen           
			using (
				var gradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), gradientColor,
															SystemColors.Control, LinearGradientMode.Vertical))
				pevent.Graphics.FillPath(gradientBrush, roundedRectangle);

			pevent.Graphics.DrawPath(
				_buttonState == buttonStates.Pressed ? SystemPens.ControlDark : SystemPens.ControlLight,
				roundedRectangle);
			roundedRectangle.Dispose();
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			_buttonState = buttonStates.Hover;
			Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			_buttonState = buttonStates.Normal;
			Invalidate();
		}
		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left) {
				_buttonState = buttonStates.Pressed;
				Invalidate();
			}
		}
		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left) {
				_buttonState = buttonStates.Hover;
				Invalidate();
			}
		}
	}
}