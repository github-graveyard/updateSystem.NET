using System;
using System.Globalization;

namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class cleanupLogRequest : authenticatedRequest {
		protected override string actionName {
			get { return "cleanupLog"; }
		}

		public DateTime cleanupDate {
			get { return DateTime.Parse(getPostData("cleanup_date"), CultureInfo.InvariantCulture, DateTimeStyles.None); }
			set { addOrUpdatePostData("cleanup_date", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public string projectId {
			get { return getPostData("project_identifer"); }
			set { addOrUpdatePostData("project_identifier", value); }
		}

	}
}
