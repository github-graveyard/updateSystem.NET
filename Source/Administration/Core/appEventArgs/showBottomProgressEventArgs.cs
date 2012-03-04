using System;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class showBottomProgressEventArgs : EventArgs {
		public showBottomProgressEventArgs(string message) {
			Message = message;
		}

		/// <summary>Die Nachricht welche in dem Statuslabel angezeigt werden soll.</summary>
		public string Message { get; private set; }
	}
}