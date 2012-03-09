/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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