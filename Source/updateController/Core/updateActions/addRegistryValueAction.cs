using System;
using System.Collections.Generic;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaktionen zum hinzufügen von einem oder mehreren Registrywerten.
	/// </summary>
	[Serializable]
	[administrationEditor("Registry", "value_add",
		"Erstellt einen oder mehrere neue Werte in der Registry des Zielcomputers oder ersetzt bereits existierende.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.addRegistryValueActionEditor")]
	public sealed class addRegistryValueAction : registryActionBase {
		private List<registryItem> m_items = new List<registryItem>();

		#region " registryItem "

		/// <summary>
		/// Item mit Informationen zu einem neuen Registryeintrag.
		/// </summary>
		[Serializable]
		public class registryItem : ICloneable {
			private string m_id = string.Empty;
			private string m_name = string.Empty;
			private registryValueTypes m_type;
			private object m_value;

			/// <summary>
			/// Gibt den Identifer für dieses Item zurück oder legt diesen fest.
			/// </summary>
			public string ID {
				get { return m_id; }
				set { m_id = value; }
			}

			/// <summary>
			/// Gibt den Namen des Eintrags zurück oder legt diesen fest.
			/// </summary>
			public string Name {
				get { return m_name; }
				set { m_name = value; }
			}

			/// <summary>
			/// Gibt den Wert für den neuen Eintrag zurück oder legt diesen fest.
			/// </summary>
			public object Value {
				get { return m_value; }
				set { m_value = value; }
			}

			/// <summary>
			/// Gibt den Datentyp für den neuen Wert zurück oder legt diesen fest.
			/// </summary>
			public registryValueTypes Type {
				get { return m_type; }
				set { m_type = value; }
			}

			#region ICloneable Member

			/// <summary>
			/// Erstellt eine Kopie des aktuellen Objekts.
			/// </summary>
			/// <returns></returns>
			public object Clone() {
				return MemberwiseClone();
			}

			#endregion
		}

		#endregion

		/// <summary>
		/// Gibt die neuen Einträge für die Registry zurück oder legt diese fest.
		/// </summary>
		public List<registryItem> Items {
			get { return m_items; }
			set { m_items = value; }
		}

		/// <summary>
		/// Gibt den Namen der Aktion zurück.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Registrywerte hinzufügen";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			if (string.IsNullOrEmpty(Path) ||
			    m_items.Count == 0) {
				return false;
			}


			return true;
		}
	}
}