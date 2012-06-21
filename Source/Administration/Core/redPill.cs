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
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace updateSystemDotNet.Administration.Core {
	internal sealed class redPill {
		public bool canIHazFeatures() {

			return true;

			//Ultra geheimer string: Gimme! Gimme! Gimme!
/*
			RegistryKey redPillHive = Registry.CurrentUser.OpenSubKey(@"Software\updateSystem.NET");
			return redPillHive != null &&
			       hashValue(redPillHive.GetValue("redPill", string.Empty).ToString()) ==
			       "26795FBB91C42644AF52F4F2D4C3EAAB1226E855EA39226E00829D8EE1D645C37F640F80771F218BB11F1FFD6A281BAC1BE9082E9EF282D5A1B641C2338F3A19" &&
			       AppDomain.CurrentDomain.BaseDirectory.ToLower() ==
			       @"S:\Sources\UpdateSystem.Net\Source\Administration\bin\Release\".ToLower();
*/
		}

/*
		private string hashValue(string value) {
			var sha512 = SHA512.Create();
			byte[] hashedBytes = sha512.ComputeHash(Encoding.Default.GetBytes(value));
			StringBuilder sbHash = new StringBuilder(hashedBytes.Length);
			foreach (var hashedByte in hashedBytes)
				sbHash.Append(hashedByte.ToString("X2"));
			return sbHash.ToString();
		}
*/
	}
}
