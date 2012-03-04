namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class getProjectRequest : authenticatedRequest {
		protected override string actionName {
			get { return "getProject"; }
		}

		public string projectId {
			get { return getPostData("project_id"); }
			set { addOrUpdatePostData("project_id", value); }
		}
	}
}