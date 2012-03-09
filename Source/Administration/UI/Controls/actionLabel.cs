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
using System.Windows.Forms;
using updateSystemDotNet.Administration.Properties;
using System.ComponentModel;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal enum actionLabelStates {
		Waiting = 0,
		Progress = 1,
		Success = 2,
		Failure = 3
	}

	internal sealed class actionLabel : Control {
		private readonly Timer tmrCircle;
		private actionLabelStates _state;
		private string _text;
		private int circleIndex;
		private bool _suppressTextPadding;

		public actionLabel() {
			_state = actionLabelStates.Waiting;
			_suppressTextPadding = false;

			tmrCircle = new Timer {Interval = 50};
			tmrCircle.Tick += tmrCircle_Tick;
			tmrCircle.Start();

			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			DoubleBuffered = true;
		}

		[Category("Appearance")]
		public actionLabelStates State {
			get { return _state; }
			set {
				_state = value;
				/*if (_state == actionLabelStates.Progress) {
					wclWork.Show();
					wclWork.Start();
				}
				else {
					wclWork.Stop();
					wclWork.Hide();
				}*/
				Invalidate();
			}
		}

		[Category("Appearance")]
		public override string Text {
			get { return _text; }
			set {
				_text = value;
				Invalidate();
			}
		}

		[Category("Appearance")]
		public bool suppressTextPadding {
			get { return _suppressTextPadding; }
			set {
				_suppressTextPadding = value;
				Invalidate();
			}
		}

		private void tmrCircle_Tick(object sender, EventArgs e) {
			circleIndex++;
			if (circleIndex >= 18) {
				circleIndex = 0;
			}
			Invalidate();
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			BackColor = Color.Transparent;

			int textPaddingLeft = 3 + 16 + 5;

			if (_suppressTextPadding && _state == actionLabelStates.Waiting)
				textPaddingLeft = 0;

			var rectTextArea = new Rectangle(new Point(textPaddingLeft, 0),
											 new Size(ClientRectangle.Width - textPaddingLeft, Height));
			var fontText = Font;
			if (_state == actionLabelStates.Progress) {
				fontText = new Font(Font, FontStyle.Bold);
			}
			TextRenderer.DrawText(e.Graphics, Text, fontText, rectTextArea, ForeColor, TextFormatFlags.VerticalCenter);
			if (_state != actionLabelStates.Waiting) {
				Image image = null;

				switch (_state) {
					case actionLabelStates.Success:
						image = Resources.actionlabel_success;
						break;
					case actionLabelStates.Failure:
						image = Resources.actionlabel_error;
						break;
					case actionLabelStates.Progress:
						image = getCircleImage();
						break;
				}
				if (image != null)
					e.Graphics.DrawImage(image,
										 new Rectangle(new Point(3, (ClientRectangle.Height/2) - (image.Height/2)),
													   new Size(image.Width, image.Height)));
			}
		}

		private Image getCircleImage() {
			var circle = new Bitmap(16, 16);
			using (Graphics g = Graphics.FromImage(circle)) {
				g.DrawImage(
					Resources.circle,
					new Rectangle(0, 0, 16, 16),
					new Rectangle(0, (16*circleIndex), 16, 16),
					GraphicsUnit.Pixel
					);
			}
			return circle;
		}
	}
}