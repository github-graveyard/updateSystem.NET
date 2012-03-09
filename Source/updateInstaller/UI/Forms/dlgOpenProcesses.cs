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
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using updateSystemDotNet.Updater.UI.Components;

namespace updateSystemDotNet.Updater.UI.Forms {
	internal partial class dlgOpenProcesses : dlgTemplate {
		/// <summary>
		/// Liste welche die Prozesse enthält die beendet werden müssen
		/// </summary>
		private readonly List<string> m_processes = new List<string>();

		public dlgOpenProcesses(string[] processes) {
			try {
				InitializeComponent();

				imgProcess.Image = SystemIcons.Application.ToBitmap();
				btnCancel.Text = Language.GetString("dlg_cancel");
				lblTitle.Text = Language.GetString("dlgOpenProcesses_lblTitle");
				lblDescription.Text = Language.GetString("dlgOpenProcesses_lblDescription");
				btnKillProcess.Text = Language.GetString("dlgOpenProcesses_btnKillProcess");
				btnRefresh.Text = Language.GetString("dlgOpenProcesses_btnRefresh");

				m_processes.AddRange(processes);
				Load_Processes();

				Shown += dlgOpenProcesses_Shown;
			}
			catch (Exception ex) {
				MessageBox.Show(string.Format("Konstruktor: {0}", ex.Message));
			}
		}

		private void dlgOpenProcesses_Shown(object sender, EventArgs e) {
			try {
				TopMost = true;
				Application.DoEvents();
				TopMost = false;
			}
			catch (Exception ex) {
				MessageBox.Show(string.Format("Shown: {0}", ex.Message));
			}
		}

		/// <summary>
		/// Lädt die Prozesse die beendet werden müssen in die ListView, sind bereits alle Prozesse geschlossen wird der Dialog geschlossen
		/// </summary>
		private void Load_Processes() {
			try {
				//Leere ListView
				lvwProcesses.Items.Clear();
				foreach (string process in m_processes) {
					if (Process.GetProcessesByName(process).Length > 0 && !processExistsInListView(process)) {
						lvwProcesses.Items.Add(process);
					}
				}
				if (lvwProcesses.Items.Count == 0) {
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex) {
				MessageBox.Show(string.Format("LoadProcesses: {0}", ex.Message));
			}
		}

		private bool processExistsInListView(string processName) {
			foreach (ListViewItem lviProcess in lvwProcesses.Items) {
				if (lviProcess.Text.ToLower().Equals(processName.ToLower())) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Beendet einen Prozess
		/// </summary>
		/// <param name="proc_name">Der Name des Prozesse der beendet werden soll</param>
		private void Close_Process(string proc_name) {
			try {
				Process[] processes = Process.GetProcessesByName(proc_name);
				if (processes.Length > 0) {
					foreach (Process proc in processes) {
						proc.CloseMainWindow();
						proc.WaitForExit(0x1388);
						proc.Kill();
					}
				}
				Thread.Sleep(500);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Load_Processes();
		}

		private void btnRefresh_Click(object sender, EventArgs e) {
			Load_Processes();
		}

		private void lvwProcesses_SelectedIndexChanged(object sender, EventArgs e) {
			btnKillProcess.Enabled = (lvwProcesses.SelectedItems.Count == 1);
		}

		private void btnKillProcess_Click(object sender, EventArgs e) {
			if (lvwProcesses.SelectedItems.Count > 0) {
				Close_Process(lvwProcesses.SelectedItems[0].Text);
			}
		}
	}
}