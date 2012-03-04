using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Layout_web : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		lblCopyrightNow.Text = DateTime.Now.Year.ToString();
		Page.Title = Page.Title.Replace("{appname}", MasterDefinition.pageName);

		//Wenn so eingestellt, alle HTTP anfragen nach HTTPS umleiten
		if (Request.Url.Scheme == "http" && bool.Parse(ConfigurationManager.AppSettings["sslOnly"]) ) {
			Response.Redirect(Request.Url.ToString().Replace("http", "https"));
			return;
		}

		//Web befindet sich im Wartungsmodus, Fehlerseite anzeigen.
		if (bool.Parse(ConfigurationManager.AppSettings["maintenanceMode"])) {
			Response.Redirect("/ErrorPages/Maintenance.aspx");
		}

		//Globale Benachrichtung anzeigen?
		if (MasterDefinition.showGlobalNotification) {
			globalNotificationOuter.Visible = true;
			lblGlobalNotification.Text = MasterDefinition.globalNotificationText;
		}

	}

	protected override void OnError(EventArgs e) {
		Session.Add("error", Server.GetLastError());
	}

}
