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
using System.Windows.Forms;
using System.Drawing;

namespace updateSystemDotNet.Internal.UI {
	internal partial class versionEditorControl : UserControl {
		public versionEditorControl(string val, bool useHostVersion) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;

			//Version zerlegen
			if (!useHostVersion) {
				try {
					string[] parts = val.Split('.');
					if (parts.Length >= 1) {
						txtMajor.Text = parts[0];
					}
					if (parts.Length >= 2) {
						txtMinor.Text = parts[1];
					}
					if (parts.Length >= 3) {
						txtBuild.Text = parts[2];
					}
					if (parts.Length >= 4) {
						txtRevision.Text = parts[3];
					}
				}
				catch {
					txtMajor.Text = "0";
					txtMinor.Text = "0";
					txtBuild.Text = "0";
					txtRevision.Text = "0";
				}
			}
			else {
				foreach (Control c in Controls)
					if (c is TextBox) c.Enabled = false;
			}
		}

		public string Value {
			get { return string.Format("{0}.{1}.{2}.{3}", new[] {txtMajor.Text, txtMinor.Text, txtBuild.Text, txtRevision.Text}); }
		}
	}
}