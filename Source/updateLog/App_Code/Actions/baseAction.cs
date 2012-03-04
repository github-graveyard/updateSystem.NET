using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using App_Code.Responses;
namespace App_Code.Actions {
	internal abstract class baseAction : IDisposable {

		//default-username: admin
		//default-pw: LetMeIn!
		//B8315ACA1E22E347EDAD38F4A25DF40C1AC06259D31F5DF0FB467136F16979F0989804ACC31889371ADD3D90B5B053417E48BA72485DBFB76AEE297012A4A733

		protected baseAction() {
			sqlParameters = new List<SqlParameter>();
			userIsAdministrator = false;
		}

		protected string connectionString {
			get { return ConfigurationManager.ConnectionStrings["update_log"].ConnectionString; }
		}

		protected bool userIsAdministrator { get; private set; }

		public virtual baseResponse runAction(HttpContext context) {

			//In Release Mode we don't support request via HTTP-Get
			if(context.Request.HttpMethod == "GET")
				throw new Exception("Sorry, GET is not allowed. Use POST instead.");

			//Authenticate, if Required
			if(requiresAuthentication) {
				loginAction login = new loginAction();
				loginResponse response = (loginResponse)login.runAction(context);

				if (response.responseCode == responseCodes.Error)
					throw new Exception(string.Format("Authentication failed [{0}]", response.responseMessage));

				if (requiresAdministrator && !response.userIsAdministrator)
					throw new Exception("An Administratoraccount is required in order to Perform this Action.");

				userIsAdministrator = response.userIsAdministrator;
			}

			return null;
		}

		/// <summary>Gets or Sets if the Action requires Authentication to perform.</summary>
		protected bool requiresAuthentication { get; set; }

		/// <summary>Gets or Sets if the User has to be Administrator in order to perform.</summary>
		protected bool requiresAdministrator { get; set; }

		/// <summary>Gets or Sets the Name of the Stored Procedure which performs the Action.</summary>
		protected virtual string storedProcedureName { get { return string.Empty; } }

		/// <summary>Gets or Sets a List of Parameters which should forwarded to the Stored Procedure</summary>
		protected List<SqlParameter> sqlParameters { get; set; }

		/// <summary>Adds a new Parameter</summary>
		protected void addParameter(string name, SqlDbType type, object value) {
			SqlParameter parameter = new SqlParameter(name, type) {Value = value};
			sqlParameters.Add(parameter);
		}

		/// <summary>Executes the StoredProcedure and Returns it's Result.</summary>
		protected int executeProcedure() {
			//Create a new Sql Connection
			using(SqlConnection connection = new SqlConnection(connectionString)) {
				//try to open it
				connection.Open();

				//Create a new Resultset
				stpResult = new stpResult();

				//Build the Command
				using (SqlCommand command = new SqlCommand(storedProcedureName, connection)) {

					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(sqlParameters.ToArray());

					SqlParameter returnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
											   {Direction = ParameterDirection.ReturnValue};
					command.Parameters.Add(returnValue);
					using(SqlDataReader reader = command.ExecuteReader()) {

						bool fieldsCreated = false;
						while (reader.Read()) {
							
							//First create the Fields which are required for accessing the Data via Columnnames
							if(!fieldsCreated) {
								for (int i = 0; i < reader.FieldCount;i++ )
									stpResult.Fields.Add(reader.GetName(i));	

								fieldsCreated = true;
							}

							var recordSet = new Dictionary<string, object>();
							for (int k = 0; k < reader.FieldCount; k++)
								recordSet.Add(stpResult.Fields[k], reader[k]);
							
							stpResult.Records.Add(recordSet);
						}

					}

					if (returnValue.Value == null)
						throw new Exception("Unknown Error during SP Execution");

					return (int) returnValue.Value;
				}
			}
		}

		protected stpResult stpResult { get; set; }

		protected string hashPassword(string password) {
			//I know this looks interesting, but DO NOT CHANGE ANY OF THIS VALUES!
			byte[] salt = new byte[] { 25, 06, 19, 88, 128, 33, 49, 24, 43 };
			byte[] bPassword = Encoding.UTF8.GetBytes(password);
			byte[] plaintext = new byte[bPassword.Length + salt.Length];
			bPassword.CopyTo(plaintext, 0);
			salt.CopyTo(plaintext, bPassword.Length);

			SHA512Managed sha512 = (SHA512Managed)SHA512.Create();
			byte[] hash = sha512.ComputeHash(plaintext);
			StringBuilder sbHash = new StringBuilder(512);
			foreach (byte b in hash)
				sbHash.Append(b.ToString("X2"));

			return sbHash.ToString();
		}


		#region IDisposable Member

		public void Dispose() {
			if (stpResult != null) {
				stpResult.Fields.Clear();
				stpResult.Records.Clear();
				stpResult = null;
			}
		}

		#endregion
	}
}