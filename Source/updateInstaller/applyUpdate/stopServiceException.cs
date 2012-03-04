using System;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class stopServiceException : Exception {
		private readonly string m_serviceName = string.Empty;

		public stopServiceException(string serviceName) {
			m_serviceName = serviceName;
		}

		public override string Message {
			get { return string.Format(Language.GetString("stopServiceException_message"), m_serviceName); }
		}
	}
}