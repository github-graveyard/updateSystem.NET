/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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