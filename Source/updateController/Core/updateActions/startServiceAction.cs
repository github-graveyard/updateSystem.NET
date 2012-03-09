/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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
using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum starten eines Windowsdienstes.
	/// </summary>
	[Serializable]
	[administrationEditor("Dienste", "start_service", "Startet einen Dienst auf dem Zielcomputer",
		"updateSystemDotNet.Administration.UI.updateActionEditor.startServiceActionEditor")]
	public sealed class startServiceAction : actionBase {
		private string m_arguments = string.Empty;
		private bool m_restartIfRunnig;
		private string m_serviceName = string.Empty;

		/// <summary>
		/// Gibt den Namen des Dienstes zurück oder legt diesen fest.
		/// </summary>
		public string serviceName {
			get { return m_serviceName; }
			set { m_serviceName = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest ob der Dienst neu gestartet werden soll wenn dieser bereits läuft.
		/// </summary>
		public bool restartIfRunnig {
			get { return m_restartIfRunnig; }
			set { m_restartIfRunnig = value; }
		}

		/// <summary>
		/// Gibt die Argumente an, die an den Service übermittelt werden sollen oder legt diese fest.
		/// </summary>
		public string Arguments {
			get { return m_arguments; }
			set { m_arguments = value; }
		}

		/// <summary>
		/// Gibt den Namen der Action zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Dienst starten";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return !string.IsNullOrEmpty(serviceName);
		}
	}
}