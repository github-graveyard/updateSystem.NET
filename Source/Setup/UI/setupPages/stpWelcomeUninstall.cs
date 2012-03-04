using System;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpWelcomeUninstall : basePage, ISetupPage {
		public stpWelcomeUninstall() {
			InitializeComponent();
			chkRemoveSettings.CheckedChanged += delegate { Context.removeSettings = chkRemoveSettings.Checked; };
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "updateSystem.NET deinstallation"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpUninstall); }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		public override void onShow() {
			base.onShow();
			chkRemoveSettings.Checked = Context.removeSettings;
		}
	}
}