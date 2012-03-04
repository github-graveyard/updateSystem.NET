using System;

namespace updateSystemDotNet.Updater {
	internal class InvalidSignatureException : Exception {
		private readonly string m_message;

		public InvalidSignatureException() {
		}

		public InvalidSignatureException(string Message) {
			m_message = Message;
		}

		public override string Message {
			get { return m_message; }
		}
	}
}