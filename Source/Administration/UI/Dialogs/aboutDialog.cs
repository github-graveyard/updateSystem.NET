using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class aboutDialog : dialogBase {
		public aboutDialog() {
			InitializeComponent();
			btnClose.Click += btnClose_Click;
			imgAppLogo.Image = resourceHelper.getImage("app_logo_big.png");
			imgDonate.Image = resourceHelper.getImage("paypalDonate.gif");

			base.Text = string.Format("Über {0}", Strings.applicationName);
			lblAppName.Text = Strings.applicationInternalName;
			lblCopyright.Text = string.Format(lblCopyright.Text, DateTime.Now.Year);
			lblCopyright.LinkArea = new LinkArea(lblCopyright.Text.IndexOf("Maximilian"), 16);
		}

		public override void initializeData() {
			lblVersion.Text = string.Format(lblVersion.Text, Assembly.GetExecutingAssembly().GetName().Version, Session.applicationCodeName);
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void imgDonate_Click(object sender, EventArgs e) {
			Process.Start(Strings.urlDonate);
		}
	}
}