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
	internal partial class closeProcessActionEditor : actionEditorBase {
		private closeProcessAction _action;

		public closeProcessActionEditor() {
			InitializeComponent();
			lvwProcesses.Columns[0].Width = lvwProcesses.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth;
			lvwProcesses.SelectedIndexChanged += lvwProcesses_SelectedIndexChanged;
		}

		private void lvwProcesses_SelectedIndexChanged(object sender, EventArgs e) {
			btnRemoveProcess.Enabled = (lvwProcesses.SelectedItems.Count > 0);
		}

		public override void initializeActionContent() {
			_action = (updateAction as closeProcessAction);
			foreach (string item in _action.processList) {
				lvwProcesses.Items.Add(item);
			}
		}

		private void btnAddProcess_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtName.Text) || _action.processList.Contains(txtName.Text))
				return;

			lvwProcesses.Items.Add(txtName.Text);
			_action.processList.Add(txtName.Text);
			txtName.Text = string.Empty;
		}

		private void btnRemoveProcess_Click(object sender, EventArgs e) {
			if (lvwProcesses.SelectedItems.Count > 0) {
				_action.processList.Remove(lvwProcesses.SelectedItems[0].Text);
				lvwProcesses.Items.Remove(lvwProcesses.SelectedItems[0]);
			}
		}
	}
}