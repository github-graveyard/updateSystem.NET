/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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
namespace updateSystemDotNet.Administration.UI.Popups {
	internal partial class updateVersionPopup : popupBase {
		public const string DCKEY_VERSION = "current_version";
		public const string DCKEY_PUBLISHED = "update_published";
		public const string DCKEY_SERVICE_PACK = "update_is_servicepack";

		public updateVersionPopup() {
			InitializeComponent();
		}

		public override void initializeData() {
			txtVersion.Text = popupArgument[DCKEY_VERSION].ToString();
			chkPublished.Checked = (bool) popupArgument[DCKEY_PUBLISHED];
			chkServicePack.Checked = (bool) popupArgument[DCKEY_SERVICE_PACK];
		}

		private void txtVersion_TextChanged(object sender, EventArgs e) {
			if (txtVersion.TextLength > 0 && isValidVersion(txtVersion.Text))
				popupResult[DCKEY_VERSION] = txtVersion.Text;
		}
		private void chkPublished_CheckedChanged(object sender, EventArgs e) {
			popupResult[DCKEY_PUBLISHED] = chkPublished.Checked;
		}
		private void chkServicePack_CheckedChanged(object sender, EventArgs e) {
			popupResult[DCKEY_SERVICE_PACK] = chkServicePack.Checked;
		}

		private bool isValidVersion(string version) {
			try {
				new Version(version);
				return true;
			}
			catch {
				return false;
			}
		}

	}
}
