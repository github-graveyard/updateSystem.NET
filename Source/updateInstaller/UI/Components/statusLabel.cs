using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace updateSystemDotNet.Updater.UI.Components {
	internal enum statusLabelStates {
		Waiting = 0,
		Progress = 1,
		Success = 2,
		Failure = 3
	}

	internal class statusLabel : Control {
		private readonly Timer tmrCircle;
		private statusLabelStates _state;
		private string _text;
		private int circleIndex;

		public statusLabel() {
			_state = statusLabelStates.Waiting;

			tmrCircle = new Timer();
			tmrCircle.Interval = 50;
			tmrCircle.Tick += tmrCircle_Tick;
			tmrCircle.Start();

			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			DoubleBuffered = true;
		}

		public statusLabelStates State {
			get { return _state; }
			set {
				_state = value;
				Invalidate();
			}
		}

		public override string Text {
			get { return _text; }
			set {
				_text = value;
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
			var rectTextArea = new Rectangle(new Point(textPaddingLeft, 0),
			                                 new Size(ClientRectangle.Width - textPaddingLeft, Height));
			Font fontText = SystemFonts.MessageBoxFont;
			if (_state == statusLabelStates.Progress) {
				fontText = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold);
			}
			TextRenderer.DrawText(e.Graphics, Text, fontText, rectTextArea, ForeColor, TextFormatFlags.WordBreak | TextFormatFlags.VerticalCenter);
			if (_state != statusLabelStates.Waiting) {
				Image image = null;

				switch (_state) {
					case statusLabelStates.Success:
						image = getResourceImage("statuslabel_success.png");
						break;
					case statusLabelStates.Failure:
						image = getResourceImage("statuslabel_error.png");
						break;
					case statusLabelStates.Progress:
						image = getCircleImage();
						break;
				}
				e.Graphics.DrawImage(image,
				                     new Rectangle(new Point(3, (ClientRectangle.Height/2) - (image.Height/2)),
				                                   new Size(image.Width, image.Height)));
			}
		}

		private Image getCircleImage() {
			var circle = new Bitmap(16, 16);
			using (Graphics g = Graphics.FromImage(circle)) {
				g.DrawImage(
					getResourceImage("statuslabel_progress.png"),
					new Rectangle(0, 0, 16, 16),
					new Rectangle(0, (16*circleIndex), 16, 16),
					GraphicsUnit.Pixel
					);
			}
			return circle;
		}

		private Image getResourceImage(string imagename) {
			using (
				Stream strImage =
					Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("updateSystemDotNet.Updater.Images.{0}",
					                                                                        imagename))
				) {
				return Image.FromStream(strImage);
			}
		}
	}
}