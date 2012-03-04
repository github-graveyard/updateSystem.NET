using System.Collections.Generic;

namespace App_Code.Actions {

	internal sealed class stpResult {

		public stpResult() {
			Fields = new List<string>();
			Records = new List<Dictionary<string, object>>();
		}

		public List<string> Fields { get; set; }

		public List<Dictionary<string, object>> Records { get; set; }

	}

}