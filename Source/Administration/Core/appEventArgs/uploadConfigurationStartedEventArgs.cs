using System;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class uploadConfigurationStartedEventArgs : EventArgs {
		public uploadConfigurationStartedEventArgs() {
		}

		public uploadConfigurationStartedEventArgs(IWin32Window owner) {
			Owner = owner;
		}

		public IWin32Window Owner { get; private set; }
	}
}