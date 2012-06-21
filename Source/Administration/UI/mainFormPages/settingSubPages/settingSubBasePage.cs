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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	[ToolboxItem(false)]
	internal class settingSubBasePage : UserControl {
		public settingSubBasePage() {
			base.Font = SystemFonts.MessageBoxFont;
			base.DoubleBuffered = true;
			base.MinimumSize = new Size(390, 25);
			Size = new Size(390, 150);
		}

		/// <summary>Die Anzeigereihenfolge dieses Einstellungsblocks auf der Einstellungsseite.</summary>
		public int displayOrder { get; set; }

		/// <summary>Bietet Zugriff auf die Anwendungssession.</summary>
		public applicationSession Session { get; set; }

		/// <summary>Gibt den Titel für diesen Einstellungsblock zurück oder legt diesen fest.</summary>
		public string Title { get; set; }

		/// <summary>Initialisiert die Daten auf dem Einstellungsblock.</summary>
		public virtual void initializeData() {
			//Ich lass mich mal überschreiben...
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			if (DesignMode)
				return;

			/*e.Graphics.DrawLine(
				SystemPens.ControlLight,
				new Point(0, Height - 1),
				new Point(Width, Height - 1)
				);*/

		}

		protected override void OnResize(System.EventArgs e) {
			base.OnResize(e);

			if (DesignMode)
				return;

			/*Invalidate(new Rectangle(
			           	new Point(0, Height - 1),
			           	new Size(Width, 1)
			           	));*/
		}

	}
}