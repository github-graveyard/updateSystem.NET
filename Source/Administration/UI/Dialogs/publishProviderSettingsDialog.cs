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
			_extendedSettings.localizeControl();
			_extendedSettings.loadSettings();
		}

		public override void localizeDialog() {
			base.localizeDialog();
			chkActive.Text = string.Empty; //This one has an external description
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
