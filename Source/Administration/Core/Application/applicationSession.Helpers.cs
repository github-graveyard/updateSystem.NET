/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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

	//Ausgelagerte Hilfsfunktionen für die Session
	internal sealed partial class applicationSession {

		/// <summary>Gibt die relative Zeit von einem bestimmten Daten zurück (z.B. vor 5 Minuten)</summary>
		public string relativeDate(DateTime date) {
			var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
			double delta = Math.Abs(ts.TotalSeconds);

			if (delta < 60) {
				return ts.Seconds == 1 ? "vor einer Sekunde" : string.Format("vor {0} Sekunden", ts.Seconds);
			}
			if (delta < 120) {
				return "vor einer Minute";
			}
			if (delta < 2700) // 45 * 60
			{
				return string.Format("vor {0} Minuten", ts.Minutes);
			}
			if (delta < 5400) // 90 * 60
			{
				return "vor einer Stunde";
			}
			if (delta < 86400) // 24 * 60 * 60
			{
				return string.Format("vor {0} Stunden", ts.Hours);
			}
			if (delta < 172800) // 48 * 60 * 60
			{
				return "Gestern";
			}
			if (delta < 2592000) // 30 * 24 * 60 * 60
			{
				return string.Format("vor {0} Tagen", ts.Days);
			}
			if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
			{
				int months = Convert.ToInt32(Math.Floor((double) ts.Days/30));
				return months <= 1 ? "vor einem Monat" : string.Format("vor {0} Monaten", months);
			}
			int years = Convert.ToInt32(Math.Floor((double) ts.Days/365));
			return years <= 1 ? "vor einem Jahr" : string.Format("vor {0} Jahren", years);
		}

		/// <summary>Gibt einen vorkonfigurierten WebClient zurück.</summary>
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
