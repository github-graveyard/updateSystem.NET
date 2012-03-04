using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class ErrorPages_FatalError : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Exception exc = (Session["error"] as Exception);
		if (exc == null)
			return;
		lblMessage.Text = exc.Message;
		lblStackTrace.Text = getExceptionString(exc);
		Server.ClearError();
	}

	private string getExceptionString(Exception ex) {
		StringBuilder ExBuilder = new StringBuilder();
		for (Exception tex = ex; tex != null; tex = tex.InnerException) {
			ExBuilder.AppendLine(tex.ToString());
			ExBuilder.AppendLine();
		}
		return ExBuilder.ToString();
	}

}