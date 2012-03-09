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

		public virtual void loadSettings() {
		}
		public virtual void saveSettings() {
		}
		public virtual bool validateSettings() {
			return true;
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
