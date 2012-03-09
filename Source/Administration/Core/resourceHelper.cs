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

using System.Drawing;
using System.IO;
using System.Reflection;

namespace updateSystemDotNet.Administration.Core {
	internal static class resourceHelper {
		public static Image getImage(string imageName) {
			using (
				Stream sImage =
					Assembly.GetExecutingAssembly().GetManifestResourceStream(
						string.Format("updateSystemDotNet.Administration.Images.{0}", imageName))) {
				return Image.FromStream(sImage);
			}
		}

		public static Image getImage(string imageName, string additionalNamespace) {
			return getImage(string.Format("{0}.{1}", additionalNamespace, imageName));
		}
	}
}