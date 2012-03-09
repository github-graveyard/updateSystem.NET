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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;
using System.Drawing;

namespace updateSystemDotNet.Setup.UI.setupPages {
	[ToolboxItem(false)]
	internal partial class basePage : UserControl {
		public basePage() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		public event EventHandler<changePageEventArgs> changePage;

		[DllImport("shell32.dll")]
		protected static extern bool IsUserAnAdmin();

		protected void onChangePage(changePageEventArgs e) {
			if (changePage != null)
				changePage(this, e);
		}

		public virtual void onShow() {
		}

		public virtual void onHide() {
		}

		public virtual bool onValidate() {
			return true;
		}
	}
}