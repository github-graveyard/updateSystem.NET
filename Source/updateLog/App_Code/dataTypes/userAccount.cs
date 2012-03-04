using System;

namespace App_Code.dataTypes {
	
	[Serializable]
	public class userAccount {

		public string Username { get; set; }

		public bool isAdmin { get; set; }

		public bool isActive { get; set; }

		public int maxProjects { get; set; }

	}
}
