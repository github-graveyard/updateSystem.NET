using System;
using System.IO;

namespace updateSystemDotNet.Setup.Core {
	internal sealed class setupContext {
		public setupContext() {
			createStartMenuShortcut = true;
		}

		public IProduct Product { get; set; }

		public string installationDirectory { get; set; }

		public string defaultInstallationDirectory {
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), Product.Product); }
		}

		public bool createStartMenuShortcut { get; set; }

		public bool createDesktopShortcut { get; set; }

		public bool runWhenDone { get; set; }

		public Exception setupException { get; set; }

		public bool removeSettings { get; set; }

		public bool isUpgrade { get; set; }

	}
}