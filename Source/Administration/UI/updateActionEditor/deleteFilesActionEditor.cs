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
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class deleteFilesActionEditor : actionEditorBase {
		private deleteFilesAction _action;

		public deleteFilesActionEditor() {
			InitializeComponent();

			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				txtPath.AutoCompleteCustomSource.Add(item.Value);
			}
			lvwFileNames.Columns[0].Width = lvwFileNames.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwFileNames.SelectedIndexChanged += lvwFileNames_SelectedIndexChanged;
		}

		private void lvwFileNames_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveEntry.Enabled = (lvwFileNames.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			_action = (updateAction as deleteFilesAction);
			txtPath.Text = _action.Path;
			foreach (string item in _action.filesToRemove) {
				lvwFileNames.Items.Add(item);
			}
		}

		private void btnAddEntry_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtFileName.Text) || _action.filesToRemove.Contains(txtFileName.Text))
				return;

			lvwFileNames.Items.Add(txtFileName.Text);
			_action.filesToRemove.Add(txtFileName.Text);
			txtFileName.Text = string.Empty;
		}

		private void btnRemoveEntry_Click(object sender, EventArgs e) {
			if (lvwFileNames.SelectedItems.Count > 0) {
				_action.filesToRemove.Remove(lvwFileNames.SelectedItems[0].Text);
				lvwFileNames.Items.Remove(lvwFileNames.SelectedItems[0]);
			}
		}

		private void lnkVarInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			var sbVars = new StringBuilder();
			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				sbVars.AppendLine(string.Format("{0}: {1}", item.Value, item));
			}
			Session.showMessage(
				this,
				sbVars.ToString(),
				"Verfügbare Pfadvariablen",
				MessageBoxIcon.Information,
				MessageBoxButtons.OK
				);
		}

		private void txtPath_TextChanged(object sender, EventArgs e) {
			_action.Path = txtPath.Text;
		}
	}
}