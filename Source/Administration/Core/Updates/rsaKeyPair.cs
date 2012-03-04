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