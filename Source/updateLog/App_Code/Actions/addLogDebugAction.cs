using System;
using System.Data;
using App_Code.Responses;
using System.Globalization;

namespace App_Code.Actions {
	internal sealed class addLogDebugAction : baseAction {
		public addLogDebugAction() {
			requiresAuthentication = true;
			requiresAdministrator = true;
		}

		protected override string storedProcedureName {
			get { return "stp_add_update_log_debug"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			unsignedResponse response = new unsignedResponse();
			try {
				base.runAction(context);

				//Lets read and validate all required parameter
				int client_os_major;
				if (!int.TryParse(context.Request["client_os_major"], out client_os_major))
					client_os_major = -1;

				int client_os_minor;
				if (!int.TryParse(context.Request["client_os_minor"], out client_os_minor))
					client_os_minor = -1;

				string client_identifier = context.Request["client_identifier"];
				string project_identifier = context.Request["project_identifier"];
				string client_version = context.Request["client_version"];

				byte request_type;
				if (!byte.TryParse(context.Request["request_type"], out request_type))
					request_type = 2;

				DateTime dtTimeStamp;
				if (!DateTime.TryParse(context.Request["timestamp"], CultureInfo.InvariantCulture, DateTimeStyles.None, out dtTimeStamp))
					dtTimeStamp = DateTime.MinValue;

				if (client_os_major == -1 ||
					client_os_minor == -1 ||
					string.IsNullOrEmpty(project_identifier) ||
					string.IsNullOrEmpty(client_version) ||
					request_type == 2 ||
					dtTimeStamp == DateTime.MinValue)
					throw new Exception("Some missing or invalid Parameters provided.");

				//Add SQL Parameter
				addParameter("@client_os_major", SqlDbType.Int, client_os_major);
				addParameter("@client_os_minor", SqlDbType.Int, client_os_minor);
				addParameter("@client_identifier", SqlDbType.VarChar, client_identifier);
				addParameter("@project_identifier", SqlDbType.VarChar, project_identifier);
				addParameter("@client_version", SqlDbType.VarChar, client_version);
				addParameter("@request_type", SqlDbType.TinyInt, request_type);
				addParameter("@timestamp", SqlDbType.DateTime, dtTimeStamp);

				if (executeProcedure() == 0)
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
