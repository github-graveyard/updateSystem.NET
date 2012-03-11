using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
	public class DownloadController : Controller
	{
		public ActionResult Index() {
			return View();
		}

		public ActionResult Detail(string id) {
			if (string.IsNullOrEmpty(id))
				return RedirectToAction("Index");

			return View();
		}

	}
}