using System;
using System.Collections.Generic;
namespace updateSystemDotNet.Administration.Core.DataValidation {
	internal sealed class validationManager {
		private readonly List<validationEntry> _entries;

		public validationManager() {
			_entries = new List<validationEntry>();
			validationResults = new List<validationResult>();
		}

		public bool Validate() {
			//Fehlertext zurücksetzen
			validationResults.Clear();

			foreach (var entry in _entries) {

				//Wert aus der Eigenschaft des zu überprüfenden Controls lesen
				object propertyValue = (entry.Owner.GetType().GetProperty(entry.validationPropertyName).GetValue(entry.Owner, null));
				if (propertyValue == null)
					continue;

				//Je nach Datentyp unterschiedliche Validierung durchführen
				if (propertyValue is float ||
				    propertyValue is int ||
				    propertyValue is double ||
				    propertyValue is decimal) {

					if (!validateNumeric(entry, propertyValue)) {
						validationResults.Add(new validationResult {
						                                             	errorText =
						                                             		string.Format("{0} besitzt einen ungültigen numerischen Wert.",
						                                             		              entry.friendlyName),
						                                             	Entry = entry
						                                             });
					}
				}
				if (propertyValue is string) {
					if (!validateString(entry, (string) propertyValue)) {
						validationResults.Add(new validationResult {
						                                           	errorText =
						                                           		string.Format("{0} besitzt einen ungültigen Wert.",
						                                           		              entry.friendlyName),
						                                           	Entry = entry
						                                           });
					}
				}

			}
			return validationResults.Count == 0;
		}

		private bool validateString(validationEntry entry, string value) {
			switch (entry.validationType) {
				case validationTypes.LowerThanZero:
					throw new Exception(string.Format("Ungültige Validierungsmethode {0} für den Datentyp string.",
					                                  entry.validationType));
				case validationTypes.GreatherThanZero:
					return value.Length > 0;
				case validationTypes.NotNull:
					return !string.IsNullOrEmpty(value);
				case validationTypes.Null:
					return string.IsNullOrEmpty(value);
			}
			return true;
		}

		private bool validateNumeric(validationEntry entry, object value) {
			decimal numValue = (decimal) value;
			switch (entry.validationType) {
				case validationTypes.GreatherThanZero:
					return numValue > 0;
				case validationTypes.LowerThanZero:
					return numValue < 0;
				case validationTypes.Null:
					return numValue.Equals(0);
				case validationTypes.NotNull:
					return !numValue.Equals(0);
			}
			return true;
		}

		public List<validationResult> validationResults { get; set; }

		public void addEntry(validationEntry entry) {
			_entries.Add(entry);
		}

	}
}