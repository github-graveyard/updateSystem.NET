#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.Core.updateLog.Requests;
using updateSystemDotNet.Administration.Core.updateLog.Responses;
using System.Collections.Generic;

namespace updateSystemDotNet.Administration.Core.updateLog {
	internal sealed class updateLogFactory {
		private readonly applicationSession _session;

		public updateLogFactory(applicationSession session) {
			_session = session;
		}

		/// <summary>Erstellt einen neuen WebRequest</summary>
		public T createRequest<T>() where T : baseRequest {
			baseRequest instance = Activator.CreateInstance<T>();
			instance.Session = _session;

			if (_session.currentProject.updateLogUser.Verified)
				instance.serverUrl = _session.currentProject.updateLogUser.serverUrl;

			return (T)instance;
		}

		#region Log

		public List<updateLogEntry> getLog(DateTime from, DateTime to, int osMajorMin, int osMinorMin, string projectId, string clientId, string clientVersion) {
			getLogRequest request = createRequest<getLogRequest>();

			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.dateFrom = from;
			request.dateTo = to;
			request.osMajorMin = osMajorMin;
			request.osMinorMin = osMinorMin;
			request.projectId = projectId;
			request.clientId = clientId;
			request.clientVersion = clientVersion;

			var response = request.Execute<getLogResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

			return response.logEntries;
		}

		public cleanupLogResponse cleanupLog(string projectId, DateTime cleanupDate) {
			var request = createRequest<cleanupLogRequest>();

			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.projectId = projectId;
			request.cleanupDate = cleanupDate;

			var response = request.Execute<cleanupLogResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

			return response;
		}

		#endregion

		#region Benutzer

		/// <summary>Gibt alle Benutzer zurück oder nur den eigenen. Dies is davon abhängig ob der derzeit angemeldete Benutzer ein Administrator ist.</summary>
		public List<userAccount> getUsers() {
			if(!_session.currentProject.updateLogUser.Verified)	
				throw new Exception("Der aktuelle Statistikbenutzer wurde nicht verifiziert bzw. es wurde kein Benutzer zugewiesen.");

			var request = createRequest<getUserRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			var response = request.Execute<getUserResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

			return response.Users;
		}

		/// <summary>Überprüft einen Benutzeraccount.</summary>
		public userAccount Login(string serverUrl, string username, string password) {

			var loginRequest = createRequest<loginRequest>();
			serverUrl = checkServerUrl(serverUrl);
			loginRequest.serverUrl = serverUrl;
			loginRequest.Username = username;
			loginRequest.Password = password;

			var loginResult = loginRequest.Execute<loginResponse>();
			if (loginResult.responseCode != responseCodes.OK)
				throw new updateLogException(loginResult.responseMessage, loginResult);

			return new userAccount {
			                         	serverUrl = serverUrl,
			                         	Password = password,
			                         	Username = username,
			                         	userIsAdmin = loginResult.userIsAdministrator,
										Verified = true
			                         };
		}

		/// <summary>Legt einen neuen Benutzer auf dem Server an.</summary>
		public void addUser(string username, string password, int maxProjects, bool isAdmin) {

			var request = createRequest<addUserRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.newUsername = username;
			request.newPassword = password;
			request.maxProjects = maxProjects;
			request.isAdmin = isAdmin;

			var result = request.Execute<defaultResponse>();
			if (result.responseCode != responseCodes.OK)
				throw new updateLogException(result.responseMessage, result);

		}
		/// <summary>Bearbeitet einen Benutzer auf dem Server</summary>
		public void editUser(string oldUsername, string username, string password, int maxProjects, bool isAdmin, bool isActive) {
			var request = createRequest<editUserRequest>();
			
			//Authentifizierung
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.oldUsername = oldUsername;
			request.editUsername = username;
			request.editPassword = password;
			request.maxProjects = maxProjects;
			request.isAdmin = isAdmin;
			request.isActive = isActive;

			var result = request.Execute<defaultResponse>();
			if (result.responseCode != responseCodes.OK)
				throw new updateLogException(result.responseMessage, result);

		}

		public void deleteUser(string username) {

			var request = createRequest<deleteUserRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;
			request.obsoleteUsername = username;

			var result = request.Execute<defaultResponse>();
			if(result.responseCode != responseCodes.OK)
				throw new updateLogException(result.responseMessage, result);

		}

		#endregion

		#region Projekte

		public void addProject(string projectId, string projectName, bool isActive) {

			var request = createRequest<addProjectRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.projectId = projectId;
			request.projectName = projectName;
			request.isActive = isActive;

			var response = request.Execute<defaultResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

		}

		/// <summary>Liefert alle Updateprojekte zurück, die dem aktuell angemeldeten Benutzer gehören.</summary>
		public List<updateLogProject> getProjects() {

			var request = createRequest<getProjectsRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			var response = request.Execute<getProjectsResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

			return response.Projects;
		}

		/// <summary>Versucht ein Projekt mit einer bestimmten ID vom Server zu holen, wenn dieses dort nicht gefunden wurde, wird null zurückgeliefert.</summary>
		public updateLogProject getProject(string projectId) {
			var request = createRequest<getProjectRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.projectId = projectId;

			var response = request.Execute<getProjectResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);

			return response.Project;
		}

		public void deleteProject(string projectId) {
			var request = createRequest<deleteProjectRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.projectId = projectId;

			var response = request.Execute<defaultResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);
		}

		public void editProject(string projectId, string projectName, bool isActive) {
			var request = createRequest<editProjectRequest>();
			request.Username = _session.currentProject.updateLogUser.Username;
			request.Password = _session.currentProject.updateLogUser.Password;

			request.projectId = projectId;
			request.projectName = projectName;
			request.isActive = isActive;

			var response = request.Execute<defaultResponse>();
			if (response.responseCode != responseCodes.OK)
				throw new updateLogException(response.responseMessage, response);
		}

		#endregion

		private string checkServerUrl(string url) {
			if(!url.ToLower().EndsWith(_session.Settings.statisticRequestDocument.ToLower())) {
				if (!url.EndsWith("/"))
					url = url + "/";
				url = url + _session.Settings.statisticRequestDocument;
			}
			return url;
		}

	}
}