using System.Windows.Forms;
using updateSystemDotNet.Core.Types;
using System.Drawing;

namespace updateSystemDotNet.Internal.UI {
	internal partial class releaseFilterControl : UserControl {
		public releaseFilterControl(releaseFilterType value) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;

			chkFinal.Checked = value.checkForFinal;
			chkBeta.Checked = value.checkForBeta;
			chkAlpha.Checked = value.checkForAlpha;
		}

		public releaseFilterType Value {
			get {
				return new releaseFilterType {
				                             	checkForFinal = chkFinal.Checked,
				                             	checkForBeta = chkBeta.Checked,
				                             	checkForAlpha = chkAlpha.Checked
				                             };
			}
		}
	}
}