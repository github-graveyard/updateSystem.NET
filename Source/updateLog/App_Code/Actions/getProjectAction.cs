using App_Code.Responses;
using System;
using System.Data;
using App_Code.dataTypes;

namespace App_Code.Actions {
	internal sealed class getProjectAction : baseAction {
		public getProjectAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_get_update_log_project"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			getProjectResponse response = new getProjectResponse {responseCode = responseCodes.Error};
			try {
				base.runAction(context);

				string projectIdentifier = context.Request["project_id"];
				if (string.IsNullOrEmpty(projectIdentifier))
					throw new Exception("No Project-Id specified");

				addParameter("@usr_name",SqlDbType.VarChar,context.Request["username"]);
				addParameter("@prj_identifier", SqlDbType.VarChar, projectIdentifier);
				executeProcedure();

				if (stpResult.Records.Count > 0) {
					response.Project = new updateLogProject {
					                                        	projectId = projectIdentifier,
					                                        	projectName = (string) stpResult.Records[0]["prj_name"],
					                                        	isActive = ((byte) stpResult.Records[0]["prj_is_active"] == 1)
					                                        };
				}

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