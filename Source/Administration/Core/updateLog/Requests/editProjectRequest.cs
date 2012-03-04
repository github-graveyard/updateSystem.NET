namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class editProjectRequest : authenticatedRequest {
		protected override string actionName {
			get { return "editProject"; }
		}

		public string projectId {
			get { return getPostData("project_id"); }
			set { addOrUpdatePostData("project_id", value); }
		}

		public string projectName {
			get { return getPostData("project_name"); }
			set { addOrUpdatePostData("project_name", value); }
		}

		public bool isActive {
			get { return getPostData("is_active") == "1"; }
			set { addOrUpdatePostData("is_active", value ? "1" : "0"); }
		}

	}
}