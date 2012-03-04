using System;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpBeta : basePage, ISetupPage {
		public stpBeta() {
			InitializeComponent();
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "updateSystem.NET - Beta"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpLicense); }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion
	}
}