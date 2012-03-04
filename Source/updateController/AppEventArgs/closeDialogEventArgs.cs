using System;
using System.Windows.Forms;

namespace updateSystemDotNet.appEventArgs {
	internal sealed class closeDialogEventArgs : EventArgs {
		public closeDialogEventArgs(DialogResult result) {
			dialogResult = result;
		}

		public DialogResult dialogResult { get; private set; }
	}
}