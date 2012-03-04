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