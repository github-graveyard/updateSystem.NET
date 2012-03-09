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

using System.Drawing;
using System;
using updateSystemDotNet.Administration.UI.Controls;
using System.Media;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal sealed partial class applicationErrorDialog : dialogBase {
		private volatile Exception _exception;       

		public applicationErrorDialog() {
			InitializeComponent();
			lblDetailsDescription.Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold);
		}
		public override void initializeData() {
			if(Argument!= null ) {
				var exception = (Argument as Exception);
				if (exception != null) {
					lblExceptionText.Text = exception.Message;
					_exception = exception;
				}
			}
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			SystemSounds.Hand.Play();
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.White, Color.DarkRed, LinearGradientMode.Vertical)) {
				e.Graphics.FillRectangle(brush,ClientRectangle);
			}

		}

		private void btnSendReport_Click(object sender, EventArgs e) {
			btnSendReport.Enabled = false;
			
			aclSend.Show();
			aclSend.State = actionLabelStates.Progress;

			bgwSendReport.RunWorkerAsync(txtEMail.Text);
		}

		private void bgwSendReport_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var email = e.Argument.ToString();
				if(_exception!=null) {
					Session.webServices.sendExceptionReport(_exception, email);
				}
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwSendReport_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			aclSend.State = actionLabelStates.Waiting;
			aclSend.Hide();
			btnSendReport.Enabled = true;

			if (e.Result == null) {
				//Report erfolgreich versendet
				Session.showMessage("Vielen Dank! Der Report wurde erfolgreich übertragen.");
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				//Fehler beim versenden
				Session.showMessage(
					this,
					((Exception) e.Result).Message, "Beim Übertragen des Reports ist ein Fehler aufgetreten", MessageBoxIcon.Error,
					MessageBoxButtons.OK);
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
