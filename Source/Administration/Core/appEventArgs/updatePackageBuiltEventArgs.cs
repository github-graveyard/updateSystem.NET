using System;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class updatePackageBuiltEventArgs : EventArgs {
		public updatePackageBuiltEventArgs(updatePackage package, Exception ex) {
			Package = package;
			Exception = ex;
		}

		public updatePackage Package { get; private set; }

		public Exception Exception { get; private set; }
	}
}