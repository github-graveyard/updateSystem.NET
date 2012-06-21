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
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class removeRegistryValuesActionEditor : registryActionEditorBase {
		private removeRegistryValuesAction _action;

		public removeRegistryValuesActionEditor() {
			InitializeComponent();
			lvwValues.Columns[0].Width = lvwValues.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwValues.SelectedIndexChanged += lvwValues_SelectedIndexChanged;
		}

		private void lvwValues_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveEntry.Enabled = (lvwValues.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			base.initializeActionContent();
			_action = (updateAction as removeRegistryValuesAction);
			foreach (string item in _action.valueNames) {
				lvwValues.Items.Add(item);
			}
		}

		private void btnAddEntry_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtValueName.Text) || _action.valueNames.Contains(txtValueName.Text))
				return;

			lvwValues.Items.Add(txtValueName.Text);
			_action.valueNames.Add(txtValueName.Text);
			txtValueName.Text = string.Empty;
		}

		private void btnRemoveEntry_Click(object sender, EventArgs e) {
			if (lvwValues.SelectedItems.Count > 0) {
				_action.valueNames.Remove(lvwValues.SelectedItems[0].Text);
				lvwValues.Items.Remove(lvwValues.SelectedItems[0]);
			}
		}
	}
}