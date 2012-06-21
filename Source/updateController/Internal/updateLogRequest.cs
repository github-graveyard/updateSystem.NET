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
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.Win32;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Internal {
	internal sealed class updateLogRequest {
		private const string _requestParamString =
			"client_os_major={0}&client_os_minor={1}&client_identifier={2}&project_identifier={3}&client_version={4}&request_type={5}&action=addLog";

		private readonly updateConfiguration _configuration;
		private readonly updateController _controller;

		public updateLogRequest(updateController controller, updateConfiguration configuration) {
			_controller = controller;
			_configuration = configuration;
		}

		private string clientIdentifier {
			get {
				RegistryKey rAppRoot = Registry.CurrentUser.CreateSubKey(Strings.AppRegHive);
				if (string.IsNullOrEmpty(rAppRoot.GetValue(string.Empty, string.Empty).ToString())) {
					rAppRoot.SetValue(string.Empty, Guid.NewGuid().ToString());
				}
				return rAppRoot.GetValue(string.Empty, string.Empty).ToString();
			}
		}

		public void sendRequest(int requestType) {
			try {
				if (_configuration.linkedUpdateLogAccount == null ||
				    string.IsNullOrEmpty(_configuration.linkedUpdateLogAccount.serverUrl))
					return;


				var request = (HttpWebRequest) WebRequest.Create(_configuration.linkedUpdateLogAccount.serverUrl);
				request.UserAgent = string.Format("updateController v{0}", Assembly.GetExecutingAssembly().GetName().Version);
				request.Headers.Add("authKey", "987a8948-df08-4cae-b031-2d2e22a1c8e7");
				request.Method = WebRequestMethods.Http.Post;
				request.ContentType = "application/x-www-form-urlencoded";
				request.AutomaticDecompression = DecompressionMethods.GZip;

				//Proxy setzen
				if (_controller.proxyEnabled) {
					request.Proxy = new WebProxy(_controller.proxyUrl, _controller.proxyPort);
					if (!string.IsNullOrEmpty(_controller.proxyUsername))
						request.Proxy.Credentials = new NetworkCredential(_controller.proxyUsername, _controller.proxyPassword);
					else if (_controller.proxyUseDefaultCredentials)
						request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
				}

				string requestString = string.Format(_requestParamString, new object[] {
				                                                                       	Environment.OSVersion.Version.Major,
				                                                                       	Environment.OSVersion.Version.Minor,
				                                                                       	clientIdentifier,
				                                                                       	_configuration.projectId,
				                                                                       	_controller.releaseInfo.Version,
				                                                                       	requestType
				                                                                       });
				byte[] requestData = Encoding.Default.GetBytes(requestString);
				request.ContentLength = requestData.Length;
				using (Stream requestStream = request.GetRequestStream())
					requestStream.Write(requestData, 0, requestData.Length);

				WebResponse response = request.GetResponse();
				response.Close();
			}
			catch (Exception exc) {
				Log.Instance.writeException(exc);
			}
		}
	}
}