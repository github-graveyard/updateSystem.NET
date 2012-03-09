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
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace updateSystemDotNet.Administration.Core {
	/// <summary>Klasse zur Verschlüsselung von Daten mittels AES-256.</summary>
	internal sealed class aesEncryption {
		private readonly byte[] _defaultOptionalEntropy = new byte[] {2, 5, 0, 6, 1, 9, 8, 8};
		private readonly SHA256Managed _sha256 = (SHA256Managed) SHA256.Create();

		/// <summary>Verschlüsselt einen Datenblock mit AES265 und einem 256 Bit starkem Schlüssel.</summary>
		/// <param name="plainData">Die Daten welche verschlüsselt werden sollen.</param>
		public byte[] encodeData(byte[] plainData) {
			return encodeData(plainData, _defaultOptionalEntropy);
		}

		/// <summary>Verschlüsselt einen Datenblock mit AES265 und einem 256 Bit starkem Schlüssel.</summary>
		/// <param name="plainData">Die Daten welche verschlüsselt werden sollen.</param>
		/// <param name="optionalEntropy">Ein ByteArray mit Daten welches dem Schlüssel hinzugefügt werden soll.</param>
		public byte[] encodeData(byte[] plainData, byte[] optionalEntropy) {
			return aesEncodeInternal(
				plainData,
				combineData(Key, optionalEntropy),
				IV);
		}

		/// <summary>Entschlüsselt einen mit AES 256 verschlüsselten Datenblock.</summary>
		/// <param name="encodedData">Die Daten welche entschlüsselt werden sollen.</param>
		public byte[] decodeData(byte[] encodedData) {
			return decodeData(encodedData, _defaultOptionalEntropy);
		}

		/// <summary>Entschlüsselt einen mit AES 256 verschlüsselten Datenblock.</summary>
		/// <param name="encodedData">Die Daten welche entschlüsselt werden sollen.</param>
		/// <param name="optionalEntropy">Ein ByteArray mit Daten welches dem Schlüssel hinzugefügt werden soll.</param>
		public byte[] decodeData(byte[] encodedData, byte[] optionalEntropy) {
			return aesDecodeInternal(
				encodedData,
				combineData(Key, optionalEntropy),
				IV);
		}

		#region " CoreEncryption "

		private byte[] aesEncodeInternal(byte[] plainData, byte[] cKey, byte[] cIV) {
			if (plainData == null || plainData.Length <= 0)
				throw new ArgumentNullException("plainData");
			if (cKey == null || cKey.Length <= 0)
				throw new ArgumentNullException("cKey");
			if (cIV == null || cIV.Length <= 0)
				throw new ArgumentNullException("cIV");

			MemoryStream msEncrypt = null;
			RijndaelManaged aesAlg = null;

			try {
				aesAlg = new RijndaelManaged();
				aesAlg.KeySize = 256;
				aesAlg.Key = _sha256.ComputeHash(cKey);
				aesAlg.IV = cIV;

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				msEncrypt = new MemoryStream();
				using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
					csEncrypt.Write(plainData, 0, plainData.Length);
				}
			}
			finally {
				if (aesAlg != null)
					aesAlg.Clear();
			}
			return msEncrypt.ToArray();
		}

		private byte[] aesDecodeInternal(byte[] cipherData, byte[] cKey, byte[] cIV) {
			if (cipherData == null || cipherData.Length <= 0)
				throw new ArgumentNullException("cipherData");
			if (cKey == null || cKey.Length <= 0)
				throw new ArgumentNullException("cKey");
			if (cIV == null || cIV.Length <= 0)
				throw new ArgumentNullException("cIV");

			RijndaelManaged aesAlg = null;
			var plainData = new byte[cipherData.Length];

			try {
				aesAlg = new RijndaelManaged();
				aesAlg.KeySize = 256;
				aesAlg.Key = _sha256.ComputeHash(cKey);
				aesAlg.IV = cIV;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (var msDecrypt = new MemoryStream(cipherData)) {
					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
						csDecrypt.Read(plainData, 0, cipherData.Length);
					}
				}
			}
			finally {
				if (aesAlg != null)
					aesAlg.Clear();
			}
			return plainData;
		}

		#endregion

		#region " Keys "

		private byte[] Key {
			get { return _sha256.ComputeHash(Assembly.GetExecutingAssembly().GetName().GetPublicKey()); }
		}

		private byte[] IV {
			get {
				byte[] hashedPbk = Key;
				var iv = new byte[16];
				for (int i = 0; i < 16; i++) {
					iv[i] = hashedPbk[(hashedPbk.Length - 1) - i];
				}
				return iv;
			}
		}

		#endregion

		#region " Hilfsfunktionen "

		private byte[] combineData(byte[] data1, byte[] data2) {
			using (var msData = new MemoryStream()) {
				msData.Write(data1, 0, data1.Length);
				msData.Write(data2, 0, data2.Length);
				return msData.ToArray();
			}
		}

		#endregion
	}
}