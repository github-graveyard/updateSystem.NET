using System.Collections.Generic;
using System.Xml.Serialization;

namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public class getUserResponse : defaultResponse {

		public getUserResponse() {
			Users = new List<userAccount>();
		}

		public override bool signatureAttached {
			get { return true; }
		}

		public List<userAccount> Users { get; set; }
	}
}
