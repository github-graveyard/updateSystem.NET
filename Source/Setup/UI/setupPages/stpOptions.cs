using System;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpOptions : basePage, ISetupPage {
		public stpOptions() {
			InitializeComponent();

			txtSetupDir.TextChanged += delegate { Context.installationDirectory = txtSetupDir.Text; };
			chkStartMenuSC.CheckedChanged += delegate { Context.createStartMenuShortcut = chkStartMenuSC.Checked; };
			chkDesktopSC.CheckedChanged += delegate { Context.createDesktopShortcut = chkDesktopSC.Checked; };
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Die Installation anpassen"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpInstall); }
		}

		public Type backwardPage {
			get { return typeof (stpDonate); }
		}

		#endregion

		public override void onShow() {
			base.onShow();

			if (string.IsNullOrEmpty(Context.installationDirectory))
				txtSetupDir.Text = Context.defaultInstallationDirectory;
			else
				txtSetupDir.Text = Context.installationDirectory;

			chkStartMenuSC.Checked = Context.createStartMenuShortcut;
			chkDesktopSC.Checked = Context.createDesktopShortcut;
		}

		public override bool onValidate() {
			if (string.IsNullOrEmpty(txtSetupDir.Text))
				MessageBox.Show("Sie müssen ein Installationsverzeichnis angeben.", Context.Product.Product, MessageBoxButtons.OK,
				                MessageBoxIcon.Exclamation);

			return (!string.IsNullOrEmpty(txtSetupDir.Text));
		}

		private void btnBrowseSetupDir_Click(object sender, EventArgs e) {
			using (var dialog = new FolderBrowserDialog()) {
				dialog.Description = "Wählen Sie einen Ordner aus, in welchen das updateSystem.NET installiert werden soll:";
				dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				if (dialog.ShowDialog(ParentForm) == DialogResult.OK) {
					txtSetupDir.Text = dialog.SelectedPath;
				}
			}
		}
	}
}