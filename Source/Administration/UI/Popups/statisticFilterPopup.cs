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
using System.Drawing;

namespace updateSystemDotNet.Administration.UI.Popups {
	internal partial class statisticFilterPopup : popupBase {

		public const string DCKEY_DATE_FROM = "dateFrom";
		public const string DCKEY_DATE_TO = "dateTo";
		public const string DCKEY_OS_MAJOR = "osMajor";
		public const string DCKEY_OS_MINOR = "osMinor";
		public const string DCKEY_SELECTED_OS_INDEX = "selected_os_index";

		private class comboboxOSObject {

			public comboboxOSObject(int osmajor, int osminor, string name) {
				osMajor = osmajor;
				osMinor = osminor;
				displayName = name;
			}

			public int osMajor { get; private set; }
			public int osMinor { get; private set; }
			private string displayName { get; set; }

			public override string ToString() {
				return displayName;
			}

		}

		public statisticFilterPopup() {
			InitializeComponent();

			cboOS.Items.Add(new comboboxOSObject(-1, -1, "Alle Betriebssysteme"));
			cboOS.Items.Add(new comboboxOSObject(5, 1, "Windows XP"));
			cboOS.Items.Add(new comboboxOSObject(5, 2, "Windows Server 2003/R2"));
			cboOS.Items.Add(new comboboxOSObject(6, 0, "Windows Vista/Server 2008"));
			cboOS.Items.Add(new comboboxOSObject(6, 1, "Windows 7/Server 2008R2"));

			dtpDateFrom.MaxDate = DateTime.Now;
			dtpDateTo.MaxDate = DateTime.Now.AddDays(1);
			lblTimespan.Font = new Font(base.Font, FontStyle.Bold);
		}

		public override void initializeData() {
			if (popupArgument == null)
				return;

			dtpDateFrom.Value = (DateTime) popupArgument[DCKEY_DATE_FROM];
			dtpDateTo.Value = (DateTime) popupArgument[DCKEY_DATE_TO];
			cboOS.SelectedIndex = (int) popupArgument[DCKEY_SELECTED_OS_INDEX];

		}

		private void dtpDateFrom_ValueChanged(object sender, EventArgs e) {
			popupResult[DCKEY_DATE_FROM] = dtpDateFrom.Value;
		}

		private void dtpDateTo_ValueChanged(object sender, EventArgs e) {
			popupResult[DCKEY_DATE_TO] = dtpDateTo.Value;
		}

		private void cboOS_SelectedIndexChanged(object sender, EventArgs e) {
			var selectedObject = (comboboxOSObject) cboOS.SelectedItem;
			popupResult[DCKEY_OS_MAJOR] = selectedObject.osMajor;
			popupResult[DCKEY_OS_MINOR] = selectedObject.osMinor;
			popupResult[DCKEY_SELECTED_OS_INDEX] = cboOS.SelectedIndex;
		}
	}
}
