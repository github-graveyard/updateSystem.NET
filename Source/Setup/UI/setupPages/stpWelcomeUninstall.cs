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

using System;
using updateSystemDotNet.Setup.Core;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpWelcomeUninstall : basePage, ISetupPage {
		public stpWelcomeUninstall() {
			InitializeComponent();
			chkRemoveSettings.CheckedChanged += delegate { Context.removeSettings = chkRemoveSettings.Checked; };
		}

		#region ISetupPage Members

		public setupContext Context { get; set; }

		public string Title {
			get { return "updateSystem.NET deinstallation"; }
		}

		public bool isLastPage {
			get { return false; }
		}

		public basePage View {
			get { return this; }
		}

		public Type forwardPage {
			get { return typeof (stpUninstall); }
		}

		public Type backwardPage {
			get { return null; }
		}

		#endregion

		public override void onShow() {
			base.onShow();
			chkRemoveSettings.Checked = Context.removeSettings;
		}
	}
}