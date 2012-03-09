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
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class downloadConfigurationCompletedEventArgs : EventArgs {
		public downloadConfigurationCompletedEventArgs(updateConfiguration configuration) {
			Configuration = configuration;
		}

		public downloadConfigurationCompletedEventArgs(Exception ex) {
			Exception = ex;
		}

		/// <summary>Gibt die heruntergeladene Updatekonfiguration zurück. Ist null wenn es bei dem Download zu einem Fehler kam.</summary>
		public updateConfiguration Configuration { get; private set; }

		/// <summary>Gibt den Fehler zurück der bei dem Download auftrat. Ist null wenn es zu keinem Fehler kam.</summary>
		public Exception Exception { get; private set; }

		/// <summary>Gibt True zurück wenn die Updatekonfiguration erfolgreich heruntergeladen wurde, andernfalls False.</summary>
		public bool Success {
			get { return (Configuration != null && Exception == null); }
		}
	}
}