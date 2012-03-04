using System.Xml.Serialization;
using App_Code.dataTypes;

namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class getProjectResponse : defaultResponse {
		public getProjectResponse() {
			attachSignature = true;
		}

		public updateLogProject Project { get; set; }

	}
}
