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