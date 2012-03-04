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