using System;
using System.Globalization;

namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class getLogRequest : authenticatedRequest {
		protected override string actionName {
			get { return "getLog"; }
		}

		protected override bool logResponse {
			get { return false; }
		}

		public DateTime dateFrom {
			get { return DateTime.Parse(getPostData("date_from"), CultureInfo.InvariantCulture); }
			set { addOrUpdatePostData("date_from", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public DateTime dateTo {
			get { return DateTime.Parse(getPostData("date_to"), CultureInfo.InvariantCulture); }
			set { addOrUpdatePostData("date_to", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public int osMajorMin {
			get { return int.Parse(getPostData("min_os_major")); }
			set { addOrUpdatePostData("min_os_major", value.ToString()); }
		}

		public int osMinorMin{
			get { return int.Parse(getPostData("min_os_minor")); }
			set { addOrUpdatePostData("min_os_minor", value.ToString()); }
		}

		public string projectId {
			get { return getPostData("project_id"); }
			set { addOrUpdatePostData("project_id", value); }
		}

		public string clientId {
			get { return getPostData("client_id"); }
			set { addOrUpdatePostData("client_id", value); }
		}

		public string clientVersion {
			get { return getPostData("client_version"); }
			set { addOrUpdatePostData("client_version", value); }
		}

	}
}
