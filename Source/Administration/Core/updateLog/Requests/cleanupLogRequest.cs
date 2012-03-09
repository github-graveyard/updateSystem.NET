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
	internal sealed class cleanupLogRequest : authenticatedRequest {
		protected override string actionName {
			get { return "cleanupLog"; }
		}

		public DateTime cleanupDate {
			get { return DateTime.Parse(getPostData("cleanup_date"), CultureInfo.InvariantCulture, DateTimeStyles.None); }
			set { addOrUpdatePostData("cleanup_date", value.ToString(CultureInfo.InvariantCulture)); }
		}

		public string projectId {
			get { return getPostData("project_identifer"); }
			set { addOrUpdatePostData("project_identifier", value); }
		}

	}
}
