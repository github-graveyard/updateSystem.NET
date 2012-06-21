/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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