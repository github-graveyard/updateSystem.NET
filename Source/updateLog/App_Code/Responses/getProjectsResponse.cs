using System.Collections.Generic;
using System.Xml.Serialization;
using App_Code.dataTypes;

namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class getProjectsResponse : defaultResponse {
		public getProjectsResponse() {
			attachSignature = true;
			Projects = new List<updateLogProject>();
		}

		public List<updateLogProject> Projects { get; set; }

	}
}
