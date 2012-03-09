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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Core {
	/// <summary>
	/// Klasse welche Hilfsfunktionen bereitstellt.
	/// </summary>
	public class Helper {
		private const int BCM_FIRST = 0x1600; //Normal button
		private const int BCM_SETSHIELD = (BCM_FIRST + 0x000C); //Elevated button
		private static string m_salt = "rno4hu92t8uhwgeinuwiun";

		/// <summary>
		/// Gibt True zurück wenn das aktuelle Betriebssystem Windows 7 oder neuer ist, anderfalls False.
		/// </summary>
		public static bool isSevenOrGreater {
			get {
				return (
				       	Environment.OSVersion.Version.Major >= 6 &&
				       	Environment.OSVersion.Version.Minor >= 1
				       );
			}
		}

		[DllImport("user32")]
		private static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

		/// <summary>
		/// Verkleinert die Größe eines Bildes.
		/// </summary>
		/// <param name="originalImage">Das Bild welches verkleinert werden soll.</param>
		/// <param name="newSize">Die neue Größe des Bildes.</param>
		/// <returns>Gibt das verkleinerte Bild zurück.</returns>
		public static Image shrinkImage(Image originalImage, Size newSize) {
			var retval = new Bitmap(newSize.Width, newSize.Height);
			using (Graphics g = Graphics.FromImage(retval)) {
				g.InterpolationMode = InterpolationMode.High;
				g.DrawImage(originalImage, new Rectangle(new Point(0, 0), newSize));
			}
			return retval;
		}

		/// <summary>
		/// Berechnet den Saltedhash eines Passwortes.
		/// </summary>
		/// <param name="plainPassword">Das Passwort das gehasht werden soll.</param>
		/// <returns>Gibt das gehashte Passwort zurück.</returns>
		public static string hashPassword(string plainPassword) {
			SHA512 sha = SHA512.Create();
			return Convert.ToBase64String(sha.ComputeHash(Encoding.Default.GetBytes(plainPassword + m_salt)));
		}

		/// <summary>
		/// Gibt die aktuelle Plattform zurück
		/// </summary>
		/// <returns></returns>
		public static updatePackage.SupportedArchitectures GetArchitecture() {
			switch (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToLower()) {
				case "x86":
					return updatePackage.SupportedArchitectures.x86;
				default:
					return updatePackage.SupportedArchitectures.x64;
			}
		}

		/// <summary>
		/// Gibt den Packagepräfix an Hand der Zielarchitektur zurück
		/// </summary>
		/// <param name="architecure">Zielarchitektur</param>
		/// <returns></returns>
		public static string getPraefix(updatePackage.SupportedArchitectures architecure) {
			switch (architecure) {
				case updatePackage.SupportedArchitectures.Both:
					return "bth_";
				case updatePackage.SupportedArchitectures.x86:
					return "x86_";
				case updatePackage.SupportedArchitectures.x64:
					return "x64_";
			}
			return "bth_";
		}

		/// <summary>
		/// Funktion zur korrekten Behandlung eines FTP-Pfades
		/// </summary>
		/// <param name="path1"></param>
		/// <returns></returns>
		public static string Combine_ftp_Path(string path1) {
			if (path1.StartsWith("/") == false) {
				path1 = "/" + path1;
			}
			if (path1.EndsWith("/") == false) {
				path1 += "/";
			}
			return path1;
		}

		/// <summary>
		/// Funktion zur korrekten Behandlung zweier FTP-Pfade
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		/// <returns></returns>
		public static string Combine_ftp_Path(string path1, string path2) {
			if (path2.StartsWith("/")) {
				path2 = path2.Substring(1);
			}
			if (path2.EndsWith("/") == false) {
				path2 += "/";
			}
			return Combine_ftp_Path(path1) + path2;
		}

		/// <summary>
		/// Gibt zurück ob es sich bei der Eingabedatei um ein .Net Assembly handelt
		/// </summary>
		/// <param name="filename">Die Eingabedatei</param>
		/// <returns></returns>
		public static bool IsNetAssembly(string filename) {
			try {
				ushort sections;
				uint timestamp;
				uint pSymbolTable;
				uint noOfSymbol;
				ushort optionalHeaderSize;
				ushort characteristics;
				ushort dataDictionaryStart;
				var dataDictionaryRVA = new uint[16];
				var dataDictionarySize = new uint[16];

				Stream fs = File.OpenRead(filename); //new FileStream(filename, FileMode.Open, FileAccess.Read);
				var reader = new BinaryReader(fs);

				fs.Position = 0x3C;
				uint peHeader = reader.ReadUInt32();
				fs.Position = peHeader;
				uint peHeaderSignature = reader.ReadUInt32();
				ushort machine = reader.ReadUInt16();
				sections = reader.ReadUInt16();
				timestamp = reader.ReadUInt32();
				pSymbolTable = reader.ReadUInt32();
				noOfSymbol = reader.ReadUInt32();
				optionalHeaderSize = reader.ReadUInt16();
				characteristics = reader.ReadUInt16();
				dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(fs.Position) + 0x60);
				fs.Position = dataDictionaryStart;
				for (int i = 0; i < 15; i++) {
					dataDictionaryRVA[i] = reader.ReadUInt32();
					dataDictionarySize[i] = reader.ReadUInt32();
				}
				if (dataDictionaryRVA[14] == 0) {
					return false;
				}
				else {
					return true;
				}
			}
			catch {
				return false;
			}
		}

		/// <summary>
		/// Entfernt alle Dateien aus dem angegebenen Verzeichnis.
		/// </summary>
		/// <param name="directory">Der Pfad des Verzeichnisses, welche gelöscht werden soll.</param>
		public static void DeleteDirectory(string directory) {
			DeleteAllFiles(directory, true);
			Directory.Delete(directory, true);
		}

		private static void DeleteAllFiles(string directory, bool alsoForSubfolders) {
			foreach (string actFile in Directory.GetFiles(directory)) {
				File.SetAttributes(actFile, FileAttributes.Normal);
				File.Delete(actFile);
			}

			if (alsoForSubfolders) {
				foreach (string actDirectory in Directory.GetDirectories(directory)) {
					DeleteAllFiles(actDirectory, alsoForSubfolders);
				}
			}
		}

		///// <summary>
		///// Konvert ein Image in einen String.
		///// </summary>
		///// <param name="source">Das Bild welches konvertiert werden soll.</param>
		///// <returns>Ein Base64 kodierter String welcher das Image enthält.</returns>
		//public static string ImageToString(Image source)
		//{
		//    using (Bitmap b = new Bitmap(source))
		//    {
		//        using (MemoryStream msBitmap = new MemoryStream())
		//        {
		//            b.Save(msBitmap, System.Drawing.Imaging.ImageFormat.Png);
		//            StringBuilder sbImage = new StringBuilder();

		//            foreach (byte bt in msBitmap.ToArray())
		//            {
		//                sbImage.Append(bt.ToString() + "-");
		//            }

		//            return sbImage.ToString().Substring(0, sbImage.ToString().Length - 1);
		//        }
		//    }
		//}

		///// <summary>
		///// Konvertiert einen String in ein Image.
		///// </summary>
		///// <param name="source">Der String welcher das in Base64 kodierte Image enthält.</param>
		///// <returns>Gibt das konvertierte Image zurück.</returns>
		//public static Image StringToImage(string source)
		//{
		//    List<byte> data = new List<byte>();
		//    foreach (string s in source.Split('-'))
		//    {
		//        data.Add(Convert.ToByte(s));
		//    }
		//    using (MemoryStream msBitmap = new MemoryStream(data.ToArray()))
		//    {
		//        using (Bitmap b = new Bitmap(msBitmap))
		//        {
		//            return b;
		//        }
		//    }
		//}

		/// <summary>
		/// Diese Funktion berechnet den Prozentsatz aus zwei Werten.
		/// </summary>
		/// <param name="CurrVal">Der aktuelle Wert.</param>
		/// <param name="MaxVal">Der maximalwert</param>
		/// <returns>Gibt den Prozentsatz aus den beiden gegebenen Werten zurück.</returns>
		public static int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}

		/// <summary>
		/// Verschlüsselt einen String mit dem AES Algorythmus.
		/// </summary>
		/// <param name="PlainText">Der Klartext der verschlüsselt werden soll.</param>
		/// <param name="Password">Das zuverwendende Passwort.</param>
		/// <param name="Salt">Der Salt.</param>
		/// <param name="HashAlgorithm">Der Hashalgorithmus (MD5 oder Sha1).</param>
		/// <param name="PasswordIterations">Die Passworditerations</param>
		/// <param name="InitialVector">Der Initialvector. (16 ASCII Zeichen lang)</param>
		/// <param name="KeySize">Die Schlüsselgröße (128 o. 256)</param>
		/// <returns>Gibt den verschlüsselten String zurück.</returns>
		public static string AESEncrypt(string PlainText, string Password, string Salt, string HashAlgorithm,
		                                int PasswordIterations, string InitialVector, int KeySize) {
			byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
			byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
			byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
			var DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
			byte[] KeyBytes = DerivedPassword.GetBytes(KeySize/8);
			var SymmetricKey = new RijndaelManaged();
			SymmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes);
			var MemStream = new MemoryStream();
			var cryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);
			cryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] CipherTextBytes = MemStream.ToArray();
			MemStream.Close();
			cryptoStream.Close();
			var sb = new StringBuilder();
			foreach (byte b in CipherTextBytes) {
				sb.Append(b.ToString() + "-");
			}
			return sb.ToString().Substring(0, sb.ToString().Length - 1);
		}

		/// <summary>
		/// Entschlüsselt einen String.
		/// </summary>
		/// <param name="CipherText">Der Verschlüsselte Text.</param>
		/// <param name="Password">Das Passwort.</param>
		/// <param name="Salt">Der Salt.</param>
		/// <param name="HashAlgorithm">Der Hashalgorithmus (MD5 o. Sha1)</param>
		/// <param name="PasswordIterations">Die Passworditerations.</param>
		/// <param name="InitialVector">Der Initialvector (16 ASCII Zeichen lang)</param>
		/// <param name="KeySize">Die Schlüsselgröße (128 o. 256).</param>
		/// <returns>Gibt den entschlüsselten String zurück.</returns>
		public static string AESDecrypt(string CipherText, string Password, string Salt, string HashAlgorithm,
		                                int PasswordIterations, string InitialVector, int KeySize) {
			byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
			byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);

			var cipherBytes = new List<byte>();
			foreach (string c in CipherText.Split('-')) {
				cipherBytes.Add(Convert.ToByte(c));
			}
			byte[] CipherTextBytes = cipherBytes.ToArray();
			var DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
			byte[] KeyBytes = DerivedPassword.GetBytes(KeySize/8);
			var SymmetricKey = new RijndaelManaged();
			SymmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes);
			var MemStream = new MemoryStream(CipherTextBytes);
			var cryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);
			var PlainTextBytes = new byte[CipherTextBytes.Length];
			int ByteCount = cryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
			MemStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
		}

		/// <summary>
		/// Liest den öffentlichen Schlüssel aus einem Assembly aus.
		/// </summary>
		/// <param name="targetFilename">Der Pfad zu dem .Net Assembly welches den öffentlichen Schlüssel enthält.</param>
		/// <returns>Gibt den öffentlichen Schlüssel als einen String zurück.</returns>
		public static string readPublicKey(string targetFilename) {
			Assembly targetAssembly = Assembly.Load(File.ReadAllBytes(targetFilename));
			return readPublicKey(targetAssembly);
		}

		/// <summary>
		/// Liest den öffentlichen Schlüssel aus einem Assembly.
		/// </summary>
		/// <param name="targetAssembly">Das Assembly aus welchem der öffentliche Schlüssel ausgelesen werden soll.</param>
		/// <returns>Gibt den öffentlichen Schlüssel als einen String zurück.</returns>
		public static string readPublicKey(Assembly targetAssembly) {
			try {
				byte[] pbk = targetAssembly.GetName().GetPublicKey();
				if (pbk.Length > 0) //Öffentlicher Schlüssel vorhanden
				{
					var sbPbk = new StringBuilder();
					foreach (byte b in pbk) {
						sbPbk.Append(b.ToString("x"));
					}
					return sbPbk.ToString();
				}
				else {
					return string.Empty;
				}
			}
			catch {
				return string.Empty;
			}
		}

		/// <summary>
		/// Generiert einen eindeutigen String zur Identifizierung eines X509-Zertifikates.
		/// </summary>
		/// <param name="certificate">Der zertifikat aus welchem der String ermittelt werden soll.</param>
		/// <returns>Gibt einen eindeutigen String zurück welcher das X509-Zertifikat identifiziert.</returns>
		public static string generateUniqueCertificateId(X509Certificate certificate) {
			var sbId = new StringBuilder();
			sbId.AppendLine(certificate.Issuer);
			sbId.AppendLine(certificate.Subject);
			sbId.AppendLine(certificate.GetSerialNumberString());
			sbId.AppendLine(certificate.GetPublicKeyString());
			sbId.AppendLine(certificate.GetExpirationDateString());

			SHA1 sha1 = SHA1.Create();
			byte[] data = sha1.ComputeHash(Encoding.ASCII.GetBytes(sbId.ToString()));

			var result = new StringBuilder();

			foreach (byte b in data) {
				result.Append(b.ToString() + "-");
			}

			return result.ToString().Substring(0, result.ToString().Length - 1);
		}

		/// <summary>
		/// Gibt die größe einer Datei in einem formatiertem String wieder.
		/// </summary>
		/// <param name="lenght">Die Größe der Datei in Bytes</param>
		/// <returns></returns>
		public static string GetFileSize(double lenght) {
			try {
				if (lenght < 1024) {
					return string.Format("{0} Bytes", lenght.ToString());
				}
				else if (lenght > 1023 && lenght < 1048576) {
					double c_lenght = lenght/1024;
					return string.Format("{0} KB", c_lenght.ToString("###0.00"));
				}
				else if (lenght >= 1048576 && lenght <= 1043741825) {
					double c_lenght = lenght/(float) (Math.Pow(1024, 2));
					return string.Format("{0} MB", c_lenght.ToString("###0.00"));
				}

				else {
					return "0 Bytes";
				}
			}
			catch {
				return "0 Bytes";
			}
		}

		/// <summary>
		/// Setzt das UAC-Shield auf einen Button.
		/// </summary>
		/// <param name="button">Der Button auf welchem das Shield angezeigt werden soll.</param>
		public static void setButtonShield(Button button) {
			if (Environment.OSVersion.Version.Major >= 6)
				SendMessage(button.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
		}

		/// <summary>
		/// Entfernt das UAC-Shield von einem Button.
		/// </summary>
		/// <param name="button">Der Button von welchem das Shield entfernt werden soll.</param>
		public static void removeButtonShield(Button button) {
			if (Environment.OSVersion.Version.Major >= 6)
				SendMessage(button.Handle, BCM_SETSHIELD, 0, 0);
		}
	}
}