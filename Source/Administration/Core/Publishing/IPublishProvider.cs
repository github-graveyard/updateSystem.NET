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

using updateSystemDotNet.Administration.Core.Application;
using System;

namespace updateSystemDotNet.Administration.Core.Publishing {
	internal interface IPublishProvider {

		#region Events

		event EventHandler<publishUpdateProgressChangedEventArgs> publishUpdateProgressChanged;

		#endregion

		#region Eigenschaften

		/// <summary>Bietet Zugriff auf die Anwendungssession.</summary>
		applicationSession Session { get; set; }

		/// <summary>Bietet Zugriff auf die Eigenschaften und Einstellungen des jeweiligen Providers.</summary>
		publishSettings Settings { get; set; }

		/// <summary>Gibt die Provider-ID zurück</summary>
		string Id { get; }

		#endregion

		#region Methoden

		/// <summary>Methode um mit dem Veröffentlichungsvorgang zu beginnen.</summary>
		publishResult publishUpdates();

		Type settingsView { get; }

		#endregion

	}
}
