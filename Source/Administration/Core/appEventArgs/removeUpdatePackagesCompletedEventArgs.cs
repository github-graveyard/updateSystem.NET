using System;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class removeUpdatePackagesCompletedEventArgs : EventArgs {
		public removeUpdatePackagesCompletedEventArgs(Exception exc) {
			Exception = exc;
		}

		public Exception Exception { get; private set; }
	}
}