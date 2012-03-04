namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class addUserRequest : authenticatedRequest {
		protected override string actionName {
			get { return "addUser"; }
		}

		public string newUsername {
			get { return getPostData("new_username"); }
			set { addOrUpdatePostData("new_username", value); }
		}

		public string newPassword {
			get { return getPostData("new_password"); }
			set { addOrUpdatePostData("new_password", value); }
		}

		public bool isAdmin {
			get { return getPostData("is_admin") == "1"; }
			set { addOrUpdatePostData("is_admin", value ? "1" : "0"); }
		}

		public int maxProjects {
			get { return int.Parse(getPostData("max_projects")); }
			set { addOrUpdatePostData("max_projects", value.ToString()); }
		}
	}
}