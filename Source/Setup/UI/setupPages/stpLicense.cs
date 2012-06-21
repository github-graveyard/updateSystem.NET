/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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