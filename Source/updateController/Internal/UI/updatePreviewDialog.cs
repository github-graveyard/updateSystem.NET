using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Core;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Internal.UI {
	internal sealed partial class updatePreviewDialog : Form {
		private readonly changelogDictionary m_changelogs;

		/// <summary>
		/// Heruntergeladene Updatekonfiguration
		/// </summary>
		private readonly updateConfiguration m_config;

		/// <summary>
		/// Resultat des Suchproviders
		/// </summary>
		private readonly List<updatePackage> m_result;

		/// <summary>
		/// UpdateSettings welche der Benutzer oder Entwickler dem UpdateHelper mitgegeben haben
		/// </summary>
		private readonly UpdateSettings m_settings;

		/// <summary>
		/// Kontruktor
		/// </summary>
		/// <param name="Settings">Die lokalen Updateeinstellungen</param>
		/// <param name="Result">Das Suchresultat</param>
		/// <param name="Config">Die heruntergeladene Updatekonfiguration</param>
		/// <param name="changelogs">Die Changelogs</param>
		/// <param name="requestElevation">Gibt an, ob eine Elevation notwendig ist.</param>
		public updatePreviewDialog(UpdateSettings Settings, List<updatePackage> Result, updateConfiguration Config,
		                           changelogDictionary changelogs, bool requestElevation) {
			InitializeComponent();

			//Systemschriftart ermitteln
			Font = SystemFonts.MessageBoxFont;

			//Initialisiere Events
			SizeChanged += UpdateDialog_SizeChanged;

			//Setze private Variablen
			m_settings = Settings;
			m_result = Result;
			m_config = Config;
			m_changelogs = changelogs;

			//Setze Sprachstrings
			lblStatus.Text = Language.GetString("UpdateForm_lblStatus_text");
			btnCancel.Text = Language.GetString("general_button_cancel");
			btnStartUpdate.Text = Language.GetString("UpdateForm_btnStartUpdate_text");
			lblCurrentVersion.Text = string.Format(Language.GetString("UpdateForm_lblCurrentVersion_text"),
			                                       Settings.releaseInfo.Version);

			if (Settings.releaseInfo.Type != releaseTypes.Final)
				lblCurrentVersion.Text += string.Format(" ({0} {1})", Settings.releaseInfo.Type.ToString(),
				                                        Settings.releaseInfo.Step.ToString());

			if (Result.Count > 0) {
				lblNewestVersion.Text = string.Format(Language.GetString("UpdateForm_lblNewestVersion_text"),
				                                      Result[Result.Count - 1].releaseInfo.Version);
				if (Result[Result.Count - 1].releaseInfo.Type != releaseTypes.Final) {
					lblNewestVersion.Text += string.Format(" ({0} {1})", Result[Result.Count - 1].releaseInfo.Type.ToString(),
					                                       Result[Result.Count - 1].releaseInfo.Step.ToString());
				}
			}

			Text = m_config.applicationName;

			//Updatedetails erstellen
			buildUpdateDetails();

			//Setze vor den Start-Button ein Schild wenn der Benutzer nicht über Administratorrechte verfügt
			if (!IsAdmin() && Environment.OSVersion.Version.Major >= 6 && requestElevation) {
				SendMessage(new HandleRef(btnStartUpdate, btnStartUpdate.Handle), 0x160c, IntPtr.Zero, new IntPtr(1));
				btnStartUpdate.MinimumSize = new Size(
					btnStartUpdate.Width + 20, //Etwas platz für das ShieldIcon schaffen
					btnStartUpdate.MinimumSize.Height);
			}


			//Setze Anwendungsbild
			try {
				imgApp.Image = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location).ToBitmap();
			}
			catch {
				imgApp.Image = SystemIcons.Application.ToBitmap();
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		private void UpdateDialog_SizeChanged(object sender, EventArgs e) {
			pnlExtended.Invalidate();
		}

		public new DialogResult ShowDialog(IWin32Window owner) {
			if (owner == null) StartPosition = FormStartPosition.CenterScreen;

			//TopMost Workaround
			try {
				var fParent = (Form) owner;
				PropertyInfo pTopMost = fParent.GetType().GetProperty("TopMost");
				TopMost = (bool) pTopMost.GetValue(fParent, null);
			}
			catch {
			}

			return base.ShowDialog(owner);
		}

		private void buildUpdateDetails() {
			//Reihenfolge umkehren damit das neueste Update an Erster Stelle steht.
			m_result.Reverse();

			var sbDetails = new StringBuilder();
			double completeSize = 0;
			var seperator = new string('-', 30);
			foreach (updatePackage package in m_result) {
				completeSize += package.packageSize;
			}
			lblSize.Text = string.Format(Language.GetString("UpdateForm_lblSize_text"), Helper.GetFileSize(completeSize));

			foreach (var changelog in m_changelogs) {
				sbDetails.AppendLine(string.Format(Language.GetString("UpdateForm_Changelog_title"),
				                                   new[] {
				                                         	changelog.Key.releaseInfo.Version +
				                                         	(changelog.Key.releaseInfo.Type !=
				                                         	 releaseTypes.Final
				                                         	 	? string.Format(
				                                         	 		" ({0} {1})",
				                                         	 		changelog.Key.releaseInfo.Type,
				                                         	 		changelog.Key.releaseInfo.Step)
				                                         	 	: ""),
				                                         	getReleaseDateByVersion(
				                                         		changelog.Key.releaseInfo,
				                                         		changelog.Key.Architecture)
				                                         }));

				sbDetails.AppendLine(seperator);

				sbDetails.AppendLine(Language.getLanguageId(m_settings.Language) == "Deutsch"
				                     	? changelog.Value.germanChanges
				                     	: changelog.Value.englishChanges);

				sbDetails.AppendLine();
			}

			txtDetails.Text = sbDetails.ToString();
			//Reihenfolge korrigieren damit die Updates in der korrekten Reihenfolge heruntergeladen- und installiert werden.
			m_result.Reverse();
		}

		private string getReleaseDateByVersion(releaseInfo rInfo, updatePackage.SupportedArchitectures target) {
			foreach (updatePackage package in m_result) {
				if (package.releaseInfo.Equals(rInfo) && package.TargetArchitecture.Equals(target)) {
					DateTime releaseDate;
					DateTime.TryParse(package.ReleaseDate, out releaseDate);
					return releaseDate.ToShortDateString();
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// Returns true if the current User has Administratorprivilegs, otherwise false.
		/// </summary>
		/// <returns>bool</returns>
		private bool IsAdmin() {
			WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
			var wPrincipal = new WindowsPrincipal(currentUser);
			return wPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// Gibt die größe einer Datei in einem formatiertem String wieder.
		/// </summary>
		/// <param name="lenght">Die Größe der Datei in Bytes</param>
		/// <returns></returns>
		public static string GetFileSize(Single lenght) {
			try {
				if (lenght < 1024) {
					return string.Format("{0} Bytes", lenght.ToString());
				}
				if (lenght > 1023 && lenght < 1048576) {
					Single c_lenght = lenght/1024;
					return string.Format("{0} KB", c_lenght.ToString("###0.00"));
				}
				if (lenght >= 1048576 && lenght <= 1043741825) {
					Single c_lenght = lenght/(float) (Math.Pow(1024, 2));
					return string.Format("{0} MB", c_lenght.ToString("###0.00"));
				}

				return "0 Bytes";
			}
			catch {
				return "0 Bytes";
			}
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			btnStartUpdate.Focus();
		}

		private void pnlExtended_Paint(object sender, PaintEventArgs e) {
			try {
				e.Graphics.DrawRectangle(
					SystemPens.ControlLight,
					new Rectangle(0, 0, pnlExtended.Width - 1, pnlExtended.Height - 1)
					);
			}
			catch {
			}
		}
	}
}