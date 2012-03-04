using System;
using System.Diagnostics;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpDonate : basePage, ISetupPage {
		public stpDonate() {
			InitializeComponent();
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Die Entwicklung unterstützen"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpOptions); }
		}

		public Type backwardPage {
			get { return typeof (stpLicense); }
		}

		#endregion

		private void imgDonate_Click(object sender, EventArgs e) {
			try {
				Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Y67TPZVJUG968");
			}
			catch (Exception) {
			}
		}
	}
}