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
using updateSystemDotNet.Administration.UI.mainFormPages.startSubPages;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal partial class startPage : basePage {
		public startPage() {
			InitializeComponent();
			pageSymbol = Core.resourceHelper.getImage("home.png");
			Id = Guid.NewGuid().ToString();
			displayOrder = 100;
		}

		public override void initializeData() {
			txtProjectName.Text = Session.currentProject.projectName;
			txtProjectId.Text = Session.currentProject.projectId;
		}

		public override void initializeSubPages() {
			//Alte Unterseiten löschen
			subPages.Clear();
			Node.Nodes.Clear();
			
		   //Neue Unterseiten hinzufügen
			var integrationSubPage = createSubPage<startVSIntegrationSubPage>(null);
			var securitySubPage = createSubPage<startSecuritySubPage>(null);

			subPages.AddRange(new baseSubPage[] {integrationSubPage});
			Node.Nodes.AddRange(new[] {integrationSubPage.Node});

			if (Session.isDevEnvironment) {
				subPages.Add(securitySubPage);
				Node.Nodes.Add(securitySubPage.Node);
			}
		}

		private void txtProjectName_TextChanged(object sender, EventArgs e) {
			Session.currentProject.projectName = !string.IsNullOrEmpty(txtProjectName.Text)
													? txtProjectName.Text
													: "Neues Updateprojekt";
			Session.onProjectTitleChanged(EventArgs.Empty);
		}

	}
}
