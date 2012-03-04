using System;
using System.IO;

public partial class Help_sampleProjects : System.Web.UI.Page {
	private downloadCounter _download;

	protected void Page_Load(object sender, EventArgs e) {
		_download = new downloadCounter(Path.Combine(Server.MapPath("~"), "App_Data"));
		lnkDownloadCSharp.Text = string.Format("Herunterladen ({0} Downloads)",
		                                       _download.getDownloadCounter(MasterDefinition.samplesCSharp));
		lnkDownloadVB.Text = string.Format("Herunterladen ({0} Downloads)",
		                                   _download.getDownloadCounter(MasterDefinition.samplesVB));
	}
	protected void lnkDownloadCSharp_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.samplesCSharp));		
	}
	protected void lnkDownloadVB_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.samplesVB));
	}
}
