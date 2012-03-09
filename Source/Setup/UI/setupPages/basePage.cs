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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;
using System.Drawing;

namespace updateSystemDotNet.Setup.UI.setupPages {
	[ToolboxItem(false)]
	internal partial class basePage : UserControl {
		public basePage() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		public event EventHandler<changePageEventArgs> changePage;

		[DllImport("shell32.dll")]
		protected static extern bool IsUserAnAdmin();

		protected void onChangePage(changePageEventArgs e) {
			if (changePage != null)
				changePage(this, e);
		}

		public virtual void onShow() {
		}

		public virtual void onHide() {
		}

		public virtual bool onValidate() {
			return true;
		}
	}
}