using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Publishing;
namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class publishProviderSettingsDialog : dialogBase {
		private publishBase _provider;
		private publishSettingsBaseControl _extendedSettings;
		public publishProviderSettingsDialog() {
			InitializeComponent();
		}
		public override void initializeData() {
			_provider = (publishBase) Argument;
			_extendedSettings = _provider.createSettingsControl();

			txtProviderName.Text = _provider.Settings.Name;
			chkActive.Checked = _provider.Settings.isActive;

			_extendedSettings.Location = new Point(0, 0);
			pnlProviderSettings.Controls.Add(_extendedSettings);

			int optWidth = pnlProviderSettings.ClientRectangle.Width;
			if (_extendedSettings.Height > pnlProviderSettings.ClientRectangle.Height)
				optWidth -= (SystemInformation.VerticalScrollBarWidth + 5);

			_extendedSettings.Size = new Size(optWidth, _extendedSettings.Height);
			_extendedSettings.loadSettings();
		}

		private void btnOk_Click(object sender, System.EventArgs e) {

			if(!_extendedSettings.validateSettings()) {
				//Show Errormessage
				return;
			}

			_provider.Settings.Name = txtProviderName.Text;
			_provider.Settings.isActive = chkActive.Checked;
			_extendedSettings.saveSettings();

			DialogResult = DialogResult.OK;
			Close();

		}
	}
}
