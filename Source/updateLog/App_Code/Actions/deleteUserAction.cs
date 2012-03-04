using App_Code.Responses;
using System;
using System.Data;
namespace App_Code.Actions {
	internal sealed class deleteUserAction : baseAction {

		public deleteUserAction() {
			requiresAuthentication = true;
			requiresAdministrator = true;
		}

		protected override string storedProcedureName {
			get { return "stp_delete_update_log_user"; }
		}

		public override baseResponse runAction(System.Web.HttpContext context) {
			var response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				base.runAction(context);

				string obsoleteUsername = context.Request["obsolete_username"];
				if(string.IsNullOrEmpty(obsoleteUsername))
					throw new Exception("obsolete_username is a required Parameter.");

				if(obsoleteUsername.ToLower() == context.Request["username"].ToLower())
					throw new Exception("Whoops, you cannot delete yourself. It's like to bite the Hand that feeds you.");

				addParameter("@usr_name", SqlDbType.VarChar, obsoleteUsername);
				int result = executeProcedure();
				if (result != 0)
					throw new Exception(string.Format("Deletion failed! You cannot delete Rootuser and it seems {0} is one. Sorry.",
					                                  obsoleteUsername));

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
