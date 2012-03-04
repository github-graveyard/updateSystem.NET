<%@ WebHandler Language="C#" Class="sendFeedback" %>

using System;
using System.Web;
using System.Net.Mail;
using System.Configuration;

public class sendFeedback : IHttpHandler {
	
	public void ProcessRequest (HttpContext context) {

		try {
			if (context.Request.HttpMethod != "POST")
				throw new InvalidOperationException("Wrong HttpMethod");
			if (context.Request.Form.Count <= 0)
				throw new InvalidOperationException("No data arrived");

			string appName = context.Request["appName"];
			SmtpClient client = new SmtpClient();
			string subject = "Feedback";
			if (!string.IsNullOrEmpty(subject))
				subject = "Feedback vom " + appName + " erhalten";

			string body = "Eine neue Feedbacknachricht ist eingetroffen." + Environment.NewLine + Environment.NewLine;
			body += "IP Adresse: " + context.Request.UserHostAddress + "(" + context.Request.UserHostName + ")" + Environment.NewLine;
			foreach (string item in context.Request.Form.AllKeys) {
				body += item + ": " + context.Request.Form[item] + Environment.NewLine;
			}

			string from = ConfigurationManager.AppSettings["Feedback.From"];
			string to = ConfigurationManager.AppSettings["Feedback.To"];
			client.Send(from, to, subject, body);
			
			context.Response.ContentType = "text/plain";
			context.Response.Write("OK");
			
		}
		catch (Exception exc) {
			context.Response.ContentType = "text/plain";
			context.Response.Write("ERROR" + exc.ToString());
		}
		
	}
 
	public bool IsReusable {
		get {
			return false;
		}
	}

}