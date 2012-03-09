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