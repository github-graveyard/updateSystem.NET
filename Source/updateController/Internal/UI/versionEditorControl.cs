using System.Windows.Forms;
using System.Drawing;

namespace updateSystemDotNet.Internal.UI {
	internal partial class versionEditorControl : UserControl {
		public versionEditorControl(string val, bool useHostVersion) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;

			//Version zerlegen
			if (!useHostVersion) {
				try {
					string[] parts = val.Split('.');
					if (parts.Length >= 1) {
						txtMajor.Text = parts[0];
					}
					if (parts.Length >= 2) {
						txtMinor.Text = parts[1];
					}
					if (parts.Length >= 3) {
						txtBuild.Text = parts[2];
					}
					if (parts.Length >= 4) {
						txtRevision.Text = parts[3];
					}
				}
				catch {
					txtMajor.Text = "0";
					txtMinor.Text = "0";
					txtBuild.Text = "0";
					txtRevision.Text = "0";
				}
			}
			else {
				foreach (Control c in Controls)
					if (c is TextBox) c.Enabled = false;
			}
		}

		public string Value {
			get { return string.Format("{0}.{1}.{2}.{3}", new[] {txtMajor.Text, txtMinor.Text, txtBuild.Text, txtRevision.Text}); }
		}
	}
}