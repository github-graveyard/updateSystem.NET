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
using System.Diagnostics;
using System.IO;
using System.Text;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpUninstalled : basePage, ISetupPage {
		public stpUninstalled() {
			InitializeComponent();
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "Deinstallation erfolgreich"; }
		}

		public bool isLastPage {
			get { return true; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return null; }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		public override void onHide() {
			base.onHide();
			executeUninstallCleanup();
		}

		private void executeUninstallCleanup() {
			string uninstallBatch = Path.Combine(Path.GetTempPath(), "usnUninstall.bat");
			var sb = new StringBuilder();
			sb.AppendLine("@Echo off");
			sb.AppendLine("PING 127.0.0.1 > nul");
			sb.AppendLine(string.Format("DEL /F /S /Q \"{0}\" > nul", AppDomain.CurrentDomain.BaseDirectory));
			sb.AppendLine(string.Format("RD /S /Q \"{0}\" > nul", AppDomain.CurrentDomain.BaseDirectory));
			sb.AppendLine(string.Format("DEL /F \"{0}\" > nul", uninstallBatch));
			File.WriteAllText(uninstallBatch, sb.ToString());

			var psi = new ProcessStartInfo(uninstallBatch);
			psi.CreateNoWindow = true;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			Process.Start(psi);
		}
	}
}