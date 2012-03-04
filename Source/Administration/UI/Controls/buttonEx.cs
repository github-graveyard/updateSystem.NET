using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class buttonEx : Button {
		public buttonEx() {
			FlatStyle = FlatStyle.System;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}
	}
}
