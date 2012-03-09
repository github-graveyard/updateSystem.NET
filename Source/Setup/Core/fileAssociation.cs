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

using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace updateSystemDotNet.Setup.Core {
	internal static class FileAssociation {
		[DllImport("shell32.dll")]
		private static extern void SHChangeNotify(int wEventId, int uFlags, int dwItem1, int dwItem2);

		public static void refreshDesktop() {
			SHChangeNotify(0x8000000, 0, 0, 0);
		}

		// Associate file extension with progID, description, icon and application
		public static void Associate(string extension, string progID, string description, string icon, string application) {
			Registry.ClassesRoot.CreateSubKey(extension).SetValue("", progID);

			if (progID != null && progID.Length > 0) {
				using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progID)) {
					if (description != null)
						key.SetValue("", description);

					if (icon != null)
						key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));

					if (application != null)
						key.CreateSubKey(@"Shell\Open\Command").SetValue("",
						                                                 ToShortPathName(application) + " \"%1\"");
				}
			}
		}

		// Return true if extension already associated in registry
		public static bool IsAssociated(string extension) {
			return (Registry.ClassesRoot.OpenSubKey(extension, false) != null);
		}

		public static void DeleteAssociation(string extension) {
			if (IsAssociated(extension))
				Registry.ClassesRoot.DeleteSubKey(extension, false);
		}

		[DllImport("Kernel32.dll")]
		private static extern uint GetShortPathName(string lpszLongPath,
		                                            [Out] StringBuilder lpszShortPath, uint cchBuffer);

		// Return short path format of a file name
		private static string ToShortPathName(string longName) {
			var s = new StringBuilder(1000);
			var iSize = (uint) s.Capacity;
			uint iRet = GetShortPathName(longName, s, iSize);
			return s.ToString();
		}
	}
}