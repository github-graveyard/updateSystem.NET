/*
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

namespace updateSystemDotNet.Internal {
	/// <summary>Interne Hilfsklasse für oft genutzte Funktionen</summary>
	internal static class internalHelper {

		/// <summary>Normalisiert den Pfad oder die Url zu den Updatedaten.</summary>
		internal static string prepareUpdateLocation(string location) {
			return prepareUpdateLocation(location, string.Empty);
		}

		/// <summary>Normalisiert den Pfad oder die Url zu den Updatedaten.</summary>
		internal static string prepareUpdateLocation(string location, string subfolder) {
			var uri = new Uri(location);
			char pathSeperator = '/';
			if (uri.IsFile || uri.IsUnc)
				pathSeperator = '\\';

			if (!location.EndsWith(pathSeperator.ToString()))
				location += pathSeperator;

			if (!string.IsNullOrEmpty(subfolder))
				location += subfolder + pathSeperator;

			return location;
		}

		internal static WebClient buildBaseWebClient(updateController controller) {
			
			var client = new WebClient();
			//Proxy setzen, falls notwendig
			if (controller.proxyEnabled) {
				client.Proxy = new WebProxy(controller.proxyUrl, controller.proxyPort);
				if (!string.IsNullOrEmpty(controller.proxyUsername))
					client.Proxy.Credentials = new NetworkCredential(controller.proxyUsername,
																   controller.proxyPassword);
				else if (controller.proxyUseDefaultCredentials)
					client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
			}

			//Anmeldeinformationen setzen, falls notwendig
			if (controller.authenticationMode == authenticationModes.Credentials)
				client.Credentials = new NetworkCredential(controller.authenticationUsername,
														 controller.authenticationPassword);

			return client;
		}

	}
}
