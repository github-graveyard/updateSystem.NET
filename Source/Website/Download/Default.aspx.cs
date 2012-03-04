using System;
using System.IO;

public partial class Download_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		lblDownloadCount.Text = new downloadCounter(Path.Combine(Server.MapPath("~"), "App_Data")).getDownloadCounter(MasterDefinition.setupFileName);
		initializeDownloadData();
	}
	protected void btnDownload_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.setupFileName));
	}

	private void initializeDownloadData() {
		
		string setupFile = Path.Combine(Path.Combine(Server.MapPath("~"), "App_Data"), MasterDefinition.setupFileName);
		lblFilename.Text = MasterDefinition.setupFileName;
		if (File.Exists(setupFile)) {
			Version appVersion = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(setupFile).ProductVersion);
			FileInfo fInfo = new FileInfo(setupFile);

			lblVersion.Text = string.Format("{0} vom {1}", new string[]{
						 appVersion.ToString(), //Komplette Version
						 fInfo.LastWriteTime.ToString(new System.Globalization.CultureInfo("de-DE"))
						});
			lblFileSize.Text = CreateNiceFileSize(fInfo.Length);
		}
		else
			btnDownload.Enabled = false;
	}

	string CreateNiceFileSize(long size) {
		int run = 0;
		double d = Convert.ToDouble(size);
		string[] sizes = { "B", "KB", "MB", "GB" };
		while (d >= 1024) {
			d /= 1024;
			run++;
		}

		double dou = Math.Round(d, 2);
		string sizestring = dou.ToString();

		return (sizestring + " " + sizes[run]);
	}


	protected void btnDownloadStable_Click(object sender, EventArgs e) {
		Response.Redirect(string.Format("/Download/GetFile.ashx?id={0}", MasterDefinition.oldSetupFileName));
	}
}