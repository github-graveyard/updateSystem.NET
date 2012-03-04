using System;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class startServiceException : Exception {
		private readonly string m_serviceName = string.Empty;

		public startServiceException(string serviceName) {
			m_serviceName = serviceName;
		}

		public override string Message {
			get { return string.Format(Language.GetString("startServiceException_message"), m_serviceName); }
		}
	}
}