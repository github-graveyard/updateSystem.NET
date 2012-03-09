/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class copySettingsDialog : Form {
		public copySettingsDialog() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			base.Text = string.Format("{0} - Updateeinstellungen kopieren", Strings.applicationName);
			imgImportSettings.Image = graphicUtils.shrinkImage(resourceHelper.getImage("copyProjectSettings.png"),
			                                                   new Size(350, 70));
			lnkHelp.Url = Strings.urlHelpMain;
			txtCSharp.Text = generateCSharpCode();
			txtVB.Text = generateVBCode();

			rbDesigner.CheckedChanged += radioButton_Checked;
			rbCSharp.CheckedChanged += radioButton_Checked;
			rbVB.CheckedChanged += radioButton_Checked;
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void radioButton_Checked(object sender, EventArgs e) {
			foreach (Control ctrl in Controls) {
				if (ctrl is Panel)
					ctrl.Hide();
			}

			if (rbDesigner.Checked)
				pnlWinForms.Show();
			else if (rbCSharp.Checked)
				pnlCSharp.Show();
			else if (rbVB.Checked)
				pnlVB.Show();
		}

		private string generateCSharpCode() {
			var sbCode = new StringBuilder();

			//sbCode.AppendLine("//updateController Objekt initialisieren");
			//sbCode.AppendLine("updateSystemDotNet.updateController updController = new updateSystemDotNet.updateController();");
			//sbCode.AppendLine(string.Format("updController.updateUrl = \"{0}\";",
			//                                applicationBase.Instance.Project.Configuration.updateUrl));
			//sbCode.AppendLine(string.Format("updController.projectId = \"{0}\";",
			//                                applicationBase.Instance.Project.Configuration.projectId));
			//sbCode.AppendLine(string.Format("updController.publicKey = \"{0}\";", applicationBase.Instance.Project.publicKey));
			//sbCode.AppendLine();

			//sbCode.AppendLine("//Releasefilter setzen, per Default wird nur nach finalen Versionen gesucht:");
			//sbCode.AppendLine("updController.releaseFilter.checkForFinal = true;");
			//sbCode.AppendLine(
			//    "updController.releaseFilter.checkForBeta = false; //Betaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			//sbCode.AppendLine(
			//    "updController.releaseFilter.checkForAlpha = false; //Alphaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			//sbCode.AppendLine();

			//sbCode.AppendLine("//Anwendung nach dem Update neustarten?");
			//sbCode.AppendLine("updController.restartApplication = true;");
			//sbCode.AppendLine();

			//sbCode.AppendLine("//Wie soll die lokale Version ermittelt werden?");
			//sbCode.AppendLine(
			//    "updController.retrieveHostVersion = true; //Empfohlen, damit wird automatisch die Assemblyversion ermittelt.");
			//sbCode.AppendLine("//Die Version kann allerdings auch manuell gesetzt werden:");
			//sbCode.AppendLine("//z.B.: updController.releaseInfo.Version = \"1.2.3.4\";");
			//sbCode.AppendLine();

			//sbCode.AppendLine("//Einfacher Aufruf der Updatesuche:");
			//sbCode.AppendLine("//updController.updateInteractive();");

			return sbCode.ToString();
		}

		private string generateVBCode() {
			var sbCode = new StringBuilder();

			//sbCode.AppendLine("'updateController Objekt initialisieren");
			//sbCode.AppendLine("Dim updController As New updateSystemDotNet.updateController()");
			//sbCode.AppendLine(string.Format("updController.updateUrl = \"{0}\"",
			//                                applicationBase.Instance.Project.Configuration.updateUrl));
			//sbCode.AppendLine(string.Format("updController.projectId = \"{0}\"",
			//                                applicationBase.Instance.Project.Configuration.projectId));
			//sbCode.AppendLine(string.Format("updController.publicKey = \"{0}\"", applicationBase.Instance.Project.publicKey));
			//sbCode.AppendLine();

			//sbCode.AppendLine("'Releasefilter setzen, per Default wird nur nach finalen Versionen gesucht:");
			//sbCode.AppendLine("updController.releaseFilter.checkForFinal = True");
			//sbCode.AppendLine(
			//    "updController.releaseFilter.checkForBeta = False 'Betaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			//sbCode.AppendLine(
			//    "updController.releaseFilter.checkForAlpha = False 'Alphaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.");
			//sbCode.AppendLine();

			//sbCode.AppendLine("'Anwendung nach dem Update neustarten?");
			//sbCode.AppendLine("updController.restartApplication = True");
			//sbCode.AppendLine();

			//sbCode.AppendLine("'Wie soll die lokale Version ermittelt werden?");
			//sbCode.AppendLine(
			//    "updController.retrieveHostVersion = True 'Empfohlen, damit wird automatisch die Assemblyversion ermittelt.");
			//sbCode.AppendLine("'Die Version kann allerdings auch manuell gesetzt werden:");
			//sbCode.AppendLine("'z.B.: updController.releaseInfo.Version = \"1.2.3.4\"");
			//sbCode.AppendLine();

			//sbCode.AppendLine("'Einfacher Aufruf der Updatesuche:");
			//sbCode.AppendLine("'updController.updateInteractive()");

			return sbCode.ToString();
		}

		private void btnCopyControllerObject_Click(object sender, EventArgs e) {
//			clipboardHelper.copyProjectDataToClipboard();
			btnCopyControllerObject.Text = "Daten kopiert!";
		}
	}
}