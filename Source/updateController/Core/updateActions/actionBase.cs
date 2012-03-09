/*
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
	/// Abstrakte Klasse welche als Basis für alle Updateaktionen dient.
	/// </summary>
	[Serializable]
	//[XmlInclude(typeof(addRegistryKeyAction))]
		//[XmlInclude(typeof(addRegistryValueAction))]
		//[XmlInclude(typeof(cleanupAction))]
		//[XmlInclude(typeof(closeProcessAction))]
		//[XmlInclude(typeof(deleteFilesAction))]
		//[XmlInclude(typeof(fileCopyAction))]
		//[XmlInclude(typeof(removeRegistryKeyAction))]
		//[XmlInclude(typeof(removeRegistryValueAction))]
		//[XmlInclude(typeof(renameFileAction))]
		//[XmlInclude(typeof(startProcessAction))]
		//[XmlInclude(typeof(stopServiceAction))]
		//[XmlInclude(typeof(userInteractionAction))]
		//[XmlInclude(typeof(validatePackageAction))]
	public abstract class actionBase {
		private string m_id;

		/// <summary>
		/// Gibt die eindeutige ID der Klasse zurück oder legt diese fest.
		/// </summary>
		public string ID {
			get { return m_id; }
			set { m_id = value; }
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public abstract bool Validate();

		/*/// <summary>
        /// Gibt die Beschreibung dieser Updateaction zurück.
        /// </summary>
        public virtual string Descripton { get { return string.Empty; } }

        /// <summary>
        /// Gibt die Kategorie zurück in welche die Updateaction einsortiert werden soll.
        /// </summary>
        public virtual string Category { get { return "Sonstige"; } }

        /// <summary>
        /// Gibt an, ob die Updateaction versteckt werden soll.
        /// </summary>
        public virtual bool hideAction { get { return false; } }

        /// <summary>
        /// Gibt den Namen eins 16x16 großesn Bildes zurück welches in der ToolBox der Administration verwendet wird.
        /// </summary>
        public virtual string toolboxImageName { get { return string.Empty; } }

        /// <summary>
        /// Gibt den Namen des Editorcontrols zurück welches zum Bearbeiten der updateAction in der Administration verwendet werden soll.
        /// </summary>
        public virtual string actionEditorName { get { return string.Empty; } }*/
	}
}