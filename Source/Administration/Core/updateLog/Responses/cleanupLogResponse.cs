using System.Xml.Serialization;

namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public sealed class cleanupLogResponse : defaultResponse {
		public int removedEntries { get; set; }
	}
}
