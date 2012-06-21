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
using updateSystemDotNet.Administration.Core;
using System.Drawing;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class addFolderDialog : Form {
		public addFolderDialog() {
			InitializeComponent();
			base.Text = string.Format("{0} - Neuen Ordner erstellen", Strings.applicationName);
			base.Font = SystemFonts.MessageBoxFont;
		}

		/// <summary>Gibt den Eingegebenen Namen für das neue Verzeichnis zurück.</summary>
		public string enteredFolder {
			get { return txtFolder.Text.Trim(); }
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtFolder.Text)) {
				MessageBox.Show("Sie müssen einen Namen für das Verzeichnis eingeben.", Strings.applicationName,
				                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}