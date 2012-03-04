using System.Web;
using System;
using App_Code.Actions;
using App_Code.Responses;

namespace App_Code {

	public class requestHandler : IDisposable {
		private HttpContext _context;

		public requestHandler(HttpContext context) {
			_context = context;
		}

		public void executeHandler() {

			if(!isRequestAuthorized()) {
				_context.Response.StatusCode = 403;
				return;
			}

			string action = _context.Request["action"];
			baseAction actionHandler = null;
			switch (action) {

					// Usermanagement
				case "login":
					actionHandler = new loginAction();
					break;
				case "addUser":
					actionHandler = new addUserAction();
					break;
				case "getUser":
					actionHandler = new getUserAction();
					break;
				case "editUser":
					actionHandler = new editUserAction();
					break;
				case "deleteUser":
					actionHandler = new deleteUserAction();
					break;

				//Projectmanagement
				case "getProjects":
					actionHandler = new getProjectsAction();
					break;
				case "getProject":
					actionHandler = new getProjectAction();
					break;
				case "addProject":
					actionHandler = new addProjectAction();
					break;
				case "deleteProject":
					actionHandler = new deleteProjectAction();
					break;
				case "editProject":
					actionHandler = new editProjectAction();
					break;

				//updateLog
				case "addLog":
					actionHandler = new addLogAction();
					break;
				case "addLogDebug":
					actionHandler = new addLogDebugAction();
					break;
				case "getLog":
					actionHandler = new getLogAction();
					break;
				case "cleanupLog":
					actionHandler = new cleanLogAction();
					break;
			}

			baseResponse response = actionHandler != null
			                        	? actionHandler.runAction(_context)
			                        	: new defaultResponse
			                        	  {responseCode = responseCodes.Error, responseMessage = "Invalid Action"};

			response.sendResponse(_context.Response);
			response.Dispose();
			if (actionHandler != null)
				actionHandler.Dispose();
			GC.Collect();
		}

		private bool isRequestAuthorized() {
			return (_context.Request.Headers["authKey"] == "987a8948-df08-4cae-b031-2d2e22a1c8e7");
		}

		public void Dispose() {
			_context = null;
		}
	}
}