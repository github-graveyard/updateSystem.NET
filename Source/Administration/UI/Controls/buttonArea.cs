/*
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

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class buttonArea : FlowLayoutPanel {
		
		public buttonArea() {
			Size = new Size(200, 50);
			FlowDirection = FlowDirection.RightToLeft;
			Padding = new Padding(0, 10, 12, 0);
			Dock = DockStyle.Bottom;
			Paint += buttonArea_Paint;
		}
		void buttonArea_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(SystemColors.Control);
			e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(0, 0),
				new Point(e.ClipRectangle.Width, 0));
		}

	}
}
