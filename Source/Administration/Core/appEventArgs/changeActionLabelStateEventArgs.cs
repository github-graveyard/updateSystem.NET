using System;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.Core.appEventArgs {
	internal sealed class changeActionLabelStateEventArgs : EventArgs {
		public changeActionLabelStateEventArgs(string name, actionLabelStates state) {
			actionLabelName = name;
			State = state;
		}

		/// <summary>Der Status auf welchen das ActionLabel aktualisiert werden soll.</summary>
		public actionLabelStates State { get; private set; }

		/// <summary>Der Name des Controls von welchem der Status geändert werden soll.</summary>
		public string actionLabelName { get; private set; }
	}
}