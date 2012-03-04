using App_Code.Responses;
using System.Web;
using System;
using System.Data;
namespace App_Code.Actions {
	internal class addUserAction : baseAction {

		public addUserAction() {
			requiresAuthentication = true;
			requiresAdministrator = true;
		}

		protected override string storedProcedureName {
			get { return "stp_add_update_log_user"; }
		}

		public override baseResponse runAction(HttpContext context) {

			defaultResponse response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				//Perform base Actions like Authentication
				base.runAction(context);

				string newUsername = context.Request["new_username"];
				string newPassword = context.Request["new_password"];
				int maxProjects =
					int.Parse(string.IsNullOrEmpty(context.Request["max_projects"]) ? "0" : context.Request["max_projects"]);
				byte isAdmin =
					byte.Parse(string.IsNullOrEmpty(context.Request["is_admin"]) ? "0" : context.Request["is_admin"]);

				if(string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
					throw new Exception();

				addParameter("@usr_name", SqlDbType.VarChar, newUsername);
				addParameter("@usr_password", SqlDbType.VarChar, hashPassword(newPassword));
				addParameter("@usr_max_projects",SqlDbType.Int, maxProjects);
				addParameter("@usr_is_admin", SqlDbType.TinyInt, isAdmin);

				int spResult = executeProcedure();
				if(spResult == -1)
					throw new Exception("This Username is already taken.");

				if (spResult == 0)
					response.responseCode = responseCodes.OK;
			}
			catch(Exception exc) {
				response.responseCode = responseCodes.Error;
				response.responseMessage = exc.Message;
			}
			return response;
		}
	}
}