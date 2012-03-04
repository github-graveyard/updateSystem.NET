using App_Code.Responses;
using System;
using System.Globalization;
using System.Data;
using App_Code.dataTypes;

namespace App_Code.Actions {
	internal sealed class getLogAction : baseAction {
		public getLogAction() {
			requiresAuthentication = true;
		}
		protected override string storedProcedureName {
			get { return "stp_get_update_log"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			getLogResponse response = new getLogResponse {responseCode = responseCodes.Error};
			try {
				base.runAction(context);

				//Read parameters
				DateTime dateFrom;
				if (
					!DateTime.TryParse(context.Request["date_from"], CultureInfo.InvariantCulture, DateTimeStyles.None, out dateFrom))
					dateFrom = DateTime.MinValue;

				DateTime dateTo;
				if (!DateTime.TryParse(context.Request["date_to"], CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
					dateTo = DateTime.MinValue;

				int osMajorMin;
				if (!int.TryParse(context.Request["min_os_major"], out osMajorMin))
					osMajorMin = -1;

				int osMinorMin;
				if (!int.TryParse(context.Request["min_os_minor"], out osMinorMin))
					osMinorMin = -1;

				string projectId = context.Request["project_id"];
				string clientId = context.Request["client_id"];
				string clientVersion = context.Request["client_version"];

				//Throw an Exception if an required parameter is missing
				if (dateFrom == DateTime.MinValue ||
				    dateTo == DateTime.MinValue ||
				    string.IsNullOrEmpty(projectId))
					throw new Exception("Some required paramers are missing");

				//Add parameter to sql query
				addParameter("@date_from", SqlDbType.DateTime, dateFrom);
				addParameter("@date_to", SqlDbType.DateTime, dateTo);
				addParameter("@min_os_major", SqlDbType.Int, osMajorMin);
				addParameter("@min_os_minor", SqlDbType.Int, osMinorMin);
				addParameter("@project_identifier", SqlDbType.VarChar, projectId);
				addParameter("@client_identifier", SqlDbType.VarChar, clientId);
				addParameter("@client_version", SqlDbType.VarChar, clientVersion);

				//Execute query
				executeProcedure();

				//Write Data into response
				foreach(var recordSet in stpResult.Records) {
					response.logEntries.Add(new updateLogEntry {
					                                           	clientOSMajor = (int) recordSet["log_client_os_major"],
					                                           	clientOSMinor = (int) recordSet["log_client_os_minor"],
					                                           	clientId = (string) recordSet["log_client_identifier"],
					                                           	clientVersion = (string) recordSet["log_client_version"],
					                                           	timeStamp = (DateTime) recordSet["log_timestamp"],
					                                           	requestType = (byte) recordSet["log_request_type"]
					                                           });
				}

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
