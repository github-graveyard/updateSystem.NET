using updateSystemDotNet.Administration.Core.Application;
using System;

namespace updateSystemDotNet.Administration.Core.Publishing {
	internal interface IPublishProvider {

		#region Events

		event EventHandler<publishUpdateProgressChangedEventArgs> publishUpdateProgressChanged;

		#endregion

		#region Eigenschaften

		/// <summary>Bietet Zugriff auf die Anwendungssession.</summary>
		applicationSession Session { get; set; }

		/// <summary>Bietet Zugriff auf die Eigenschaften und Einstellungen des jeweiligen Providers.</summary>
		publishSettings Settings { get; set; }

		/// <summary>Gibt die Provider-ID zurück</summary>
		string Id { get; }

		#endregion

		#region Methoden

		/// <summary>Methode um mit dem Veröffentlichungsvorgang zu beginnen.</summary>
		publishResult publishUpdates();

		Type settingsView { get; }

		#endregion

	}
}
