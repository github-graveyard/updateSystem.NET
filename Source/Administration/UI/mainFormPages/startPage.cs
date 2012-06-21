/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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
