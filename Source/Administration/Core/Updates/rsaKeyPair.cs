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

using System.Security.Cryptography;

namespace updateSystemDotNet.Administration.Core.Updates {

	/// <summary>Klasse ein RSA-Schlüsselpaar verwaltet</summary>
	public sealed class rsaKeyPair {

		/// <summary>Gibt den öffentlichen Schlüssel zurück oder legt diesen fest.</summary>
		public string publicKey { get; set; }

		/// <summary>Gibt den privaten Schlüssel zurück oder legt diesen fest.</summary>
		public string privateKey { get; set; }

		/// <summary>Erstellt ein neues Schlüsselpaar mit einer Größe von 4096-Bits.</summary>
		public static rsaKeyPair Create() {
			return Create(2048);
		}

		/// <summary>Erstellt ein neues Schlüsselpaar mit variabler Schlüsselgröße.</summary>
		public static rsaKeyPair Create(int keysize) {
			var rsa = new RSACryptoServiceProvider(keysize);
			return new rsaKeyPair {
			                        	publicKey = rsa.ToXmlString(false),
			                        	privateKey = rsa.ToXmlString(true)
			                        };
		}

	}

}