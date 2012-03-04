using System;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateActionFinishedEventArgs : EventArgs {
		private readonly Exception m_exception;

		public applyUpdateActionFinishedEventArgs() {
		}

		public applyUpdateActionFinishedEventArgs(Exception aException) {
			m_exception = aException;
		}

		public Exception actionException {
			get { return m_exception; }
		}
	}
}