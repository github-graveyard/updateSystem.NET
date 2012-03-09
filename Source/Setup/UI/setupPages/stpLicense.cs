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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpLicense : basePage, ISetupPage {
		public stpLicense() {
			InitializeComponent();

			using (
				var msLicense =
					(UnmanagedMemoryStream)
					Assembly.GetExecutingAssembly().GetManifestResourceStream("updateSystemDotNet.Setup.License.rtf")) {
				rtbLicense.LoadFile(msLicense, RichTextBoxStreamType.RichText);
			}
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Lizenzvertrag"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpDonate); }
		}

		public Type backwardPage {
			get {
				if (Context.Product.GetType() == typeof (productBeta))
					return typeof (stpBeta);
				else
					return null;
			}
		}

		#endregion

		public override bool onValidate() {
			if (!chkAccepted.Checked) {
				MessageBox.Show("Sie müssen dem Lizenzvertrag zustimmen um das updateSystem.NET installieren zu können.",
				                Context.Product.Product, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return chkAccepted.Checked;
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			//Oben
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(rtbLicense.Location.X - 2, rtbLicense.Location.X + 0),
				new Point(rtbLicense.Width + 2, rtbLicense.Location.X + 0));

			//Links
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(rtbLicense.Location.X - 3, rtbLicense.Location.Y - 5),
				new Point(rtbLicense.Location.X - 3, rtbLicense.Height + 9));

			//Unten
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(rtbLicense.Location.X - 2, rtbLicense.Height + (rtbLicense.Location.Y + 1)),
				new Point(rtbLicense.Width + 2, rtbLicense.Height + (rtbLicense.Location.Y + 1)));
		}
	}
}