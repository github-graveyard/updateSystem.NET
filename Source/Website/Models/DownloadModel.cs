using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models {
	public class DownloadModel {

		public int Id { get; set; }
		public string Filename { get; set; }
		public int Hits { get; set; }
		public long Size { get; set; }
		public Version Version { get; set; }
		public string completePath { get; set; }
		public string friendlyName { get; set; }
		public string Description { get; set; }
	}
}