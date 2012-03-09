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
