using System;
namespace updateSystemDotNet.Administration.Core.updateLog {
	[Serializable]
	public sealed class updateLogProject {

		public string projectName { get; set; }

		public string projectId { get; set; }

		public bool isActive { get; set; }

	}
}
