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

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class chooseNewPublishProviderDialog : dialogBase {
		private class cboProviderItem {
			public string Name { private get; set; }
			public Type Type { get; set; }
			public override string ToString() {
				return Name;
			}
		}
		public chooseNewPublishProviderDialog() {
			InitializeComponent();
			cboPublishProvider.SelectedIndexChanged += cboPublishProvider_SelectedIndexChanged;
		}

		void cboPublishProvider_SelectedIndexChanged(object sender, EventArgs e) {
			var selectedObject = (cboProviderItem) cboPublishProvider.SelectedItem;
			lblPublishDescription.Text = Session.publishFactory.availableProvider[selectedObject.Type].Description;
		}

		public override void initializeData() {
			foreach(var provider in Session.publishFactory.availableProvider) {
				cboPublishProvider.Items.Add(new cboProviderItem {Name = provider.Value.Name, Type = provider.Key});
			}
			cboPublishProvider.SelectedIndex = 0;
		}

		private void btnOk_Click(object sender, EventArgs e) {
			Result = (cboPublishProvider.SelectedItem as cboProviderItem).Type;
			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
