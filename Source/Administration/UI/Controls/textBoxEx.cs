using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class textBoxEx : TextBox {

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);

		private string _cueText;

		private void SetCue() {
			if (IsHandleCreated && _cueText != null) {
				SendMessage(Handle, 0x1501, (IntPtr) 1, _cueText);
			}
		}

		[Category("Appearance")]
		public string cueText {
			get { return _cueText; }
			set { _cueText = value; SetCue(); }
		}

		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);
			SetCue();
		}
	}
}