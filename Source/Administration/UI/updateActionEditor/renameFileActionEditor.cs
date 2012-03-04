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