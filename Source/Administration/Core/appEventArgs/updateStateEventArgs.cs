using System;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class updateStateEventArgs : EventArgs {
		public updateStateEventArgs(string text) {
			Text = text;
		}

		public string Text { get; set; }
	}
}