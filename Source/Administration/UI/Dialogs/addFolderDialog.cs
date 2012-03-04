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