using System.Xml.Serialization;

namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public sealed class getProjectResponse : defaultResponse {

		public updateLogProject Project { get; set; }

	}
}
