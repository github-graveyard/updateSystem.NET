#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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