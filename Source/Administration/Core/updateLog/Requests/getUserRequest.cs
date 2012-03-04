namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class getUserRequest : authenticatedRequest {
		protected override string actionName {
			get { return "getUser"; }
		}
	}
}