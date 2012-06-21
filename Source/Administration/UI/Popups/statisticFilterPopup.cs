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
