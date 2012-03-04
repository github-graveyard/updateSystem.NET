using System;
namespace App_Code.dataTypes {
	[Serializable]
	public class updateLogProject {

		public string projectName { get; set; }

		public string projectId { get; set; }

		public bool isActive { get; set; }

	}
}
