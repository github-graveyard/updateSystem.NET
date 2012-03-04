using System;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.updateLog;
using updateSystemDotNet.Administration.Core.DataValidation;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class manageUpdateLogProjectDialog : dialogBase {
		private updateLogProject _project;

		public manageUpdateLogProjectDialog() {
			InitializeComponent();
		}
		public override void initializeData() {
			permanentlyDisableControl(txtProjectId);

			if(Argument == null)
				throw new ArgumentException("Es wurde kein updateLogProject übergeben!");

			_project = (updateLogProject) Argument;
			txtProjectId.Text = _project.projectId;
			txtProjectName.Text = _project.projectName;
			chkIsActive.Checked = _project.isActive;
			registerValidationEntry(txtProjectName, validationTypes.NotNull, "Anzeigename");
		}

		private void bgwEditProject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var args = (object[]) e.Argument;
				Session.updateLogFactory.editProject(
					Session.currentProject.projectId,
					(string) args[0],
					(bool) args[1]
					);
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (validateDialog()) {
				lockUi(false);
				bgwEditProject.RunWorkerAsync(new object[] {
				                                           	txtProjectName.Text,
				                                           	chkIsActive.Checked
				                                           });
			}
		}

		private void bgwEditProject_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if(e.Result == null) {
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				lockUi(true);
				Session.showMessage(this,
				                    string.Format(
				                    	"Das Project konnte aufgrund des folgenden Problems nicht bearbeitet werden:\r\n{0}",
				                    	((Exception) e.Result).Message), "Während der Serveranfrage ist ein Problem aufgetreten",
				                    MessageBoxIcon.Error, MessageBoxButtons.OK);
			}
		}
	}
}
