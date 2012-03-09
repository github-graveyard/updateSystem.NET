/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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