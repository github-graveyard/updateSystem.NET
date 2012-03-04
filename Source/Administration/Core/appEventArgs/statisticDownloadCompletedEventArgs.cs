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