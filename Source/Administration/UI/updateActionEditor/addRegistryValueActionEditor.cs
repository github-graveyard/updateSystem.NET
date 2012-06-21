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
	internal partial class addRegistryValueActionEditor : registryActionEditorBase {
		private addRegistryValueAction _action;

		public addRegistryValueActionEditor() {
			InitializeComponent();

			foreach (string item in Enum.GetNames(typeof (registryValueTypes))) {
				cboValueTypes.Items.Add(item);
			}
			cboValueTypes.SelectedIndex = 0;

			lvwValues.SelectedIndexChanged += lvwValues_SelectedIndexChanged;
		}

		public override void initializeActionContent() {
			base.initializeActionContent();
			_action = (updateAction as addRegistryValueAction);

			foreach (addRegistryValueAction.registryItem item in _action.Items) {
				var lvItem = new ListViewItem(item.Name);
				lvItem.SubItems.Add(item.Value.ToString());
				lvItem.SubItems.Add(item.Type.ToString());
				lvwValues.Items.Add(lvItem);
			}
		}

		private void btnAddValue_Click(object sender, EventArgs e) {
			if (listViewContainsName(txtName.Text)) {
				//Eintrag bearbeiten

				//Betroffenes Item heraussuchen
				ListViewItem lvItem = getListViewItemByName(txtName.Text);
				lvItem.Text = txtName.Text;
				lvItem.SubItems[1].Text = txtValue.Text;
				lvItem.SubItems[2].Text = cboValueTypes.SelectedItem.ToString();

				//Beotroffenes actionItem heraussuchen
				addRegistryValueAction.registryItem rItem = getRegistryItemByName(txtName.Text);
				rItem.Name = txtName.Text;
				rItem.Value = txtValue.Text;
				rItem.Type = (registryValueTypes) cboValueTypes.SelectedIndex;
			}
			else {
				//Neuen Eintrag hinzufügen
				var lvi = new ListViewItem();
				lvi.Text = txtName.Text;
				lvi.SubItems.Add(txtValue.Text);
				lvi.SubItems.Add(cboValueTypes.SelectedItem.ToString());
				lvwValues.Items.Add(lvi);

				_action.Items.Add(new addRegistryValueAction.registryItem {
				                                                          	ID = Guid.NewGuid().ToString(),
				                                                          	Name = txtName.Text,
				                                                          	Value = txtValue.Text,
				                                                          	Type = (registryValueTypes) cboValueTypes.SelectedIndex
				                                                          });
			}
			txtName.Text = string.Empty;
			txtValue.Text = string.Empty;
			btnAddValue.Text = "Hinzufügen";
			btnRemove.Hide();
		}

		/// <summary>Überprüft ob der ListView schon einen Eintrag mit einem bestimmten Namen enthält.</summary>
		/// <param name="name">Der Name nach welchem gesucht werden.</param>
		/// <returns>Gibt True zurück wenn der Name vorhanden ist, andernfalls False.</returns>
		private bool listViewContainsName(string name) {
			foreach (ListViewItem lvItem in lvwValues.Items) {
				if (name.ToLower().Equals(lvItem.Text.ToLower()))
					return true;
			}
			return false;
		}

		/// <summary>Gibt ein ListViewItem anhand des Namens zurück</summary>
		private ListViewItem getListViewItemByName(string name) {
			foreach (ListViewItem lvi in lvwValues.Items) {
				if (name.ToLower().Equals(lvi.Text.ToLower()))
					return lvi;
			}
			return null;
		}

		/// <summary>Gibt ein Registryitem anhand des Namens zurück.</summary>
		private addRegistryValueAction.registryItem getRegistryItemByName(string name) {
			foreach (addRegistryValueAction.registryItem item in _action.Items) {
				if (item.Name.ToLower().Equals(name.ToLower()))
					return item;
			}
			return null;
		}

		private void lvwValues_SelectedIndexChanged(object sender, EventArgs e) {
			if (lvwValues.SelectedItems.Count > 0) {
				ListViewItem selectedItem = lvwValues.SelectedItems[0];
				txtName.Text = selectedItem.Text;
				txtValue.Text = selectedItem.SubItems[1].Text;
				cboValueTypes.SelectedIndex = (int) Enum.Parse(typeof (registryValueTypes), selectedItem.SubItems[2].Text);
				btnAddValue.Text = "Aktualisieren";
				btnRemove.Show();
			}
			else {
				txtName.Text = string.Empty;
				txtValue.Text = string.Empty;
				btnAddValue.Text = "Hinzufügen";
				btnRemove.Hide();
			}
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			lvwValues.Items.Remove(getListViewItemByName(txtName.Text));
			_action.Items.Remove(getRegistryItemByName(txtName.Text));
			txtName.Text = string.Empty;
			txtValue.Text = string.Empty;
			btnRemove.Hide();
			btnAddValue.Text = "Hinzufügen";
		}
	}
}