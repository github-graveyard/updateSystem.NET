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
using System.Media;
using System.Windows.Forms;
using updateSystemDotNet.Updater.UI.Components;

namespace updateSystemDotNet.Updater.UI.Forms {
	internal partial class fileAccessDialog : dlgTemplate {
		public fileAccessDialog() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			imgExclamation.Image = SystemIcons.Exclamation.ToBitmap();
			Shown += fileAccessDialog_Shown;

			lblTitle.Text = Language.GetString("fileAccessDialog_lblTitle_text");
			btnRetry.Text = Language.GetString("fileAccessDialog_btnRetry_text");
			btnAbort.Text = Language.GetString("fileAccessDialog_btnAbort_text");
		}

		private void fileAccessDialog_Shown(object sender, EventArgs e) {
			SystemSounds.Exclamation.Play();
		}

		public DialogResult ShowDialog(IWin32Window Owner, string Path) {
			lblInfo.Text = string.Format(
				Language.GetString("fileAccessDialog_lblInfo_text")
				, Path);

			return base.ShowDialog(Owner);
		}
	}
}