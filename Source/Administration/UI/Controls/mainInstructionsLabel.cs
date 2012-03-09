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
