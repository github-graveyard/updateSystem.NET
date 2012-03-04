using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using updateSystemDotNet.Core.Types;
using System;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal sealed partial class upgradeProjectDialog : dialogBase {

		#region Projectfiles

		private interface IProjectFile {
			void Open(string filename);
			string privateKey { get; set; }
			string publicKey { get; set; }
		}

		private class udprojxFile : IProjectFile {

			#region IProjectFile Members

			public void Open(string filename) {

				//Set Projectkey
				byte[] _projEntropy = new byte[] {
				                                 	3, 2, 55, 2, 4, 11, 4, 87, 1, 24, 61,
				                                 	1
				                                 };

				//Load Projectdata
				var aes = new Core.aesEncryption();
				byte[] encodedProjectData = File.ReadAllBytes(filename);
				byte[] decodedProjectData = aes.decodeData(encodedProjectData, _projEntropy);
				XmlDocument projectDocument = null;
				using (var msProjectData = new MemoryStream(decodedProjectData)) {
					using (var reader = new StreamReader(msProjectData, Encoding.UTF8)) {
						projectDocument = new XmlDocument();
						projectDocument.Load(reader);
					}
				}

				//Load Private and Public Key
				XmlNode nodePublicKey = projectDocument.SelectSingleNode("updateProject/publicKey");
				XmlNode nodePrivateKey = projectDocument.SelectSingleNode("updateProject/privateKey");

				if (nodePublicKey != null)
					publicKey = nodePublicKey.InnerText;
				if (nodePrivateKey != null)
					privateKey = nodePrivateKey.InnerText;

			}

			public string privateKey { get; set; }

			public string publicKey { get; set; }

			#endregion

		}

		private class udprojFile : IProjectFile {

			public void Open(string filename) {
				XmlDocument projDocument = null;
				using (var reader = new StreamReader(filename, Encoding.UTF8)) {
					projDocument = new XmlDocument();
					projDocument.Load(reader);
				}

				XmlNode nodePublicKey = projDocument.SelectSingleNode("Project/publickey");
				XmlNode nodePrivateKey = projDocument.SelectSingleNode("Project/privatekey");

				if (nodePublicKey != null)
					publicKey = nodePublicKey.InnerText;
				if (nodePrivateKey != null)
					privateKey = nodePrivateKey.InnerText;
			}

			public string privateKey { get; set; }

			public string publicKey { get; set; }

		}

		#endregion

		#region Conversion

		private IProjectFile loadProject(string filename) {

			IProjectFile projectFile = null;
			if (filename.EndsWith(".udprojx"))
				projectFile = new udprojxFile();

			if(filename.EndsWith(".udproj"))
				projectFile = new udprojFile();

			if (projectFile != null)
				projectFile.Open(filename);

			return projectFile;
		}

		private updateConfiguration downloadConfiguration(string updateUrl) {

			string completeUrl = updateUrl;

			//Fix missing Url parts
			if (!completeUrl.EndsWith("/"))
				completeUrl = completeUrl + "/";
			completeUrl = completeUrl + "update.xml";

			//Download Configuration
			var client = Session.createWebClient();
			byte[] configurationData = client.DownloadData(completeUrl);

			var container = new SecureContainer();
			container.Load(configurationData);

			//Deserialize and Load Configuration
			return updateSystemDotNet.Core.Serializer.Deserialize(container.Content);
		}

		private void downloadUpdatePackages(updateConfiguration configuration, string destination, string updateUrl) {

			string updateDirectory = Path.Combine(destination, "Updates");
			string downloadUrl = updateUrl;
			if (!downloadUrl.EndsWith("/"))
				downloadUrl = downloadUrl + "/";

			downloadUrl = downloadUrl + "updates/";
			var client = Session.createWebClient();

			//Download Updatepackages and Changelogs
			foreach (var package in configuration.updatePackages) {
				
				//Download Updatepackage
				client.DownloadFile(string.Format("{0}{1}", downloadUrl, package.getFilename()),
				                    Path.Combine(updateDirectory, package.getFilename()));

				//Download Changelog
				client.DownloadFile(string.Format("{0}{1}", downloadUrl, package.getChangelogFilename()),
				                    Path.Combine(updateDirectory, package.getChangelogFilename()));
			}
		}

		public string Convert(string projectFile, string updateUrl, string destination) {
			
			//Open the old Project and extract Private- and Public Key
			IProjectFile oldProject = loadProject(projectFile);

			//Download and Open the Updateconfiguration
			var configuration = downloadConfiguration(updateUrl);

			//Setup new Updateproject
			var newProject = Session.updateFactory.createNewProject();
			newProject.keyPair.privateKey = oldProject.privateKey;
			newProject.keyPair.publicKey = oldProject.publicKey;
			newProject.projectId = configuration.projectId;
			newProject.projectName = configuration.applicationName;
			
			//Copy Updatepackages
			foreach (var package in configuration.updatePackages) {
				newProject.updatePackages.Add(package);
			}

			//Save the Project the first time in order to create the Folder for the Updatepackages
			string completeProjectPath = Path.Combine(destination,
			                                          string.Format("{0}.uaproj", Path.GetFileNameWithoutExtension(projectFile)));
			Session.updateFactory.saveProject(completeProjectPath, newProject);

			//Download Updatepackages
			downloadUpdatePackages(configuration, destination, updateUrl);

			return completeProjectPath;
		}

		#endregion

		public upgradeProjectDialog() {
			InitializeComponent();
			bgwConvert.RunWorkerCompleted += bgwConvert_RunWorkerCompleted;
			FormClosing += upgradeProjectDialog_FormClosing;
		}

		void upgradeProjectDialog_FormClosing(object sender, FormClosingEventArgs e) {
			//Do not close the Form if the Worker is running.
			e.Cancel = bgwConvert.IsBusy;
		}

		public override void initializeData() {
			txtDestination.Text = Session.defaultProjectLocation;
		}

		private void btnBrowseProjectFile_Click(object sender, EventArgs e) {
			using (var dialog = new OpenFileDialog() { Filter = "Updateprojekte|*.udproj;*.udprojx" }) {
				if (dialog.ShowDialog(this) == DialogResult.OK) {
					txtProjectFile.Text = dialog.FileName;
					txtDestination.Text = Path.Combine(Session.defaultProjectLocation,
					                                   Path.GetFileNameWithoutExtension(dialog.FileName));
				}
			}
		}

		private void btnBrowseDestination_Click(object sender, EventArgs e) {
			using (var dialog = new FolderBrowserDialog() {SelectedPath = txtDestination.Text}) {
				if (dialog.ShowDialog(this) == DialogResult.OK)
					txtDestination.Text = dialog.SelectedPath;
			}
		}

		private void btnConvert_Click(object sender, EventArgs e) {

			//Check if the Destinationdirectory exists
			if (Directory.Exists(txtDestination.Text) && Directory.GetFiles(txtDestination.Text, "*", SearchOption.AllDirectories).Length > 0) {
				if (
					Session.showMessage(this,
										"In dem angegebenen Verzeichnis befinden sich bereits Projektdateien. Sind Sie sicher, dass Sie dieses überschreiben möchten?",
										"Projektdaten überschreiben?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) != DialogResult.Yes)
					return;
			}

			lockUi(false);
			prgConvert.Style = ProgressBarStyle.Marquee;
			prgConvert.Show();

			bgwConvert.RunWorkerAsync(new[] {
			                                	txtProjectFile.Text,
			                                	txtUpdateUrl.Text,
			                                	txtDestination.Text
			                                });
		}

		private void bgwConvert_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				string[] args = (string[]) e.Argument;
				e.Result = Convert(args[0], args[1], args[2]);
			}
			catch (Exception exc) {
				e.Result = exc;
			}
		}
		void bgwConvert_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			lockUi(true);

			prgConvert.Style = ProgressBarStyle.Blocks;
			prgConvert.Hide();

			if (e.Result is string) {
				DialogResult = DialogResult.OK;
				Result = e.Result;
				Close();
			}
			else {
				var exception = (Exception) e.Result;
				Session.Log.writeException(exception);
				Session.showMessage(this, string.Format("Bei der Projektkonvertierung ist folgendes Problem aufgetreten:\r\n{0}", exception.Message),
				                    "Die Projektkonvertierung konnte nicht abgeschlossen werden", MessageBoxIcon.Error,
				                    MessageBoxButtons.OK);
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
