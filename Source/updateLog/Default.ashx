<%@ WebHandler Language="C#" Class="Default" %>

using System.Web;
using App_Code;

public class Default : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        using(requestHandler handler = new requestHandler(context)) {
        	handler.executeHandler();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}