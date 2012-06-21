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
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace updateSystemDotNet.Setup.Core {
	/// <summary>
	/// Hilfsklasse zum Verwalten der Programmeinträge in der Softwareauflistung in der Systemsteuerung von Windows.
	/// </summary>
	internal static class ProgramsAndFeaturesHelper {
		private static string _uninstallRoot = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

		/// <summary>Fügt einen neuen Eintrag der Softwareauflistung in der Systemsteuerung hinzu.</summary>
		/// <param name="product">Die von IProduct abgeleitete Klasse welche Informationen über das Produkt bereithält.</param>
		/// <returns>Gibt True zurück wenn der Eintrag erfolgreich erzeugt wurde, andernfalls False.</returns>
		public static bool Add(setupContext context) {
			RegistryKey softwareRoot = Registry.LocalMachine.OpenSubKey(_uninstallRoot, true);
			RegistryKey productRoot = softwareRoot.OpenSubKey(context.Product.applicationID, true);

			if (productRoot == null) //Hive existiert noch nicht
				productRoot = softwareRoot.CreateSubKey(context.Product.applicationID);

			//Produktinformationen setzen
			productRoot.SetValue("DisplayVersion", context.Product.newVersion.ToString());
			productRoot.SetValue("DisplayName", context.Product.Product);
			productRoot.SetValue("DisplayIcon", Path.Combine(context.installationDirectory, context.Product.mainExecutable));
			productRoot.SetValue("Contact", context.Product.Contact);
			productRoot.SetValue("Comments", "");
			productRoot.SetValue("Publisher", context.Product.Publisher);
			productRoot.SetValue("HelpLink", context.Product.supportUrl);
			productRoot.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
			productRoot.SetValue("InstallDirectory", context.installationDirectory);

			//Install/Uninstallflags setzen
			productRoot.SetValue("NoModify", 1, RegistryValueKind.DWord);
			productRoot.SetValue("NoRepair", 1, RegistryValueKind.DWord);
			productRoot.SetValue("WindowsInstaller", 0, RegistryValueKind.DWord);
			productRoot.SetValue("UninstallString",
			                     string.Format("{0} /uninstall",
			                                   Path.Combine(context.installationDirectory, context.Product.setupName)));

			return true;
		}

		/// <summary>Überprüft ob ein Produkt bereits installiert wurde.</summary>
		/// <param name="product">Die von IProduct abgeleitete Klasse welche Informationen über das Produkt bereithält.</param>
		/// <returns>Gibt True zurück wenn das Produkt bereits installiert ist, anderfalls False.</returns>
		public static bool isInstalled(IProduct product) {
			RegistryKey softwareRoot = Registry.LocalMachine.OpenSubKey(_uninstallRoot, false);
			return (new List<string>(softwareRoot.GetSubKeyNames()).Contains(product.applicationID));
		}

		/// <summary>Entfernt einen Eintrag aus der Softwareauflistung.</summary>
		/// <param name="product">Die von IProduct abgeleitete Klasse welche Informationen über das Produkt bereithält.</param>
		/// <returns>Gibt True zurück wenn der Eintrag entfernt wurde, anderfalls False.</returns>
		public static bool Remove(IProduct product) {
			if (!isInstalled(product))
				return false;

			RegistryKey softwareRoot = Registry.LocalMachine.OpenSubKey(_uninstallRoot, true);
			softwareRoot.DeleteSubKey(product.applicationID, false);

			return true;
		}

		/// <summary>Gibt die Versionsnummer der zur Zeit installierten Anwendung zurück.</summary>
		/// <param name="product">Die von IProduct abgeleitete Klasse welche Informationen über das Produkt bereithält.</param>
		/// <returns>Die Versionsnummer der bereits installierten Anwendung.</returns>
		public static Version getCurrentVersion(IProduct product) {
			if (!isInstalled(product))
				throw new Exception("Anwendung ist nicht installiert!");

			RegistryKey softwareRoot = Registry.LocalMachine.OpenSubKey(_uninstallRoot, false);
			return new Version(softwareRoot.OpenSubKey(product.applicationID, false).GetValue("DisplayVersion").ToString());
		}

		/// <summary>Gibt das Installationsverzeichnis der Anwendung zurück</summary>
		public static string installationDirectory(IProduct product) {
			if (!isInstalled(product))
				throw new Exception("Anwendung ist nicht installiert!");

			RegistryKey softwareRoot = Registry.LocalMachine.OpenSubKey(_uninstallRoot, false);
			return softwareRoot.OpenSubKey(product.applicationID, false).GetValue("InstallDirectory").ToString();
		}
	}
}