using App_Code.Responses;
using System;
using System.Globalization;
using System.Data;

namespace App_Code.Actions {
	internal sealed class cleanLogAction : baseAction {
		public cleanLogAction() {
			requiresAuthentication = true;
		}

		protected override string storedProcedureName {
			get { return "stp_cleanup_update_log"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			cleanLogResponse response = new cleanLogResponse {responseCode = responseCodes.Error};
			try {
				//Perform authentication
				base.runAction(context);

				string project_id = context.Request["project_identifier"];
				if (string.IsNullOrEmpty(project_id))
					throw new Exception("Missing Parameter: Project Id");

				string cleanupParam = context.Request["cleanup_date"];
				if (string.IsNullOrEmpty(cleanupParam))
					throw new Exception("Missing Parameter: cleanup_date");

				DateTime cleanupDate;
				if (!DateTime.TryParse(cleanupParam, CultureInfo.InvariantCulture, DateTimeStyles.None, out cleanupDate))
					throw new Exception("Invalid Date");

				addParameter("@usr_name", SqlDbType.VarChar, context.Request["username"]);
				addParameter("@project_identifier", SqlDbType.VarChar, project_id);
				addParameter("@cleanup_date", SqlDbType.DateTime, cleanupDate);

				int result = executeProcedure();
				if (result == 0) {
					response.responseCode = responseCodes.OK;
					response.removedEntries = int.Parse(stpResult.Records[0]["removed_entries"].ToString());
				}
			}
			catch (Exception exc) {
				response.responseCode = responseCodes.Error;
				response.responseMessage = exc.Message;
			}
			return response;
		}
	}
}