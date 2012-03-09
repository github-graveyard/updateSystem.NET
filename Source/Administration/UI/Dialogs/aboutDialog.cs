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
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class aboutDialog : dialogBase {
		public aboutDialog() {
			InitializeComponent();
			btnClose.Click += btnClose_Click;
			imgAppLogo.Image = resourceHelper.getImage("app_logo_big.png");
			imgDonate.Image = resourceHelper.getImage("paypalDonate.gif");

			base.Text = string.Format("Über {0}", Strings.applicationName);
			lblAppName.Text = Strings.applicationInternalName;
			lblCopyright.Text = string.Format(lblCopyright.Text, DateTime.Now.Year);
			lblCopyright.LinkArea = new LinkArea(lblCopyright.Text.IndexOf("Maximilian"), 16);
		}

		public override void initializeData() {
			lblVersion.Text = string.Format(lblVersion.Text, Assembly.GetExecutingAssembly().GetName().Version, Session.applicationCodeName);
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void imgDonate_Click(object sender, EventArgs e) {
			Process.Start(Strings.urlDonate);
		}
	}
}