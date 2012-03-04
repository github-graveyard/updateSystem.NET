using System.Xml.Serialization;
namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class loginResponse : baseResponse {
		public loginResponse() {
			attachSignature = true;
		}
		public bool userIsAdministrator { get; set; }
	}
}
