using System;
using App_Code.Responses;
using System.Data;

namespace App_Code.Actions {
	internal class loginAction : baseAction {
		
		public override baseResponse runAction(System.Web.HttpContext context) {
			loginResponse response = new loginResponse();
			try {
				base.runAction(context);

				string username = context.Request["username"];
				string password = context.Request["password"];
				if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
					throw new Exception("No Username and/or Password supplied.");

				addParameter("@usr_name", SqlDbType.VarChar, username);
				addParameter("@usr_password", SqlDbType.VarChar, hashPassword(password));

				int spResult = executeProcedure();

				if (spResult == -2)
					throw new Exception("The provided Useraccount is not active.");
				if (spResult == -1)
					throw new Exception("Username and/or Password are incorrect.");

				response.responseCode = (spResult >= 0 ? responseCodes.OK : responseCodes.Error);
				response.userIsAdministrator = (spResult == 1);

			}
			catch(Exception exc) {
				response.responseCode = responseCodes.Error;
				response.responseMessage = exc.Message;
			}
			return response;
		}

		protected override string storedProcedureName {
			get { return "stp_check_update_log_user"; }
		}
	}
}
