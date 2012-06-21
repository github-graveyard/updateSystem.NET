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
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class registryActionEditorBase : actionEditorBase {
		private registryActionBase _action;

		public registryActionEditorBase() {
			InitializeComponent();

			foreach (string item in Enum.GetNames(typeof (registryHives))) {
				cboRegistryRoot.Items.Add(item);
			}
			cboRegistryRoot.SelectedIndex = 0;
			cboRegistryRoot.SelectedIndexChanged += cboRegistryRoot_SelectedIndexChanged;
			txtRegistryPath.TextChanged += txtRegistryPath_TextChanged;
		}

		public override void initializeLocalization() {
			base.initializeLocalization();
		}

		private void txtRegistryPath_TextChanged(object sender, EventArgs e) {
			_action.Path = txtRegistryPath.Text;
		}

		private void cboRegistryRoot_SelectedIndexChanged(object sender, EventArgs e) {
			_action.rootHive = (registryHives) cboRegistryRoot.SelectedIndex;
		}

		public override void initializeActionContent() {
			_action = (registryActionBase) updateAction;
			cboRegistryRoot.SelectedIndex = (int) _action.rootHive;
			txtRegistryPath.Text = _action.Path;
		}
	}
}