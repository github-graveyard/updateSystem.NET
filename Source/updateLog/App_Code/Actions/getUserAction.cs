using App_Code.Responses;
using System;
using System.Data;
using App_Code.dataTypes;

namespace App_Code.Actions {
	internal sealed class getUserAction : baseAction {
		public getUserAction() {
			requiresAuthentication = true;
			requiresAdministrator = false;
		}

		protected override string storedProcedureName {
			get { return "stp_get_update_log_user"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			getUserResponse response = new getUserResponse {responseCode = responseCodes.Error};
			try {
				base.runAction(context);
				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);

				executeProcedure();

				foreach (var recordSet in stpResult.Records) {
					response.Users.Add(new userAccount {
					                                   	Username = (string) recordSet["usr_name"],
					                                   	isAdmin = ((byte) recordSet["usr_is_admin"]) == 1,
					                                   	maxProjects = (int) recordSet["usr_max_projects"],
					                                   	isActive = ((byte) recordSet["usr_is_active"]) == 1
					                                   });
				}
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
