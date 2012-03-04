using System.Xml.Serialization;
using System.Data.SqlClient;
namespace App_Code.Responses {
	[XmlRoot("serverResponse")]
	public class defaultResponse : baseResponse {
		public defaultResponse() {
			attachSignature = true;
		}
	}
}