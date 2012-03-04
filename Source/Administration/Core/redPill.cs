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
