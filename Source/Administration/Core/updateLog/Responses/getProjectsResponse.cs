using System.Collections.Generic;
using System.Xml.Serialization;
namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public sealed class getProjectsResponse : defaultResponse {

		public getProjectsResponse() {
			Projects = new List<updateLogProject>();
		}

		public List<updateLogProject> Projects { get; set; }

		public override bool signatureAttached {
			get { return true; }
		}

	}
}
