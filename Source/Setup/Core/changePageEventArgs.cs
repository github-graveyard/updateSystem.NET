using System;

namespace updateSystemDotNet.Setup.Core {
	internal sealed class changePageEventArgs : EventArgs {
		public changePageEventArgs(Type tNewPage) {
			newPage = tNewPage;
		}

		public Type newPage { get; private set; }
	}
}