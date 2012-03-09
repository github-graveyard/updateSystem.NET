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

using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class saveProjectDialog : dialogBase {

		private string _location;
		private readonly List<char> _invalidChars;

		public saveProjectDialog() {
			InitializeComponent();

			_invalidChars=new List<char>();
			_invalidChars.AddRange(Path.GetInvalidFileNameChars());
			_invalidChars.AddRange(Path.GetInvalidPathChars());

			txtProjectName.KeyPress += txtProjectName_KeyPress;
		}

		void txtProjectName_KeyPress(object sender, KeyPressEventArgs e) {
			e.Handled = (_invalidChars.Contains(e.KeyChar) && e.KeyChar != '\b');
		}

		public override void initializeData() {
			_location = Session.defaultProjectLocation;
			txtProjectName_TextChanged(null,null);
			txtProjectName.Text = Session.currentProject.projectName;
			txtProjectName.SelectAll();
		}

		private void btnBrowse_Click(object sender, System.EventArgs e) {
			using (var dialog = new FolderBrowserDialog()) {
				dialog.Description = "Wählen Sie ein Verzeichnis aus, in welchem das Projektverzeichnis erzeugt werden soll:";
				dialog.SelectedPath = _location;
				if (dialog.ShowDialog(this) == DialogResult.OK) {
					_location = dialog.SelectedPath;
					txtProjectName_TextChanged(null, null);
				}
			}
		}

		private void txtProjectName_TextChanged(object sender, System.EventArgs e) {
			string projectName = string.IsNullOrEmpty(txtProjectName.Text) ? Session.currentProject.projectName : txtProjectName.Text;
			txtProjectLocation.Text = Path.Combine(_location, projectName);
			txtProjectLocation.Select(txtProjectLocation.TextLength, 0);
			btnOk.Enabled = (txtProjectName.TextLength > 0 && txtProjectLocation.TextLength < 255);
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			Result = Path.Combine(txtProjectLocation.Text, string.Format("{0}.uaproj", txtProjectName.Text));
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
