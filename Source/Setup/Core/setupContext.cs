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
using System.IO;

namespace updateSystemDotNet.Setup.Core {
	internal sealed class setupContext {
		public setupContext() {
			createStartMenuShortcut = true;
		}

		public IProduct Product { get; set; }

		public string installationDirectory { get; set; }

		public string defaultInstallationDirectory {
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), Product.Product); }
		}

		public bool createStartMenuShortcut { get; set; }

		public bool createDesktopShortcut { get; set; }

		public bool runWhenDone { get; set; }

		public Exception setupException { get; set; }

		public bool removeSettings { get; set; }

		public bool isUpgrade { get; set; }

	}
}