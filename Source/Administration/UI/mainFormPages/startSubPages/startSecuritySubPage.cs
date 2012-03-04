using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.mainFormPages.startSubPages {
	internal sealed partial class startSecuritySubPage : baseSubPage {
		public startSecuritySubPage() {
			InitializeComponent();
			pageSymbol = resourceHelper.getImage("security.png");
			Id = "c74f5aaf-6a5f-4b17-baef-f08911d7fea7";
			Title = "Sicherheit";
			pageName = Title;
		}
	}
}
