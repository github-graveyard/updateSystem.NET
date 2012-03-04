<%@ WebHandler Language="C#" Class="GetFile" %>

using System.Web;
using System.IO;

public class GetFile : IHttpHandler {
	
	public void ProcessRequest (HttpContext context) {
		string ServerPath = Path.Combine(context.Server.MapPath("~"), "App_Data");

		//Downloadhandler abbrechen wenn:
		string id = context.Request["id"];
		if (string.IsNullOrEmpty(id) || //Keine ID übergeben wurde
			!File.Exists(Path.Combine(ServerPath, id)) || //Die Datei nicht existiert
			MasterDefinition.blockedFiles.Contains(id.ToLower()) //Die Datei nicht heruntergeladen werden darf
			) {
			context.Response.Redirect("/ErrorPages/Http404.aspx");
			return;
		}

		//Counter erhöhen
		new downloadCounter(ServerPath).increaseDownloadCounter(id);
		
		context.Response.ContentType = "application/octet-stream";

		context.Response.AddHeader("content-disposition", "attachment; filename=\"" + id + "\"");
		
		using (FileStream fsDownload = File.OpenRead(Path.Combine(ServerPath, id))) {
			byte[] fileData = new byte[fsDownload.Length];
			fsDownload.Read(fileData, 0, (int)fsDownload.Length);
			context.Response.OutputStream.Write(fileData, 0, fileData.Length);
		}
	}
 
	public bool IsReusable {
		get {
			return false;
		}
	}

}