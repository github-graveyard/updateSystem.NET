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
using System;
using System.Windows.Forms.VisualStyles;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class mainInstructionsLabel : Label {
		private readonly bool _isVisualStyleSupported;
		private readonly VisualStyleElement _vseMainInstruction;
		
		public mainInstructionsLabel() {
			ForeColor = Color.FromArgb(0, 51, 153);
			Font = new Font(SystemFonts.MessageBoxFont.FontFamily.Name, 12f, GraphicsUnit.Point);
			_isVisualStyleSupported = (Environment.OSVersion.Version.Major >= 6 && VisualStyleRenderer.IsSupported);
			
			if (_isVisualStyleSupported)
				_vseMainInstruction = VisualStyleElement.CreateElement("TEXTSTYLE", 1, 0);
		}

		protected override void OnPaint(PaintEventArgs e) {
			if(_isVisualStyleSupported)
				new VisualStyleRenderer(_vseMainInstruction).DrawText(e.Graphics, ClientRectangle, Text);
			else
				base.OnPaint(e);
		}
	}
}
