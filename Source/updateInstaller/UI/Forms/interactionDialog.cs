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