using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;
using System.Drawing;

namespace updateSystemDotNet.Setup.UI.setupPages {
	[ToolboxItem(false)]
	internal partial class basePage : UserControl {
		public basePage() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		public event EventHandler<changePageEventArgs> changePage;

		[DllImport("shell32.dll")]
		protected static extern bool IsUserAnAdmin();

		protected void onChangePage(changePageEventArgs e) {
			if (changePage != null)
				changePage(this, e);
		}

		public virtual void onShow() {
		}

		public virtual void onHide() {
		}

		public virtual bool onValidate() {
			return true;
		}
	}
}