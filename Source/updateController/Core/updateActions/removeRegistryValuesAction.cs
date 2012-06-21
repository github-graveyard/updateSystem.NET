/*
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
using System;
using System.Collections.Generic;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction zum entfernen eines oder mehreren Registrywerten.
	/// </summary>
	[Serializable]
	[administrationEditor("catRegistry", "value_delete",
		"Entfernt einen oder mehrere Werte aus der Registry des Zielcomputers.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.removeRegistryValuesActionEditor")]
	public sealed class removeRegistryValuesAction : registryActionBase {
		private List<string> m_valueNames = new List<string>();

		/// <summary>
		/// Gibt eine Liste mit den Namen der Werte zurück die entfernt werden sollen oder legt diese fest.
		/// </summary>
		public List<string> valueNames {
			get { return m_valueNames; }
			set { m_valueNames = value; }
		}

		/// <summary>
		/// Gibt den Name der Updateaction zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Registrywerte entfernen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (!string.IsNullOrEmpty(base.Path) &&
			    m_valueNames.Count > 0) {
				return true;
			}
			return false;
		}
	}
}