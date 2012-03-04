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
