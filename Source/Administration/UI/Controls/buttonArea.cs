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
