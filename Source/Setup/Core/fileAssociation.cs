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