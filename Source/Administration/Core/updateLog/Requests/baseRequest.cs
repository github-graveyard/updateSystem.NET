using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.Core.updateLog.Responses;

namespace updateSystemDotNet.Administration.Core.updateLog.Requests {
	internal abstract class baseRequest {
		protected baseRequest() {
			postData = new Dictionary<string, string>();
		}

		/// <summary>Bietet Zugriff auf die aktuelle Session.</summary>
		public applicationSession Session { get; set; }

		/// <summary>Gitb die Adresse des Servers zurück oder legt diese fest.</summary>
		public string serverUrl { get; set; }

		/// <summary>Eine Auflistung mit allen Daten die per POST an den Server gesendet werden sollen.</summary>
		protected Dictionary<string, string> postData { get; private set; }

		/// <summary>Gibt den Namen der Aktion zurück, die auf dem Server ausgeführt werden soll.</summary>
		protected abstract string actionName { get; }

		/// <summary>Gibt an, ob die Antwort des Statistikservers geloggt werden soll.</summary>
		protected virtual bool logResponse {
			get { return true; }
		}

		public virtual T Execute<T>() where T : defaultResponse {
			HttpWebResponse httpResponse = sendRequest(createRequest());
			try {
				byte[] responseData = readResponse(httpResponse);
				
				if(logResponse && Session.Settings.logUpdatelog)
					Session.Log.writeKeyValue(logLevel.Info, "updateLog Response", Encoding.UTF8.GetString(responseData));

				return deserializeAndVerifyResponse<T>(responseData);
			}
			finally {
				httpResponse.Close();
			}
		}

		/// <summary>Fügt einen neuen Eintrag zu den POST-Daten hinzu oder aktualisiert einen bestehenden.</summary>
		protected void addOrUpdatePostData(string key, string value) {
			if (postData.ContainsKey(key))
				postData[key] = value;
			else
				postData.Add(key, value);
		}

		/// <summary>Gibt einen Eintrag aus den POST-Daten zurück.</summary>
		protected string getPostData(string key) {
			return !postData.ContainsKey(key) ? string.Empty : postData[key];
		}

		/// <summary>Erstellt einen vorkonfigurierten WebRequest.</summary>
		protected HttpWebRequest createRequest() {
			var request = (HttpWebRequest) WebRequest.Create(serverUrl);
			request.UserAgent = string.Format("updateSystem.NET Administration v{0}",
			                                  Assembly.GetExecutingAssembly().GetName().Version);

			if (Session.Settings.proxySettings.proxyMode != proxyModes.useSystemDefaults) {
				request.Proxy = new WebProxy(Session.Settings.proxySettings.Server, Session.Settings.proxySettings.Port);
				switch (Session.Settings.proxySettings.Authentication) {
					case proxyAuthentication.NetworkCredentials:
						request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
						break;
					case proxyAuthentication.Custom:
						request.Proxy.Credentials = new NetworkCredential(Session.Settings.proxySettings.Username,
																		 Session.Settings.proxySettings.Password);
						break;
				}
			}
			request.Headers.Add("authKey", "987a8948-df08-4cae-b031-2d2e22a1c8e7");
			request.Method = WebRequestMethods.Http.Post;
			request.ContentType = "application/x-www-form-urlencoded";
			request.AutomaticDecompression = DecompressionMethods.GZip;
			return request;
		}

		/// <summary>Sendet einen Request mit den POST-Parametern an den Server und gibt die Response zurück.</summary>
		protected HttpWebResponse sendRequest(HttpWebRequest request) {
			//Action hinzufügen, es gibt keinen Request ohne.
			addOrUpdatePostData("action", actionName);

			//POST-Daten erstellen
			var sbPost = new StringBuilder();
			int i = 0;
			foreach (var item in postData) {
				//Parameter nicht anfügen wenn der Wert null oder "" ist
				if (!string.IsNullOrEmpty(item.Key))
					sbPost.Append(string.Format("{0}={1}{2}", item.Key.ToLower(), item.Value, (i < (postData.Count - 1) ? "&" : "")));

				i++;
			}

			//Log schreiben
			if(Session.Settings.logUpdatelog)
				Session.Log.writeKeyValue(logLevel.Info, "updateLog Request",
										  string.Format("POST -> \"{0}\" to {1}", sbPost, serverUrl));

			byte[] rawPostData = Encoding.UTF8.GetBytes(sbPost.ToString());
			request.ContentLength = rawPostData.Length;
			using (Stream requestStream = request.GetRequestStream())
				requestStream.Write(rawPostData, 0, rawPostData.Length);

			return (HttpWebResponse) request.GetResponse();
		}

		/// <summary>Liest die Daten aus dem Responsestream und gibt diese als Bytearray zurück.</summary>
		protected byte[] readResponse(HttpWebResponse response) {
			using (var msData = new MemoryStream()) {
				var buffer = new byte[1024];
				using (Stream responseStream = response.GetResponseStream()) {
					int bytesRead;
					do {
						bytesRead = responseStream.Read(buffer, 0, buffer.Length);
						msData.Write(buffer, 0, bytesRead);
					} while (bytesRead > 0);
				}
				return msData.ToArray();
			}
		}

		/// <summary>Deserialisiert die Responsedaten in ein .NET Objekt</summary>
		protected T deserializeAndVerifyResponse<T>(byte[] responseData) where T : defaultResponse {
			using (var msResponseData = new MemoryStream(responseData)) {
				using (var reader = new StreamReader(msResponseData, Encoding.UTF8)) {
					var serializer = new XmlSerializer(typeof (T));
					var instance = (T) serializer.Deserialize(reader);
					if (instance.signatureAttached)
						verifyAttachedSignature(responseData);

					return instance;
				}
			}
		}

		/// <summary>Überprüft die Signatur der Serverresponse.</summary>
		private void verifyAttachedSignature(byte[] responseData) {
			var document = new XmlDocument {PreserveWhitespace = true};
			using (var msResponseData = new MemoryStream(responseData)) {
				using (var reader = new StreamReader(msResponseData, Encoding.UTF8))
					document.Load(reader);
			}

			var cspParams = new CspParameters {KeyContainerName = "XML_DSIG_RSA_KEY"};
			var rsaKey = new RSACryptoServiceProvider(cspParams);
			rsaKey.FromXmlString(
				"<RSAKeyValue><Modulus>ww0BFd1ejrwZDCXbRVop9soKLx+LMYlhwNFZEnu41Ahew+bZq/MwW2ENduFe6dDYNl9oqNMbxXZrW6wg9htw7ctFgjorxbmMW4Z4XW2DgKGqZsGJD8AxI6r6y/4jGINLaF/dJDW5kJD9JLkY4L8OSHaVDtFnbBK+50eyrHBGVl7/zSAueW4TVNz5tosPoery2UfhR+162KdJ63vN+E9hkMNTuS91dCQGp3BPGZSuvsMXFtgMSC1D0WbZMQJzesuR2OaKE80cX4miKH+BNte1TVg+kkKfTYBePNprF+cJwJkWaf0Ie5eP2wMNPRDa4fLuYiFnhLJdlQcCcIToFSfk8w==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

			var signedXml = new SignedXml(document);
			XmlNodeList nodeList = document.GetElementsByTagName("Signature");

			if (nodeList.Count <= 0) {
				throw new CryptographicException("Verification failed: No Signature was found in the document.");
			}
			if (nodeList.Count >= 2) {
				throw new CryptographicException("Verification failed: More that one signature was found for the document.");
			}
			signedXml.LoadXml((XmlElement) nodeList[0]);

			if (!signedXml.CheckSignature(rsaKey))
				throw new Exception("Die Signatur ist ungültig.");
		}
	}
}