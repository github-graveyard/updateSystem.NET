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
