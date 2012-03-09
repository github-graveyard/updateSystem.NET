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

	}
}
