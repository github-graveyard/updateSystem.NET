using System;

namespace updateSystemDotNet.Administration.Core.updateLog {
	public sealed class updateLogEntry {
		public int clientOSMajor { get; set; }

		public int clientOSMinor { get; set; }

		public string clientId { get; set; }

		public string clientVersion { get; set; }

		public DateTime timeStamp { get; set; }

		public byte requestType { get; set; }
	}
}
