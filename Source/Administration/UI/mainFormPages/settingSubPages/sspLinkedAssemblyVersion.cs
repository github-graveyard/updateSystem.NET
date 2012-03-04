using System.Windows.Forms;
namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspLinkedAssemblyVersion : settingSubBasePage {
		public sspLinkedAssemblyVersion() {
			InitializeComponent();
		}

		public override void initializeData() {
			if (Session.currentProject.linkAssemblyToVersion)
				rbLinked.Checked = true;
			else
				rbNotLinked.Checked = true;
			
			txtLinkedAssemblyPath.Text = Session.currentProject.linkedAssemblyPath;
		}

		private void rbLinked_CheckedChanged(object sender, System.EventArgs e) {
			pnlLinkedAssembly.Enabled = rbLinked.Checked;
			Session.currentProject.linkAssemblyToVersion = rbLinked.Checked;
		}

		private void btnBrowseAssembly_Click(object sender, System.EventArgs e) {
			using(var dialog = new OpenFileDialog()) {
				dialog.Filter = ".NET Assemblies|*.dll;*.exe";
				if (dialog.ShowDialog(ParentForm) != DialogResult.OK) return;
				
				txtLinkedAssemblyPath.Text = dialog.FileName;
				Session.currentProject.linkedAssemblyPath = dialog.FileName;
			}
		}
	}
}
