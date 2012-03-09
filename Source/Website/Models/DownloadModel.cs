using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models {
	public class DownloadModel {

		public string Id { get; set; }
		public string Filename { get; set; }
		public int Hits { get; set; }
		public long Size { get; set; }

	}
}