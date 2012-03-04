using System;
using updateSystemDotNet.Core.Types;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class downloadConfigurationCompletedEventArgs : EventArgs {
		public downloadConfigurationCompletedEventArgs(updateConfiguration configuration) {
			Configuration = configuration;
		}

		public downloadConfigurationCompletedEventArgs(Exception ex) {
			Exception = ex;
		}

		/// <summary>Gibt die heruntergeladene Updatekonfiguration zurück. Ist null wenn es bei dem Download zu einem Fehler kam.</summary>
		public updateConfiguration Configuration { get; private set; }

		/// <summary>Gibt den Fehler zurück der bei dem Download auftrat. Ist null wenn es zu keinem Fehler kam.</summary>
		public Exception Exception { get; private set; }

		/// <summary>Gibt True zurück wenn die Updatekonfiguration erfolgreich heruntergeladen wurde, andernfalls False.</summary>
		public bool Success {
			get { return (Configuration != null && Exception == null); }
		}
	}
}