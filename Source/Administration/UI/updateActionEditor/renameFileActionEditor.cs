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
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class renameFileActionEditor : actionEditorBase {
		private renameFileAction _action;

		public renameFileActionEditor() {
			InitializeComponent();
			foreach (Directories.DirectoryItem item in new Directories().GetDirectories()) {
				txtPath.AutoCompleteCustomSource.Add(item.Value);
			}

			txtPath.TextChanged += delegate { _action.Path = txtPath.Text; };
			txtNewFilename.TextChanged += delegate { _action.newFilename = txtNewFilename.Text; };
		}

		public override void initializeActionContent() {
			_action = (updateAction as renameFileAction);
			txtPath.Text = _action.Path;
			txtNewFilename.Text = _action.newFilename;
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
	}
}