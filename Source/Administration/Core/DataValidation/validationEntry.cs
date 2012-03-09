#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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
