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
using System.Reflection;

namespace updateSystemDotNet.Setup.Core {
	internal class productRTM : IProduct {
		#region IProduct Members

		public string mainExecutable {
			get { return "updateSystemDotNet.Administration.exe"; }
		}

		public string setupName {
			get { return "uninstall.exe"; }
		}

		public string Contact {
			get { return "mail@maximiliankrauss.net"; }
		}

		public virtual Version currentVersion {
			get {
				if (ProgramsAndFeaturesHelper.isInstalled(this))
					return ProgramsAndFeaturesHelper.getCurrentVersion(this);
				else
					return newVersion;
			}
		}

		public string Description {
			get { return "Updatelösung für .NET Entwickler"; }
		}

		public virtual Version newVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
		}

		public virtual string Product {
			get { return "updateSystem.NET"; }
		}

		public string Publisher {
			get { return "Maximilian Krauss"; }
		}

		public virtual string supportUrl {
			get { return "http://updatesystem.net"; }
		}

		public virtual string applicationID {
			get { return "8d7ea403-65fb-4276-8ada-3b39f0fe2461"; }
		}

		#endregion
	}
}