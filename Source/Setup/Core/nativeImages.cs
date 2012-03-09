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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace updateSystemDotNet.Setup.Core {
	internal static class nativeImages {
		private static string _clrDirectory = string.Empty;

		[DllImport("mscoree.dll")]
		private static extern IntPtr GetCORSystemDirectory([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pbuffer,
		                                                   int cchBuffer, ref int dwlength);

		/// <summary>Ermittelt das Verzeichnis, in welchem die .Net Frameworktools installiert sind. </summary>
		/// <returns>Gibt das Frameworkverzeichnis zurück.</returns>
		private static string GetClrInstallationDirectory() {
			int capacity = 260;
			var pbuffer = new StringBuilder(capacity);
			GetCORSystemDirectory(pbuffer, capacity, ref capacity);
			return pbuffer.ToString();
		}

		/// <summary>Generiert ein natives Image eines .Net Assemblies</summary>
		/// <param name="filename">Der Pfad zu dem Assembly das optimiert werden soll.</param>
		public static void Install(string filename) {
			if (string.IsNullOrEmpty(_clrDirectory)) {
				_clrDirectory = GetClrInstallationDirectory();
			}
			var process = new Process();
			process.StartInfo.FileName = Path.Combine(_clrDirectory, "ngen.exe");
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Arguments = " install \"" + filename + "\" /NoDependencies /nologo /silent";
			process.Start();
			process.WaitForExit(60*1000);
		}

		/// <summary>Entfernt ein Image aus dem Cache der natives Images auf dem Computer.</summary>
		/// <param name="filename">Der Dateiname zu dem Assembly das entfernt werden soll.</param>
		public static void Uninstall(string filename) {
			if (string.IsNullOrEmpty(_clrDirectory)) {
				_clrDirectory = GetClrInstallationDirectory();
			}

			var process = new Process();
			process.StartInfo.FileName = Path.Combine(_clrDirectory, "ngen.exe");
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Arguments = " uninstall \"" + filename + "\" /NoDependencies /nologo /silent";
			process.Start();
			process.WaitForExit(60*1000);
		}
	}
}