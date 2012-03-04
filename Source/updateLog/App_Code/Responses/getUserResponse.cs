using System.Xml.Serialization;
using App_Code.dataTypes;
using System.Collections.Generic;
namespace App_Code.Responses {
	
	[XmlRoot("serverResponse")]
	public class getUserResponse : baseResponse {
		public getUserResponse() {
			attachSignature = true;
			Users = new List<userAccount>();
		}

		public List<userAccount> Users { get; set; }

	}
}
