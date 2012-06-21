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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;
using updateSystemDotNet.Setup.UI.setupPages;

namespace updateSystemDotNet.Setup.UI {
	internal sealed partial class setupWizard : Form {
		private readonly List<string> _arguments;
		private setupContext _context;
		private ISetupPage _currentPage;
		private Dictionary<Type, ISetupPage> _setupPages;

		public setupWizard(IEnumerable<string> args) {
			InitializeComponent();
			_arguments = new List<string>(args);

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.ThreadException += Application_ThreadException;

			Font = SystemFonts.MessageBoxFont;
			flpButtons.Font = SystemFonts.MessageBoxFont;
			if (initializeSetup()) {
				Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
				Text = string.Format("{0} - {1}", _context.Product.Product, (_context.isUpgrade ? "Upgrade" : "Setup"));
				Load += setupWizard_Load;
				Paint += setupWizard_Paint;
				lblVersion.Text = string.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version);
				lblTitle.Font = new Font(SystemFonts.MessageBoxFont.Name, 12);
			}
			else
				Close();
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			showException(e.Exception);
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			showException(e.ExceptionObject as Exception);
		}

		private void showException(Exception exc) {
			Type exceptionPage = typeof (stpInterrupted);
			if (_setupPages.ContainsKey(exceptionPage)) {
				_context.setupException = exc;
				showPage(exceptionPage);
			}
			else {
				MessageBox.Show(exc.Message, "updateSystem.NET Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		private void setupWizard_Paint(object sender, PaintEventArgs e) {
		}

		private void setupWizard_Load(object sender, EventArgs e) {
			if (!_arguments.Contains("/uninstall")) {
				if (_context.Product is productBeta && !_context.isUpgrade)
					showPage(typeof (stpBeta));
				else if (_context.isUpgrade) {
					_context.installationDirectory = ProgramsAndFeaturesHelper.installationDirectory(_context.Product);
					showPage(typeof (stpUpgrade));
				}
				else
					showPage(typeof(stpLicense));
			}
			else {
				//Anwendung deinstallieren

				//Installationsverzeichnis setzen
				_context.installationDirectory = ProgramsAndFeaturesHelper.installationDirectory(_context.Product);

				showPage(typeof (stpWelcomeUninstall));
			}
		}

		private bool initializeSetup() {

			//BETA RTM SWITCH
			_context = new setupContext {
			                            	Product = new productBeta()
			                            };

			//Setupseiten initialisieren
			_setupPages = new Dictionary<Type, ISetupPage> {
			                                               	{typeof (stpBeta), new stpBeta()},
			                                               	{typeof (stpLicense), new stpLicense()},
			                                               	{typeof (stpDonate), new stpDonate()},
			                                               	{typeof (stpOptions), new stpOptions()},
			                                               	{typeof (stpInstall), new stpInstall()},
			                                               	{typeof (stpInterrupted), new stpInterrupted()},
			                                               	{typeof (stpInstalled), new stpInstalled()},
			                                               	{typeof (stpWelcomeUninstall), new stpWelcomeUninstall()},
			                                               	{typeof (stpUninstall), new stpUninstall()},
			                                               	{typeof (stpUninstalled), new stpUninstalled()},
			                                               	{typeof (stpUpgrade), new stpUpgrade()}
			                                               };

			_context.isUpgrade = (ProgramsAndFeaturesHelper.isInstalled(_context.Product) &&
			                      ProgramsAndFeaturesHelper.getCurrentVersion(_context.Product) <
			                      Assembly.GetExecutingAssembly().GetName().Version);

			if (ProgramsAndFeaturesHelper.isInstalled(_context.Product) &&
				ProgramsAndFeaturesHelper.getCurrentVersion(_context.Product) == Assembly.GetExecutingAssembly().GetName().Version &&
				!_arguments.Contains("/uninstall"))
				if (MessageBox.Show(string.Format("Es ist bereits eine identische Version von {0} installiert.\r\nMöchten Sie das Setup trotzdem starten?", _context.Product.Product), _context.Product.Product, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
					return false;

			return true;
		}

		private void showPage(Type page, bool validate) {
			if (!_setupPages.ContainsKey(page))
				throw new KeyNotFoundException();

			//Wenn dies nicht die erste Seite ist, dann
			if (_currentPage != null) {
				if (validate && !_currentPage.View.onValidate()) //Benutzereingaben validieren
					return;

				//Letzte Seite entfernen
				_currentPage.View.onHide();
				_currentPage.View.changePage -= View_changePage;
				pnlContent.Controls.Remove(_currentPage.View);
			}

			_currentPage = _setupPages[page];
			_currentPage.Context = _context;
			_currentPage.View.onShow();
			_currentPage.View.changePage += View_changePage;
			lblTitle.Text = _currentPage.Title;
			pnlContent.Controls.Add(_currentPage.View);
			pnlContent.Controls[_currentPage.View.Name].Dock = DockStyle.Fill;
			btnBack.Enabled = (_currentPage.backwardPage != null);
			btnNext.Enabled = (_currentPage.forwardPage != null || _currentPage.isLastPage);
		}

		private void showPage(Type page) {
			showPage(page, true);
		}

		private void View_changePage(object sender, changePageEventArgs e) {
			showPage(e.newPage);
		}

		private void flpButtons_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(SystemColors.Control);
			e.Graphics.DrawLine(SystemPens.ControlLight, new Point(0, 0), new Point(flpButtons.Width, 0));
		}

		private void btnNext_Click(object sender, EventArgs e) {
			if (_currentPage != null) {
				if (_currentPage.forwardPage != null) //Nächste Seite im Assistenten laden
					showPage(_currentPage.forwardPage);
				else if (_currentPage.isLastPage) {
					//Aktuelle Seite ist die letzte, Seite abschließen und Form schließen
					_currentPage.View.onHide();
					Close();
				}
			}
		}

		public Image getImage(string imageName) {
			using (
				Stream sImage =
					Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("updateSystemDotNet.Setup.Images.{0}",
					                                                                        imageName))) {
				if (sImage != null) return Image.FromStream(sImage);
			}
			return null;
		}

		private void btnBack_Click(object sender, EventArgs e) {
			if (_currentPage != null && _currentPage.backwardPage != null)
				showPage(_currentPage.backwardPage, false);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			if (
				MessageBox.Show(
					"Die Installation ist nocht nicht abgeschlossen. Sind Sie sicher, dass Sie den Setupassistenten beenden möchten?",
					_context.Product.Product, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				Close();
		}

		private void pnlHeader_Paint(object sender, PaintEventArgs e) {

			if (e.ClipRectangle.Width <= 0 || e.ClipRectangle.Height <= 0)
				return;

			var brush = new LinearGradientBrush(e.ClipRectangle, SystemColors.Control, SystemColors.ControlLight,
			                                    LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush, e.ClipRectangle);

			e.Graphics.DrawLine(
				SystemPens.ControlDark,
				new Point(0, pnlHeader.Height - 1),
				new Point(e.ClipRectangle.Width, pnlHeader.Height - 1)
				);
		}
	}
}