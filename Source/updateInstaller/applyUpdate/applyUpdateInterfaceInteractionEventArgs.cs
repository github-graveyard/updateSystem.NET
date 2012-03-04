using System;
using updateSystemDotNet.Updater.UI.Components;

namespace updateSystemDotNet.Updater.applyUpdate {
	internal class applyUpdateInterfaceInteractionEventArgs : EventArgs {
		public applyUpdateInterfaceInteractionEventArgs(ProgressBarState prgState) {
			progressBarState = prgState;
		}

		public ProgressBarState progressBarState { get; private set; }
	}
}