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
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class linkLabelEx : LinkLabel {
		public linkLabelEx() {
			LinkColor = SystemColors.HotTrack;
			Font = SystemFonts.MessageBoxFont; // Core.Fonts.defaultFont;
			ActiveLinkColor = SystemColors.Highlight;
			LinkBehavior = LinkBehavior.NeverUnderline;
		}

		public string Url { get; set; }

		private void openFailed() {
			MessageBox.Show(
				"Die Adresse konnte wegen eines Fehlers nicht geöffnet werden:\r\n" + Url,
				"assemblyCompressor",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}

		protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e) {
			if (!string.IsNullOrEmpty(Url)) {
				new Thread(openUrl).Start(Url);
			}
			else {
				base.OnLinkClicked(e);
			}
		}

		private void openUrl(object argument) {
			try {
				Process.Start((argument as string));
			}
			catch {
				Invoke(new delOpenFailed(openFailed));
			}
		}

		#region Nested type: delOpenFailed

		private delegate void delOpenFailed();

		#endregion
	}
}