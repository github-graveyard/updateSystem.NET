using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Next_Default : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {
		Response.Redirect(Server.MapPath("~"));
		return;
		lblDownloads.Text = new downloadCounter(Path.Combine(Server.MapPath("~"), "App_Data")).getDownloadCounter(MasterDefinition.previewFilename);
	}
	protected void btnDownloadPreview_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.previewFilename));
	}
}
