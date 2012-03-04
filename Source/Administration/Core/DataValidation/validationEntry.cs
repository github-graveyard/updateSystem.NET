using System.Windows.Forms;
namespace updateSystemDotNet.Administration.Core.DataValidation {
	/// <summary>Ein Eintrag welcher Regeln zur Überprüfung von Daten eines Controls besitzt.</summary>
	internal sealed class validationEntry {
		internal const string defaultValidationPropertyName = "Text";

		public validationEntry() {
			validationPropertyName = defaultValidationPropertyName;
		}

		/// <summary>Legt das zu validierende Control fest.</summary>
		public Control Owner { get; set; }

		/// <summary>Der Name der Eigenschaft des Owners welche validiert werden soll.</summary>
		public string validationPropertyName { get; set; }

		/// <summary>Der Name der angezeigt werden soll, wenn dieser Eintrag ungültig ist.</summary>
		public string friendlyName { get; set; }
        
		/// <summary>Legt die Art der Überprüfung fest.</summary>
		public validationTypes validationType { get; set; }

	}
}
