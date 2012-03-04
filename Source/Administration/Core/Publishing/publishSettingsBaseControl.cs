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
