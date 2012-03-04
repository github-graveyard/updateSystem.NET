namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class editUserRequest : authenticatedRequest {
		protected override string actionName {
			get { return "editUser"; }
		}

		public string oldUsername {
			get { return getPostData("old_username"); }
			set { addOrUpdatePostData("old_username", value); }
		}

		public string editUsername {
			get { return getPostData("edit_username"); }
			set { addOrUpdatePostData("edit_username", value); }
		}

		public string editPassword {
			get { return getPostData("edit_password"); }
			set { addOrUpdatePostData("edit_password", value); }
		}

		public int maxProjects {
			get { return int.Parse(getPostData("max_projects")); }
			set { addOrUpdatePostData("max_projects", value.ToString()); }
		}

		public bool isAdmin {
			get { return (getPostData("is_admin") == "1"); }
			set { addOrUpdatePostData("is_admin", value ? "1" : "0"); }
		}

		public bool isActive {
			get { return (getPostData("is_active") == "1"); }
			set { addOrUpdatePostData("is_active", value ? "1" : "0"); }
		}
	}
}