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
using System.Collections.Specialized;
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


		/// <summary>Überprüft die Anmeldedaten eines EAP-Benutzers.</summary>
		public bool eapLogin(string email, string password) {
			var client = _session.createWebClient();
			var colLogin = new NameValueCollection { { "email", email }, { "password", password } };
			var response = client.UploadValues(_eapLoginUrl, colLogin);
			return (Encoding.UTF8.GetString(response) == _positiveEapResponse);
		}

		/// <summary>Versendet das vom Benutzer eingegebene Feedback.</summary>
		public void sendFeedback(string name, string mail, string message) {
			var client = _session.createWebClient();
			var postData = new NameValueCollection {
			                                       	{"Name", name},
			                                       	{
			                                       		"E-Mail",
			                                       		!string.IsNullOrEmpty(mail) ? mail : "<Keine Mailadresse angegeben>"
			                                       		},
			                                       	{"Nachricht", message}
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

		/// <summary>Versendet einen Fehlerreport.</summary>
		public void sendExceptionReport(Exception exception, string userData) {
			var client = _session.createWebClient();
			var values = new NameValueCollection();

			var mainAssembly = Assembly.GetExecutingAssembly();
			values.Add("Anwendung", mainAssembly.GetName().Name);
			values.Add("Version", mainAssembly.GetName().Version.ToString());
			values.Add("Betriebssystem", Environment.OSVersion.VersionString);
			var environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
			values.Add("Plattform",
			           (environmentVariable != null && environmentVariable.Contains("64") ? "64-Bit" : "32-Bit"));
			values.Add("Anzahl Kerne", Environment.ProcessorCount.ToString());
			values.Add("Anwendungspfad", AppDomain.CurrentDomain.BaseDirectory);
			values.Add("Umgebungssprache", Thread.CurrentThread.CurrentUICulture.ToString());
			values.Add("CLR Version", Environment.Version.ToString());

			if (!string.IsNullOrEmpty(userData))
				values.Add("E-Mail", userData);


			//Kompletten Exceptionstring zusammenbauen
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
