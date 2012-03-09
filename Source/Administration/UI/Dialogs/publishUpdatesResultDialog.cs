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
using updateSystemDotNet.Administration.Core.Publishing;
using System.Windows.Forms;
using System.Drawing;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class publishUpdatesResultDialog : dialogBase {
		private publishResultList _results;

		public publishUpdatesResultDialog() {
			InitializeComponent();
			Closing += publishUpdatesResultDialog_Closing;
		}

		void publishUpdatesResultDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			saveColumnHeaderSizes(lvwResult);
			Session.currentProject.hidePublishResult = chkHidePublishResult.Checked;
		}

		public override void initializeData() {
			_results = (Argument as publishResultList);
			restoreColumnHeaderSizes(lvwResult);

			if (_results == null)
				throw new InvalidOperationException("Argument is null");

			foreach (var result in _results) {

				var item = new ListViewItem {Text = result.Provider.Settings.Name};
				item.SubItems.Add(Session.publishFactory.availableProvider[result.Provider.GetType()].Name);
				if(result.Successful) {
					item.SubItems.Add("-");
					item.Group = lvwResult.Groups["grpSuccess"];
					item.ForeColor = Color.Green;
				}
				else {
					item.SubItems.Add(result.Error.Message);
					item.Group = lvwResult.Groups["grpFailed"];
					item.ForeColor = Color.DarkRed;
				}
				lvwResult.Items.Add(item);
			}
			chkHidePublishResult.Checked = Session.currentProject.hidePublishResult;
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void mnuExportCSV_Click(object sender, EventArgs e) {
			using(var dialog = new SaveFileDialog()) {
				dialog.Filter = "CSV-Dateien|*.csv";
				if (dialog.ShowDialog(this) == DialogResult.OK)
					lvwResult.exportAsCSV(dialog.FileName);
			}
		}

	}
}
