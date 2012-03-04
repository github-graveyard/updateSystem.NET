using App_Code.Responses;
using System;
using System.Data;
using App_Code.dataTypes;

namespace App_Code.Actions {
	internal sealed class getProjectsAction : baseAction {

		public getProjectsAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_get_update_log_projects"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			getProjectsResponse response = new getProjectsResponse {responseCode = responseCodes.Error};
			try {
				//Perform Basicauthetication etc.
				base.runAction(context);

				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);
				int spResult = executeProcedure();
				if (spResult == -1)
					throw new Exception("The Username provided does not exists.");

				foreach (var result in stpResult.Records)
					response.Projects.Add(new updateLogProject {
					                                           	projectId = (string) result["prj_identifier"],
					                                           	projectName = (string) result["prj_name"],
					                                           	isActive = (byte) result["prj_is_active"] == 1
					                                           });
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
