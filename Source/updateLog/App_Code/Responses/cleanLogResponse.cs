using System.Xml.Serialization;
namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class cleanLogResponse : defaultResponse {
		public cleanLogResponse() {
			attachSignature = true;
		}

		public int removedEntries { get; set; }
	}
}
