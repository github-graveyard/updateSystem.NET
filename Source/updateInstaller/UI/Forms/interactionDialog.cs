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
using System.Drawing;
using System.Windows.Forms;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Updater.UI.Forms {
	public partial class interactionDialog : Form {
		public interactionDialog(interactionButtons buttons, string Title, string Message) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;

			lblTitle.Text = Title;
			lblMessage.Text = Message;

			SetClientSizeCore(ClientRectangle.Width, (12 + lblTitle.Height + 10 + lblMessage.Height + 12 + flpBottom.Height));
			lblMessage.Location = new Point(lblMessage.Location.X, (12 + lblTitle.Height + 10));

			switch (buttons) {
				case interactionButtons.Close:
					btnCancel.Hide();
					btnOk.Text = Language.GetString("general_button_close");
					imgInformation.Image = SystemIcons.Information.ToBitmap();
					ControlBox = true;
					break;
				case interactionButtons.OkCancel:
					btnCancel.Text = Language.GetString("general_button_cancel");
					btnOk.Text = Language.GetString("general_button_ok");
					imgInformation.Image = SystemIcons.Question.ToBitmap();
					break;
				case interactionButtons.YesNo_1: //Abbruch bei Ja
					btnCancel.Text = Language.GetString("general_button_no");
					btnOk.Text = Language.GetString("general_button_yes");
					btnOk.DialogResult = DialogResult.Cancel;
					btnCancel.DialogResult = DialogResult.OK;
					CancelButton = btnOk;
					AcceptButton = btnCancel;
					imgInformation.Image = SystemIcons.Question.ToBitmap();
					break;
				case interactionButtons.YesNo_2: //Abbruch bei Nein
					btnCancel.Text = Language.GetString("general_button_no");
					btnOk.Text = Language.GetString("general_button_yes");
					imgInformation.Image = SystemIcons.Question.ToBitmap();
					break;
			}
		}

		private void flpBottom_Paint(object sender, PaintEventArgs e) {
			try {
				e.Graphics.Clear(Color.FromArgb(240, 240, 240));
				e.Graphics.DrawLine(new Pen(Color.FromArgb(223, 223, 223), 1), new Point(0, 0),
				                    new Point(flpBottom.ClientRectangle.Width, 0));
			}
			catch {
			}
		}
	}
}