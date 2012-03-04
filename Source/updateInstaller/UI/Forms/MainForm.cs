using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using updateSystemDotNet.Updater.UI.Components;
using updateSystemDotNet.Updater.Win32;
using updateSystemDotNet.Updater.applyUpdate;

namespace updateSystemDotNet.Updater.UI.Forms {
	internal sealed partial class MainForm : Form {
		private readonly applyUpdateManager m_updateManager;

		private bool _updateFailed;

		public MainForm() {
			InitializeComponent();

			Font = SystemFonts.MessageBoxFont;
			Shown += MainForm_Shown;
			FormClosing += MainForm_FormClosing;

			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			m_updateManager = new applyUpdateManager(this);
			m_updateManager.updateFinished += m_updateManager_updateFinished;
			m_updateManager.updateProgressChanged += m_updateManager_updateProgressChanged;
			m_updateManager.rollbackFinished += m_updateManager_rollbackFinished;
			m_updateManager.interfaceInteraction += m_updateManager_interfaceInteraction;

			//Sprache setzen
			Language.Set_Language(m_updateManager.currentConfig.Settings.Language);

			if (!string.IsNullOrEmpty(m_updateManager.currentConfig.Settings.applicationPath) &&
			    File.Exists(m_updateManager.currentConfig.Settings.applicationPath)) {
				try {
					imageApplication.Image =
						Icon.ExtractAssociatedIcon(m_updateManager.currentConfig.Settings.applicationPath).ToBitmap();
				}
				catch {
					imageApplication.Image = Icon.ToBitmap();
				}
			}
			else {
				imageApplication.Image = Icon.ToBitmap();
			}

			lblStatus.Text = Language.GetString("mainForm_lblStatus_initialize");
			lblStatus.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12);
			aclApply.Text = string.Empty;
			aclApply.State = statusLabelStates.Progress;
			btnCancel.Text = Language.GetString("general_button_cancel");

			aclApply.Text = Language.GetString("MainForm_aclApply");
			aclDownload.Text = Language.GetString("MainForm_aclDownload");

			btnCancel.Enabled = !m_updateManager.currentConfig.Settings.disableCancel;
			Text = m_updateManager.currentConfig.ServerConfiguration.applicationName;
		}

		private void m_updateManager_interfaceInteraction(object sender, applyUpdateInterfaceInteractionEventArgs e) {
			if (m_updateManager.currentConfig.Settings.showTaskBarProgress) {
				prgUpdate.State = e.progressBarState;
			}
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			showUnhandledException((e.ExceptionObject as Exception));
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			showUnhandledException(e.Exception);
		}

		private void showUnhandledException(Exception ex) {
			MessageBox.Show(this,
			                string.Format(Language.GetString("mainForm_unhandledException_text"), "\r\n", ex.Message),
			                "updateInstaller",
			                MessageBoxButtons.OK,
			                MessageBoxIcon.Error);
		}

		private void m_updateManager_rollbackFinished(object sender, applyUpdateActionFinishedEventArgs e) {
			btnCancel.Enabled = true;
			aclApply.Text = Language.GetString("mainForm_lblCurrentStatus_updateFailed");
			lblStatus.Text = Language.GetString("mainForm_lblStatus_updateFailed");
			aclApply.State= statusLabelStates.Failure;
			btnCancel.Text = Language.GetString("general_button_close");
			//(new exceptionDialog(e.actionException)).ShowDialog(this);

			if (!(e.actionException is userCancelledException)) {
				MessageBox.Show(this,
				                string.Format(Language.GetString("mainForm_rollback"), "\r\n", e.actionException.Message),
				                "updateInstaller",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			}
			prgUpdate.ShowInTaskbar = false;
			prgUpdate.Value = prgUpdate.Maximum;
			_updateFailed = true;
			;
			if (m_updateManager.currentConfig.Settings.SkipOK) {
				Close();
			}
		}

		private void m_updateManager_updateProgressChanged(object sender, applyUpdateProgressChangedEventArgs e) {
			//lblStatus.Text = e.actionName;
			aclApply.Text = string.Format("[{0}] {1}", e.actionName, e.actionDescription);
			prgUpdate.Value = e.percentDone;
		}

		private void m_updateManager_updateFinished(object sender, applyUpdateActionFinishedEventArgs e) {
			btnCancel.Enabled = true;
			if (!m_updateManager.currentConfig.Settings.SkipOK) {
				aclApply.Text = Language.GetString("mainForm_lblCurrentStatus_updateSuccessfull");
				aclApply.State = statusLabelStates.Success;
				lblStatus.Text = Language.GetString("mainForm_lblStatus_updateSuccessfull");
				btnCancel.Text = Language.GetString("general_button_close");
				prgUpdate.ShowInTaskbar = false;
				prgUpdate.Value = prgUpdate.Maximum;
			}
			else {
				Close();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (m_updateManager.isBusy) {
				e.Cancel = true;
			}
			else {
				BlockLogOff(false);

				if (m_updateManager.currentConfig.Settings.restartApplication &&
				    File.Exists(m_updateManager.currentConfig.Settings.applicationPath)) {
					if (Environment.OSVersion.Version.Major >= 6 && IsAdmin()) {
						IntPtr hProcess = IntPtr.Zero;
						Security.ExecRequireNonAdmin(this, m_updateManager.currentConfig.Settings.applicationPath,
						                             extendCommandLineArguments(), out hProcess);

						//Wenn Prozess nicht gestartet, dann normal starten
						try {
							if (hProcess == IntPtr.Zero)
								Process.Start(m_updateManager.currentConfig.Settings.applicationPath, extendCommandLineArguments());
						}
						catch (Win32Exception) {
						}
					}
					else {
						try {
							Process.Start(m_updateManager.currentConfig.Settings.applicationPath, extendCommandLineArguments());
						}
						catch (Win32Exception) {
						}
					}
				}
			}
		}

		private string extendCommandLineArguments() {
			string currentArguments = m_updateManager.currentConfig.Settings.commandlineArguments;
			string extendedArguments = string.Empty;

			if (!_updateFailed) {
				extendedArguments = m_updateManager.currentConfig.ServerConfiguration.startParameterSuccess;
			}
			else {
				extendedArguments = m_updateManager.currentConfig.ServerConfiguration.startParameterFailed;
			}

			if (!string.IsNullOrEmpty(extendedArguments)) {
				if (!currentArguments.EndsWith(" ")) {
					extendedArguments = " " + extendedArguments;
				}
				extendedArguments = extendedArguments.Replace("$oldVersion",
				                                              m_updateManager.currentConfig.Settings.releaseInfo.Version);
				extendedArguments = extendedArguments.Replace("$newVersion",
				                                              m_updateManager.currentConfig.Result[
				                                              	m_updateManager.currentConfig.Result.Count - 1].releaseInfo.Version);
			}

			return currentArguments + extendedArguments;
		}

		/// <summary>
		/// Gibt zurück ob der angemeldete Benutzer über Administratorrechte verfügt.
		/// </summary>
		/// <returns>bool</returns>
		private bool IsAdmin() {
			WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
			var wPrincipal = new WindowsPrincipal(currentUser);
			return wPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		private void MainForm_Shown(object sender, EventArgs e) {
			try {
				BlockLogOff(true);
				m_updateManager.runUpdate();

				//Anwendung in den Vordergrund holen
				TopMost = true;
				TopMost = false;
			}
			catch (Exception ex) {
				showUnhandledException(ex);
				throw ex;
			}
		}

		private void MainForm_Load(object sender, EventArgs e) {
			Location = new Point(
				(Screen.PrimaryScreen.WorkingArea.Width/2) - (Width/2),
				(Screen.PrimaryScreen.WorkingArea.Height/2) - (Height/2));
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			if (m_updateManager.isBusy) {
				m_updateManager.cancelUpdate();
				btnCancel.Enabled = false;
			}
			else {
				Close();
			}
		}

		#region " Abmelden Blockieren "

		private bool logOffBlocked;

		[DllImport("user32.dll")]
		public static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);

		[DllImport("user32.dll")]
		public static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);

		private void BlockLogOff(bool block) {
			logOffBlocked = block;

			if (Environment.OSVersion.Version.Major < 6) {
				return;
			}

			try {
				if (block)
					ShutdownBlockReasonCreate(Handle, "updateSystem.NET");
				else
					ShutdownBlockReasonDestroy(Handle);
			}
			catch {
			}
		}

		protected override void WndProc(ref Message aMessage) {
			//WM_QUERYENDSESSION = 0x0011
			//WM_ENDSESSION = 0x0016
			if (logOffBlocked && (aMessage.Msg == 0x0011 || aMessage.Msg == 0x0016))
				return;

			base.WndProc(ref aMessage);
		}

		#endregion
	}
}