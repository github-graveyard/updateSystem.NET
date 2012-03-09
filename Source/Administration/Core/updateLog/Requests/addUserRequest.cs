#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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