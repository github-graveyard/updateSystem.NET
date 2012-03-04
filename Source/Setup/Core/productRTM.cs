using System;
using System.Reflection;

namespace updateSystemDotNet.Setup.Core {
	internal class productRTM : IProduct {
		#region IProduct Members

		public string mainExecutable {
			get { return "updateSystemDotNet.Administration.exe"; }
		}

		public string setupName {
			get { return "uninstall.exe"; }
		}

		public string Contact {
			get { return "mail@maximiliankrauss.net"; }
		}

		public virtual Version currentVersion {
			get {
				if (ProgramsAndFeaturesHelper.isInstalled(this))
					return ProgramsAndFeaturesHelper.getCurrentVersion(this);
				else
					return newVersion;
			}
		}

		public string Description {
			get { return "Updatelösung für .NET Entwickler"; }
		}

		public virtual Version newVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
		}

		public virtual string Product {
			get { return "updateSystem.NET"; }
		}

		public string Publisher {
			get { return "Maximilian Krauss"; }
		}

		public virtual string supportUrl {
			get { return "http://updatesystem.net"; }
		}

		public virtual string applicationID {
			get { return "8d7ea403-65fb-4276-8ada-3b39f0fe2461"; }
		}

		#endregion
	}
}