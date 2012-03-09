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