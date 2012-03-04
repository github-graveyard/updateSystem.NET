namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class loginRequest : authenticatedRequest {
		protected override string actionName {
			get { return "login"; }
		}
	}
}