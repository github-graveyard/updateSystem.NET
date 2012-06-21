/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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
