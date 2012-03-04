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
