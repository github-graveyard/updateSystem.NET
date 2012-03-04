using System.Xml.Serialization;
namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public class loginResponse : defaultResponse {
		public override bool signatureAttached {
			get { return true; }
		}

		public bool userIsAdministrator { get; set; }
	}
}
