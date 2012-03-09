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
using System;
using System.Globalization;

namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal sealed class getLogRequest : authenticatedRequest {
		protected override string actionName {
			get { return "getLog"; }
		}

		protected override bool logResponse {
			get { return false; }
		}

		public DateTime dateFrom {
			get { return DateTime.Parse(getPostData("date_from"), CultureInfo.InvariantCulture); }
			set { addOrUpdatePostData("date_from", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public DateTime dateTo {
			get { return DateTime.Parse(getPostData("date_to"), CultureInfo.InvariantCulture); }
			set { addOrUpdatePostData("date_to", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public int osMajorMin {
			get { return int.Parse(getPostData("min_os_major")); }
			set { addOrUpdatePostData("min_os_major", value.ToString()); }
		}

		public int osMinorMin{
			get { return int.Parse(getPostData("min_os_minor")); }
			set { addOrUpdatePostData("min_os_minor", value.ToString()); }
		}

		public string projectId {
			get { return getPostData("project_id"); }
			set { addOrUpdatePostData("project_id", value); }
		}

		public string clientId {
			get { return getPostData("client_id"); }
			set { addOrUpdatePostData("client_id", value); }
		}

		public string clientVersion {
			get { return getPostData("client_version"); }
			set { addOrUpdatePostData("client_version", value); }
		}

	}
}
