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

using System.Collections.Generic;
using System.Xml.Serialization;
namespace updateSystemDotNet.Administration.Core.updateLog.Responses {
	[XmlRoot("serverResponse")]
	public sealed class getProjectsResponse : defaultResponse {

		public getProjectsResponse() {
			Projects = new List<updateLogProject>();
		}

		public List<updateLogProject> Projects { get; set; }

		public override bool signatureAttached {
			get { return true; }
		}

	}
}
