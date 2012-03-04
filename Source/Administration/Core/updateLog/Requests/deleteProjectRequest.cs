namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class deleteProjectRequest : authenticatedRequest {
		protected override string actionName {
			get { return "deleteProject"; }
		}

		public string projectId {
			get { return getPostData("project_id"); }
			set { addOrUpdatePostData("project_id", value); }
		}
	}
}