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