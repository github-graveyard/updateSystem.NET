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
