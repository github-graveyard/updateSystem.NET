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
using System.Collections.Generic;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class statisticDownloadCompletedEventArgs : EventArgs {
		public statisticDownloadCompletedEventArgs(Exception occouredException, Dictionary<DateTime, int> upRequests,
		                                           Dictionary<DateTime, int> upDownloads) {
			Exception = occouredException;
			updateRequests = upRequests;
			updateDownloads = upDownloads;
		}

		/// <summary>Gibt den Fehler zurück der während dem Download aufgetreten ist. Kann null sein.</summary>
		public Exception Exception { get; private set; }

		/// <summary>Gibt eine Auflistung von gefilterten Updateanfragen zurück.</summary>
		public Dictionary<DateTime, int> updateRequests { get; private set; }

		/// <summary>Gibt eine Auflistung von gefilterten Downloadanfragen zurück.</summary>
		public Dictionary<DateTime, int> updateDownloads { get; private set; }

		/// <summary>Gibt True zurück wenn Daten über Anfragen vorhanden sind, andernfalls False.</summary>
		public bool hasData {
			get {
				if ((updateRequests != null && updateRequests.Count > 0) ||
				    (updateDownloads != null && updateDownloads.Count > 0)) {
					foreach (var reqItem in updateRequests)
						if (reqItem.Value > 0)
							return true;

					foreach (var dllItem in updateDownloads)
						if (dllItem.Value > 0)
							return true;
				}
				return false;
			}
		}
	}
}