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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpInterrupted : basePage, ISetupPage {
		public stpInterrupted() {
			InitializeComponent();
			imgError.Image = SystemIcons.Error.ToBitmap();
			bgwSendReport.RunWorkerCompleted += bgwSendReport_RunWorkerCompleted;
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Der Vorgang wurde unterbrochen"; }
		}

		public bool isLastPage {
			get { return true; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return null; }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
		}

		public override void onShow() {
			base.onShow();
			txtException.Text = Context.setupException.ToString();
		}

		private void pnlErrorReport_Paint(object sender, PaintEventArgs e) {
			e.Graphics.DrawRectangle(
				SystemPens.ControlLight,
				new Rectangle(0, 0, pnlErrorReport.Width - 1, pnlErrorReport.Height - 1));
		}

		private void bgwSendReport_DoWork(object sender, DoWorkEventArgs e) {
			try {
				//TODO: Fehlenden Exceptionreport fixen
				//var report = new exceptionReport(e.Argument as Exception);
				//report.sendReport(string.Empty);
			}
			catch (Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwSendReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Result == null) {
				//Report erfolgreich übertragen
				MessageBox.Show("Der Problembericht wurde erfolgreich an den Entwickler übertragen. Vielen Dank!",
				                "updateSystem.NET Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else {
				//Fehler bei der Übertragung
				pnlErrorReport.Enabled = true;
				if (MessageBox.Show(
					string.Format(
						"Der Report konnte auf Grund des folgenden Problems nicht übertragen werden:\r\n{0}\r\nDenken Sie daran, dass zur Übermittlung des Reports eine aktive Internetverbindung benötigt wird. Wollen Sie den Sendevorgang wiederholen?",
						(e.Result as Exception).Message),
					"updateSystem.NET Setup",
					MessageBoxButtons.RetryCancel,
					MessageBoxIcon.Error) == DialogResult.Retry) {
					bgwSendReport.RunWorkerAsync(Context.setupException);
				}
			}
		}

		private void btnSendErrorReport_Click(object sender, EventArgs e) {
			bgwSendReport.RunWorkerAsync(Context.setupException);
			pnlErrorReport.Enabled = false;
		}
	}
}