using App_Code.Responses;
using System;
using System.Data;

namespace App_Code.Actions {
	internal sealed class editUserAction : baseAction {
		
		public editUserAction() {
			requiresAuthentication = true;
		}
		
		protected override string storedProcedureName {
			get { return "stp_edit_update_log_user"; }
		}
        
		public override baseResponse runAction(System.Web.HttpContext context) {
			defaultResponse response = new defaultResponse {responseCode = responseCodes.Error};
			try {
				//Perform base Actions like Authentication
				base.runAction(context);

				//Add and validate old Username-Parameter
				string oldUsername = context.Request["old_username"];
				if(string.IsNullOrEmpty(oldUsername))
					throw new Exception("old_username not specified.");
				addParameter("@old_usr_name", SqlDbType.VarChar, oldUsername);

				//Add and validate new Username-Parameter
				string editUsername = context.Request["edit_username"];
				if(string.IsNullOrEmpty(editUsername))
					throw new Exception("You have to specify a Username which you want to edit.");
				addParameter("@usr_name", SqlDbType.VarChar,editUsername);

				//Add Password-Parameter if not empty
				string editPassword = context.Request["edit_password"];
				if (!string.IsNullOrEmpty(editPassword))
					addParameter("@usr_password", SqlDbType.VarChar, hashPassword(editPassword));
				
				int maxProjects;
				if (!int.TryParse(context.Request["max_projects"], out maxProjects) || !userIsAdministrator)
					maxProjects = -1;
				addParameter("@usr_max_projects", SqlDbType.Int, maxProjects);

				byte isAdmin;
				if (!byte.TryParse(context.Request["is_admin"], out isAdmin) || !userIsAdministrator)
					isAdmin = 2;
				addParameter("@usr_is_admin", SqlDbType.TinyInt, isAdmin);

				byte isActive;
				if (!byte.TryParse(context.Request["is_active"], out isActive) || !userIsAdministrator)
					isActive = 2;
				addParameter("@usr_is_active", SqlDbType.TinyInt, isActive);

				//Check if the Current User is allowed to change the userdetails
				string currentUsername = context.Request["username"];
				if (currentUsername != editUsername && !userIsAdministrator)
					throw new Exception(string.Format("The User {0} is not authorized to edit User {1}", currentUsername, editUsername));

				int result = executeProcedure();
				if (result == -1)
					throw new Exception(string.Format("The Username {0} could not be found", editUsername));
				if (result == -2)
					throw new Exception(string.Format("The Username {0} is already in use.", editUsername));

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