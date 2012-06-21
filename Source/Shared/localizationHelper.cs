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
using System.Threading;
using System.Windows.Forms;
namespace updateSystemDotNet.Localization {
	
	/// <summary>Helperclass for updateController and updateInstaller which simplifies the Access to localized strings.</summary>
	internal sealed class localizationHelper {
		private static localizationHelper _instance;
		private readonly localizationFile _file;

		private localizationHelper() {
			cultureId = Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2).ToLowerInvariant();
			_file = new localizationFile();
			_file.Load();
		}

		public static localizationHelper Instance {
			get { return _instance ?? (_instance = new localizationHelper()); }
		}

		public string cultureId { get; set; }

		public void setLanguage(Languages language) {
			switch(language) {
				case Languages.Deutsch:
					cultureId = "de";
					break;
				case Languages.English:
					cultureId = "en";
					break;
				default:
					cultureId = Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2).ToLowerInvariant();
					break;
			}
		}

		public string exceptionMessage(string key) {
			return _file[string.Format("Exceptions.{0}", key), cultureId];
		}

		public string controlText(Control control) {
			return controlText(control, string.Empty);
		}

		public string controlText(Control control, string statusSuffix) {
			string parentName = string.Empty;
			for (Control parent = control.Parent; parent != null; parent = parent.Parent)
				parentName = parent.Name;

			return _file[string.Format("Dialogs.{0}.{1}{2}.Text",
			                           parentName,
			                           control.Name,
									   string.IsNullOrEmpty(statusSuffix) ? "" : "_" + statusSuffix), cultureId];
		}

		public string Message(string key) {
			return _file[key, cultureId];
		}

	}
}