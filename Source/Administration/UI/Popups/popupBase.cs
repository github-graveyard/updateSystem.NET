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
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.Popups {
	internal class popupBase : Form {
		public popupBase() {
			popupResult = new dataContainer();
			//Form entsprechend anpassen
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
			ShowInTaskbar = false;
			MinimizeBox = false;
			MaximizeBox = false;
			ControlBox = false;
			base.Font = SystemFonts.MessageBoxFont;
			//addLink();
		}

		public dataContainer popupResult { get; protected set; }

		public dataContainer popupArgument { get; set; }

		public applicationSession Session { get; set; }

		public virtual void initializeData() {
			//per default wird hier nüscht gemacht
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			var rectBorder = new Rectangle(
				0,
				0,
				ClientRectangle.Width - 1,
				ClientRectangle.Height - 1
				);
			e.Graphics.DrawRectangle(SystemPens.ControlDark, rectBorder);
		}
		private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Close();
		}

		private const int CS_DROPSHADOW = 0x20000;
		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}

	}
}