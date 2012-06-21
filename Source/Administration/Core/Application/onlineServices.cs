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
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace updateSystemDotNet.Administration.Core.Application {
	internal sealed class onlineServices {
		private readonly applicationSession _session;
		private const string _eapLoginUrl = "https://forum.devs-on.net/eapLogin.axd";
		private const string _feedbackUrl = "https://maximiliankrauss.net/sendFeedback.ashx?appName={0}";
		private const string _exceptionUrl = "https://maximiliankrauss.net/BugReport.ashx?appName={0}";
		private const string _positiveEapResponse = "authenticated";

		public onlineServices(applicationSession session) {
			_session = session;
			ServicePointManager.ServerCertificateValidationCallback += OnCheckSSLCert;
		}


		/// <summary>Checks the Login for Early Access Programm.</summary>
		public bool eapLogin(string email, string password) {
			var client = _session.createWebClient();
			var colLogin = new NameValueCollection { { "email", email }, { "password", password } };
			var response = client.UploadValues(_eapLoginUrl, colLogin);
			return (Encoding.UTF8.GetString(response) == _positiveEapResponse);
		}

		/// <summary>Sends the Userprovided Feedback to moi :)</summary>
		public void sendFeedback(string name, string mail, string message) {
			var client = _session.createWebClient();
			var postData = new NameValueCollection {
			                                       	{"Name", name},
			                                       	{"E-Mail", !string.IsNullOrEmpty(mail) ? mail : "<No Mail specified>"},
			                                       	{"Message", message}
			                                       };
			string response =
				Encoding.Default.GetString(
					client.UploadValues(
						string.Format(_feedbackUrl,
						              Assembly.GetExecutingAssembly().GetName().Name), "POST", postData));
			if (response != "OK") {
				throw new Exception(response);
			}
		}

		/// <summary>Sends an Errorreport.</summary>
		public void sendExceptionReport(Exception exception, string userData) {
			var client = _session.createWebClient();
			var values = new NameValueCollection();

			var mainAssembly = Assembly.GetExecutingAssembly();
			values.Add("Application", mainAssembly.GetName().Name);
			values.Add("Version", mainAssembly.GetName().Version.ToString());
			values.Add("Operating System", Environment.OSVersion.VersionString);
			var environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
			values.Add("Plattform",
			           (environmentVariable != null && environmentVariable.Contains("64") ? "64-Bit" : "32-Bit"));
			values.Add("ProcessorCount", Environment.ProcessorCount.ToString(CultureInfo.InvariantCulture));
			values.Add("Applicationpath", AppDomain.CurrentDomain.BaseDirectory);
			values.Add("Environmentlanguage", Thread.CurrentThread.CurrentUICulture.ToString());
			values.Add("CLR Version", Environment.Version.ToString());

			if (!string.IsNullOrEmpty(userData))
				values.Add("E-Mail", userData);


			//Build complete StackTrace
			var sbException = new StringBuilder();
			for (Exception exc = exception; exc != null; exc = exc.InnerException)
				sbException.AppendLine(exc.ToString());

			values.Add("Exception", sbException.ToString());

			string response =
				Encoding.Default.GetString(
					client.UploadValues(
						string.Format(_exceptionUrl, mainAssembly.GetName().Name), "POST",
						values));
			if (response != "Done!")
				throw new Exception(response);
		}

		private static bool OnCheckSSLCert(object sender, X509Certificate certificate, X509Chain chain,
								   SslPolicyErrors sslPolicyErrors) {
			return true;
		}

	}
}
