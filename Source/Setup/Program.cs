using System;
using System.Windows.Forms;
using updateSystemDotNet.Setup.UI;

namespace updateSystemDotNet.Setup {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] arguments) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);

			if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 0) {
				MessageBox.Show(
					"Das Setup kann nicht gestartet werden.\r\nWindows 2000 wird von dem updateSystem.NET nicht unterstützt. Sie benötigen mindestens Windows XP um das updateSystem.NET verwenden zu können.",
					"updateSystem.NET Setup",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else {
				var setup = new setupWizard(arguments);
				if(!setup.IsDisposed)
					Application.Run(setup);
			}
		}
	}
}