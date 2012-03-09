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
