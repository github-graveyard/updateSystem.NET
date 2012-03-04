using System;

namespace updateSystemDotNet.Core.Types {
	/// <summary>Verlinkung auf einen updateLog-Server.</summary>
	[Serializable]
	public sealed class updateLogLinkedAccount : ICloneable {
		/// <summary>Gibt die Url zu dem Statistikserver zurück oder legt diese fest.</summary>
		public string serverUrl { get; set; }

		#region ICloneable Member

		/// <summary>Erzeugt eine Kopie des <see cref="updateLogLinkedAccount"/>-Objektes.</summary>
		public object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}