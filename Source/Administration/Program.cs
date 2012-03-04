using System;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.Run(new UI.mainForm(args));
		}
	}
}