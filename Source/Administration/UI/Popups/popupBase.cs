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