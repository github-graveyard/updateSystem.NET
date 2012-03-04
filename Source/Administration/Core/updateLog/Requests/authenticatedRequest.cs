namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal abstract class authenticatedRequest : baseRequest {
		public string Username {
			get { return getPostData("username"); }
			set { addOrUpdatePostData("username", value); }
		}

		public string Password {
			get { return getPostData("password"); }
			set { addOrUpdatePostData("password", value); }
		}
	}
}