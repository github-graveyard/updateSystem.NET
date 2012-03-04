using System.Xml.Serialization;

namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	
	public enum responseCodes {
		OK = 0,
		Error = 2
	}

	[XmlRoot("serverResponse")]
	[XmlInclude(typeof(loginResponse))]
	[XmlInclude(typeof(getUserResponse))]
	public class defaultResponse {

		/// <summary>Gibt den ResponseStatus zurück.</summary>
		public responseCodes responseCode { get; set; }

		/// <summary>Gibt eine erweiterte Fehlermeldung zurück.</summary>
		public string responseMessage { get; set; }

		/// <summary>Gibt zurück ob die Response digital signiert ist.</summary>
		[XmlIgnore]
		public virtual bool signatureAttached { get { return true; } }

	}
}
