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
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace updateSystemDotNet.Administration.Core {

	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	sealed class encryptPropertyAttribute : Attribute {
	}

	internal static class secureSerializer {

		private static readonly AESEncryption _cryptoProvider;
		private static readonly string _defaultKey = "{B5A3DEA5-B765-4dcb-BC98-DE22EC1EF310}";

		private sealed class AESEncryption {
			private readonly byte[] _internalIV;
			private readonly SHA256 _sha256;

			public AESEncryption() {
				_sha256 = SHA256.Create();
				_internalIV = new byte[] { 25, 6, 19, 88, 4, 10, 44, 52, 65, 4, 21, 19, 22, 33, 99, 100 };
			}


			public string Encrypt(string plaintext, string cryptoKey) {
				if (string.IsNullOrEmpty(plaintext))
					throw new ArgumentException("plaintext");
				if (string.IsNullOrEmpty(cryptoKey))
					throw new ArgumentException("cryptoKey");

				byte[] plainData = Encoding.Default.GetBytes(plaintext);
				byte[] key = Encoding.Default.GetBytes(cryptoKey);
				return Convert.ToBase64String(aesEncodeInternal(plainData, key, _internalIV));
			}

			public string Decrypt(string encodedText, string cryptoKey) {
				if (string.IsNullOrEmpty(encodedText))
					throw new ArgumentException("encodedText");
				if (string.IsNullOrEmpty(cryptoKey))
					throw new ArgumentException("cryptoKey");

				byte[] encodedData = Convert.FromBase64String(encodedText);
				byte[] key = Encoding.Default.GetBytes(cryptoKey);
				return Encoding.Default.GetString(aesDecodeInternal(encodedData, key, _internalIV)).Replace("\0", "");
			}

			#region " Core Encryption "

			private byte[] aesEncodeInternal(byte[] plainData, byte[] Key, byte[] IV) {
				if (plainData == null || plainData.Length <= 0)
					throw new ArgumentNullException("plainData");
				if (Key == null || Key.Length <= 0)
					throw new ArgumentNullException("Key");
				if (IV == null || IV.Length <= 0)
					throw new ArgumentNullException("IV");

				MemoryStream msEncrypt;
				RijndaelManaged aesAlg = null;

				try {
					aesAlg = new RijndaelManaged { KeySize = 256, Key = _sha256.ComputeHash(Key), IV = IV };

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

			private byte[] aesDecodeInternal(byte[] cipherData, byte[] Key, byte[] IV) {
				if (cipherData == null || cipherData.Length <= 0)
					throw new ArgumentNullException("cipherData");
				if (Key == null || Key.Length <= 0)
					throw new ArgumentNullException("Key");
				if (IV == null || IV.Length <= 0)
					throw new ArgumentNullException("IV");

				RijndaelManaged aesAlg = null;
				var plainData = new byte[cipherData.Length];

				try {
					aesAlg = new RijndaelManaged { KeySize = 256, Key = _sha256.ComputeHash(Key), IV = IV };

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
		}

		static secureSerializer() {
			_cryptoProvider = new AESEncryption();
		}

		public static void Serialize<T>(string fileName, T instance) {
			Serialize(fileName, instance, _defaultKey);
		}
		public static void Serialize<T>(string fileName, T instance, string password) {
			if (!implementsIClonable(typeof(T)))
				throw new ArgumentException("The Type has to implement the System.IClonable-Interface before it can serialized.");

			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("password");

			//Create a Copy of the instance 
			instance = (T)((ICloneable)instance).Clone();

			//Encrypt all Properties which are marked with the encryptPropertyAttribute.
			encodeProperties(instance, true, password);

			//Serialize and Save the instance
			using (var writer = new StreamWriter(fileName, false, Encoding.UTF8)) {
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(writer, instance);
			}
		}

		public static T Deserialize<T>(string fileName) {
			return Deserialize<T>(fileName, _defaultKey);
		}
		public static T Deserialize<T>(string fileName, string password) {
			if (!File.Exists(fileName))
				throw new FileNotFoundException("File not found", fileName);
			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("password");

			using (var reader = new StreamReader(fileName, Encoding.UTF8)) {
				var serializer = new XmlSerializer(typeof(T));
				var instance = (T)serializer.Deserialize(reader);
				encodeProperties(instance, false, password);
				return instance;
			}
		}


		private static void encodeProperties(object instance, bool encrypt, string password) {
			if (instance == null) return;
			
			var t = instance.GetType();
			foreach (PropertyInfo property in t.GetProperties()) {
				if (!property.PropertyType.IsValueType && !property.PropertyType.IsGenericType) {
					if (property.PropertyType == typeof(string) && containsEncryptionAttribute(property)) {
						string propValue = property.GetValue(instance, null).ToString();
						if (!string.IsNullOrEmpty(propValue))
							property.SetValue(instance,
							                  encrypt
							                  	? _cryptoProvider.Encrypt(propValue, password)
							                  	: _cryptoProvider.Decrypt(propValue, password), null);
					}
					else
						encodeProperties(property.GetValue(instance, null), encrypt, password);
				}
				else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) {
					var reflectedList = property.GetValue(instance, null);
					var count = (int)reflectedList.GetType().GetProperty("Count").GetValue(reflectedList, null);
					for (var i = 0; i < count; i++)
						encodeProperties(reflectedList.GetType().GetProperty("Item").GetValue(reflectedList, new object[] { i }), encrypt, password);
				}
			}
		}

		private static bool implementsIClonable(Type objecType) {
			Type tInterface = objecType.GetInterface("System.ICloneable", false);
			return (tInterface != null);
		}

		private static bool containsEncryptionAttribute(PropertyInfo prop) {
			object[] attributes = prop.GetCustomAttributes(typeof(encryptPropertyAttribute), true);
			return attributes.Length > 0;
		}
	}
}