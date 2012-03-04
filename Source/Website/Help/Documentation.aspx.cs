using System;
using System.IO;

public partial class Help_Documentation : System.Web.UI.Page {
	private downloadCounter _download;
	protected void Page_Load(object sender, EventArgs e) {
			// ReSharper disable SuggestUseVarKeywordEvident
			_download = new downloadCounter(Path.Combine(Server.MapPath("~"), "App_Data"));
			// ReSharper restore SuggestUseVarKeywordEvident
			lnkDownload.Text = string.Format("Herunterladen ({0} Downloads)",
											 _download.getDownloadCounter(MasterDefinition.Documentation));
	}
	protected void lnkDownload_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.Documentation));
	}
}
