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

using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core.Publishing.FileSystem {
	internal partial class pbsfsSettingsControl : publishSettingsBaseControl {
		public pbsfsSettingsControl() {
			InitializeComponent();
		}
		public override void loadSettings() {
			txtPublishDirectory.Text = getSetting("target");
		}
		public override void saveSettings() {
			addOrUpdateSetting("target", txtPublishDirectory.Text);
		}

		private void btnBrowseDirectory_Click(object sender, System.EventArgs e) {
			using(var dialog = new FolderBrowserDialog()) {
				dialog.Description = "Wählen Sie ein Verzeichnis aus, in welchen Sie die Updates veröffentlichen möchten:";
				if (dialog.ShowDialog() == DialogResult.OK)
					txtPublishDirectory.Text = dialog.SelectedPath;
			}
		}
	}
}