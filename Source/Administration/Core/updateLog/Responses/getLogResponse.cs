using System.Xml.Serialization;
using System.Collections.Generic;
namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public sealed class getLogResponse : defaultResponse {

		public getLogResponse() {
			logEntries = new List<updateLogEntry>();
		}

		public override bool signatureAttached {
			get { return true; }
		}

		public List<updateLogEntry> logEntries { get; set; }

	}
}
