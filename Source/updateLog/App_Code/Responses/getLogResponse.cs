using System.Xml.Serialization;
using App_Code.dataTypes;
using System.Collections.Generic;

namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class getLogResponse : defaultResponse  {

		public getLogResponse() {
			logEntries = new List<updateLogEntry>();
		}

		public List<updateLogEntry> logEntries { get; set; }

		public override void Dispose() {
			base.Dispose();
			logEntries.Clear();
			logEntries = null;
		}

	}
}
