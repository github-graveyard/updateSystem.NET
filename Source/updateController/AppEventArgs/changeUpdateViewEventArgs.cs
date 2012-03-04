using System;

namespace updateSystemDotNet.appEventArgs {
	internal sealed class changeUpdateViewEventArgs : EventArgs {
		public changeUpdateViewEventArgs(Type view) {
			newView = view;
		}

		public Type newView { get; private set; }
	}
}