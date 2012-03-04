using System.Collections.Generic;

namespace updateSystemDotNet.Administration.Core.Publishing {

	/// <summary>Eine Liste mit Resultaten der Veröffentlichungsschnittstellen.</summary>
	internal sealed class publishResultList : List<publishResult> {

		/// <summary>Gibt zurück, ob es in der Auflistung mindestens ein Eintrag mit einem Fehler gibt.</summary>
		public bool hasErrors {
			get {
				foreach (var result in this)
					if (!result.Successful)
						return true;
				return false;
			}
		}
	}
}
