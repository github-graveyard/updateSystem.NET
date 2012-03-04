namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class deleteUserRequest : authenticatedRequest {
		protected override string actionName {
			get { return "deleteUser"; }
		}

		public string obsoleteUsername {
			get { return getPostData("obsolete_username"); }
			set { addOrUpdatePostData("obsolete_username", value); }
		}

	}
}
