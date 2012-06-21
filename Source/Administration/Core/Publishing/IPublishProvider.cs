/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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
