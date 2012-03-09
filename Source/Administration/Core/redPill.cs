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
