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