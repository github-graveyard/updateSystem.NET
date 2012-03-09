/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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
