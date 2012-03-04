namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class getProjectsRequest : authenticatedRequest {
		protected override string actionName {
			get { return "getProjects"; }
		}
	}
}