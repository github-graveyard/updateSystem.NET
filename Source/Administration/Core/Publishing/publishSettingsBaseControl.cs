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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.Core.Publishing {

	[ToolboxItem(false)]
	internal class publishSettingsBaseControl : UserControl {

		public publishSettingsBaseControl() {
			base.Font = SystemFonts.MessageBoxFont;
		}

		public applicationSession Session { get; set; }

		public IPublishProvider Provider { get; set; }

		protected string localizationPath {
			get { return string.Format("publishProvider.{0}.Control.{1}.Text", Provider.GetType().Name, "{0}"); }
		}

		public virtual void loadSettings() {
		}
		public virtual void saveSettings() {
		}
		public virtual bool validateSettings() {
			return true;
		}
		public virtual void localizeControl() {
		}

		protected void addOrUpdateSetting(string key, string setting) {
			if (Provider.Settings.customSettings.ContainsKey(key))
				Provider.Settings.customSettings[key] = setting;
			else
				Provider.Settings.customSettings.Add(key, setting);
		}

		protected string getSetting(string key) {
			return getSetting(key, string.Empty);
		}
		protected string getSetting(string key, string defaultValue) {
			return Provider.Settings.customSettings.ContainsKey(key) ? Provider.Settings.customSettings[key] : defaultValue;
		}
	}
}
