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
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpOptions : basePage, ISetupPage {
		public stpOptions() {
			InitializeComponent();

			txtSetupDir.TextChanged += delegate { Context.installationDirectory = txtSetupDir.Text; };
			chkStartMenuSC.CheckedChanged += delegate { Context.createStartMenuShortcut = chkStartMenuSC.Checked; };
			chkDesktopSC.CheckedChanged += delegate { Context.createDesktopShortcut = chkDesktopSC.Checked; };
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Die Installation anpassen"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpInstall); }
		}

		public Type backwardPage {
			get { return typeof (stpDonate); }
		}

		#endregion

		public override void onShow() {
			base.onShow();

			if (string.IsNullOrEmpty(Context.installationDirectory))
				txtSetupDir.Text = Context.defaultInstallationDirectory;
			else
				txtSetupDir.Text = Context.installationDirectory;

			chkStartMenuSC.Checked = Context.createStartMenuShortcut;
			chkDesktopSC.Checked = Context.createDesktopShortcut;
		}

		public override bool onValidate() {
			if (string.IsNullOrEmpty(txtSetupDir.Text))
				MessageBox.Show("Sie müssen ein Installationsverzeichnis angeben.", Context.Product.Product, MessageBoxButtons.OK,
				                MessageBoxIcon.Exclamation);

			return (!string.IsNullOrEmpty(txtSetupDir.Text));
		}

		private void btnBrowseSetupDir_Click(object sender, EventArgs e) {
			using (var dialog = new FolderBrowserDialog()) {
				dialog.Description = "Wählen Sie einen Ordner aus, in welchen das updateSystem.NET installiert werden soll:";
				dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				if (dialog.ShowDialog(ParentForm) == DialogResult.OK) {
					txtSetupDir.Text = dialog.SelectedPath;
				}
			}
		}
	}
}