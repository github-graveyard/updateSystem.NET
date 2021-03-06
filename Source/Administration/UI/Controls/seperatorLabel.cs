﻿/**
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

namespace updateSystemDotNet.Administration.UI.Controls {
	internal class seperatorLabel : Label {
		public seperatorLabel() {
			base.TextAlign = ContentAlignment.MiddleLeft;
		}

		public override bool AutoSize {
			get { return false; }
			set { base.AutoSize = value; }
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			SizeF textSize = e.Graphics.MeasureString(Text, Font);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(213, 223, 223)), new Point((int) textSize.Width + 10, Height/2),
			                    new Point(Width, Height/2));
			e.Graphics.DrawLine(Pens.White, new Point((int) textSize.Width + 10, (Height/2) + 1),
			                    new Point(Width, (Height/2) + 1));
		}
	}
}