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