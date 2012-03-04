using App_Code.Responses;
using System;
using System.Data;
namespace App_Code.Actions {
	internal sealed class addProjectAction : baseAction {
		public addProjectAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_add_update_log_project"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			defaultResponse response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				//Perform Basic-Auth
				base.runAction(context);

				string projectName = context.Request["project_name"];
				string projectId = context.Request["project_id"];
				byte isActive;
				if (!byte.TryParse(context.Request["is_active"], out isActive))
					isActive = 0;

				if (string.IsNullOrEmpty(projectName) || string.IsNullOrEmpty(projectId))
					throw new Exception("Not enough Parameter provided.");

				addParameter("@prj_name", SqlDbType.VarChar, projectName);
				addParameter("@prj_identifier", SqlDbType.VarChar, projectId);
				addParameter("@prj_is_active", SqlDbType.TinyInt, isActive);
				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);

				int result = executeProcedure();
				if (result == -1)
					throw new Exception("The User could not be found or the User is inactice.");
				if (result == -2)
					throw new Exception("The Projectlimit exceeded for this User. You have to delete one or more Projects in order to add a new one.");

				response.responseCode = responseCodes.OK;
			}
			catch (Exception exc) {
				response.responseCode = responseCodes.Error;
				response.responseMessage = exc.Message;
			}
			return response;
		}

	}
}
