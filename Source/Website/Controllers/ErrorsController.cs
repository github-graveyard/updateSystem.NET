using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index() {
        	return RedirectToAction("Index", "Home");
        }
    	public ActionResult Http404() {
    		return View();
    	}
    }
}
