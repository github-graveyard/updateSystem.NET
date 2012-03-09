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
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class groupBoxEx : GroupBox {
		private VisualStyleElement _styleElement;

		public groupBoxEx() {
			Padding = new Padding(12, 6, 12, 6);
		}

		private VisualStyleElement styleElement {
			get { return (_styleElement ?? (_styleElement = VisualStyleElement.CreateElement("TASKDIALOG", 8, 0))); }
		}

		[DefaultValue(typeof (Padding), "12,6,12,6")]
		public new Padding Padding {
			get { return base.Padding; }
			set { base.Padding = value; }
		}

		protected override void OnPaint(PaintEventArgs e) {
			Size size = e.Graphics.MeasureString(Text, Font).ToSize();
			var bounds = new Rectangle(size.Width + 1, (size.Height/2) + 1, Width - size.Width, 1);
			TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle.Location, Enabled ? ForeColor : SystemColors.GrayText );
			if (Environment.OSVersion.Version.Major >= 6 && VisualStyleRenderer.IsSupported) {
				new VisualStyleRenderer(styleElement).DrawBackground(e.Graphics, bounds);
			}
			else {
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), bounds);
			}
		}
	}
}