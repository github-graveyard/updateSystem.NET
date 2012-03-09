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
namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspLinkedAssemblyVersion : settingSubBasePage {
		public sspLinkedAssemblyVersion() {
			InitializeComponent();
		}

		public override void initializeData() {
			if (Session.currentProject.linkAssemblyToVersion)
				rbLinked.Checked = true;
			else
				rbNotLinked.Checked = true;
			
			txtLinkedAssemblyPath.Text = Session.currentProject.linkedAssemblyPath;
		}

		private void rbLinked_CheckedChanged(object sender, System.EventArgs e) {
			pnlLinkedAssembly.Enabled = rbLinked.Checked;
			Session.currentProject.linkAssemblyToVersion = rbLinked.Checked;
		}

		private void btnBrowseAssembly_Click(object sender, System.EventArgs e) {
			using(var dialog = new OpenFileDialog()) {
				dialog.Filter = ".NET Assemblies|*.dll;*.exe";
				if (dialog.ShowDialog(ParentForm) != DialogResult.OK) return;
				
				txtLinkedAssemblyPath.Text = dialog.FileName;
				Session.currentProject.linkedAssemblyPath = dialog.FileName;
			}
		}
	}
}
