using System.Xml.Serialization;
namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class unsignedResponse : baseResponse {
		public unsignedResponse() {
			attachSignature = false;
		}
	}
}
