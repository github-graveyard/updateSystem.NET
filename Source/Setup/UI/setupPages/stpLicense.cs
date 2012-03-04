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