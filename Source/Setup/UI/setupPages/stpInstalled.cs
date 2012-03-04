using System;
using System.IO;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpInstalled : basePage, ISetupPage {
		public stpInstalled() {
			InitializeComponent();
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Installation erfolgreich"; }
		}

		public bool isLastPage {
			get { return true; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return null; }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		public override void onShow() {
			base.onShow();
			chkRunWhenDone.Checked = Context.runWhenDone;
		}

		public override void onHide() {
			base.onHide();

			string mainApp = Path.Combine(Context.installationDirectory, Context.Product.mainExecutable);
			if (File.Exists(mainApp) && chkRunWhenDone.Checked) {
				limitedProcess.Start(mainApp);
			}
		}
	}
}