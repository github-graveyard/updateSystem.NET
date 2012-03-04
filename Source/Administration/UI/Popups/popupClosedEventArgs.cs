using System;
using updateSystemDotNet.Administration.Core;

namespace updateSystemDotNet.Administration.UI.Popups {

	internal delegate void popupClosedEventHandler(popupBase sender, popupClosedEventArgs e);
	
	internal sealed class popupClosedEventArgs : EventArgs {
		
		public popupClosedEventArgs() {
			Result = new dataContainer();
		}
		public popupClosedEventArgs(dataContainer result) {
			Result = result;
		}

		public dataContainer Result { get; private set; }

	}
}
