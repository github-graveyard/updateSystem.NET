using System;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class uploadConfigurationCompletedEventArgs : EventArgs {
		public uploadConfigurationCompletedEventArgs() {
		}

		public uploadConfigurationCompletedEventArgs(Exception ex) {
			Exception = ex;
		}

		public uploadConfigurationCompletedEventArgs(Exception ex, IWin32Window owner)
			: this(ex) {
			Owner = owner;
		}

		public Exception Exception { get; private set; }

		public IWin32Window Owner { get; private set; }
	}
}