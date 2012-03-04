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