using System;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class setupStatisticServerCompletedEventArgs : EventArgs {
		public setupStatisticServerCompletedEventArgs(Exception exc) {
			Exception = exc;
		}

		public Exception Exception { get; private set; }
	}
}