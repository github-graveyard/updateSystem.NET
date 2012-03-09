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
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Windows.Forms;

namespace updateSystemDotNet.Internal.Designer {
	internal class ControllerActionList : SmartTagActionListBase {
		private readonly updateController m_control;

		/// <summary>
		/// Konstruktur
		/// </summary>
		/// <param name="component">Der UpdateController welcher um den SmartTag erweitert werden soll.</param>
		public ControllerActionList(IComponent component)
			: base(component) {
			m_control = (updateController) component;
		}

		public string UpdateURL {
			get { return m_control.updateLocation; }
			set { SetPropertyByName(m_control, "updateUrl", value); }
		}

		public string PublicKey {
			get { return m_control.publicKey; }
			set { SetPropertyByName(m_control, "publicKey", value); }
		}

		public string ProjektID {
			get { return m_control.projectId; }
			set { SetPropertyByName(m_control, "projectId", value); }
		}

		public Languages Language {
			get { return m_control.Language; }
			set { SetPropertyByName(m_control, "Language", value); }
		}

		public Interval UpdateInterval {
			get { return m_control.updateCheckInterval; }
			set { SetPropertyByName(m_control, "updateCheckInterval", value); }
		}

		public int CustomInterval {
			get { return m_control.customUpdateCheckInterval; }
			set { SetPropertyByName(m_control, "customUpdateCheckInterval", value); }
		}

		public void SetClipboardSettings() {
			try {
				var permission = new UIPermission(UIPermissionClipboard.AllClipboard);
				if (Clipboard.ContainsData("UPDATEDATAv3")) {
					var rawClipboarData = (string) Clipboard.GetData("UPDATEDATAv3");
					var clipboardData = new Dictionary<string, string>();
					foreach (string dataItem in rawClipboarData.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)) {
						clipboardData.Add(
							dataItem.Split(new[] {'#'})[0],
							dataItem.Split(new[] {'#'})[1]
							);
					}
					//UpdateURL = clipboardData["updateUrl"];
					ProjektID = clipboardData["projectId"];
					PublicKey = clipboardData["publicKey"];
				}
				else
					MessageBox.Show("Es konnten keine Updateinformationen in der Zwischenablage gefunden werden.", "updateSystem.NET",
					                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				RefreshDesigner();
			}
			catch (Exception ex) {
				MessageBox.Show(
					string.Format("Die Updateeinstellungen konnten aufgrund eines Fehlers nicht übernommen werden:\r\n{0}", ex.ToString()),
					"updateSystem.Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public override void AddActionItems() {
			//AddActionHeader("Allgemeine Einstellungen");
			//AddActionProperty("UpdateURL", "Update URL:", "Allgemeine Einstellungen", "Die Adresse an welcher sich die Updatekonfiguration befindet.");
			//AddActionProperty("LocalVersion", "Lokale Version:", "Allgemeine Einstellungen", "Die lokal installierte Version.");
			//AddActionProperty("Language", "Sprache:", "Allgemeine Einstellungen", "Die Sprache welche im UpdaterHelper und Updater verwendet werden soll.");
			//AddActionProperty("PublicKey", "Öffentlicher Schlüssel:", "Allgemeine Einstellungen", "Der öffentliche Schlüssel der zur Validierung verwendet werden soll.");
			//AddActionProperty("ProjektID", "Projekt ID:", "Allgemeine Einstellungen", "");

			//AddActionHeader("UpdateInterval");
			//AddActionProperty("UpdateInterval", "Interval:", "UpdateInterval", "Der Interval nach welchem nach Updates gesucht werden soll");
			//AddActionProperty("CustomInterval", "Benutzerdefinierter Interval:", "UpdateInterval", "Der Benutzerdefinierte Updateinterval in Tagen");

			AddActionMethod("SetClipboardSettings", "Projekteinstellungen aus der Zwischenablage einfügen", "",
			                "Kopiert die Updateeinstellungen aus der Zwischenablage in Ihr Projekt.", true);
		}
	}
}