using App_Code.Responses;
using System;
using System.Data;
namespace App_Code.Actions {
	internal sealed class editProjectAction : baseAction {
		public editProjectAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_edit_update_log_project"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			defaultResponse response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				base.runAction(context);

				string projectId = context.Request["project_id"];
				if (string.IsNullOrEmpty(projectId))
					throw new Exception("project_id is not specified.");
				addParameter("@prj_identifier", SqlDbType.VarChar, projectId);

				string projectName = context.Request["project_name"];
				if(string.IsNullOrEmpty(projectName))
					throw new Exception("project_name is not specified");
				addParameter("@prj_name", SqlDbType.VarChar, projectName);

				byte isActive;
				if (!byte.TryParse(context.Request["is_active"], out isActive))
					isActive = 0;
				addParameter("@prj_is_active", SqlDbType.TinyInt, isActive);
				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);

				executeProcedure();

				response.responseCode = responseCodes.OK;
			}
			catch(Exception exc) {
				response.responseCode = responseCodes.Error;
				response.responseMessage = exc.ToString();
			}
			return response;
		}

	}
}
