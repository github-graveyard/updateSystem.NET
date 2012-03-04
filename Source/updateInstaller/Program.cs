using System;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Updater.Properties;
using updateSystemDotNet.Updater.UI.Forms;

namespace updateSystemDotNet.Updater {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			Application.Run(new MainForm());
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			if (args.Name.Contains("ICSharpCode"))
				return Assembly.Load(Resources.ICSharpCode_SharpZipLib);
			else
				return null;
		}
	}
}