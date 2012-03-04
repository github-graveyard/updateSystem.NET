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
