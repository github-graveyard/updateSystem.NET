using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Website.Data;
using Website.Models;
using System.IO;

namespace Website.Controllers
{
	public class DownloadController : Controller {
		private WebModelDataContext _dataContext;

		public ActionResult Index() {
			return View();
		}

		public ActionResult Detail(string id) {
			var model = (from download in dataContext.Downloads
			             where download.Alias == id
			             select new DownloadModel {
			                                      	Filename = download.Filename,
			                                      	Hits = download.Hits,
			                                      	Id = download.Id,
			                                      	friendlyName = download.friendlyName,
			                                      	Description = download.Description,
			                                      	completePath = Path.Combine(Server.MapPath(downloadDirectory), download.Filename)
			                                      }).FirstOrDefault();

			//Check if the requestet File exists
			if (model != null) {
				if (!System.IO.File.Exists(model.completePath))
					throw new HttpException(404, string.Format("Could not find {0} on the Server.", model.Filename));

				return View(model);
			}
			return RedirectToAction("Index");
		}

		#region DataAccess

		private string connectionString {
			get { return ConfigurationManager.ConnectionStrings["Web"].ConnectionString; }
		}
		private string downloadDirectory{get { return ConfigurationManager.AppSettings["DownloadDirectory"]; }}

		private WebModelDataContext dataContext {
			get { return _dataContext ?? (_dataContext = new WebModelDataContext(connectionString)); }
		}

		#endregion

	}
}