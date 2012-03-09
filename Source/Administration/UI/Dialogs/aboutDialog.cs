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
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class aboutDialog : dialogBase {
		public aboutDialog() {
			InitializeComponent();
			btnClose.Click += btnClose_Click;
			imgAppLogo.Image = resourceHelper.getImage("app_logo_big.png");
			imgDonate.Image = resourceHelper.getImage("paypalDonate.gif");

			base.Text = string.Format("Über {0}", Strings.applicationName);
			lblAppName.Text = Strings.applicationInternalName;
			lblCopyright.Text = string.Format(lblCopyright.Text, DateTime.Now.Year);
			lblCopyright.LinkArea = new LinkArea(lblCopyright.Text.IndexOf("Maximilian"), 16);
		}

		public override void initializeData() {
			lblVersion.Text = string.Format(lblVersion.Text, Assembly.GetExecutingAssembly().GetName().Version, Session.applicationCodeName);
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void imgDonate_Click(object sender, EventArgs e) {
			Process.Start(Strings.urlDonate);
		}
	}
}