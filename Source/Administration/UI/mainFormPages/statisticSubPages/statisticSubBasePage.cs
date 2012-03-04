using System;
using System.Windows.Forms;
namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	internal class statisticSubBasePage : baseSubPage {

		protected void showServerError(Exception exception) {
			Session.showMessage(
				ParentForm,
				string.Format(
					"Die Serverabfrage konnte aufgrund des folgenden Problems nicht erfolgreich ausgeführt werden:\r\n{0}",
					exception.Message),
				"Während der Serverabfrage ist ein Problem aufgetreten",
				MessageBoxIcon.Error,
				MessageBoxButtons.OK
				);
		}

	}
}
