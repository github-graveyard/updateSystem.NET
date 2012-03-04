using System;

namespace updateSystemDotNet.Administration.Core.Application {
	[Serializable]
	public sealed class updateReleaseChannel : ICloneable {

		/// <summary>Der Anzeigename für den Updatekanal.</summary>
		public string Name { get; set; }

		/// <summary>Die Adresse (Url oder UNC Path) für die Updates.</summary>
		public string updateLocation { get; set; }

		public override string ToString() {
			return Name;
		}


		#region ICloneable Member

		public object Clone() {
			return MemberwiseClone();
		}

		#endregion
	}
}
