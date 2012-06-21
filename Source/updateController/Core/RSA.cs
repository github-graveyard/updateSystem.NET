/*
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
using System.Collections;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace updateSystemDotNet.Core {
	/// <summary>
	/// Statische Klasse welche RSA Verschlüsselung und Signierung bereitstellt.
	/// </summary>
	public class RSA {
		/// <summary>
		/// Verschlüsselt einen String
		/// </summary>
		/// <param name="inputString">Der String der verschlüsselt werden soll</param>
		/// <param name="dwKeySize">Die Schlüsselgröße (z.B. 1024Bit)</param>
		/// <param name="xmlPublicKey">Der öffentliche Teil des RSA-Keypairs</param>
		/// <returns></returns>
		public static string EncryptString(string inputString, int dwKeySize, string xmlPublicKey) {
			var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlPublicKey);
			int keySize = dwKeySize/8;
			byte[] bytes = Encoding.UTF32.GetBytes(inputString);
			// The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
			// int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
			int maxLength = keySize - 42;
			int dataLength = bytes.Length;
			int iterations = dataLength/maxLength;
			var stringBuilder = new StringBuilder();
			for (int i = 0; i <= iterations; i++) {
				var tempBytes = new byte[(dataLength - maxLength*i > maxLength) ? maxLength : dataLength - maxLength*i];
				Buffer.BlockCopy(bytes, maxLength*i, tempBytes, 0, tempBytes.Length);
				byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
				// Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
				// If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
				// Comment out the next line and the corresponding one in the DecryptString function.
				Array.Reverse(encryptedBytes);
				// Why convert to base 64?
				// Because it is the largest power-of-two base printable using only ASCII characters
				stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Entschlüsselt einen String
		/// </summary>
		/// <param name="inputString">Der verschlüsselte String der decodiert werden soll</param>
		/// <param name="dwKeySize">Die Schlüsselgröße (z.B. 1024Bit)</param>
		/// <param name="xmlPrivateKey">Der private Teil des RSA-Keypairs</param>
		/// <returns></returns>
		public static string DecryptString(string inputString, int dwKeySize, string xmlPrivateKey) {
			var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlPrivateKey);
			int base64BlockSize = ((dwKeySize/8)%3 != 0) ? (((dwKeySize/8)/3)*4) + 4 : ((dwKeySize/8)/3)*4;
			int iterations = inputString.Length/base64BlockSize;
			var arrayList = new ArrayList();
			for (int i = 0; i < iterations; i++) {
				byte[] encryptedBytes =
					Convert.FromBase64String(inputString.Substring(base64BlockSize*i, base64BlockSize));
				// Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
				// If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
				// Comment out the next line and the corresponding one in the EncryptString function.
				Array.Reverse(encryptedBytes);
				arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
			}
			return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
		}


		/// <summary>
		/// Erstellt ein neues Schlüsselpaar
		/// </summary>
		/// <returns></returns>
		public static string[] CreateNewKeys() {
			System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
			return new[] {
			             	rsa.ToXmlString(true), //PrivateKey
			             	rsa.ToXmlString(false) //PublicKey
			             };
		}

		/// <summary>
		/// Signiert einen Text mit dem angegebenen privaten Schlüssel.
		/// </summary>
		/// <param name="textToSign">Der zusignierende Text.</param>
		/// <param name="privateKey">Der private Schlüssel.</param>
		/// <returns></returns>
		public static string Sign(string textToSign, string privateKey) {
			//Initialisieren der Provider
			var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
			var rsaFormatter = new RSAPKCS1SignatureFormatter(rsaCryptoServiceProvider);
			System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
			var encoding = new ASCIIEncoding();
			var sha1 = new SHA1Managed();

			//Zuweisen des Hashalgorithmus und des privaten Schlüssels
			rsaFormatter.SetHashAlgorithm("SHA1");
			rsa.FromXmlString(privateKey);
			rsaFormatter.SetKey(rsa);

			//String nach Byte[] Konvertieren und die Signatur erstellen
			byte[] valueToHash = encoding.GetBytes(textToSign);
			byte[] signedValue = rsaFormatter.CreateSignature(sha1.ComputeHash(valueToHash));

			return Convert.ToBase64String(signedValue);
		}

		/// <summary>
		/// Validiert einen signierten String
		/// </summary>
		/// <param name="textToValidate">Der unsignierte Text welcher mit der Signatur überprüft werden soll.</param>
		/// <param name="signToValidate">Die Signatur des Textes.</param>
		/// <param name="publicKey">Der öffentliche Schlüssel.</param>
		/// <returns></returns>
		public static bool validateSign(string textToValidate, string signToValidate, string publicKey) {
			//Initialisieren der Provider
			var rsacryptoprov = new RSACryptoServiceProvider();
			var rsaDeFormatter = new RSAPKCS1SignatureDeformatter(rsacryptoprov);
			System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
			var sha1 = new SHA1Managed();
			var encoding = new ASCIIEncoding();

			//Zuweisen des Hashalgorithmus und des öffentlichen Schlüssels
			rsaDeFormatter.SetHashAlgorithm("SHA1");
			rsa.FromXmlString(publicKey);
			rsaDeFormatter.SetKey(rsa);

			//String nach Byte[]
			byte[] hashed_value = encoding.GetBytes(textToValidate);
			byte[] signed_value = Convert.FromBase64String(signToValidate);

			//Signatur validieren und wert zurückgeben true/false
			return rsaDeFormatter.VerifySignature(sha1.ComputeHash(hashed_value), signed_value);
		}

		/// <summary>
		/// Signiert ein Xml-Document.
		/// </summary>
		/// <param name="xDoc">Das Dokument welches die Daten enthält die signiert werden sollen.</param>
		/// <param name="privateKey">Der private Schlüssel.</param>
		/// <returns>Gibt ein Xml Element mit den Signierten daten zurück.</returns>
		public static XmlElement SignXmlDocument(XmlDocument xDoc, string privateKey) {
			var signedXml = new SignedXml();
			System.Security.Cryptography.RSA pvk = System.Security.Cryptography.RSA.Create();
			pvk.FromXmlString(privateKey);
			signedXml.SigningKey = pvk;

			var dataObject = new DataObject();
			dataObject.Id = "content";
			dataObject.Data = xDoc.ChildNodes;

			signedXml.AddObject(dataObject);

			var reference = new Reference();
			reference.Uri = "#content";

			signedXml.AddReference(reference);

			var keyinfo = new KeyInfo();
			keyinfo.AddClause(new RSAKeyValue(pvk));
			signedXml.KeyInfo = keyinfo;

			signedXml.ComputeSignature();

			return signedXml.GetXml();
		}

		/// <summary>
		/// Überprüft die Signatur eines Xml Dokuments.
		/// </summary>
		/// <param name="xDoc">Das Dokument welches überprüft werden soll.</param>
		/// <returns>Gibt True zurück wenn die Signatur gültig ist, andernfalls False.</returns>
		public static bool validateXmlDocument(XmlDocument xDoc) {
			var signedXml = new SignedXml();
			XmlNodeList nodeList = xDoc.GetElementsByTagName("Signature");

			signedXml.LoadXml((nodeList[0] as XmlElement));

			return signedXml.CheckSignature();
		}
	}
}