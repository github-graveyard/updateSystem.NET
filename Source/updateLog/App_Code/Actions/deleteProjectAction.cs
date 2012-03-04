using App_Code.Responses;
using System;
using System.Data;
namespace App_Code.Actions {
	internal sealed class deleteProjectAction : baseAction {

		public deleteProjectAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_delete_update_log_project"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			defaultResponse response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				//Perform Authentication
				base.runAction(context);

				string projectId = context.Request["project_id"];
				if (string.IsNullOrEmpty(projectId))
					throw new ArgumentException("No Project-ID provided!");
				addParameter("@prj_identifier", SqlDbType.VarChar, projectId);
				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);

				int result = executeProcedure();
				if(result == -1)
					throw new Exception("The User has no permission to delete this Project");

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
