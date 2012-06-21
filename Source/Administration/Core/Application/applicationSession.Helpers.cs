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
using System.Net;
using System.Net.Cache;

namespace updateSystemDotNet.Administration.Core.Application {

	//External and commonly used helper methods
	internal sealed partial class applicationSession {

		/// <summary>Returns a relative Date, e.g.: 5 minutes ago.</summary>
		public string relativeDate(DateTime date) {
			var ts = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
			double delta = Math.Abs(ts.TotalSeconds);
			const string localizationRoot = "prettyDate.";
			if (delta < 60)
				return ts.Seconds == 1
				       	? localizeMessage(localizationRoot + "Second")
				       	: string.Format(localizeMessage(localizationRoot + "Seconds"), ts.Seconds);
			if (delta < 120)
				return localizeMessage(localizationRoot + "Minute");
			if (delta < 2700) // 45 * 60
				return string.Format(localizeMessage(localizationRoot + "Minutes"), ts.Minutes);
			if (delta < 5400) // 90 * 60
				return localizeMessage(localizationRoot + "Hour");
			if (delta < 86400) // 24 * 60 * 60
				return string.Format(localizeMessage(localizationRoot + "Hours"), ts.Hours);
			if (delta < 172800) // 48 * 60 * 60
				return localizeMessage(localizationRoot + "Day");
			if (delta < 2592000) // 30 * 24 * 60 * 60
				return string.Format(localizeMessage(localizationRoot + "Days"), ts.Days);
			if (delta < 31104000) { // 12 * 30 * 24 * 60 * 60
				int months = Convert.ToInt32(Math.Floor((double) ts.Days/30));
				return months <= 1
				       	? localizeMessage(localizationRoot + "Month")
				       	: string.Format(localizeMessage(localizationRoot + "Months"), months);
			}
			int years = Convert.ToInt32(Math.Floor((double) ts.Days/365));
			return years <= 1
			       	? localizeMessage(localizationRoot + "Year")
			       	: string.Format(localizeMessage(localizationRoot + "Years"), years);
		}

		/// <summary>Creates a WebClient which is already set up for Proxyuse and other stuff.</summary>
		public WebClient createWebClient() {
			var client = new WebClient {
				CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
			};

			if (Settings.proxySettings.proxyMode != proxyModes.useSystemDefaults) {
				client.Proxy = new WebProxy(Settings.proxySettings.Server, Settings.proxySettings.Port);
				switch (Settings.proxySettings.Authentication) {
					case proxyAuthentication.NetworkCredentials:
						client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
						break;
					case proxyAuthentication.Custom:
						client.Proxy.Credentials = new NetworkCredential(Settings.proxySettings.Username,
																		 Settings.proxySettings.Password);
						break;
				}
			}

			return client;
		}

		/// <summary>Checks if a Type inherits from another Type.</summary>
		public bool derivesFrom<T>(Type type) {
			for (Type baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
				if (baseType == typeof(T))
					return true;
			return false;
		}

	}
}
