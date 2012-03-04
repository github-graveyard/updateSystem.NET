using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Popups {
	internal class popupBase : Form {
		public popupBase() {
			popupResult = new dataContainer();
			//Form entsprechend anpassen
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
			ShowInTaskbar = false;
			MinimizeBox = false;
			MaximizeBox = false;
			ControlBox = false;
			base.Font = SystemFonts.MessageBoxFont;
			//addLink();
		}

		public dataContainer popupResult { get; protected set; }

		public dataContainer popupArgument { get; set; }

		public applicationSession Session { get; set; }

		public virtual void initializeData() {
			//per default wird hier nüscht gemacht
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			var rectBorder = new Rectangle(
				0,
				0,
				ClientRectangle.Width - 1,
				ClientRectangle.Height - 1
				);
			e.Graphics.DrawRectangle(SystemPens.ControlDark, rectBorder);
		}
		private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Close();
		}

		private const int CS_DROPSHADOW = 0x20000;
		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}

	}
}