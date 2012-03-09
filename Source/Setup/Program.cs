#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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